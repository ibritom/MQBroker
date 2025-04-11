using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    public class ParejaDeNodos<Tipo1, Tipo2>
    {
        public Nodo<Tipo1> Nombre { get; set; }
        public  Nodo<Tipo2> Valor { get; set; }

        public ParejaDeNodos(Nodo<Tipo1> nombre, Nodo<Tipo2> valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
        }
    }
}
