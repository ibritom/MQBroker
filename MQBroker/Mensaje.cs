using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker
{
    internal class Mensaje
    {
        public string tema { get; set; }
        public string contenido { get; set; }
        public Mensaje(string tema, string contendio)
        {
            tema = tema;
            contenido = contenido;

        }
    }
}
