﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    public interface Lista
    {
        public void Vaciar();
        public bool RevisarVacio();

        public int Tamano();
        public bool Contiene(int elemento);
        public bool Anadir(int elemento);
        public int Borrar(int elemento);

    }
}
