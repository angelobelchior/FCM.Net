using Newtonsoft.Json;

namespace FCM.Net
{
    /// <summary>
    /// Priority of the message
    /// </summary>
    public enum Priority
    {
        [JsonProperty("normal")]
        Normal,
        [JsonProperty("high")]
        High
    }
}
