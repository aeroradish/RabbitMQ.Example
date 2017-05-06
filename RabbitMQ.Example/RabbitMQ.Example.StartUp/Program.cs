using RabbitMQ.Client;
using RabbitMqService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Example.StartUp
{
    class Program
    {
        static void Main(string[] args)
        {

            //OneWayMessageQueue();
            //WorkerQueue();
            PublishToSubscribers();
        }

        #region "OneWayMessageQueue"

        public static void OneWayMessageQueue()
        {
            AmqpMessagingService messagingService = new AmqpMessagingService();
            IConnection connection = messagingService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            messagingService.SetUpQueueForOneWayMessageDemo(model);

            RunOneWayMessageDemo(model, messagingService);
           
        }


        private static void RunOneWayMessageDemo(IModel model, AmqpMessagingService messagingService)
        {
            Console.WriteLine("Enter your message and press Enter. Quit with 'q'.");
            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "q") break;

                messagingService.SendOneWayMessage(message, model);
            }
        }
        #endregion

        #region "WorkerQueue"
        //client pulls message off queue.  message no longer available.

        public static void WorkerQueue()
        {
            AmqpMessagingService messagingService = new AmqpMessagingService();
            IConnection connection = messagingService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            messagingService.SetUpQueueForWorkerQueueDemo(model);
            RunWorkerQueueMessageDemo(model, messagingService);
        }

        private static void RunWorkerQueueMessageDemo(IModel model, AmqpMessagingService messagingService)
        {
            Console.WriteLine("Enter your message and press Enter. Quit with 'q'.");
            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "q") break;
                messagingService.SendMessageToWorkerQueue(message, model);
            }
        }
        #endregion

        #region "Publish/Subscriber"

        public static void PublishToSubscribers()
        {
            AmqpMessagingService messagingService = new AmqpMessagingService();
            IConnection connection = messagingService.GetRabbitMqConnection();
            IModel model = connection.CreateModel();
            messagingService.SetUpExchangeAndQueuesForDemo(model);

            RunPublishSubscribeMessageDemo(model, messagingService);
        }

        private static void RunPublishSubscribeMessageDemo(IModel model, AmqpMessagingService messagingService)
        {
            Console.WriteLine("Enter your message and press Enter. Quit with 'q'.");
            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "q") break;

                messagingService.SendMessageToPublishSubscribeQueues(message, model);
            }
        }

        #endregion

    }
}
