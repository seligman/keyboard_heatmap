using System.Diagnostics;

namespace ShowKeys
{
    public partial class KeyForm : Form
    {
        LoggerForm? _logger = null;
        public KeyForm()
        {
            InitializeComponent();
            Counts.Init(this);
            Keys.Init();
        }

        private void KeyForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        void KeyForm_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.Black);

            int top = 0;
            foreach (var kvp in Counts.VkCounts)
            {
                top = Math.Max(top, kvp.Value);
            }

            using (var fontSegoe = new Font("Segoe UI", 10))
            using (var sf = (StringFormat)StringFormat.GenericDefault.Clone())
            using (var keyBack = new SolidBrush(Color.FromArgb(50, 50, 50)))
            using (var keyDown = new SolidBrush(Color.FromArgb(225, 255, 255)))
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                foreach (var key in Keys.All)
                {
                    if (key.Desc != null)
                    {
                        var rt = new RectangleF(
                            key.X / Keys.Width * ClientSize.Width + ClientRectangle.Left,
                            key.Y / Keys.Height * (ClientSize.Height - m_menu.Height) + ClientRectangle.Top + m_menu.Height,
                            key.Width / Keys.Width * ClientSize.Width,
                            key.Height / Keys.Height * (ClientSize.Height - m_menu.Height));
                        rt.Inflate(-1, -1);
                        var font = fontSegoe;
                        var desc = key.Desc;
                        if (Counts.VkCounts.ContainsKey(key.VK))
                        {
                            var perc = ((double)Counts.VkCounts[key.VK]) / ((double)top);
                            var color = Color.FromArgb((int)(perc * 255), 0, (int)((1 - perc) * 255));
                            using (var solid = new SolidBrush(color))
                            {
                                g.FillRectangle(solid, rt.X, rt.Y, rt.Width, rt.Height);
                            }
                        }
                        else
                        {
                            g.FillRectangle(keyBack, rt.X, rt.Y, rt.Width, rt.Height);
                        }
                        g.DrawString(desc, font, keyDown, rt, sf);
                    }

                }
            }
        }

        public void UpdateKeyboard()
        {
            Invalidate();
        }

        public void RemoveLogger()
        {
            _logger = null;
        }

        void loggerWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_logger == null)
            {
                _logger = new LoggerForm(this);
                _logger.Show();
            }
        }
    }
}
