using Newtonsoft.Json;
using System.Collections.Generic;

namespace FCM.Net
{
    /// <summary>
    /// Keys for notification messages
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// (i0S, Android, Web) Indicates notification title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// (i0S, Android, Web) Indicates notification body text.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        /// <summary>
        /// <para/>(iOS) N/A
        /// <para/>(Android) Indicates notification icon. Sets value to myicon for drawable resource myicon. If you don't send this key in the request, FCM displays the launcher icon specified in your app manifest.
        /// <para/>(Web) The URL for a notification icon.
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// <para/>(iOS) Indicates the action associated with a user click on the notification. Corresponds to category in the APNs payload.
        /// <para/>(Android) Indicates the action associated with a user click on the notification. When this is set, an activity with a matching intent filter is launched when user clicks the notification.
        /// <para/>(Web) Indicates the action associated with a user click on the notification. For all URL values, secure HTTPS is required.
        /// </summary>
        [JsonProperty("click_action")]
        public string ClickAction { get; set; }

        /// <summary>
        /// <para/>(iOS) Indicates a sound to play when the device receives a notification.Sound files can be in the main bundle of the client app or in the Library/Sounds folder of the app's data container. See the iOS Developer Library for more information.
        /// <para/>(Android) Indicates a sound to play when the device receives a notification. Supports default or the filename of a sound resource bundled in the app. Sound files must reside in /res/raw/.
        /// <para/>(Web) N/A
        /// </summary>
        [JsonProperty("sound")]
        public string Sound { get; set; }

        /// <summary>
        /// <para/>(iOS)Indicates the badge on the client app home icon.
        /// <para/>(Android) N/A
        /// <para/>(Web) N/A
        /// </summary>
        [JsonProperty("badge")]
        public string Badge { get; set; }

        /// <summary>
        /// <para/>(iOS) N/A
        /// <para/>(Android) Indicates color of the icon, expressed in #rrggbb format
        /// <para/>(Web) N/A
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// <para/>(iOS) N/A
        /// <para/>(Android) Indicates whether each notification results in a new entry in the notification drawer on Android. 
        /// <para/> - If not set, each request creates a new notification.
        /// <para/> - If set, and a notification with the same tag is already being shown, the new notification replaces the existing one in the notification drawer.
        /// <para/>(Web) N/A
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// <para/>(iOS) Indicates the key to the body string for localization.Corresponds to "loc-key" in the APNs payload.
        /// <para/>(Android) ndicates the key to the body string for localization. Use the key in the app's string resources when populating this value.
        /// <para/>(Web) N/A
        /// </summary>
        [JsonProperty("body_loc_key")]
        public string BodyLocalizationKey { get; set; }

        /// <summary>
        /// <para/>(iOS) Indicates the string value to replace format specifiers in the body string for localization.Corresponds to "loc-args" in the APNs payload.
        /// <para/>(Android) Indicates the string value to replace format specifiers in the body string for localization. 
        /// <para/>(Web) N/A
        /// </summary>
        [JsonProperty("body_loc_args")]
        public List<string> BodyLocalizationArguments { get; set; }

        /// <summary>
        /// <para/>(iOS)Indicates the key to the title string for localization.Corresponds to "title-loc-key" in the APNs payload.
        /// <para/>(Android) Indicates the key to the title string for localization. Use the key in the app's string resources when populating this value.
        /// <para/>(Web) N/A
        /// </summary>
        [JsonProperty("title_loc_key")]
        public string TitleLocalizationKey { get; set; }

        /// <summary>
        /// <para/>(iOS)Indicates the string value to replace format specifiers in the title string for localization. Corresponds to "title-loc-args" in the APNs payload.
        /// <para/>(Android) Indicates the string value to replace format specifiers in the title string for localization. 
        /// <para/>(Web) N/A
        /// </summary>
        public List<string> TitleLocalizationArguments { get; set; }
    }
}
