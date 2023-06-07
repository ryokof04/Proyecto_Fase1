using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Fase1.clases
{
    class Producto
    {
        private string _nombre;
        private string _descripcion;
        private string _id_producto;
        private int _existencia;
        private int _valor;
        private int _depreciacion;

        public Producto sig = null;

        public void CopiarEn(out Producto copiaconta)
        {
            // realiza una copia de valores actuales de sus campos
            // hacia una nueva instancia
            copiaconta = new Producto();

            copiaconta.Depreciacion = this.Depreciacion;
            copiaconta.Descripcion = this.Descripcion;
            copiaconta.Existencia = this.Existencia;
            copiaconta.Valor = this.Valor;
            copiaconta.Nombre = this.Nombre;
        }


        public Producto()
        {
        }

        public Producto(string nombre, string descripcion, string id_producto, int existencia, int valor, int depreciacion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Id_producto = id_producto;
            Existencia = existencia;
            Valor = valor;
            Depreciacion = depreciacion;
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Id_producto { get => _id_producto; set => _id_producto = value; }
        public int Existencia { get => _existencia; set => _existencia = value; }
        public int Valor { get => _valor; set => _valor = value; }
        public int Depreciacion { get => _depreciacion; set => _depreciacion = value; }
    }
}