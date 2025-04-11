using System.Net.Http.Json;
using System.Threading.Tasks;
using MQProject;
using Broker;
namespace App
{
    public partial class Form1 : Form
    {
        private MQBrokerClient client;
        private Task brokerTask;
        private Task handleClientTask;

        public Form1()
        {
            InitializeComponent();

            brokerTask = Task.Run(() =>
            {
                MQBroker broker = new MQBroker("127.0.0.1", 5000);
                broker.Iniciar();
            });
        }
        
        private async void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // MQBroker IP
        {

        }

        private async void button1_Click(object sender, EventArgs e) // Boton suscribirse
        {
            string ip = textBox1.Text.Trim();
            int port = int.Parse(textBox2.Text.Trim());
            string appId = textBox3.Text.Trim();
            string tema = textBox4.Text.Trim();

            if (client == null)
            {
                client = new MQBrokerClient(ip, port, appId);
            }
            bool exito = await client.SubscribeAsync(tema);
            MessageBox.Show(exito ? $"Suscrito a {tema}" : $"Error al suscribirse a {tema}");
        }

        private async void button2_Click(object sender, EventArgs e) // Boton desuscribirse
        {
            string tema = textBox4.Text.Trim();
            if (client != null)
            {
                bool exito = await client.UnsubscribeAsync(tema);
                MessageBox.Show(exito ? $"Desuscrito de {tema}" : $"Error al desuscribir de {tema}");
            }
        }

        private async void button3_Click(object sender, EventArgs e) // Boton publicar
        {
            string tema = textBox4.Text.Trim();
            string contenido = richTextBox1.Text.Trim();
            if (client != null)
            {
                bool exito = await client.PublishAsync(tema, contenido);
                MessageBox.Show(exito ? $"Mensaje publicado en {tema}" : $"Error publicando en {tema}");
            }

        }

        private async void button4_Click(object sender, EventArgs e) // Boton obtener mensaje
        {
            string tema = textBox4.Text.Trim();
            if (client != null)
            {
                string mensaje = await client.ReceiveAsync(tema);
                if (mensaje != "NO_MESSAGES" && mensaje != "TOPIC_NOT_FOUND" && !string.IsNullOrEmpty(mensaje))
                {
                    this.Invoke((Action)(() =>
                    {
                        Label label = new Label
                        {
                            Text = $"TEMA = {tema}, MENSAJE = {mensaje}",
                            AutoSize = true
                        };
                        tableLayoutPanel1.Controls.Add(label);
                    }));
                }
                else
                {
                    MessageBox.Show("No hay mensajes o el tema no existe");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // MQBroker port
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // AppID
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) // Tema
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) // Contenido de la publicacion
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) // Mensajes recibidos
        {

        }
    }
}
