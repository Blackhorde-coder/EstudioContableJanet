using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEstudio
{
    public partial class menu_providers : Form
    {

        Manipulationcls bd = new Manipulationcls(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = E:\Hernan\Estudio Contable Janet\ProyectoEstudio\EstudioJanet.mdb");
        DataTable tbl = new DataTable();
        int c;
        const int tam = 1000;
        Consortiumcls[] arraycons = new Consortiumcls[tam];
        bool nuevo;

        public menu_providers()
        {
            InitializeComponent();
            activarbotones(false);

        }

        private void menu_providers_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            activarbotones(true);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void activarbotones(bool s)
        {
            txtRazonSocial.Enabled = s;
            txtDireccion.Enabled = s;
            txtCuit.Enabled = s;
            txtNumero.Enabled = s;
            txtEmail.Enabled = s;
            txtObservacion.Enabled = s;
            cmbCondicion_iva.Enabled = s;
            listBox1.Enabled = s;
            btnEliminar.Enabled = s;
            btnGuardar.Enabled = s;
            btnCancelar.Enabled = s;

            btnNuevo.Enabled = !s;
            btnEditar.Enabled = !s;
            btnSalir.Enabled = !s;
        }
        private void limpiar()
        {
            txtRazonSocial.Text = "";
            txtCuit.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtObservacion.Text = "";
            txtNumero.Text = "";
            cmbCondicion_iva.SelectedIndex = -1;

        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }


    }
}
