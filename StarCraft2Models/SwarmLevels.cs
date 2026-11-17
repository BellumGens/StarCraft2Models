namespace StarCraft2Models
{
    /// <summary>
    /// The overall and per race swarm levels of a profile, the <c>swarmLevels</c> of a profile.
    /// </summary>
    public class SwarmLevels
    {
        /// <summary>
        /// Gets or sets the combined swarm level, the sum of the three race levels.
        /// </summary>
        public int level { get; set; }

        /// <summary>
        /// Gets or sets the Terran level.
        /// </summary>
        public RaceSwarmLevel terran { get; set; }

        /// <summary>
        /// Gets or sets the Zerg level.
        /// </summary>
        public RaceSwarmLevel zerg { get; set; }

        /// <summary>
        /// Gets or sets the Protoss level.
        /// </summary>
        public RaceSwarmLevel protoss { get; set; }
    }

    /// <summary>
    /// The level of a single race and the progress towards the next one.
    /// </summary>
    public class RaceSwarmLevel
    {
        /// <summary>
        /// Gets or sets the race level.
        /// </summary>
        public int level { get; set; }

        /// <summary>
        /// Gets or sets the experience needed to complete the current level.
        /// </summary>
        public int maxLevelPoints { get; set; }

        /// <summary>
        /// Gets or sets the experience earned so far towards the next level.
        /// </summary>
        public int currentLevelPoints { get; set; }
    }
}
