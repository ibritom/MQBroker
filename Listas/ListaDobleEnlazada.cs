using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Listas
{
    public class ListaDobleEnlazada<Tipo> : Lista<Tipo>, IEnumerable<Tipo>
    {
        private Nodo<Tipo> cabeza;
        private int tamano;

        public ListaDobleEnlazada()
        {
            this.cabeza = null;
            this.tamano = 0;
        }

        public void Vaciar()
        {
            this.cabeza = null;
            this.tamano = 0;
        }

        public bool RevisarVacio()
        {
            return this.tamano == 0;
        }

        public int Tamano()
        {
            return this.tamano;
        }

        public bool Contiene(Tipo elemento)
        {
            Nodo<Tipo> actual = this.cabeza;
            while (actual != null)
            {
                if (EqualityComparer<Tipo>.Default.Equals(actual.valor, elemento))
                {
                    return true;
                }
                actual = actual.siguiente;
            }
            return false;
        }

        public bool Anadir(Tipo elemento)
        {
            Nodo<Tipo> nuevoNodo = new Nodo<Tipo>(elemento);
            if (this.cabeza == null)
            {
                this.cabeza = nuevoNodo;
            }
            else
            {
                Nodo<Tipo> actual = this.cabeza;
                while (actual.siguiente != null)
                {
                    actual = actual.siguiente;
                }
                actual.siguiente = nuevoNodo;
                nuevoNodo.anterior = actual;
            }
            this.tamano++;
            return true;
        }

        public Tipo Borrar(Tipo elemento)
        {
            if (this.cabeza == null)
            {
                throw new KeyNotFoundException();
            }

            if (EqualityComparer<Tipo>.Default.Equals(this.cabeza.valor, elemento))
            {
                Tipo valorBorrado = this.cabeza.valor;
                this.cabeza = this.cabeza.siguiente;
                if (this.cabeza != null)
                {
                    this.cabeza.anterior = null;
                }
                this.tamano--;
                return valorBorrado;
            }

            Nodo<Tipo> actual = this.cabeza;
            while (actual.siguiente != null)
            {
                if (EqualityComparer<Tipo>.Default.Equals(actual.siguiente.valor, elemento))
                {
                    Tipo valorBorrado = actual.siguiente.valor;
                    actual.siguiente = actual.siguiente.siguiente;
                    if (actual.siguiente != null)
                    {
                        actual.siguiente.anterior = actual;
                    }
                    this.tamano--;
                    return valorBorrado;
                }
                actual = actual.siguiente;
            }

            throw new KeyNotFoundException();
        }
        public IEnumerator<Tipo> GetEnumerator()
        {
            Nodo<Tipo> actual = cabeza;
            while (actual != null)
            {
                yield return actual.valor;
                actual = actual.siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return ToString_aux();
        }

        private string ToString_aux()
        {
            Nodo<Tipo> actual = this.cabeza;
            List<string> elementos = new List<string>();

            while (actual != null)
            {
                elementos.Add(actual.valor?.ToString());
                actual = actual.siguiente;
            }

            return "[" + string.Join(", ", elementos) + "]";
        }
    }
}
