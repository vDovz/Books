namespace Books
{
    partial class MainForm
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
            this.btnBook = new System.Windows.Forms.Button();
            this.btnJournal = new System.Windows.Forms.Button();
            this.btnNewspaper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(30, 53);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(80, 36);
            this.btnBook.TabIndex = 0;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnJournal
            // 
            this.btnJournal.Location = new System.Drawing.Point(152, 53);
            this.btnJournal.Name = "btnJournal";
            this.btnJournal.Size = new System.Drawing.Size(80, 36);
            this.btnJournal.TabIndex = 1;
            this.btnJournal.Text = "Journal";
            this.btnJournal.UseVisualStyleBackColor = true;
            this.btnJournal.Click += new System.EventHandler(this.btnJournal_Click);
            // 
            // btnNewspaper
            // 
            this.btnNewspaper.Location = new System.Drawing.Point(276, 53);
            this.btnNewspaper.Name = "btnNewspaper";
            this.btnNewspaper.Size = new System.Drawing.Size(80, 36);
            this.btnNewspaper.TabIndex = 2;
            this.btnNewspaper.Text = "Newspaper";
            this.btnNewspaper.UseVisualStyleBackColor = true;
            this.btnNewspaper.Click += new System.EventHandler(this.btnNewspaper_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 139);
            this.Controls.Add(this.btnNewspaper);
            this.Controls.Add(this.btnJournal);
            this.Controls.Add(this.btnBook);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnJournal;
        private System.Windows.Forms.Button btnNewspaper;
    }
}