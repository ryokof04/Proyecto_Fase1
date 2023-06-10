using Proyecto_Fase1.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Fase1.hash
{
    internal class ListaClaves
    {
        private Producto primero = null;
        private int totnodos = 0;

        public ListaClaves()
        {
            // Constructor vacío
        }

        public int TotNodos
        {
            get => totnodos;
        }

        public string[] ListaCodigos()
        {
            if (totnodos == 0) return new string[0];

            string[] ids = new string[totnodos];
            Producto aux;
            int i = 0;
            aux = primero;
            while (aux != null)
            {
                ids[i] = aux.Id_producto;
                i++;
                aux = aux.sig;
            }
            return ids;
        }

        public Producto[] ListaProductos()
        {
            if (totnodos == 0) return new Producto[0];

            Producto[] ids = new Producto[totnodos];
            Producto aux;
            int i = 0;
            aux = primero;
            while (aux != null)
            {
                ids[i] = aux;
                i++;
                aux = aux.sig;
            }
            return ids;
        }

        public string getNextId()
        {
            int listaCodigos = ListaCodigos().Length + 1;
            return string.Format("P{0}", listaCodigos.ToString().PadLeft(3, '0'));
        }

        public void InsertarProductos(Producto producto)
        {
            Producto aux;
            producto.CopiarEn(out aux);
            //inserta nodo al inicio del contenido de lista
            if (totnodos == 0)
                primero = aux;
            else
            {
                aux.sig = primero;
                primero = aux;
            }
            totnodos++; //incrementa conteo de nodos
        }

        public Producto RetornarProducto(string Clave)
        {
            // ubica a nodo que coincide con Clave/Key (Num. Placa de automovil)
            // si lo encuentra, retorna una copia del mismo.
            Producto aux;
            Producto encontrado;
            if (totnodos > 0)
            {
                aux = primero;
                //inicia busqueda de nodo cuyo num. placa del automovil
                //coincida con la Clave usada por la tabla de dispersion
                while (aux != null)
                {
                    if (aux.Id_producto == Clave) // coincide nodo
                    {
                        // hace copia de campos de nodo hacia a nodo a retornar (encontrado)
                        aux.CopiarEn(out encontrado);
                        //finaliza funcion, retornando nodo solicitado
                        return (encontrado);
                    }
                    aux = aux.sig; // mueve puntero a siguiente nodo de la lista.
                }
            }
            return null; // nodo solicitado no existe en la lista
        }

        public int BuscarProducto(string Clave)
        {
            int c = 0;
            Producto aux;
            if (totnodos > 0)
            {
                aux = primero;

                //recorre todo el contenido de la lista
                while (aux != null)
                {
                    if (aux.Id_producto == Clave)
                        return c; // retorna indice de posicion de nodo coincidente
                    c++; //actualiza conteo de indice de posicion
                    aux = aux.sig;
                }
            }
            return 0; //no encontro nodo coincidente con parametro recibido
        }

        public bool RemoverProducto(int indicenodo)
        {
            //borra nodo ubicado en posicion recibida en parametro
            Producto aux = primero, aux2;
            if (totnodos > 0 && indicenodo <= totnodos)
            {
                if (indicenodo == 1) //primero
                    primero = primero.sig;
                else
                {
                    // ubica puntero auxiliar en nodo anterior al eliminar
                    for (int c = 1; c < indicenodo - 1; c++) aux = aux.sig;

                    aux2 = aux.sig; //ubica nodo a borrar
                    if (aux2 != null) aux.sig = aux2.sig;
                    aux2 = null; //borra todo
                }
                totnodos--;
                return true; // fue eliminado de la lista

            }
            return false; //nodo en posicion no existe en lista
        }

        public void ActualizarProducto(string clave, Producto nuevoProducto)
        {
            Producto aux = primero;

            while (aux != null)
            {
                if (aux.Id_producto == clave)
                {
                    aux.Nombre = nuevoProducto.Nombre;
                    aux.Valor = nuevoProducto.Valor;
                    aux.ValorRescate = nuevoProducto.ValorRescate;
                    aux.Vida = nuevoProducto.Vida;
                    aux.Descripcion = nuevoProducto.Descripcion;
                    aux.Existencia = nuevoProducto.Existencia;
                }

                aux = aux.sig;
            }
        }
    }
}

