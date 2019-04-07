using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFetcherCore.Interfaces;
using UFetcherCore.Models;
using System.Messaging;
using System.Configuration;

namespace UFetcherQService
{
    public class QService : IUFetcherQServiceInterface
    {
        //string path = @".\Private$\RequestQ";
        //string path = @".\Private$\ResponseQ";

        public static MessageQueue Queue { get; set; }
        public static string Message { get; set; }
        
        public void Send(UrlContentModel model)
        {
             SendQueue(model);
        }

        public string Recieve(UrlContentModel model)
        {
            // Begin the asynchronous receive operation.
            Queue.BeginReceive(TimeSpan.FromSeconds(10.0));
            return Message;
        }
        
        private void SendQueue(UrlContentModel model)
        {
            CreateQueue(model.QPath,false);
            Message = string.Empty;

            Queue = new MessageQueue(model.QPath);
            Queue.ReceiveCompleted += new ReceiveCompletedEventHandler(ReceiveCompleted);
            Queue.Send(model.QMessage);
        }

        public static void CreateQueue(string queuePath, bool transactional)
        {
            if (!MessageQueue.Exists(queuePath))
            {
                MessageQueue.Create(queuePath, transactional);
            }
        }

        // Provides an event handler for the ReceiveCompleted event.
        private static void ReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            // Connect to the queue.
            Queue = (MessageQueue)source;

            // End the asynchronous receive operation.
            Message msg = Queue.EndReceive(asyncResult.AsyncResult);
            Message = msg.Body.ToString();
            // Display the message information on the screen.
            Console.WriteLine("Message body: {0}", (string)msg.Body);
        }
    }
}
