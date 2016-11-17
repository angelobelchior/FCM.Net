using System;
using System.Collections.Generic;

namespace FCM.Net.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var registrationId = "ID gerado quando o device é registrado no FCM";
            var serverKey = "acesse https://console.firebase.google.com/project/MY_PROJECT/settings/cloudmessaging";

            var sender = new Sender(serverKey);
            var message = new Message
            {
                RegistrationIds = new List<string> { registrationId },
                Notification = new Notification
                {
                    Title = "Test from FCM.Net",
                    Body = $"Miguel@!{DateTime.Now.ToString()}"
                }
            };
            var result = sender.SendAsync(message).Result;
            WriteResult(result);

            Console.Read();
        }

        private static void WriteResult(ResponseContent result)
        {
            Console.WriteLine($"StatusCode {result.StatusCode}");
            Console.WriteLine($"ReasonPhrase {result.ReasonPhrase}");
            if (result.MessageResponse == null) return;

            Console.WriteLine($"MessageResponse.Success {result.MessageResponse.Success}");
            Console.WriteLine($"MessageResponse.Failure {result.MessageResponse.Failure}");
            Console.WriteLine($"MessageResponse.MulticastId {result.MessageResponse.MulticastId}");
            Console.WriteLine($"MessageResponse.CanonicalIds {result.MessageResponse.CanonicalIds}");
            Console.WriteLine($"MessageResponse.InternalError {result.MessageResponse.InternalError}");
            Console.WriteLine($"MessageResponse.ResponseContent {result.MessageResponse.ResponseContent}");
            if (result.MessageResponse.Results == null) return;

            foreach (var item in result.MessageResponse.Results)
            {
                Console.WriteLine($"MessageResponse.Results.MessageId {item.MessageId}");
                Console.WriteLine($"MessageResponse.Results.RegistrationId {item.RegistrationId}");
                Console.WriteLine($"MessageResponse.Results.Error {item.Error}");
            }
        }
    }
}
