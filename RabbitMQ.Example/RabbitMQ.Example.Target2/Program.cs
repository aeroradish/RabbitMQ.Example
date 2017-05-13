using RabbitMQ.Client;
using RabbitMqService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Example.Target2
{
    class Program
    {
        static void Main(string[] args)
        {

            ReceiveWorkerQueue();
            //ReceiveFromPublisher();
        }

        #region "WorkerQueue"     

        public static void ReceiveWorkerQueue()
        {
            AmqpMessagingService messagingService = new AmqpMessagingService();
            IConnection connection = messagingService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            messagingService.ReceiveWorkerQueueMessages(model);
        }

        #endregion

        #region "Publish/Subscriber"
        #region "Publish/Subscriber"

        public static void ReceiveFromPublisher()
        {
            AmqpMessagingService messagingService = new AmqpMessagingService();
            IConnection connection = messagingService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            messagingService.ReceivePublishSubscribeMessageReceiverTwo(model);
        }

        #endregion
        #endregion

    }
}
