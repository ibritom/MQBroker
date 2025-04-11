namespace Broker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MQBroker broker = new MQBroker("127.0.0.1", 5000);
            broker.Iniciar();
        }
    }
}
