using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilasycolas
{
    public interface Cola<Tipo>
    {
        void AnadirACola(Tipo elemento);
        Tipo QuitarDeCola();
        Tipo Frente();
        int Tamano();
    }
}
