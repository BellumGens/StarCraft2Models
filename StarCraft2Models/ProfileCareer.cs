namespace StarCraft2Models
{
    /// <summary>
    /// The career totals and best league finishes of a profile, the <c>career</c> of a profile.
    /// </summary>
    public class ProfileCareer
    {
        /// <summary>
        /// Gets or sets the number of games won as Terran.
        /// </summary>
        public int terranWins { get; set; }

        /// <summary>
        /// Gets or sets the number of games won as Zerg.
        /// </summary>
        public int zergWins { get; set; }

        /// <summary>
        /// Gets or sets the number of games won as Protoss.
        /// </summary>
        public int protossWins { get; set; }

        /// <summary>
        /// Gets or sets the number of games played over the whole career.
        /// </summary>
        public int totalCareerGames { get; set; }

        /// <summary>
        /// Gets or sets the number of games played this season.
        /// </summary>
        public int totalGamesThisSeason { get; set; }

        /// <summary>
        /// Gets or sets the current 1v1 league. Null when the player is not ranked in 1v1 this season.
        /// </summary>
        public string current1v1LeagueName { get; set; }

        /// <summary>
        /// Gets or sets the best current team league. Null when the player is not ranked in a team mode this season.
        /// </summary>
        public string currentBestTeamLeagueName { get; set; }

        /// <summary>
        /// Gets or sets the best 1v1 league finish.
        /// </summary>
        public LeagueFinish best1v1Finish { get; set; }

        /// <summary>
        /// Gets or sets the best team league finish.
        /// </summary>
        public LeagueFinish bestTeamFinish { get; set; }
    }

    /// <summary>
    /// A best league finish and how many times it was achieved.
    /// </summary>
    public class LeagueFinish
    {
        /// <summary>
        /// Gets or sets the league, for example <c>MASTER</c>. Null when the player never finished a season ranked.
        /// </summary>
        public string leagueName { get; set; }

        /// <summary>
        /// Gets or sets the number of seasons the player finished in this league.
        /// </summary>
        public int timesAchieved { get; set; }
    }
}
