using MySql.Data.MySqlClient;
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
        public Contabilidad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string connectionString = "Data Source=localhost;Initial Catalog=informacion;uid=root;password=;Integrated Security=True";
            

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                   
                   

                    string query3 = "SELECT MAX(SUBSTRING(id_producto, 2)) FROM descripcion_producto";
                    int ultimoNumeroSecuencial;

  //                  using (MySqlConnection connection = new MySqlConnection(connectionString))
                    using (MySqlCommand command = new MySqlCommand(query3, connection))
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            ultimoNumeroSecuencial = Convert.ToInt32(result);
                        }
                        else
                        {
                            ultimoNumeroSecuencial = 0;
                        }
                        ultimoNumeroSecuencial++;

                        string nuevoIdProducto = "P" + ultimoNumeroSecuencial.ToString("D3");
                        connection.Close();
                        txtID.Text = nuevoIdProducto;
                    }
                    connection.Open();

                    string query = "INSERT INTO descripcion_producto (nombre_producto, descripcion_producto, id_producto, existencia_producto, valor_producto, depreciacion_producto) VALUES (@valor1, @valor2, @valor3, @valor4, @valor5, @valor6)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        string nombre = txtNombre.Text;
                        string desc =   txtDesc.Text;
                        string id = txtID.Text;
                        string existencia = txtExistencia.Text;
                        string valor = txtValor.Text;
                        string depreciacion = txtDepreciacion.Text;

                        // Asignar valores a los parámetros
                        command.Parameters.AddWithValue("@valor1", nombre);
                        command.Parameters.AddWithValue("@valor2", desc);
                        command.Parameters.AddWithValue("@valor3", id);
                        command.Parameters.AddWithValue("@valor4", existencia);
                        command.Parameters.AddWithValue("@valor5", valor);
                        command.Parameters.AddWithValue("@valor6", depreciacion);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Producto Agregado Exitosamente");
                        string query2 = "SELECT * FROM descripcion_producto";
                        DataTable dataTable = new DataTable();
                        MySqlCommand command2 = new MySqlCommand(query2, connection);
                        connection.Open();
                        
                        using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command2))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                        dataGridView1.DataSource = dataTable;
                        connection.Close();
                        
                        txtNombre.Text = string.Empty;
                        txtDesc.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                        txtDesc.Text = string.Empty;
                        txtID.Text = string.Empty;
                        txtExistencia.Text = string.Empty;
                        txtValor.Text = string.Empty;
                        txtDepreciacion.Text = string.Empty;

                        string query4 = "SELECT MAX(SUBSTRING(id_producto, 2)) FROM descripcion_producto";

                        using (MySqlCommand command3 = new MySqlCommand(query4, connection))
                            
                        

                        using (MySqlConnection connection2 = new MySqlConnection(connectionString))
  //                     using (MySqlCommand command3 = new MySqlCommand(query4, connection))
                        {
                            connection.Open();
                            int ultimoNumeroSecuencial2;
                            object result = command3.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                ultimoNumeroSecuencial2 = Convert.ToInt32(result);
                            }
                            else
                            {
                                ultimoNumeroSecuencial2 = 0;
                            }
                            ultimoNumeroSecuencial2++;

                            string nuevoIdProducto = "P" + ultimoNumeroSecuencial2.ToString("D3");
                            connection.Close();
                            txtID.Text = nuevoIdProducto;

                        }

                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la conexión o las operaciones en la base de datos
                    Console.WriteLine("Error: " + ex.Message);
                }
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
            // ...

            // Crear una DataTable para almacenar los datos
            DataTable dataTable = new DataTable();

            // Cadena de conexión para conectar a la instancia local de SQL Server
            string connectionString = "Data Source=localhost;Initial Catalog=informacion;uid=root;password=;Integrated Security=True";
            
            // Consulta SQL para obtener los datos
            string query = "SELECT * FROM descripcion_producto";
            
            // Crear la conexión y el comando SQL
  //          using (MySqlConnection connection = new MySqlConnection(connectionString))
  //          using (MySqlCommand command = new MySqlCommand(query, connection);
            {
                // Abrir la conexión
                

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    connection.Open();
                    //MessageBox.Show("conexion exitosa");
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
                // Crear un DataAdapter para llenar el DataTable
                ;

                // Llenar el DataTable con los datos obtenidos
                
            }
            // Asignar el DataTable como origen de datos del DataGridView
            dataGridView1.DataSource = dataTable;
            string query3 = "SELECT MAX(SUBSTRING(id_producto, 2)) FROM descripcion_producto";
            int ultimoNumeroSecuencial;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query3, connection))
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    ultimoNumeroSecuencial = Convert.ToInt32(result);
                }
                else
                {
                    ultimoNumeroSecuencial = 0;
                }
                ultimoNumeroSecuencial++;

                string nuevoIdProducto = "P" + ultimoNumeroSecuencial.ToString("D3");
                connection.Close();
                txtID.Text = nuevoIdProducto;

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
            reportes reportes = new reportes();
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
