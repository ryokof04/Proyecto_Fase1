using Proyecto_Fase1.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Fase1.clases;
using MySql;
using MySql.Data.MySqlClient;


namespace Proyecto_Fase1
{
    public partial class Reportes : Form
    {
        private MySqlConnection connection;
        public Reportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contabilidad Contabilidad = new Contabilidad();
            Contabilidad.ShowDialog();
        }

        private void reportes_Load(object sender, EventArgs e)
        {
            //          string query = "SELECT nombre_producto, existencia_producto,valor_producto FROM informacion.descripcion_producto";
            string connectionString = "Data Source=localhost;Initial Catalog=informacion;uid=root;password=;Integrated Security=True";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT nombre_producto, existencia_producto,valor_producto, valor_rescate, vida_util FROM informacion.descripcion_producto";
                // Resto del código...

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Resto del código...
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        dataTable.Columns.Add("Valor Total", typeof(int));
                        dataTable.Columns.Add("Depreciacion por Producto", typeof(int));
                        dataTable.Columns.Add("Depreciacion Total", typeof(int));
                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Obtener los valores de la columna 1 y columna 2
                            int columna1 = Convert.ToInt32(row["existencia_producto"]);
                            int columna2 = Convert.ToInt32(row["valor_producto"]);
                            int columna3 = Convert.ToInt32(row["valor_rescate"]);
                            int columna4 = Convert.ToInt32(row["vida_util"]);

                            // Realizar la multiplicación
                            int resultado = columna1 * columna2;
                            int depreciacion = (columna2 - columna3) / columna4;
                            int depreciaciont = depreciacion * columna1;

                            // Guardar el resultado en la columna 3
                            row["Valor Total"] = resultado;
                            row["Depreciacion por Producto"] = depreciacion;
                            row["Depreciacion Total"] = depreciaciont;
                        }

                        // Resto del código...
                    }
                }

            }


        }
    }
}
