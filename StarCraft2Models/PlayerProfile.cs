using System.Collections.Generic;

namespace StarCraft2Models
{
    /// <summary>
    /// A StarCraft II profile, as returned by <c>/sc2/profile/{regionId}/{realmId}/{profileId}</c>.
    /// </summary>
    /// <remarks>
    /// The metadata endpoint, <c>/sc2/metadata/profile/{regionId}/{realmId}/{profileId}</c>, returns a
    /// different, flat shape. Deserialize that one into <see cref="Player"/>.
    /// </remarks>
    public class PlayerProfile
    {
        /// <summary>
        /// Gets or sets the profile summary: the display name, portrait, decals and totals.
        /// </summary>
        public PlayerProfileSummary summary { get; set; }

        /// <summary>
        /// Gets or sets the ladder standing for the current season.
        /// </summary>
        public ProfileSnapshot snapshot { get; set; }

        /// <summary>
        /// Gets or sets the career totals and best league finishes.
        /// </summary>
        public ProfileCareer career { get; set; }

        /// <summary>
        /// Gets or sets the overall and per race swarm levels.
        /// </summary>
        public SwarmLevels swarmLevels { get; set; }

        /// <summary>
        /// Gets or sets the campaign progress.
        /// </summary>
        public ProfileCampaign campaign { get; set; }

        /// <summary>
        /// Gets or sets the achievement points earned in each achievement category.
        /// </summary>
        public List<CategoryPointProgress> categoryPointProgress { get; set; } = new();

        /// <summary>
        /// Gets or sets the identifiers of the achievements the player chose to show off on the profile.
        /// </summary>
        public List<string> achievementShowcase { get; set; } = new();

        /// <summary>
        /// Gets or sets the rewards (portraits, decals, skins and so on) the player has earned.
        /// </summary>
        public List<EarnedReward> earnedRewards { get; set; } = new();

        /// <summary>
        /// Gets or sets the achievements the player has completed or has in progress.
        /// </summary>
        public List<EarnedAchievement> earnedAchievements { get; set; } = new();
    }
}
