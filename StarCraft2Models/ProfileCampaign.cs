using System.Collections.Generic;

namespace StarCraft2Models
{
    /// <summary>
    /// The campaign progress of a profile, the <c>campaign</c> of a profile.
    /// </summary>
    public class ProfileCampaign
    {
        /// <summary>
        /// Gets or sets the hardest difficulty completed in each campaign, keyed by the campaign slug,
        /// for example <c>wings-of-liberty</c> or <c>heart-of-the-swarm</c>, with values such as
        /// <c>BRUTAL</c>. It is a dictionary rather than a property per campaign so that campaigns
        /// added to the response later, such as <c>legacy-of-the-void</c>, still come through.
        /// </summary>
        public Dictionary<string, string> difficultyCompleted { get; set; } = new();
    }
}
