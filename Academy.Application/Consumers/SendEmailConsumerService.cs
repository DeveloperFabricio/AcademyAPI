using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Academy.Application.Options;
using Academy.Core.IntegrationEvents;
using Academy.Application.Email;

namespace Academy.Application.Consumers
{
    public sealed class SendEmailConsumerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly ConnectionFactory _connectionFactory;
        private readonly RabbitMqOptions _rabbitMqOptions;

        private readonly string _queue;

        public SendEmailConsumerService(IServiceProvider serviceProvider, IOptions<RabbitMqOptions> rabbitMqOptions)
        {
            _serviceProvider = serviceProvider;

            _rabbitMqOptions = rabbitMqOptions.Value;

            if (string.IsNullOrEmpty(_rabbitMqOptions.UserName))
            {
                throw new ArgumentNullException(nameof(_rabbitMqOptions.UserName), "RabbitMQ username is null or empty.");
            }

            _connectionFactory = new ConnectionFactory
            {
                HostName = _rabbitMqOptions.HostName,
                Port = _rabbitMqOptions.Port,
                UserName = _rabbitMqOptions.UserName,
                Password = _rabbitMqOptions.Password
            };

            _queue = nameof(SendEmailEvent);

            _connection = _connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare
                (
                    queue: _queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: true,
                    arguments: null
                );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var bytes = eventArgs.Body.ToArray();
                var eventMessage = Encoding.UTF8.GetString(bytes);
                var sendEmailEvent = JsonSerializer.Deserialize<SendEmailEvent>(eventMessage);

                await SendEmail(sendEmailEvent);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume
                (
                    queue: _queue,
                    autoAck: false,
                    consumer: consumer
                );

            return Task.CompletedTask;
        }

        private async Task SendEmail(SendEmailEvent sendEmailEvent)
        {
            using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var emailApi = scope.ServiceProvider.GetRequiredService<IEmailService>();

                bool emailSent = await emailApi.SendEmail(sendEmailEvent.Destiny, sendEmailEvent.Subject, sendEmailEvent.Body);
            }
        }
    }
}

