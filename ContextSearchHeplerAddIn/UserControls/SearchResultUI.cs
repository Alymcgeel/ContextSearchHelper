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
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ContextSearchHeplerAddIn
{
    public partial class SearchResultUI : UserControl
    {
        public SearchResultUI()
        {
            InitializeComponent();
        }

        public string Icon
        {
            set
            {
                Byte[] bitmapData = new Byte[value.Length];
                bitmapData = Convert.FromBase64String(Utilities.Helper.GetBase64ImageByName(value));
                System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
                Bitmap bitImage = new Bitmap((Bitmap)Image.FromStream(streamBitmap));
                pctType.Image = bitImage;
            }
        }

        public string Type
        {
            get
            {
                return this.lblType.Text;
            }
            set
            {
                this.lblType.Text = value;
            }
        }

        public string HiddenValue
        {
            get
            {
                return this.lblHiddenValue.Text;
            }
            set
            {
                this.lblHiddenValue.Text = value;
            }
        }

        public string Score
        {
            get
            {
                return this.lblScore.Text;
            }
            set
            {
                this.lblScore.Text = value;
            }
        }

        public string Link
        {
            set
            {
                string url = value;
                if (url.Length > 50)
                {
                    url = url.Substring(0, 50) + "...";
                }

                this.lblLink.Text = url;
                this.lblLink.Links.Add(0, value.Length, value);
                this.lblLink.LinkClicked += lblLink_LinkClicked;
                toolTip1.SetToolTip(this.lblLink, value);
            }
        }

        void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblType.Text.ToLower() != "mail")
            {
                try
                {
                    string toopen = e.Link.LinkData as string;
                    Process.Start(toopen);
                }
                catch (Exception ex)
                {
                    Utilities.Logger.LogError(ex);
                }
            }
            else //ismail
            {

                Outlook.Application myApp = Utilities.Helper.GetApplicationObject();
                Outlook.NameSpace mapiNameSpace = myApp.GetNamespace("MAPI");

                Outlook.MailItem getItem = (Outlook.MailItem)mapiNameSpace.GetItemFromID(lblHiddenValue.Text, null);
                getItem.Display();
            }
        }

        private void SearchResultUI_DoubleClick(object sender, EventArgs e)
        {
            lblLink_LinkClicked(this.lblLink, new LinkLabelLinkClickedEventArgs(this.lblLink.Links[0],MouseButtons.Left));
        }
    }
}
