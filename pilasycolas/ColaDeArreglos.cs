using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace pilasycolas
{
    public class ColaDeArreglo : Cola<int>
    {
        private int[] cola;
        private int delante;
        private int destras;
        private int tamano;

        public void ColaDeArreglos(int tamano)
        {
            this.tamano = tamano;
            cola = new int[tamano];
            delante = -1;
            destras = -1;
        }

        public void AnadirACola(int elemento)
        {
            if (destras == tamano - 1)
            {
                Console.WriteLine("Desbordamiento de la cola");
            }
            else
            {
                if (delante == -1)
                {
                    delante = 0;
                }
                cola[++destras] = elemento;
            }
        }

        public int QuitarDeCola()
        {
            if (delante == -1)
            {
                Console.WriteLine("Desfase de cola");
                return -1;
            }
            else
            {
                int elemento = cola[delante];
                if (delante == destras)
                {
                    delante = -1;
                    destras = -1;
                }
                else
                {
                    delante++;
                }
                return elemento;
            }
        }

        public int Frente()
        {
            if (delante == -1)
            {
                Console.WriteLine("Lista desfasada");
                return -1;
            }
            else
            {
                return cola[delante];
            }
        }
        public int Tamano()
        {
            return tamano;
        }

        public override string ToString()
        {
            if (delante == -1)
            {
                return "[]"; // Cola vacía
            }

            StringBuilder resultado = new StringBuilder("[");
            for (int i = delante; i <= destras; i++)
            {
                resultado.Append(cola[i]);
                if (i < destras)
                {
                    resultado.Append(", ");
                }
            }
            resultado.Append("]");
            return resultado.ToString();
        }
    }

}
