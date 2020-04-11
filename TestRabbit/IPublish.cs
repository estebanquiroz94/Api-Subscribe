using RabbitMQ.Client;
using System;

namespace TestRabbit
{
    public interface IPublish
    {
        public void Run(string data);
    }
    public class PublishDefault : IPublish
    {
        string connection = "amqp://xpsxyjse:nqXwuQgoRcJCp7yPMvRqSGLWEh7HEWwX@barnacle.rmq.cloudamqp.com/xpsxyjse";
        public void Run(string data)
        {
            //TODO ARCHIVO PLANO

            //ConnectionFactory factory = new ConnectionFactory();
            //factory.Uri = new Uri(connection);

            //IConnection conn = factory.CreateConnection();
            //IModel channel = conn.CreateModel();

            //byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(data);
            //channel.BasicPublish("jquiroz", "prueba_libre", null, messageBodyBytes);

        }
    }
}
