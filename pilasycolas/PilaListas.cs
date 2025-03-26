using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilasycolas
{
    public class PilaListas : Pila
    {
        public PilaListas()
        {
            cima = null;
        }
        private Nodo cima;
        public void Push(int elemento)
        {
            Nodo nuevoNodo = new Nodo(elemento);
            nuevoNodo.siguiente = cima;
            cima = nuevoNodo;
        }
        public int Pop()
        {
            if (cima == null)
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            } else {
                int elemento = cima.valor;
                cima = cima.siguiente;
                return elemento;
            }
        }
        public int Top()
        {
            if (cima == null) {
                Console.WriteLine("Stack Underflow");
                return -1;
            } else {
                return cima.valor;
            }
        }
        public override string ToString()
        {
            if (cima == null)
                return "Pila vacía"; // Si la pila está vacía, devolvemos un mensaje adecuado.

            StringBuilder sb = new StringBuilder();
            Nodo actual = cima;

            // Recorremos la pila y agregamos cada elemento al StringBuilder
            while (actual != null)
            {
                sb.Append(actual.valor);
                if (actual.siguiente != null)
                    sb.Append(", "); // Agregamos una coma si hay más elementos en la pila.
                actual = actual.siguiente;
            }

            return sb.ToString();
        }
    }
}
