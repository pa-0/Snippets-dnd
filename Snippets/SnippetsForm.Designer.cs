namespace Snippets
{
    partial class SnippetsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnippetsForm));
            snippetList = new ListBox();
            SuspendLayout();
            // 
            // snippetList
            // 
            snippetList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            snippetList.BackColor = Color.FromArgb(15, 15, 19);
            snippetList.BorderStyle = BorderStyle.None;
            snippetList.ForeColor = Color.White;
            snippetList.FormattingEnabled = true;
            snippetList.ItemHeight = 15;
            snippetList.Location = new Point(2, 2);
            snippetList.Name = "snippetList";
            snippetList.Size = new Size(400, 480);
            snippetList.TabIndex = 0;
            // 
            // SnippetsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 19);
            ClientSize = new Size(404, 484);
            Controls.Add(snippetList);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SnippetsForm";
            Text = "SnippetsForm";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private ListBox snippetList;
    }
}