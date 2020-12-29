using System;
using System.Windows.Forms;

namespace Sokoban2Players
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!radioClient.Checked && !radioServer.Checked)
            {
                MessageBox.Show("Выберите режим подключения!");
                return;
            }

            LabirintForm labirint = null;
            if (radioServer.Checked) labirint = new LabirintForm(tbPort.Text);
            if (radioClient.Checked) labirint = new LabirintForm(tbHost.Text, tbPort.Text);

            if (labirint == null) return;

            labirint.OpenLevel(1);
            labirint.ShowDialog();
        }

        private void radioServer_CheckedChanged(object sender, EventArgs e)
        {
            lbHost.Visible = false;
            tbHost.Visible = false;
            lbPort.Visible = true;
            tbPort.Visible = true;
        }

        private void radioClient_CheckedChanged(object sender, EventArgs e)
        {
            lbHost.Visible = true;
            tbHost.Visible = true;
            lbPort.Visible = true;
            tbPort.Visible = true;
        }
    }
}
