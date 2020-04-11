using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TestRabbit
{
    /// <summary>
    /// https://www.rabbitmq.com/dotnet-api-guide.html
    /// </summary>
    class Program
    {
        static string connection = "amqp://xpsxyjse:nqXwuQgoRcJCp7yPMvRqSGLWEh7HEWwX@barnacle.rmq.cloudamqp.com/xpsxyjse";
        static string queueName = "testBermudez";
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(Program.connection);

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            var mainProcess = new MainProccess(new ConvertBasic(),new PublishDefault(), new ValidateDefault(), new ProcessDefault());

            consumer.Received += (ch, ea) =>
            {

                try
                {
                    var body = ea.Body;
                    var data = Encoding.UTF8.GetString(body, 0, body.Length);

                    mainProcess.Run(data);

                    // ... process the message
                    channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    throw;
                }

            };

            String consumerTag = channel.BasicConsume(queueName, false, consumer);
            String consumerTagQuiroz = channel.BasicConsume("testQuiroz", false, consumer);
        }

     
    }
}
