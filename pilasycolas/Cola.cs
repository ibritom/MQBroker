using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilasycolas
{
    public interface Cola
    {
        void AnadirACola(int elemento);
        int QuitarDeCola();
        int Delante();

    }
}
