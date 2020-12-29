using System;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LabirintForm labirint = new LabirintForm();
            labirint.OpenLevel(1);
            labirint.ShowDialog();
        }
    }
}
