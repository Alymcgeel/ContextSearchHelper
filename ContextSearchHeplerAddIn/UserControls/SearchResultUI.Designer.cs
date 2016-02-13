namespace ContextSearchHeplerAddIn
{
    partial class SearchResultUI
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
            this.lblType = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblHiddenValue = new System.Windows.Forms.Label();
            this.pctType = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(7, 15);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "label1";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(7, 62);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(55, 13);
            this.lblLink.TabIndex = 1;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "linkLabel1";
            // 
            // lblHiddenValue
            // 
            this.lblHiddenValue.AutoSize = true;
            this.lblHiddenValue.Location = new System.Drawing.Point(252, 4);
            this.lblHiddenValue.Name = "lblHiddenValue";
            this.lblHiddenValue.Size = new System.Drawing.Size(0, 13);
            this.lblHiddenValue.TabIndex = 2;
            this.lblHiddenValue.Visible = false;
            // 
            // pctType
            // 
            this.pctType.Location = new System.Drawing.Point(221, 4);
            this.pctType.Name = "pctType";
            this.pctType.Size = new System.Drawing.Size(60, 60);
            this.pctType.TabIndex = 3;
            this.pctType.TabStop = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(180, 15);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(35, 13);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "label1";
            this.lblScore.Visible = false;
            // 
            // SearchResultUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pctType);
            this.Controls.Add(this.lblHiddenValue);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lblType);
            this.Name = "SearchResultUI";
            this.Size = new System.Drawing.Size(284, 84);
            this.DoubleClick += new System.EventHandler(this.SearchResultUI_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pctType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.LinkLabel lblLink;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblHiddenValue;
        private System.Windows.Forms.PictureBox pctType;
        private System.Windows.Forms.Label lblScore;
    }
}
