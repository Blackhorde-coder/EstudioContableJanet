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
    public partial class menu_consort : Form
    {
        Manipulationcls bd = new Manipulationcls(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Blackhorde\Documents\GitHub\EstudioContableJanet\ProyectoEstudio\EstudioJanet.mdb");
        DataTable tbl = new DataTable();
        int c;
        const int tam = 1000;
        Consortiumcls[] arraycons = new Consortiumcls[tam];
        bool nuevo;

        public menu_consort()
        {
            InitializeComponent();
            cargarcombo(cmbConsorcio, "consorcio");
            cargararray("consorcio");
            activarbotones(false);
            cmbConsorcio.Enabled = false;


        }

        private void menu_consort_Load(object sender, EventArgs e)
        {
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            activarbotones(true);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            nuevo = false;
            activarbotones(true);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int selec = listBox1.SelectedIndex;
            if (selec != -1)
            {
                string consultasql = "delete from consorcio where id_consorcio= " + arraycons[selec].Idconsortium;
                bd.modificarbd(consultasql);
                cargarcombo(cmbConsorcio, "consorcio");
                cargararray("consorcio");
                limpiar();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Consortiumcls p = new Consortiumcls();
            p.Name = txtNombre.Text;
            p.Cuit = Convert.ToDouble(txtCuit.Text);
            p.District = txtBarrio.Text;
            p.Address = txtDireccion.Text;
            p.Number = Convert.ToInt32(txtNumero.Text);

            if (nuevo == true)
            {
                string consultasql = "insert into consorcio(cuit,nombre,direccion,numero,barrio) " +
                                    "values (" + p.Cuit +
                                    ",'" + p.Name +
                                    "','" + p.Address +
                                    "'," + p.Number +
                                    ",'" + p.District +
                                    "')";
                bd.modificarbd(consultasql);
                cargarcombo(cmbConsorcio, "consorcio");
                cargararray("consorcio");
                limpiar();
            }
            else
            {
                p.Idconsortium = arraycons[listBox1.SelectedIndex].Idconsortium;
                string consultasql = "update consorcio set " +
                                     "nombre= '" + p.Name + "'," +
                                     "cuit= " + p.Cuit + "," +
                                     "direccion= '" + p.Address + "'," +
                                     "numero= " + p.Number + "," +
                                     "barrio= '" + p.District + "' " +
                                     "where id_consorcio= " + p.Idconsortium;
                bd.modificarbd(consultasql);
                cargarcombo(cmbConsorcio, "consorcio");
                cargararray("consorcio");
                limpiar();
            }

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
        private void cmbConsorcio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = cmbConsorcio.SelectedIndex;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selected = listBox1.SelectedIndex;
            if (selected != -1)
            {
                txtNombre.Text = arraycons[selected].Name;
                txtCuit.Text = Convert.ToString(arraycons[selected].Cuit);
                txtDireccion.Text = arraycons[selected].Address;
                txtNumero.Text = Convert.ToString(arraycons[selected].Number);
                txtBarrio.Text = arraycons[selected].District;
            }

        }
        private void cargarcombo(ComboBox nomcombo, string nomtabla)
        {
            tbl.Clear();
            tbl = bd.consultartabla(nomtabla);
            nomcombo.DataSource = tbl;
            nomcombo.ValueMember = tbl.Columns[0].ColumnName;
            nomcombo.DisplayMember = tbl.Columns[1].ColumnName;
            nomcombo.SelectedIndex = 1;
            nomcombo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void cargardatos()
        {
            int val = cmbConsorcio.SelectedIndex;
            //txtNombre.Text =Convert.ToString(arraycons[val].Name);
            MessageBox.Show(Convert.ToString(val));

        }
        private void cargararray(string nomtabla)
        {
            int c = 0;
            bd.leertabla(nomtabla);
            while (bd.Leer.Read())
            {
                Consortiumcls cons = new Consortiumcls();
                if(!bd.Leer.IsDBNull(0))
                    cons.Idconsortium = bd.Leer.GetInt32(0);
                if (!bd.Leer.IsDBNull(1))
                    cons.Name = bd.Leer.GetString(1);
                if (!bd.Leer.IsDBNull(2))
                    cons.Cuit = bd.Leer.GetDouble(2);
                if (!bd.Leer.IsDBNull(3))
                    cons.Address = bd.Leer.GetString(3);
                if (!bd.Leer.IsDBNull(4))
                    cons.Number = bd.Leer.GetInt32(4);
                if (!bd.Leer.IsDBNull(5))
                    cons.District = bd.Leer.GetString(5);
                arraycons[c] = cons;
                c++;
            }
            bd.Leer.Close();
            bd.desconectar();
            listBox1.Items.Clear();
            for (int i = 0; i < c; i++)
            {
                listBox1.Items.Add(arraycons[i].Name);
            }
        }
        private void activarbotones(bool s)
        {
            txtNombre.Enabled = s;
            txtDireccion.Enabled = s;
            txtCuit.Enabled = s;
            txtNumero.Enabled = s;
            txtBarrio.Enabled = s;
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
            txtNombre.Text = "";
            txtNumero.Text = "";
            txtDireccion.Text = "";
            txtCuit.Text = "";
            txtBarrio.Text = "";
            cmbConsorcio.SelectedIndex = -1;
        }
    }


    
}
