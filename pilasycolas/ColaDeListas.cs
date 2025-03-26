using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilasycolas
{
    public class ColaDeListas : Cola
    {
        private Nodo delante;
        private Nodo detras;

        public ColaDeListas()
        {
            delante = null;
            detras = null;
        }

        public void AnadirACola(int element)
        {
            Nodo nuevoNodo = new Nodo(element);
            if (detras == null)
            {
                delante = nuevoNodo;
                detras = nuevoNodo;
            }
            else
            {
                detras.siguiente = nuevoNodo;
                detras = nuevoNodo;
            }
        }

        public int QuitarDeCola()
        {
            if (delante == null)
            {
                Console.WriteLine("Cola desfasada");
                return -1;
            }
            else
            {
                int element = delante.valor;
                delante = delante.siguiente;
                if (delante == null)
                {
                    detras = null;
                }
                return element;
            }
        }

        public int Delante()
        {
            if (delante == null)
            {
                Console.WriteLine("Cola desfasada");
                return -1;
            }
            else
            {
                return delante.valor;
            }
        }

        public override string ToString()
        {
            StringBuilder resultado = new StringBuilder("[");
            Nodo actual = delante;

            while (actual != null)
            {
                resultado.Append(actual.valor);
                if (actual.siguiente != null)
                {
                    resultado.Append(", ");
                }
                actual = actual.siguiente;
            }

            resultado.Append("]");
            return resultado.ToString();
        }
    }

}
