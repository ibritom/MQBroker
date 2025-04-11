using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    internal class Diccionario<Tipo1, Tipo2>: Lista<ParejaDeNodos<Tipo1, Tipo2>>
    {
        private ParejaDeNodos<Tipo1, Tipo2> parejaDeValores { get; set; }

        private int tamano;

        public Diccionario()
        {
            this.parejaDeValores = null;
            this.tamano = 0;
        }
        public void Anadir(ParejaDeNodos<Tipo1, Tipo2> parejaDeValores)
        {
            if (this.parejaDeValores == null)
            {
                this.parejaDeValores = parejaDeValores;
                this.tamano++;
                return;
            }
            Nodo<Tipo1> nuevoNombre = new Nodo<Tipo1>(parejaDeValores.Nombre);
            Nodo<Tipo2> nuevoValor = new Nodo<Tipo2>(parejaDeValores.Valor);
            nuevoNombre.siguiente = this.parejaDeValores;
            this.parejaDeValores.anterior = nuevoNombre;
            this.parejaDeValores = nuevoNombre;
            this.tamano++;
        }
        public Tipo2 Obtener(Tipo1 nombre)
        {
            Nodo<Tipo1> actual = this.parejaDeValores;
            while (actual != null)
            {
                if (actual.valor.Equals(nombre))
                {
                    return this.Valor.valor;
                }
                actual = actual.siguiente;
            }
            throw new KeyNotFoundException("El nombre no se encuentra en el diccionario.");
        }
        public void Borrar(Tipo1 nombre)
        {
            Nodo<Tipo1> actual = this.parejaDeValores;
            while (actual != null)
            {
                if (actual.valor.Equals(nombre))
                {
                    if (actual.anterior != null)
                    {
                        actual.anterior.siguiente = actual.siguiente;
                    }
                    if (actual.siguiente != null)
                    {
                        actual.siguiente.anterior = actual.anterior;
                    }
                    this.tamano--;
                    return;
                }
                actual = actual.siguiente;
            }
            throw new KeyNotFoundException("El nombre no se encuentra en el diccionario.");
        }
        public bool Contiene(Tipo1 nombre)
        {
            Nodo<Tipo1> actual = this.parejaDeValores;
            while (actual != null)
            {
                if (actual.valor.Equals(nombre))
                {
                    return true;
                }
                actual = actual.siguiente;
            }
            return false;
        }
        public void Vaciar()
        {
            this.parejaDeValores = null;
            this.Valor = null;
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
        public int Borrar(ParejaDeNodos<Tipo1, Tipo2> elemento)
        {
            Nodo<Tipo1> actual = this.parejaDeValores;
            while (actual != null)
            {
                if (actual.valor.Equals(elemento.Nombre))
                {
                    if (actual.anterior != null)
                    {
                        actual.anterior.siguiente = actual.siguiente;
                    }
                    if (actual.siguiente != null)
                    {
                        actual.siguiente.anterior = actual.anterior;
                    }
                    this.tamano--;
                    return 1;
                }
                actual = actual.siguiente;
            }
            throw new KeyNotFoundException("El nombre no se encuentra en el diccionario.");
        }
    }
}
