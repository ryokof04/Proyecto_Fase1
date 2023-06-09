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


namespace Proyecto_Fase1
{
    public partial class Reportes : Form
    {
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
            try
            {
                
                DBConexion dBConexion = new DBConexion();
                
                dataGridView1.DataSource = dBConexion.FillTable2();


                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
