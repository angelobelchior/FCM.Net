using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FCM.Net
{
    /// <summary>
    /// Send messages from your app server to client apps via Firebase Cloud Messaging
    /// </summary>
    public class Sender
    {
        private readonly string _endpoint = "https://fcm.googleapis.com/fcm/send";
        private readonly string _contentType = "application/json";
        private readonly string _serverKey;

        /// <summary>
        /// Initialize the Message Sender
        /// </summary>
        /// <param name="serverKey">Server Key. To access this information, go to https://console.firebase.google.com/project/<<MY_PROJECT>>/settings/cloudmessaging </param>
        public Sender(string serverKey)
        {
            if (string.IsNullOrWhiteSpace(serverKey))
                throw new ArgumentNullException(nameof(serverKey));

            this._serverKey = serverKey;
        }

        /// <summary>
        /// Send a message Async
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>Response Content</returns>
        public async Task<ResponseContent> SendAsync(Message message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            using (var client = new HttpClient())
            {
                var requestContent = this.GetRequestContent(message);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={this._serverKey}");

                var response = await client.PostAsync(this._endpoint, requestContent);

                var responseContent = await GetResponseContentAsync(response); ;
                var result = new ResponseContent(response.StatusCode, response.ReasonPhrase, responseContent);

                return result;
            }
        }

        private HttpContent GetRequestContent(Message message)
        {
            string json = JsonConvert.SerializeObject(message, Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                            });

            var content = new StringContent(json, Encoding.UTF8, this._contentType);
            return content;
        }

        private async Task<MessageResponse> GetResponseContentAsync(HttpResponseMessage response)
        {
            string json = string.Empty;
            try
            {
                json = await response.Content.ReadAsStringAsync();
                var messageResponse = JsonConvert.DeserializeObject<MessageResponse>(json);
                return messageResponse;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new MessageResponse { InternalError = ex.Message, ResponseContent = json };
            }
        }
    }
}
