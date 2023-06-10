using MySql.Data.MySqlClient;
using Proyecto_Fase1.clases;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Fase1.db
{
    class DBConexion
    {
        private string ConnectionString = "Data Source=localhost;Initial Catalog=informacion;uid=root;password=;Integrated Security=True";
        private MySqlConnection connection;

        public DBConexion()
        {
            connection = new MySqlConnection(ConnectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Closed) connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string NextProjectId()
        {
            string nuevoIdProducto = "P";
            try
            {
                OpenConnection();

                string query = "SELECT MAX(SUBSTRING(id_producto, 2)) FROM descripcion_producto";
                int ultimoNumeroSecuencial;

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

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

                    nuevoIdProducto += ultimoNumeroSecuencial.ToString("D3");
                }
            } catch (Exception ex)
            {
                throw ex;
            } finally
            {
                CloseConnection();
            }

            return nuevoIdProducto;
        }

        public bool InsertarProducto(Producto producto)
        {
            int res = -1;
            string query = "INSERT INTO descripcion_producto (nombre_producto, descripcion_producto, id_producto, existencia_producto, valor_producto, valor_rescate, vida_util) VALUES (@valor1, @valor2, @valor3, @valor4, @valor5, @valor6, @valor7)";
            try
            {
                OpenConnection();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Asignar valores a los parámetros
                    command.Parameters.AddWithValue("@valor1", producto.Nombre);
                    command.Parameters.AddWithValue("@valor2", producto.Descripcion);
                    command.Parameters.AddWithValue("@valor3", producto.Id_producto);
                    command.Parameters.AddWithValue("@valor4", producto.Existencia);
                    command.Parameters.AddWithValue("@valor5", producto.Valor);
                    command.Parameters.AddWithValue("@valor6", producto.ValorRescate);
                    command.Parameters.AddWithValue("@valor7", producto.Vida);

                    // Ejecutar el comando
                    res = command.ExecuteNonQuery();
                }
            } catch (Exception ex)
            {
                throw ex;
            } finally
            {
                CloseConnection();
            }

            return res > 0;
         }

        public DataTable FillTable()
        {
            string query = "SELECT * FROM descripcion_producto";
            DataTable dataTable = new DataTable();

            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
                }
            } catch (Exception ex)
            {
                throw ex;
            } finally
            {
                CloseConnection();
            }

            return dataTable;
        }
        public DataTable FillTable2()
        {
            string query = "SELECT nombre_producto, existencia_product, valor_producto FROM descripcion_producto";
            DataTable dataTable = new DataTable();

            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
 
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return dataTable;
        }

        async public Task<Producto[]> GetProductos()
        {
            string query = "SELECT * FROM descripcion_producto";
            List<Producto> productos = new List<Producto>();

            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();

                        producto.Id_producto = reader.GetString("id_producto");
                        producto.Nombre = reader.GetString("nombre_producto");
                        producto.Descripcion = reader.GetString("descripcion_producto");
                        producto.Existencia = reader.GetInt32("existencia_producto");
                        producto.Valor = reader.GetDouble("valor_producto");
                        producto.ValorRescate = reader.GetDouble("valor_rescate");
                        producto.Vida = reader.GetInt32("vida_util");

                        productos.Add(producto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return productos.ToArray();
        }

        public bool EliminarProducto(string idProducto)
        {
            int res = -1;
            string query = "DELETE FROM descripcion_producto WHERE id_producto = @valor1";

            try
            {
                OpenConnection();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@valor1", idProducto);

                    res = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return res > 0;
        }

        public bool ActualizarProducto(Producto producto)
        {
            int res = -1;
            string query = "UPDATE descripcion_producto SET nombre_producto = @valor1, descripcion_producto = @valor2, existencia_producto = @valor3, valor_producto = @valor4, valor_rescate = @valor5, vida_util = @valor6 WHERE id_producto = @valor7";

            try
            {
                OpenConnection();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@valor1", producto.Nombre);
                    command.Parameters.AddWithValue("@valor2", producto.Descripcion);
                    command.Parameters.AddWithValue("@valor3", producto.Existencia);
                    command.Parameters.AddWithValue("@valor4", producto.Valor);
                    command.Parameters.AddWithValue("@valor5", producto.ValorRescate);
                    command.Parameters.AddWithValue("@valor6", producto.Vida);
                    command.Parameters.AddWithValue("@valor7", producto.Id_producto);

                    res = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return res > 0;
        }
    }
}
