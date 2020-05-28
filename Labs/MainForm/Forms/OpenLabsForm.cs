using System;
using System.Windows.Forms;

namespace MainForm.Forms
{
    public partial class OpenLabsForm : Form
    {
        public OpenLabsForm()
        {
            InitializeComponent();
        }

        private void Lab5Btn_Click(object sender, EventArgs e)
        {
            new Lab5.Forms.DrawForm().ShowDialog();
        }

        private void Lab1Btn_Click(object sender, EventArgs e)
        {
            new Lab1.Forms.DrawForm().ShowDialog();
        }

        private void Lab2Btn_Click(object sender, EventArgs e)
        {
            new Lab2.Forms.DrawForm().ShowDialog();
        }

        private void Lab3Btn_Click(object sender, EventArgs e)
        {
            new Lab3.Forms.DrawForm().ShowDialog();
        }

        private void Lab4Btn_Click(object sender, EventArgs e)
        {
            new Lab4.Forms.DrawForm().ShowDialog();
        }

        private void Lab6Btn_Click(object sender, EventArgs e)
        {
            new Lab6.Forms.DrawForm().ShowDialog();
        }
    }
}
