namespace ContextSearchHeplerAddIn
{
    partial class ContextSearchBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearhBox = new System.Windows.Forms.TextBox();
            this.btnDirectSearch = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlResults = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblResultCount = new System.Windows.Forms.Label();
            this.cbxWord = new System.Windows.Forms.CheckBox();
            this.cbxExcel = new System.Windows.Forms.CheckBox();
            this.cbxPP = new System.Windows.Forms.CheckBox();
            this.cbxPDF = new System.Windows.Forms.CheckBox();
            this.cbxChrome = new System.Windows.Forms.CheckBox();
            this.cbxOutlook = new System.Windows.Forms.CheckBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.cbxWeb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Direktsuche";
            // 
            // txtSearhBox
            // 
            this.txtSearhBox.Location = new System.Drawing.Point(27, 22);
            this.txtSearhBox.Multiline = true;
            this.txtSearhBox.Name = "txtSearhBox";
            this.txtSearhBox.Size = new System.Drawing.Size(293, 57);
            this.txtSearhBox.TabIndex = 1;
            this.txtSearhBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearhBox_KeyDown);
            // 
            // btnDirectSearch
            // 
            this.btnDirectSearch.Location = new System.Drawing.Point(326, 23);
            this.btnDirectSearch.Name = "btnDirectSearch";
            this.btnDirectSearch.Size = new System.Drawing.Size(32, 56);
            this.btnDirectSearch.TabIndex = 2;
            this.btnDirectSearch.Text = "GO";
            this.btnDirectSearch.UseVisualStyleBackColor = true;
            this.btnDirectSearch.Click += new System.EventHandler(this.btnDirectSearch_Click);
            // 
            // pnlResults
            // 
            this.pnlResults.AutoScroll = true;
            this.pnlResults.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlResults.Location = new System.Drawing.Point(27, 162);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(331, 315);
            this.pnlResults.TabIndex = 3;
            this.pnlResults.WrapContents = false;
            this.pnlResults.MouseHover += new System.EventHandler(this.pnlResults_MouseHover);
            // 
            // lblResultCount
            // 
            this.lblResultCount.AutoSize = true;
            this.lblResultCount.Location = new System.Drawing.Point(27, 62);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(0, 13);
            this.lblResultCount.TabIndex = 4;
            // 
            // cbxWord
            // 
            this.cbxWord.AutoSize = true;
            this.cbxWord.Checked = true;
            this.cbxWord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxWord.Location = new System.Drawing.Point(30, 85);
            this.cbxWord.Name = "cbxWord";
            this.cbxWord.Size = new System.Drawing.Size(56, 17);
            this.cbxWord.TabIndex = 5;
            this.cbxWord.Text = "DOCX";
            this.cbxWord.UseVisualStyleBackColor = true;
            this.cbxWord.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // cbxExcel
            // 
            this.cbxExcel.AutoSize = true;
            this.cbxExcel.Checked = true;
            this.cbxExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxExcel.Location = new System.Drawing.Point(116, 85);
            this.cbxExcel.Name = "cbxExcel";
            this.cbxExcel.Size = new System.Drawing.Size(53, 17);
            this.cbxExcel.TabIndex = 6;
            this.cbxExcel.Text = "XLSX";
            this.cbxExcel.UseVisualStyleBackColor = true;
            this.cbxExcel.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // cbxPP
            // 
            this.cbxPP.AutoSize = true;
            this.cbxPP.Checked = true;
            this.cbxPP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPP.Location = new System.Drawing.Point(202, 85);
            this.cbxPP.Name = "cbxPP";
            this.cbxPP.Size = new System.Drawing.Size(54, 17);
            this.cbxPP.TabIndex = 7;
            this.cbxPP.Text = "PPTX";
            this.cbxPP.UseVisualStyleBackColor = true;
            this.cbxPP.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // cbxPDF
            // 
            this.cbxPDF.AutoSize = true;
            this.cbxPDF.Checked = true;
            this.cbxPDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPDF.Location = new System.Drawing.Point(278, 85);
            this.cbxPDF.Name = "cbxPDF";
            this.cbxPDF.Size = new System.Drawing.Size(47, 17);
            this.cbxPDF.TabIndex = 8;
            this.cbxPDF.Text = "PDF";
            this.cbxPDF.UseVisualStyleBackColor = true;
            this.cbxPDF.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // cbxChrome
            // 
            this.cbxChrome.AutoSize = true;
            this.cbxChrome.Checked = true;
            this.cbxChrome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxChrome.Location = new System.Drawing.Point(30, 108);
            this.cbxChrome.Name = "cbxChrome";
            this.cbxChrome.Size = new System.Drawing.Size(73, 17);
            this.cbxChrome.TabIndex = 9;
            this.cbxChrome.Text = "CHROME";
            this.cbxChrome.UseVisualStyleBackColor = true;
            this.cbxChrome.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // cbxOutlook
            // 
            this.cbxOutlook.AutoSize = true;
            this.cbxOutlook.Checked = true;
            this.cbxOutlook.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxOutlook.Location = new System.Drawing.Point(116, 108);
            this.cbxOutlook.Name = "cbxOutlook";
            this.cbxOutlook.Size = new System.Drawing.Size(51, 17);
            this.cbxOutlook.TabIndex = 10;
            this.cbxOutlook.Text = "MAIL";
            this.cbxOutlook.UseVisualStyleBackColor = true;
            this.cbxOutlook.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(27, 130);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(156, 23);
            this.btnApplyFilter.TabIndex = 11;
            this.btnApplyFilter.Text = "Apply filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // cbxWeb
            // 
            this.cbxWeb.AutoSize = true;
            this.cbxWeb.Checked = true;
            this.cbxWeb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxWeb.Location = new System.Drawing.Point(202, 108);
            this.cbxWeb.Name = "cbxWeb";
            this.cbxWeb.Size = new System.Drawing.Size(51, 17);
            this.cbxWeb.TabIndex = 12;
            this.cbxWeb.Text = "WEB";
            this.cbxWeb.UseVisualStyleBackColor = true;
            this.cbxWeb.CheckedChanged += new System.EventHandler(this.cbx_CheckedChanged);
            // 
            // ContextSearchBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxWeb);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.cbxOutlook);
            this.Controls.Add(this.cbxChrome);
            this.Controls.Add(this.cbxPDF);
            this.Controls.Add(this.cbxPP);
            this.Controls.Add(this.cbxExcel);
            this.Controls.Add(this.cbxWord);
            this.Controls.Add(this.lblResultCount);
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.btnDirectSearch);
            this.Controls.Add(this.txtSearhBox);
            this.Controls.Add(this.label1);
            this.Name = "ContextSearchBar";
            this.Size = new System.Drawing.Size(450, 566);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearhBox;
        private System.Windows.Forms.Button btnDirectSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel pnlResults;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.CheckBox cbxWord;
        private System.Windows.Forms.CheckBox cbxExcel;
        private System.Windows.Forms.CheckBox cbxPP;
        private System.Windows.Forms.CheckBox cbxPDF;
        private System.Windows.Forms.CheckBox cbxChrome;
        private System.Windows.Forms.CheckBox cbxOutlook;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.CheckBox cbxWeb;
    }
}
