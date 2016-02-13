using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Windows.Forms;

namespace ContextSearchHeplerAddIn
{
    public partial class ThisAddIn
    {
        Timer activeDocumentTimer_;
        private ContextSearchBar sideBar_;
        private Microsoft.Office.Tools.CustomTaskPane sideBarPane_;
        private bool documentLoaded_;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            activeDocumentTimer_ = new Timer();
            activeDocumentTimer_.Interval = 500;
            activeDocumentTimer_.Tick += activeDocumentTimer__Tick;

            sideBar_ = new ContextSearchBar();
            sideBarPane_ = this.CustomTaskPanes.Add(sideBar_, "Context Search Helper");
            sideBarPane_.Width = 400;
            sideBarPane_.Visible = true;

            activeDocumentTimer_.Start();


        }

        void activeDocumentTimer__Tick(object sender, EventArgs e)
        {
            if (this.Application.Documents.Count > 0 && !documentLoaded_)
            {
                documentLoaded_ = true;
                this.sideBar_.SetActiveDocument(this.Application.ActiveDocument);
                activeDocumentTimer_.Stop();
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
