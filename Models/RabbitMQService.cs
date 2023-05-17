using RabbitMQ.Client;
using System;
using System.Text;

namespace AsistenciaAPIPSQL.Models
{
    public interface IRabbitMQService
    {
        void SendMessage(string message);
    }

    public class RabbitMQService : IRabbitMQService
    {
        private readonly string _hostName;
        private readonly int _port;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _exchangeName;

        public RabbitMQService(string hostName, int port, string userName, string password, string exchangeName)
        {
            _hostName = hostName ?? throw new ArgumentNullException(nameof(hostName));
            _port = port;
            _userName = userName ?? throw new ArgumentNullException(nameof(userName));
            _password = password ?? throw new ArgumentNullException(nameof(password));
            _exchangeName = exchangeName ?? throw new ArgumentNullException(nameof(exchangeName));
        }

        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                Port = _port,
                UserName = _userName,
                Password = _password
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(
                    exchange: _exchangeName,
                    type: ExchangeType.Fanout,
                    durable: false,
                    autoDelete: false,
                    arguments: null
                );

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(
                    exchange: _exchangeName,
                    routingKey: "",
                    basicProperties: null,
                    body: body
                );
            }
        }
    }
}
