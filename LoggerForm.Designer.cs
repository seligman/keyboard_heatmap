namespace ShowKeys
{
    partial class LoggerForm
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
            _log = new ListBox();
            SuspendLayout();
            // 
            // _log
            // 
            _log.Dock = DockStyle.Fill;
            _log.FormattingEnabled = true;
            _log.IntegralHeight = false;
            _log.ItemHeight = 15;
            _log.Location = new Point(0, 0);
            _log.Name = "_log";
            _log.Size = new Size(295, 258);
            _log.TabIndex = 0;
            // 
            // LoggerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 258);
            Controls.Add(_log);
            Name = "LoggerForm";
            Text = "Keyboard Logger";
            FormClosed += LoggerForm_FormClosed;
            Load += LoggerForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox _log;
    }
}