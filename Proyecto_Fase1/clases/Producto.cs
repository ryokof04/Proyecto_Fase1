using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Fase1.clases
{
    class Producto
    {
        private string _nombre;
        private string _descripcion;
        private string _id_producto;
        private int _existencia;
        private double _valor;
        private double _valor_rescate;
        private int _vida;

        public Producto sig = null;

        public void CopiarEn(out Producto copiaconta)
        {
            // realiza una copia de valores actuales de sus campos
            // hacia una nueva instancia
            copiaconta = new Producto();

            copiaconta.Nombre = this.Nombre;
            copiaconta.Descripcion = this.Descripcion;
            copiaconta.Id_producto = this.Id_producto;
            copiaconta.Existencia = this.Existencia;
            copiaconta.Valor = this.Valor;
            copiaconta.ValorRescate = this.ValorRescate;
            copiaconta.Vida = this.Vida;
        }


        public Producto()
        {
        }

        public Producto(string nombre, string descripcion, string id_producto, int existencia, double valor, double depreciacion, int vida)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Id_producto = id_producto;
            Existencia = existencia;
            Valor = valor;
            ValorRescate = depreciacion;
            Vida = vida;
        }

        public Producto(string nombre, string descripcion, string id_producto, string existencia, string valor, string depreciacion, string vida)
        {
            int.TryParse(existencia, out int exis);
            double.TryParse(valor, out double val);
            double.TryParse(depreciacion, out double dep);
            int.TryParse(vida, out int vid);

            Nombre = nombre;
            Descripcion = descripcion;
            Id_producto = id_producto;
            Existencia = exis;
            Valor = val;
            ValorRescate = dep;
            Vida = vid;
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Id_producto { get => _id_producto; set => _id_producto = value; }
        public int Existencia { get => _existencia; set => _existencia = value; }
        public double Valor { get => _valor; set => _valor = value; }
        public double ValorRescate { get => _valor_rescate; set => _valor_rescate = value; }

        public int Vida { get => _vida; set => _vida = value; }
    }
}