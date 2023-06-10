using MySql.Data.MySqlClient;
using Proyecto_Fase1.db;
using Proyecto_Fase1.clases;
using Proyecto_Fase1.hash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Fase1
{
    public partial class Contabilidad : Form 
    {
        public Conexion connect;
        DBConexion DBConexion;
        ListaClaves ListaClaves;
        Producto producto;

        public Contabilidad()
        {
            InitializeComponent();
            DBConexion = new DBConexion();
            ListaClaves = new ListaClaves();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // txtID.Text = DBConexion.NextProjectId();

                string nombre = txtNombre.Text;
                string desc = txtDesc.Text;
                string id = txtID.Text;
                string existencia = txtExistencia.Text;
                string valor = txtValor.Text;
                string depreciacion = txtDepreciacion.Text;
                string vida = txtVida.Text;

                producto = new Producto(nombre, desc, id, existencia, valor, depreciacion, vida);
                if (ListaClaves.RetornarProducto(id) == null)
                {

                    ListaClaves.InsertarProductos(producto);
                } else
                {
                    ListaClaves.ActualizarProducto(id, producto);
                }

                //bool res = DBConexion.InsertarProducto(producto);
                MessageBox.Show("Producto guardado exitosamente");
                CleanForm();
            } catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la conexión o las operaciones en la base de datos
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void CleanForm()
        {

            // dataGridView1.DataSource = DBConexion.FillTable();

            txtNombre.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtID.Text = string.Empty;
            txtExistencia.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtDepreciacion.Text = string.Empty;
            txtVida.Text = string.Empty;

            // txtID.Text = DBConexion.NextProjectId();
            txtID.Text = ListaClaves.getNextId();
            dataGridView1.DataSource = ListaClaves.ListaProductos();
        }

        private void Contabilidad_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            txtID.ReadOnly = true;
            txtNombre.TextChanged += txtNombre_TextChanged;
            txtDesc.TextChanged += txtNombre_TextChanged;
            txtExistencia.TextChanged += txtNombre_TextChanged;
            txtValor.TextChanged += txtNombre_TextChanged;
            txtDepreciacion.TextChanged += txtNombre_TextChanged;
            txtVida.TextChanged += txtNombre_TextChanged;
            // CARGAR ID
            txtID.Text = ListaClaves.getNextId();
            // Asignar el DataTable como origen de datos del DataGridView
            try
            {
                // dataGridView1.DataSource = DBConexion.FillTable();
                dataGridView1.DataSource = ListaClaves.ListaProductos();
                // txtID.Text = DBConexion.NextProjectId();
            } catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal Principal = new Principal();
            Principal.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reportes reportes = new Reportes();
            reportes.ShowDialog();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            // Verificar si todas las TextBox están llenas
            bool todasLlenas = !string.IsNullOrEmpty(txtNombre.Text) &&
                               !string.IsNullOrEmpty(txtDesc.Text) &&
                               !string.IsNullOrEmpty(txtExistencia.Text) &&
                               !string.IsNullOrEmpty(txtValor.Text) &&
                               !string.IsNullOrEmpty(txtVida.Text) &&
                               !string.IsNullOrEmpty(txtDepreciacion.Text);

            // Habilitar o deshabilitar el botón según si todas las TextBox están llenas
            button1.Enabled = todasLlenas;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the clicked DataGridViewRow
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Access the data in the clicked row
                // You can access the data using the index of the column or the column name
                string cellValue = row.Cells["Id_Producto"].Value.ToString();
                // Alternatively, you can use the column index:
                // string cellValue = row.Cells[columnIndex].Value.ToString();

                producto = ListaClaves.RetornarProducto(cellValue);

                txtNombre.Text = producto.Nombre;
                txtDesc.Text = producto.Descripcion;
                txtExistencia.Text = producto.Existencia.ToString();
                txtValor.Text = producto.Valor.ToString();
                txtDepreciacion.Text = producto.ValorRescate.ToString();
                txtVida.Text = producto.Vida.ToString();
                txtID.Text = producto.Id_producto;
            }
        }

        private void txtEliminar_Click(object sender, EventArgs e)
        {
            int indice = ListaClaves.BuscarProducto(txtID.Text);
            ListaClaves.RemoverProducto(indice);
            MessageBox.Show("Producto eliminado exitosamente");

            CleanForm();
        }
    }
}
