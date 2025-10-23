using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClearPlanet
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new PartnerForm());
        }

        // загрузка формы партнеров в панель на главной странице
        private void ShowFormInPanel(Form form)
        {
            pnlForm.Controls.Clear();

            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;

            pnlForm.Controls.Add(form);
            form.Show();
        }
    }
}
