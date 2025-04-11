using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Listas;


namespace MQBroker
{
    public class MQBroker
    {
        private TcpListener servidor;
        private ListaDobleEnlazada<ParejaDeNodos<string, Tema>> Temas;

        public MQBroker(string ip, int puerto)
        {
            this.servidor = new TcpListener(IPAddress.Parse(ip), puerto);
            this.temas = new ListaDobleEnlazada<Tema>();
        }
        public void Iniciar()
        {
            this.servidor.Start();
            Console.WriteLine("Servidor MQBroker iniciado y escuchando peticiones...");
            while (true)
            {
                TcpClient cliente = this.servidor.AcceptTcpClient();
                Console.WriteLine("Cliente conectado.");
                Task.Run(() => ManejarCliente(cliente));
            }
        }
        private void ManejarCliente(TcpClient cliente)
        {
            try
            {
                using (NetworkStream stream = cliente.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                    Console.WriteLine($"Mensaje recibido: {mensaje}");

                    string[] partes = mensaje.Split('|');
                    string comando = partes[0].ToUpper();

                    if (comando == "SUSCRIBE")
                    {
                        string appId = partes[1];
                        string nombreTema = partes[2];

                        if (!temas.Contiene(new Tema(nombreTema)))
                        {
                            temas.Anadir(new Tema(nombreTema));
                        }
                    }
                }
            }
        }
    }
}
