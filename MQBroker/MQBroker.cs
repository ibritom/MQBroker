using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Listas;

namespace MQBroker
{
    public class MQBroker
    {
        private TcpListener server;
        private Diccionario<string, Tema> temas;

        public MQBroker(string ip, int port)
        {
            server = new TcpListener(IPAddress.Parse(ip), port);
            temas = new Diccionario<string, Tema>();
        }

        public void Iniciar()
        {
            server.Start();
            Console.WriteLine("MQBroker iniciado y escuchando peticiones...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Task.Run(() => ManejarCliente(client));
            }
        }

        private void ManejarCliente(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] parts = request.Split('|');

                    string command = parts[0].ToUpper();

                    if (command == "SUBSCRIBE")
                    {
                        string appId = parts[1];
                        string topicName = parts[2];


                        if (!temas.Contiene(topicName))
                        {
                            temas.Anadir(topicName, new Tema(topicName));
                        }

                        Tema topic = temas.Obtener(topicName);
                        topic.AnadirSub(appId);

                        Console.WriteLine($"{appId} se suscribió al topic {topicName}");

                        byte[] response = Encoding.UTF8.GetBytes("SUBSCRIBED");
                        stream.Write(response, 0, response.Length);
                    }
                    else if (command == "UNSUBSCRIBE")
                    {
                        string appId = parts[1];
                        string topicName = parts[2];

                        if (temas.Contiene(topicName))
                        {
                            temas.Obtener(topicName).QuitarSub(appId);
                            Console.WriteLine($"{appId} se desuscribió del topic {topicName}");
                        }
                        byte[] response = Encoding.UTF8.GetBytes("UNSUBSCRIBED");
                        stream.Write(response, 0, response.Length);
                    }
                    else if (command == "PUBLISH")
                    {
                        string appId = parts[1];
                        string topicName = parts[2];
                        string content = parts[3];

                        if (temas.Contiene(topicName))
                        {
                            Mensaje msg = new Mensaje(topicName, content);
                            temas.Obtener(topicName).ColarMensaje(msg);

                            foreach (var subscriber in temas.Obtener(topicName).GetSub() as IEnumerable<string>)
                            {
                                Console.WriteLine($"Mensaje para {subscriber} en {topicName}: {content}");
                            }
                            byte[] response = Encoding.UTF8.GetBytes("PUBLISHED");
                            stream.Write(response, 0, response.Length);
                        }
                        else
                        {
                            Console.WriteLine($"El topic {topicName} no existe. Publicación ignorada.");
                            byte[] response = Encoding.UTF8.GetBytes("TOPIC_NOT_FOUND");
                            stream.Write(response, 0, response.Length);
                        }
                    }
                    else if (command == "RECEIVE")
                    {
                        string appId = parts[1];
                        string topicName = parts[2];

                        if (temas.Contiene(topicName))
                        {
                            Mensaje message = temas.Obtener(topicName).DecolarMensaje();
                            if (message != null)
                            {
                                byte[] response = Encoding.UTF8.GetBytes(message.contenido);
                                stream.Write(response, 0, response.Length);
                            }
                            else
                            {
                                byte[] response = Encoding.UTF8.GetBytes("NO_MESSAGES");
                                stream.Write(response, 0, response.Length);
                            }
                        }
                        else
                        {
                            byte[] response = Encoding.UTF8.GetBytes("TOPIC_NOT_FOUND");
                            stream.Write(response, 0, response.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error procesando petición: " + ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
