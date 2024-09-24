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
    public partial class FrmReporte : Form
    {
        //readonly
        private GestionEstudiantes estudiante;
        private FrmRegistroDatos frmRegistroDatos;


        public FrmReporte(GestionEstudiantes estudiante, FrmRegistroDatos frmRegistroDatos)
        {
            InitializeComponent();
            this.estudiante = estudiante;
            this.frmRegistroDatos = frmRegistroDatos;
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            lblFechaRegsitro.Text = estudiante.FechaRegistro.ToShortDateString();
            lbl1.Text = estudiante.Nombre;
            lbl2.Text = estudiante.Identificacion;
            lbl3.Text = estudiante.Genero;
            lbl4.Text = estudiante.Instrumento;
            lbl5.Text = estudiante.NumeroClases.ToString();
            lbl6.Text = estudiante.CostoPorClase.ToString("F2");
            lbl7.Text = estudiante.CalcularCostoTotal().ToString("f2");

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {

            //limpiar campos
            frmRegistroDatos.LimpiarCampos();
            frmRegistroDatos.Show();

            this.Close();//cierra formulario
            
        }

        
    }
}
