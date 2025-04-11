using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Listas;  // Asegúrate de tener la definición correcta de Lista<T>
using pilasycolas;  // Asegúrate de tener la definición correcta de Cola<T>

namespace Broker
{
    internal class Tema
    {
        public string Nombre { get; private set; }

        private Lista<string> listaSuscriptores;
        private Cola<Mensaje> colaMensajes;

        public Tema(string nombre)
        {
            Nombre = nombre;
            listaSuscriptores = new ListaDobleEnlazada<string>();
            colaMensajes = new ColaDeListas<Mensaje>();
        }

        public void AnadirSub(string clientId)
        {
            if (!listaSuscriptores.Contiene(clientId))
            {
                listaSuscriptores.Anadir(clientId);
            }
        }

        public void QuitarSub(string clientId)
        {
            if (listaSuscriptores.Contiene(clientId))
            {
                listaSuscriptores.Borrar(clientId);
            }
        }

        public Lista<string> GetSub()
        {
            return listaSuscriptores;
        }

        public void ColarMensaje(Mensaje mensaje)
        {
            if (mensaje != null)
            {
                colaMensajes.AnadirACola(mensaje);
            }
        }

        public Mensaje DecolarMensaje()
        {
            if (colaMensajes.Tamano() > 0)
            {
                return colaMensajes.QuitarDeCola();
            }
            return null;
        }
    }
}
