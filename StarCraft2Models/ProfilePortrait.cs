using System.Text.Json.Serialization;

namespace StarCraft2Models
{
    /// <summary>
    /// The portrait of a legacy StarCraft II profile, a cell in a sprite sheet rather than an image of its own.
    /// </summary>
    public class ProfilePortrait
    {
        /// <summary>
        /// Gets or sets the x coordinate of the profile portrait.
        /// </summary>
        /// <value>
        /// The x coordinate of the profile portrait.
        /// </value>
        [JsonPropertyName("x")]
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate of the profile portrait.
        /// </summary>
        /// <value>
        /// The y coordinate of the profile portrait.
        /// </value>
        [JsonPropertyName("y")]
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the width of the profile portrait.
        /// </summary>
        /// <value>
        /// The width of the profile portrait.
        /// </value>
        [JsonPropertyName("w")]
        public int W { get; set; }

        /// <summary>
        /// Gets or sets the height of the profile portrait.
        /// </summary>
        /// <value>
        /// The height of the profile portrait.
        /// </value>
        [JsonPropertyName("h")]
        public int H { get; set; }

        /// <summary>
        /// Gets or sets the offset of the profile portrait.
        /// </summary>
        /// <value>
        /// The offset of the profile portrait.
        /// </value>
        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the URL of the profile portrait.
        /// </summary>
        /// <value>
        /// The URL of the profile portrait.
        /// </value>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}