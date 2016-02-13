namespace SearchHost
{
    partial class TestFileQuery
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtquery = new System.Windows.Forms.TextBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.lblResCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtquery
            // 
            this.txtquery.Location = new System.Drawing.Point(13, 3);
            this.txtquery.Multiline = true;
            this.txtquery.Name = "txtquery";
            this.txtquery.Size = new System.Drawing.Size(728, 57);
            this.txtquery.TabIndex = 1;
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(8, 102);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtResults.Size = new System.Drawing.Size(728, 147);
            this.txtResults.TabIndex = 2;
            // 
            // lblResCount
            // 
            this.lblResCount.AutoSize = true;
            this.lblResCount.Location = new System.Drawing.Point(105, 67);
            this.lblResCount.Name = "lblResCount";
            this.lblResCount.Size = new System.Drawing.Size(35, 13);
            this.lblResCount.TabIndex = 3;
            this.lblResCount.Text = "label1";
            // 
            // TestFileQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 261);
            this.Controls.Add(this.lblResCount);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.txtquery);
            this.Controls.Add(this.btnSearch);
            this.Name = "TestFileQuery";
            this.Text = "TestFileQuery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtquery;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Label lblResCount;
    }
}