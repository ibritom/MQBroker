using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MQProject
{
    public class MQBrokerClient
    {
        private string brokerIp;
        private int brokerPort;
        private string appId;

        public MQBrokerClient(string ip, int port, string appId)
        {
            brokerIp = ip;
            brokerPort = port;
            this.appId = appId;
        }

        public async Task<bool> SubscribeAsync(string topic)
        {
            string request = $"SUBSCRIBE|{appId}|{topic}";
            string response = await SendRequestAsync(request);
            return response == "SUBSCRIBED";
        }

        public async Task<bool> UnsubscribeAsync(string topic)
        {
            string request = $"UNSUBSCRIBE|{appId}|{topic}";
            string response = await SendRequestAsync(request);
            return response == "UNSUBSCRIBED";
        }

        public async Task<bool> PublishAsync(string topic, string message)
        {
            string request = $"PUBLISH|{appId}|{topic}|{message}";
            string response = await SendRequestAsync(request);
            return response == "PUBLISHED";
        }

        public async Task<string> ReceiveAsync(string topic)
        {
            string request = $"RECEIVE|{appId}|{topic}";
            string response = await SendRequestAsync(request);
            return response;
        }

        private async Task<string> SendRequestAsync(string request)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    await client.ConnectAsync(brokerIp, brokerPort);
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] data = Encoding.UTF8.GetBytes(request);
                        await stream.WriteAsync(data, 0, data.Length);

                        byte[] buffer = new byte[1024];
                        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                        return Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error enviando petición: " + ex.Message);
                return "";
            }
        }
    }
}


