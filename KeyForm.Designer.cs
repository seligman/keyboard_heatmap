

namespace ShowKeys
{
    partial class KeyForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m_menu = new MenuStrip();
            openToolStripMenuItem = new ToolStripMenuItem();
            loggerWindowToolStripMenuItem = new ToolStripMenuItem();
            m_menu.SuspendLayout();
            SuspendLayout();
            // 
            // m_menu
            // 
            m_menu.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            m_menu.Location = new Point(0, 0);
            m_menu.Name = "m_menu";
            m_menu.Size = new Size(1061, 24);
            m_menu.TabIndex = 0;
            m_menu.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loggerWindowToolStripMenuItem });
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(48, 20);
            openToolStripMenuItem.Text = "Open";
            // 
            // loggerWindowToolStripMenuItem
            // 
            loggerWindowToolStripMenuItem.Name = "loggerWindowToolStripMenuItem";
            loggerWindowToolStripMenuItem.Size = new Size(165, 22);
            loggerWindowToolStripMenuItem.Text = "Logger window...";
            loggerWindowToolStripMenuItem.Click += loggerWindowToolStripMenuItem_Click;
            // 
            // KeyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 387);
            Controls.Add(m_menu);
            DoubleBuffered = true;
            MainMenuStrip = m_menu;
            Name = "KeyForm";
            Text = "Keys";
            Paint += KeyForm_Paint;
            Resize += KeyForm_Resize;
            m_menu.ResumeLayout(false);
            m_menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private MenuStrip m_menu;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem loggerWindowToolStripMenuItem;
    }
}
