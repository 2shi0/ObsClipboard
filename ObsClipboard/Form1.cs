using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObsClipboard
{
    public partial class Form1 : Form
    {
        ClipBoardWatcher cbw;
        Image tmp;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbw = new ClipBoardWatcher();
            cbw.DrawClipBoard += (sender2, e2) => {
                if (Clipboard.ContainsImage())
                {
                    if (tmp == null) tmp = Clipboard.GetImage();
                    if (tmp == Clipboard.GetImage()) return;

                    Clipboard.GetImage().Save("img.png");
                    MessageBox.Show("clipboard changed(img)");
                }
            };
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cbw.Dispose();
        }
    }
}
