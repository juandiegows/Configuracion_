using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Properties;

namespace Vista
{
    public partial class FormConfiguracion : Form
    {
        public FormConfiguracion()
        {
            InitializeComponent();
        }

        private void CargarConfiguracion()
        {
            this.Location = Settings.Default.Posicion;
            this.Size = Settings.Default.Tamaño;
            txtMensaje.Text = Settings.Default.Mensaje;
            listaNumero.Value = Settings.Default.Numero;
            cbActivo.Checked = Settings.Default.Activo;

        }

        private void RestablecerConfiguracion()
        {
            Settings.Default.Reset();
            CargarConfiguracion();
            MessageBox.Show("Se ha restablecido correctamente");
        }

        private bool GuardarConfiguracion()
        {
            Settings.Default.Mensaje = txtMensaje.Text;
            Settings.Default.Numero = (int)listaNumero.Value;
            Settings.Default.Activo = cbActivo.Checked;
            Settings.Default.Posicion = this.Location;
            Settings.Default.Tamaño = this.Size;
            Settings.Default.Save();
            return true;
          

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarConfiguracion();
        }

        private void FormConfiguracion_Load(object sender, EventArgs e)
        {
            CargarConfiguracion();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            RestablecerConfiguracion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           if(GuardarConfiguracion())
            {
                MessageBox.Show("Se ha Guardado correctamente");
            }
        }

        private void FormConfiguracion_FormClosed(object sender, FormClosedEventArgs e)
        {
            GuardarConfiguracion();
        }
    }
}
