using MySql.Data.MySqlClient;
using Proyecto_Fase1.db;
using Proyecto_Fase1.clases;
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

        public Contabilidad()
        {
            InitializeComponent();
            DBConexion = new DBConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = DBConexion.NextProjectId();

                string nombre = txtNombre.Text;
                string desc = txtDesc.Text;
                string id = txtID.Text;
                string existencia = txtExistencia.Text;
                string valor = txtValor.Text;
                string depreciacion = txtDepreciacion.Text;

                Producto producto = new Producto(nombre, desc, id, existencia, valor, depreciacion);

                bool res = DBConexion.InsertarProducto(producto);

                if (res)
                {
                    MessageBox.Show("Producto Agregado Exitosamente");
                }

                dataGridView1.DataSource = DBConexion.FillTable();

                txtNombre.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtID.Text = string.Empty;
                txtExistencia.Text = string.Empty;
                txtValor.Text = string.Empty;
                txtDepreciacion.Text = string.Empty;

                txtID.Text = DBConexion.NextProjectId();
            } catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la conexión o las operaciones en la base de datos
                Console.WriteLine("Error: " + ex.Message);
            }
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
            // Asignar el DataTable como origen de datos del DataGridView
            try
            {
                dataGridView1.DataSource = DBConexion.FillTable();
                txtID.Text = DBConexion.NextProjectId();
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
                               !string.IsNullOrEmpty(txtDepreciacion.Text);

            // Habilitar o deshabilitar el botón según si todas las TextBox están llenas
            button1.Enabled = todasLlenas;
        }
    }
}
