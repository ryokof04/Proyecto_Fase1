using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Fase1
{
    public partial class reportes : Form
    {
        public reportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contabilidad Contabilidad = new Contabilidad();
            Contabilidad.ShowDialog();
        }
    }
}
