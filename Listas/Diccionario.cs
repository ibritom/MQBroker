using System;
using System.Collections.Generic;

namespace Listas
{
    public class Diccionario<TKey, TValue>
    {
        private ListaDobleEnlazada<ParejaDeNodos<TKey, TValue>> elementos;

        public Diccionario()
        {
            elementos = new ListaDobleEnlazada<ParejaDeNodos<TKey, TValue>>();
        }

        public void Anadir(TKey clave, TValue valor)
        {
            if (Contiene(clave))
            {
                throw new ArgumentException("La clave ya existe en el diccionario.");
            }
            elementos.Anadir(new ParejaDeNodos<TKey, TValue>(clave, valor));
        }

        public TValue Obtener(TKey clave)
        {
            Nodo<ParejaDeNodos<TKey, TValue>> actual = ObtenerCabeza();
            while (actual != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(actual.valor.Clave, clave))
                {
                    return actual.valor.Valor;
                }
                actual = actual.siguiente;
            }
            throw new KeyNotFoundException("La clave no se encuentra en el diccionario.");
        }

        public void Borrar(TKey clave)
        {
            Nodo<ParejaDeNodos<TKey, TValue>> actual = ObtenerCabeza();
            while (actual != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(actual.valor.Clave, clave))
                {
                    elementos.Borrar(actual.valor);
                    return;
                }
                actual = actual.siguiente;
            }
            throw new KeyNotFoundException("La clave no se encuentra en el diccionario.");
        }

        public bool Contiene(TKey clave)
        {
            Nodo<ParejaDeNodos<TKey, TValue>> actual = ObtenerCabeza();
            while (actual != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(actual.valor.Clave, clave))
                {
                    return true;
                }
                actual = actual.siguiente;
            }
            return false;
        }

        public void Vaciar()
        {
            elementos.Vaciar();
        }

        public bool RevisarVacio()
        {
            return elementos.RevisarVacio();
        }

        public int Tamano()
        {
            return elementos.Tamano();
        }

        public override string ToString()
        {
            return elementos.ToString();
        }

        // Ayudante interno para acceder al nodo cabeza de la lista
        private Nodo<ParejaDeNodos<TKey, TValue>> ObtenerCabeza()
        {
            var tipoLista = elementos.GetType();
            var campoCabeza = tipoLista.GetField("cabeza", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return campoCabeza.GetValue(elementos) as Nodo<ParejaDeNodos<TKey, TValue>>;
        }
    }
}
