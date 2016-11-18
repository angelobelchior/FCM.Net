using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace FCM.Net
{
    public class ResponseContent
    {
        public HttpStatusCode StatusCode { get; }
        public string ReasonPhrase { get; }
        public MessageResponse MessageResponse { get; }

        public ResponseContent(HttpStatusCode statusCode, string reasonPhrase, MessageResponse messageResponse)
        {
            this.StatusCode = statusCode;
            this.ReasonPhrase = reasonPhrase;
            this.MessageResponse = messageResponse;
        }
    }

    /// <summary>
    /// Response Message Content
    /// </summary>
    public class MessageResponse
    {
        /// <summary>
        /// Internal Error
        /// </summary>
        public string InternalError { get; set; }

        /// <summary>
        /// Response Content
        /// </summary>
        public string ResponseContent { get; set; }

        /// <summary>
        /// Unique ID (number) identifying the multicast message.
        /// </summary>
        [JsonProperty("multicast_id")]
        public string MulticastId { get; set; }

        /// <summary>
        /// Number of messages that were processed without an error.
        /// </summary>
        [JsonProperty("success")]
        public int Success { get; set; }

        /// <summary>
        /// Number of messages that could not be processed.
        /// </summary>
        [JsonProperty("failure")]
        public int Failure { get; set; }

        /// <summary>
        /// Number of results that contain a canonical registration token. A canonical registration ID is the registration token of the last registration requested by the client app. This is the ID that the server should use when sending messages to the device.
        /// </summary>
        [JsonProperty("canonical_ids")]
        public string CanonicalIds { get; set; }

        /// <summary>
        /// Array of objects representing the status of the messages processed. The objects are listed in the same order as the request (i.e., for each registration ID in the request, its result is listed in the same index in the response).
        /// </summary>
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    /// <summary>
    /// Result Item
    /// </summary>
    public class Result
    {
        /// <summary>
        /// String specifying a unique ID for each successfully processed message.
        /// </summary>
        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// Optional string specifying the canonical registration token for the client app that the message was processed and sent to. Sender should use this value as the registration token for future requests. Otherwise, the messages might be rejected.
        /// </summary>
        [JsonProperty("registration_id")]
        public string RegistrationId { get; set; }

        /// <summary>
        /// String specifying the error that occurred when processing the message for the recipient. The possible values can be found in https://firebase.google.com/docs/cloud-messaging/http-server-ref#table9
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
