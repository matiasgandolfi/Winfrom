using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbCasado.Items.Add(true);
            cmbCasado.Items.Add(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            ListaConexion conexion = new ListaConexion();
            dtvDatos.DataSource = conexion.listarEmpleados();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ListaConexion conexion = new ListaConexion();
            ListaEmpleados a = new ListaEmpleados();
            a.NombreViejo = txtNomCambio.Text; 
            a.NombreCompleto = txtNombre.Text;
            a.DNI = txtDNI.Text;
            a.Edad = int.Parse(txtEdad.Text);
            a.Casado = cmbCasado.Created;
            a.Salario = decimal.Parse(txtSalario.Text);
            //a.Fecha = dtpFecha.Value;



            conexion.agregar(a);
            MessageBox.Show("Agregado exitosamente");
            cargar();

            txtNombre.Text = "";
            txtEdad.Text = "";
            txtDNI.Text = "";
            txtSalario.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ListaConexion conexion = new ListaConexion();
            ListaEmpleados a = new ListaEmpleados();
            a.NombreViejo = txtNomCambio.Text;
            a.NombreCompleto = txtNombre.Text;
            a.DNI = txtDNI.Text;
            a.Edad = int.Parse(txtEdad.Text);
            a.Casado = cmbCasado.Created;
            a.Salario = decimal.Parse(txtSalario.Text);

            conexion.update(a);
            MessageBox.Show("Editado exitosamente");
            cargar();

            txtNomCambio.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtDNI.Text = "";
            txtSalario.Text = "";

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            ListaConexion conexion = new ListaConexion();
            ListaEmpleados a = new ListaEmpleados();
            a.NombreViejo = txtNomCambio.Text;

            conexion.delete(a);
            MessageBox.Show("Editado exitosamente");
            cargar();

            txtNomCambio.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtDNI.Text = "";
            txtSalario.Text = "";
        }

        private void dtvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string nombre = this.dtvDatos.SelectedRows[0].Cells[0].Value.ToString();
                txtNomCambio.Text = nombre;

            }
            catch
            {
                return;
            }
            
        }
    }
}
