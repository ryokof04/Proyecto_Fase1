using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;


namespace Proyecto_Fase1
{
    public class Conexion
    {
        

        public void Conectar()
        {
            string connectionString = "server=(localdb)\\mssqllocaldb;database=informacion;uid=roo;password=;port=3304";
            string sqlQuery = "SELECT * FROM tabla";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlQuery, connection);
                connection.Open();
                MessageBox.Show("conexion exitosa");
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Accede a los datos y muestra la información en la ventana
                        string columna1 = reader.GetString(0);
                        string columna2 = reader.GetString(1);
                        MessageBox.Show(columna1);
                        MessageBox.Show(columna2);

                        // Agrega el código para mostrar los datos en la ventana según tus necesidades
                    }
                }
            }
        }

    }

}
