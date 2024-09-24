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
    public partial class FrmRegistroDatos : Form


    {

        private GestionEstudiantes estudiante;
        private ErrorProvider errorProvider;

        public FrmRegistroDatos()
        {
            InitializeComponent();
            cmbInstrumento.Items.AddRange(new[] { "Piano", "Guitarra", "Violín", "Batería", "Canto" });
            txtCosto.Enabled = false;
            errorProvider1 = new ErrorProvider();
        }

        private void button1_Click(object sender, EventArgs e)//Primero se deben guardar datos siempre para poder mostrar resultados
        {
            //validar datos


            if (ValidarCampos())
            {
                string genero = checkBoxFeminino.Checked ? "Femenino" : checkBoxMasculino.Checked ? "Masculino" : "";
                estudiante = new GestionEstudiantes
                {
                    Identificacion = txtIdentificacion.Text,
                    Nombre = txtNombre.Text,
                    Instrumento = cmbInstrumento.SelectedItem.ToString(),
                    Genero = genero,
                    NumeroClases = int.Parse(txtNumeroClases.Text),
                    FechaRegistro = DateTime.Now

                };
                {
                    switch (cmbInstrumento.SelectedItem.ToString())
                    {
                        case "Piano":
                            txtCosto.Text = "100000";
                            break;
                        case "Guitarra":
                            txtCosto.Text = "80000";
                            break;
                        case "Violín":
                            txtCosto.Text = "90000";
                            break;
                        case "Batería":
                            txtCosto.Text = "85000";
                            break;
                        case "Canto":
                            txtCosto.Text = "95000";
                            break;
                    }

                }
            }
            else
            {
                MessageBox.Show("Complete los datos ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (estudiante != null)
            {
                var frmReporte = new FrmReporte(estudiante, this);
                frmReporte.Show();

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Seguro? ", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            errorProvider1.Clear();
            //Validar Identificacion
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) || !int.TryParse(txtIdentificacion.Text, out _))
            {
                errorProvider1.SetError(txtIdentificacion, " La identificación debe ser un número");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || TieneNumeros(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, " El nombre no debe contener números");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtNumeroClases.Text) || !int.TryParse(txtNumeroClases.Text, out _))
            {
                errorProvider1.SetError(txtNumeroClases, " Debe ingresar números");
                esValido = false;
            }
            if(cmbInstrumento.SelectedItem==null)
            {
                errorProvider1.SetError(cmbInstrumento, "Debe seleccionar un instrumento ");
                esValido = false;

            }
            if(!checkBoxFeminino.Checked && !checkBoxMasculino.Checked)
            {
                errorProvider1.SetError(checkBoxFeminino, "Debe seleccionar un género");
                esValido=false;
                errorProvider1.SetError(checkBoxMasculino, "Debe seleccionar un género");
                esValido = false;
            }

            return esValido;

        }

        private bool TieneNumeros(string texto)
        {
            foreach (char c in texto)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }

            return false;
        }

        public void LimpiarCampos()
        {
            {
                txtIdentificacion.Clear();
                txtNombre.Clear();
                txtCosto.Clear();
                txtNumeroClases.Clear();
                cmbInstrumento.SelectedIndex = -1;
                checkBoxFeminino.Checked = false;
                checkBoxMasculino.Checked = false;

            }



        }

        
    }
}


//return !string.IsNullOrEmpty(txtIdentificacion.Text) &&
          //     !string.IsNullOrEmpty(txtNombre.Text) &&
           //    cmbInstrumento.SelectedItem != null &&
            //   (checkBoxFeminino.Checked || checkBoxMasculino.Checked) &&
           //    int.TryParse(txtNumeroClases.Text, out _);