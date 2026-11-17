using System.Text.Json.Serialization;

namespace StarCraft2Models
{
    /// <summary>
    /// The ladder standing of a profile for the current season, the <c>snapshot</c> of a profile.
    /// </summary>
    public class ProfileSnapshot
    {
        /// <summary>
        /// Gets or sets the standing in each ladder mode.
        /// </summary>
        public SeasonSnapshot seasonSnapshot { get; set; }

        /// <summary>
        /// Gets or sets the number of ranked games played this season across all modes.
        /// </summary>
        public int totalRankedSeasonGamesPlayed { get; set; }
    }

    /// <summary>
    /// The standing in each ladder mode for the current season. The API keys these by mode name,
    /// <c>1v1</c>, <c>2v2</c>, <c>3v3</c>, <c>4v4</c> and <c>Archon</c>, which are not valid C# names.
    /// </summary>
    public class SeasonSnapshot
    {
        /// <summary>
        /// Gets or sets the 1v1 standing.
        /// </summary>
        [JsonPropertyName("1v1")]
        public LadderSnapshot oneVsOne { get; set; }

        /// <summary>
        /// Gets or sets the 2v2 standing.
        /// </summary>
        [JsonPropertyName("2v2")]
        public LadderSnapshot twoVsTwo { get; set; }

        /// <summary>
        /// Gets or sets the 3v3 standing.
        /// </summary>
        [JsonPropertyName("3v3")]
        public LadderSnapshot threeVsThree { get; set; }

        /// <summary>
        /// Gets or sets the 4v4 standing.
        /// </summary>
        [JsonPropertyName("4v4")]
        public LadderSnapshot fourVsFour { get; set; }

        /// <summary>
        /// Gets or sets the Archon standing. The API capitalizes this one.
        /// </summary>
        [JsonPropertyName("Archon")]
        public LadderSnapshot archon { get; set; }
    }

    /// <summary>
    /// The standing in a single ladder mode.
    /// </summary>
    public class LadderSnapshot
    {
        /// <summary>
        /// Gets or sets the rank within the division. 0 when the player is not ranked in this mode.
        /// </summary>
        public int rank { get; set; }

        /// <summary>
        /// Gets or sets the league, for example <c>GRANDMASTER</c> or <c>DIAMOND</c>.
        /// Null when the player is not ranked in this mode.
        /// </summary>
        public string leagueName { get; set; }

        /// <summary>
        /// Gets or sets the number of games played in this mode this season.
        /// </summary>
        public int totalGames { get; set; }

        /// <summary>
        /// Gets or sets the number of games won in this mode this season.
        /// </summary>
        public int totalWins { get; set; }
    }
}
