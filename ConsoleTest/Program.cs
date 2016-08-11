using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConsoleTest
{
    class Program
    {

        private static void SendMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                    string message = $"Hello World at {DateTime.Now:G}";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine($" [{DateTime.Now:G}] Sent {message}");
                }
            }
        }

        private static void ReceiveMessages(Action<object, BasicDeliverEventArgs> action)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, args) => action(sender,args);
                channel.BasicConsume(queue: "hello",
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static void ReceiveMessages()
        {
            ReceiveMessages((model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [{DateTime.Now:G}] Received {message}");
            });
        }

        private static void SendMails()
        {
            ReceiveMessages((model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Sending mail: {message}");
                MailMessage msg = new MailMessage("rabbitservice@myhost.com", "joan.vilarino@gmail.com", "New message in queue", message);
                SmtpClient mailClient = new SmtpClient("localhost");
                mailClient.Send(msg);
            });
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo k;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Enviar mensaje");
                Console.WriteLine("2 - Leer mensajes");
                Console.WriteLine("3 - Email messages");
                Console.WriteLine("ESC - Salir");
                k = Console.ReadKey();
                switch (k.KeyChar)
                {
                    case '1':
                        SendMessage();
                        break;
                    case '2':
                        ReceiveMessages();
                        break;
                    case '3':
                        SendMails();
                        break;
                }
            } while (k.Key != ConsoleKey.Escape);
        }
    }
}
