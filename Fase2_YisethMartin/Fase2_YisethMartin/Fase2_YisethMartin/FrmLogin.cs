using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fase2_YisethMartin
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "123")
            {
                
                this.Hide();
                var FrmRegistroDatos=new FrmRegistroDatos();
                FrmRegistroDatos.Show();
            }
            else
            {
                MessageBox.Show("Contraseña Incorrecta", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
