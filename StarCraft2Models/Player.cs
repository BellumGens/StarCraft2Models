namespace StarCraft2Models
{
    public class Player
    {
        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        /// <value>
        /// The player name.
        /// </value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the player profile URL.
        /// </summary>
        /// <value>
        /// The player profile URL.
        /// </value>
        public string profileUrl { get; set; }

        /// <summary>
        /// Gets or sets the player avatar URL.
        /// </summary>
        /// <value>
        /// The player avatar URL.
        /// </value>
        public string avatarUrl { get; set; }

        /// <summary>
        /// Gets or sets the player profile identifier.
        /// </summary>
        /// <value>
        /// The player profile identifier.
        /// </value>
        public string profileId { get; set; }

        /// <summary>
        /// Gets or sets the player region identifier.
        /// </summary>
        /// <value>
        /// The player region identifier.
        /// </value>
        public int regionId { get; set; }

        /// <summary>
        /// Gets or sets the player realm identifier.
        /// </summary>
        /// <value>
        /// The player realm identifier.
        /// </value>
        public int realmId { get; set; }
    }
}
