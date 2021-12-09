using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleSoanDe
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        Form current = new Form();
        private void openForm(Form f)
        {
            f.TopLevel = false;
            panelMain.Controls.Add(f);
            panelMain.Tag = f;

            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.BringToFront();
            f.Show();
            current.Close();
        }
        private void btnSoanCauHoi_Click(object sender, EventArgs e)
        {
            frmSoanCauHoi f = new frmSoanCauHoi();
            openForm(f);
            current = f;
        }

        private void btnTaoDeThi_Click(object sender, EventArgs e)
        {
            frmTaoDeThi f = new frmTaoDeThi();
            openForm(f);
            current = f;
        }

        private void btnChamBai_Click(object sender, EventArgs e)
        {
            frmChamBai f = new frmChamBai();
            openForm(f);
            current = f;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            current.Close();
        }
    }
}
