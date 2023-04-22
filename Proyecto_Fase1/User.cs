using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Proyecto_Fase1
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal Principal = new Principal();
            Principal.ShowDialog();

        }
        private void registrarbtn_Click(object sender, EventArgs e)
        {
            if (newpassword.Text == newpassword.Text) CuentasRepetidas();
            else
            {
                MessageBox.Show("Las contraseñas no coinciden, vuelve a intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CuentasRepetidas()
        {
            string userReg = newuser.Text;  
            StreamReader leer;
            leer = File.OpenText("usuarios2.txt");
            string cadena;
            string[] arreglos = new string[1]; // Crea arreglos (secciones)
            char[] separador = { '-' }; // Crea el separador entre user y password
            bool repetido = false;
            cadena = leer.ReadLine();
            while (cadena != null && repetido == false)
            {
                arreglos = cadena.Split(separador);
                if (arreglos[0].Trim().Equals(userReg))
                {
                    MessageBox.Show("Este usuario ya ha sido registrado. Ingrese uno nuevo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    leer.Close();
                    repetido = true;
                }
                else
                {
                    cadena = leer.ReadLine();
                }
            }
            if (repetido == false)
            {
                leer.Close();
                RegistroCuenta();
            }
        }
        public void RegistroCuenta()
        {
            string userReg = newuser.Text;
            string passReg = newpassword.Text;
            StreamWriter registrar = new StreamWriter("usuarios2.txt", true);
            registrar.WriteLine(userReg + "-" + passReg + "\n");
            registrar.Close();
            MessageBox.Show("El usuario se ha registrado correctamente. Inicie sesión para continuar.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (newpassword.Text == textBox1.Text) CuentasRepetidas();
            else
            {
                MessageBox.Show("Las contraseñas no coinciden, vuelve a intentarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
