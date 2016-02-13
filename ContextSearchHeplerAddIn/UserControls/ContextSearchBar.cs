using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using System.Collections;
using DAL;
using Data;

namespace ContextSearchHeplerAddIn
{
    public partial class ContextSearchBar : UserControl
    {
        Document activeDoc_;
        HashSet<string> oldWords_;
        HashSet<string> newWords_;
        GenericLogPhrasesToDB phraseLogger_;
        DBReader dbReader_;
        int refreshCounter_;
        List<SearchResult> results_;
        BackgroundWorker guiWorker_;

        public void SetActiveDocument(Document doc)
        {
            this.activeDoc_ = doc;
            this.timer1.Start();
        }
        public ContextSearchBar()
        {
            InitializeComponent();
            this.timer1.Interval = 5000;
            this.timer1.Tick += timer1_Tick;

            oldWords_ = new HashSet<string>();
            newWords_ = new HashSet<string>();

            phraseLogger_ = new GenericLogPhrasesToDB();
            dbReader_ = new DBReader();

            refreshCounter_ = 0;
            results_ = new List<SearchResult>();

            guiWorker_ = new BackgroundWorker();
            guiWorker_.DoWork += GuiWorker__DoWork;
        }

        private void GuiWorker__DoWork(object sender, DoWorkEventArgs e)
        {
            lblResultCount.Invoke(new MethodInvoker(delegate
            {
                lblResultCount.Text = results_.Count.ToString() + " results";
            }));

            pnlResults.Invoke(new MethodInvoker(delegate {
                try
                {
                    pnlResults.Controls.Clear();

                    foreach (SearchResult result in results_)
                    {
                        if (!cbxWord.Checked && result.Type == "docx" ||
                           !cbxPP.Checked && result.Type == "pptx" ||
                           !cbxExcel.Checked && result.Type == "xlsx" ||
                           !cbxPDF.Checked && result.Type == "pdf" ||
                           !cbxChrome.Checked && result.Type == "chrome" ||
                           !cbxOutlook.Checked && result.Type == "mail" ||
                           !cbxWeb.Checked && result.Type == "web")
                        {
                            continue;
                        }

                        SearchResultUI res = new SearchResultUI();
                        res.Type = result.Type.ToString();
                        res.Link = result.Path;
                        res.HiddenValue = result.AdditionalInformation;
                        res.Icon = result.Type.ToString();
                        res.Score = result.Score;
                        pnlResults.Controls.Add(res);
                    }
                }
                catch (Exception ex)
                {
                    Utilities.Logger.LogInfo("Error occured loading gui in BW thread");
                    Utilities.Logger.LogError(ex);
                }
            }));
     
            
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            newWords_.Clear();
            
            for (int i = 1; i <= this.activeDoc_.Words.Count; i++ )
            {
                newWords_.Add(this.activeDoc_.Words[i].Text);
            }

            List<string> diff = Utilities.Helper.GetListChanges(newWords_, oldWords_);

            string newAdded = String.Empty;
            foreach (string d in diff)
            {
                newAdded += d + " ";
            }

            oldWords_.Clear();

            foreach (string word in newWords_)
            {
                oldWords_.Add(word);
            }
            
            //do nothing if no words changed...
            if (diff.Count == 0 && refreshCounter_ == 0 && this.activeDoc_.Words.Count > 1)
            {
                btnDirectSearch_Click(null, null);
            }
           
            //there is diff and user stopped typing
            if (diff.Count != 0)
            {
                if (refreshCounter_ == 0)
                {
                    this.txtSearhBox.Text = newAdded;
                }
                refreshCounter_ = 0;

                //if there is diff, just log actual context
                GetWordsFromBoxAndLogContext();
            }           
        }

        // Returns true if 'target' is contained in 'source'
        private bool IsInRange(Range target, Range source)
        {
            bool toreturn = target.Start >= source.Start && target.End <= source.End;
            return toreturn;
        }

        private void btnDirectSearch_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= this.activeDoc_.Paragraphs.Count; i++)
            {
                if (IsInRange(this.activeDoc_.Parent.Selection.Range, this.activeDoc_.Paragraphs[i].Range))
                {
                    Range actualrange = this.activeDoc_.Paragraphs[i].Range;

                    string words = String.Empty;
                    for (int w = 1; w <= actualrange.Words.Count; w++)
                    {
                        words += actualrange.Words[w].Text + " ";
                    }

                    this.txtSearhBox.Text += words.Trim();
                    break;
                }

            }

            refreshCounter_++;

            //log actual words to db
            GetWordsFromBoxAndLogContext();

            results_ = dbReader_.ReadCurrentSearchResults();

            guiWorker_.RunWorkerAsync();
        }

        private void GetWordsFromBoxAndLogContext()
        {
            string[] tempphrases = txtSearhBox.Text.Split(' ');
            List<string> phrases = new List<string>();

            for (int i = 0; i < tempphrases.Length; i++)
            {
                string trimmed = tempphrases[i].Trim();

                if (!String.IsNullOrEmpty(trimmed))
                {
                    phrases.Add(trimmed);
                }
            }

            if (phrases.Count > 0)
            {
                phraseLogger_.LogPhrasesToDB(phrases.ToArray());
            }
        }

        private void txtSearhBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDirectSearch_Click(null, null);
            }
        }

        private void pnlResults_MouseHover(object sender, EventArgs e)
        {
            pnlResults.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
        }

        private void cbx_CheckedChanged(object sender, EventArgs e)
        {
            //guiWorker_.RunWorkerAsync();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            guiWorker_.RunWorkerAsync();
        }
    }
}
