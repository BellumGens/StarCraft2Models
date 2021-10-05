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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the player profile URL.
        /// </summary>
        /// <value>
        /// The player profile URL.
        /// </value>
        public string ProfileUrl { get; set; }

        /// <summary>
        /// Gets or sets the player avatar URL.
        /// </summary>
        /// <value>
        /// The player avatar URL.
        /// </value>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// Gets or sets the player profile identifier.
        /// </summary>
        /// <value>
        /// The player profile identifier.
        /// </value>
        public string ProfileId { get; set; }

        /// <summary>
        /// Gets or sets the player region identifier.
        /// </summary>
        /// <value>
        /// The player region identifier.
        /// </value>
        public int RegionId { get; set; }

        /// <summary>
        /// Gets or sets the player realm identifier.
        /// </summary>
        /// <value>
        /// The player realm identifier.
        /// </value>
        public int RealmId { get; set; }
    }
}
