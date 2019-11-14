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
    public partial class menu_provider : Form
    {

        Manipulationcls bd = new Manipulationcls(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Blackhorde\Documents\GitHub\EstudioContableJanet\ProyectoEstudio\EstudioJanet.mdb");
        DataTable tbl = new DataTable();
        const int tam = 1000;
        providercls[] arrayprov = new providercls[tam];
        bool nuevo;

        public menu_provider()
        {
            InitializeComponent();
            activarbotones(false);
            cargarcombo(cmbCondicion_iva, "CondicionIva");
            cargarlista("Proveedores");

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
            limpiar();
            activarbotones(false);
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
        private void cargarcombo(ComboBox combo, string nombretabla)
        {
            tbl = bd.consultartabla(nombretabla);
            combo.DataSource = tbl;
            combo.ValueMember = tbl.Columns[0].ColumnName;
            combo.DisplayMember = tbl.Columns[1].ColumnName;
            combo.SelectedIndex = 0;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void cargarlista(string nombretabla)
        {
            bd.leertabla(nombretabla);
            int c = 0;
            listBox1.Items.Clear();
            while (bd.Leer.Read())
            {
                providercls p = new providercls();
                if (!bd.Leer.IsDBNull(0))
                    p.Idprovider = bd.Leer.GetInt32(0);
                if (!bd.Leer.IsDBNull(1))
                    p.Reason = bd.Leer.GetString(1);
                if (!bd.Leer.IsDBNull(2))
                    p.Cuit = bd.Leer.GetInt32(2);
                if (!bd.Leer.IsDBNull(3))
                    p.Ivacondition = bd.Leer.GetInt32(3);
                if (!bd.Leer.IsDBNull(4))
                    p.Address = bd.Leer.GetString(4);
                if (!bd.Leer.IsDBNull(5))
                    p.Number = bd.Leer.GetInt32(5);
                if (!bd.Leer.IsDBNull(6))
                    p.Observation = bd.Leer.GetString(6);
                if (!bd.Leer.IsDBNull(7))
                    p.Email = bd.Leer.GetString(7);
                arrayprov[c] = p;
                c++;
            }
            bd.Leer.Close();
            bd.desconectar();
            for (int i = 0; i < c; i++)
            {
                listBox1.Items.Add(arrayprov[i].Reason);
            }

        }

    }
}
