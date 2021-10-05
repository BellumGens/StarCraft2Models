namespace StarCraft2Models
{
    public class PlayerProfile
    {
        /// <summary>
        /// Gets or sets the player profile identifier.
        /// </summary>
        /// <value>
        /// The player profile identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the player realm identifier.
        /// </summary>
        /// <value>
        /// The player realm identifier.
        /// </value>
        public int Realm { get; set; }

        /// <summary>
        /// Gets or sets the player display name.
        /// </summary>
        /// <value>
        /// The player display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name of the player clan.
        /// </summary>
        /// <value>
        /// The name of the player clan.
        /// </value>
        public string ClanName { get; set; }

        /// <summary>
        /// Gets or sets the player clan tag.
        /// </summary>
        /// <value>
        /// The player clan tag.
        /// </value>
        public string ClanTag { get; set; }

        /// <summary>
        /// Gets or sets the player profile path.
        /// </summary>
        /// <value>
        /// The player profile path.
        /// </value>
        public string ProfilePath { get; set; }

        /// <summary>
        /// Gets or sets the player portrait.
        /// </summary>
        /// <value>
        /// The player portrait.
        /// </value>
        public ProfilePortrait Portrait { get; set; }

    }
}
