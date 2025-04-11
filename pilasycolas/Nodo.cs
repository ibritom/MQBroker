using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilasycolas
{
    internal class Nodo<Tipo>
    {
        internal Tipo valor { get; set; }
        internal Nodo<Tipo> siguiente { get; set; }
        internal Nodo<Tipo> anterior { get; set; }

        public Nodo(Tipo valor)
        {
            this.valor = valor;
            this.siguiente = null;
            this.anterior = null;
        }
    }
}
