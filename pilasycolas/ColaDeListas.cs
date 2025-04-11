using System;
using System.Text;

namespace pilasycolas
{
    public class ColaDeListas<Tipo> : Cola<Tipo>
    {
        private Nodo<Tipo> delante;
        private Nodo<Tipo> detras;
        private int tamano;

        public ColaDeListas()
        {
            delante = null;
            detras = null;
            tamano = 0;
        }

        public void AnadirACola(Tipo elemento)
        {
            Nodo<Tipo> nuevoNodo = new Nodo<Tipo>(elemento);
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
            tamano++;
        }

        public Tipo QuitarDeCola()
        {
            if (delante == null)
            {
                throw new InvalidOperationException("Cola vacía");
            }
            else
            {
                Tipo elemento = delante.valor;
                delante = delante.siguiente;
                if (delante == null)
                {
                    detras = null;
                }
                tamano--;
                return elemento;
            }
        }

        public Tipo Frente()
        {
            if (delante == null)
            {
                throw new InvalidOperationException("Cola vacía");
            }
            return delante.valor;
        }

        public int Tamano()
        {
            return tamano;
        }

        public override string ToString()
        {
            StringBuilder resultado = new StringBuilder("[");
            Nodo<Tipo> actual = delante;

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
