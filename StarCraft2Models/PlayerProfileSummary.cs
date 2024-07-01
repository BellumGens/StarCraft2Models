namespace StarCraft2Models
{
    public class PlayerProfileSummary
    {
        /// <summary>
        /// Gets or sets the player profile identifier.
        /// </summary>
        /// <value>
        /// The player profile identifier.
        /// </value>
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the player realm identifier.
        /// </summary>
        /// <value>
        /// The player realm identifier.
        /// </value>
        public int realm { get; set; }

        /// <summary>
        /// Gets or sets the player display name.
        /// </summary>
        /// <value>
        /// The player display name.
        /// </value>
        public string displayName { get; set; }

        /// <summary>
        /// Gets or sets the portrait url.
        /// </summary>
        /// <value>
        /// The player portrait url.
        /// </value>
        public string portrait { get; set; }

        /// <summary>
        /// Gets or sets the player terran decal.
        /// </summary>
        /// <value>
        /// The player terran decal.
        /// </value>
        public string decalTerran { get; set; }

        /// <summary>
        /// Gets or sets the player protoss decal.
        /// </summary>
        /// <value>
        /// The player protoss decal.
        /// </value>
        public string decalProtoss { get; set; }

        /// <summary>
        /// Gets or sets the player zerg decal.
        /// </summary>
        /// <value>
        /// The player zerg decal.
        /// </value>
        public string decalZerg { get; set; }

        public int totalSwarmLevel { get; set; }

        public int totalAchievementPoints { get; set; }
    }
}