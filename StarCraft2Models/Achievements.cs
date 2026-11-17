using System.Collections.Generic;

namespace StarCraft2Models
{
    /// <summary>
    /// The achievement points earned in one achievement category.
    /// </summary>
    public class CategoryPointProgress
    {
        /// <summary>
        /// Gets or sets the achievement category identifier.
        /// </summary>
        public string categoryId { get; set; }

        /// <summary>
        /// Gets or sets the points earned in the category.
        /// </summary>
        public int pointsEarned { get; set; }
    }

    /// <summary>
    /// A reward the player has earned, such as a portrait, a decal or a unit skin.
    /// </summary>
    public class EarnedReward
    {
        /// <summary>
        /// Gets or sets the reward identifier.
        /// </summary>
        public string rewardId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the reward is currently equipped.
        /// </summary>
        public bool selected { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the achievement that unlocks the reward.
        /// Null for rewards that are not unlocked by an achievement.
        /// </summary>
        public string achievementId { get; set; }

        /// <summary>
        /// Gets or sets the reward category. Not every reward carries one.
        /// </summary>
        public string category { get; set; }
    }

    /// <summary>
    /// An achievement the player has completed or has in progress.
    /// </summary>
    public class EarnedAchievement
    {
        /// <summary>
        /// Gets or sets the achievement identifier.
        /// </summary>
        public string achievementId { get; set; }

        /// <summary>
        /// Gets or sets when the achievement was completed, in seconds since the Unix epoch.
        /// The API sends this as a floating point number, often in exponent notation such as
        /// <c>1.58058432E9</c>, which is why it is a <see cref="double"/>.
        /// </summary>
        public double completionDate { get; set; }

        /// <summary>
        /// Gets or sets how many achievements of the series the achievement belongs to are completed.
        /// </summary>
        public int numCompletedAchievementsInSeries { get; set; }

        /// <summary>
        /// Gets or sets how many achievements the series the achievement belongs to has.
        /// </summary>
        public int totalAchievementsInSeries { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the achievement is completed.
        /// </summary>
        public bool isComplete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the achievement is in progress.
        /// </summary>
        public bool inProgress { get; set; }

        /// <summary>
        /// Gets or sets the criteria of the achievement the player has met.
        /// </summary>
        public List<AchievementCriterion> criteria { get; set; } = new();

        /// <summary>
        /// Gets or sets the quantity earned towards the next step of a progress achievement.
        /// 0 for achievements without steps.
        /// </summary>
        public int nextProgressEarnedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the quantity required for the next step of a progress achievement.
        /// 0 for achievements without steps.
        /// </summary>
        public int nextProgressRequiredQuantity { get; set; }
    }

    /// <summary>
    /// A criterion of an achievement that the player has met.
    /// </summary>
    public class AchievementCriterion
    {
        /// <summary>
        /// Gets or sets the criterion identifier.
        /// </summary>
        public string criterionId { get; set; }
    }
}
