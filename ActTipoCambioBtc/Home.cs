using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActTipoCambioBtc
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            openChildForm(new Configuracion());
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(childForm);
            panelContenedor.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnActulizador_Click(object sender, EventArgs e)
        {
            openChildForm(new Actulizador());
        }
    }
}
