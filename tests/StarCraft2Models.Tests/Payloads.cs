using System.Text.Json;

namespace StarCraft2Models.Tests
{
    /// <summary>
    /// Sample battle.net StarCraft II API payloads shared across the test suites. They are trimmed
    /// down but keep the shape, the field names and the quirks of what the API returns.
    /// </summary>
    internal static class Payloads
    {
        /// <summary>
        /// A <c>/sc2/player/{accountId}</c> response: one entry per region the account has played in.
        /// </summary>
        public const string PlayerAccount = """
        [
          {"name":"SamplePlayer","profileUrl":"https://starcraft2.blizzard.com/profile/2/1/315071",
           "avatarUrl":"https://static.starcraft2.com/starport/d0e7c831-18ab-4cd5-9b7c-ae2d5c80b9c1/portraits/1-24.jpg",
           "profileId":"315071","regionId":2,"realmId":1},
          {"name":"SamplePlayer","profileUrl":"https://starcraft2.blizzard.com/profile/1/1/7052911",
           "avatarUrl":"https://static.starcraft2.com/starport/d0e7c831-18ab-4cd5-9b7c-ae2d5c80b9c1/portraits/1-24.jpg",
           "profileId":"7052911","regionId":1,"realmId":1}
        ]
        """;

        /// <summary>
        /// A <c>/sc2/metadata/profile/{regionId}/{realmId}/{profileId}</c> response. It is the same flat
        /// shape as an entry of <see cref="PlayerAccount"/>, not a <see cref="PlayerProfile"/>.
        /// </summary>
        public const string ProfileMetadata = """
        {"name":"SamplePlayer","profileUrl":"https://starcraft2.blizzard.com/profile/2/1/315071",
         "avatarUrl":"https://static.starcraft2.com/starport/d0e7c831-18ab-4cd5-9b7c-ae2d5c80b9c1/portraits/1-24.jpg",
         "profileId":"315071","regionId":2,"realmId":1}
        """;

        /// <summary>
        /// A <c>/sc2/profile/{regionId}/{realmId}/{profileId}</c> response. The player is ranked in 1v1
        /// and in 2v2 but not in 3v3, 4v4 or Archon, which the API reports as a zero rank and a null league.
        /// </summary>
        public const string Profile = """
        {
          "summary":{"id":"315071","realm":1,"displayName":"SamplePlayer",
            "portrait":"https://static.starcraft2.com/starport/d0e7c831-18ab-4cd5-9b7c-ae2d5c80b9c1/portraits/1-24.jpg",
            "decalTerran":"https://static.starcraft2.com/starport/d0e7c831-18ab-4cd5-9b7c-ae2d5c80b9c1/decals/0-0.jpg",
            "decalProtoss":"https://static.starcraft2.com/starport/d0e7c831-18ab-4cd5-9b7c-ae2d5c80b9c1/decals/0-1.jpg",
            "decalZerg":"https://static.starcraft2.com/starport/d0e7c831-18ab-4cd5-9b7c-ae2d5c80b9c1/decals/0-2.jpg",
            "totalSwarmLevel":412,"totalAchievementPoints":7925},
          "snapshot":{
            "seasonSnapshot":{
              "1v1":{"rank":3,"leagueName":"GRANDMASTER","totalGames":412,"totalWins":301},
              "2v2":{"rank":57,"leagueName":"DIAMOND","totalGames":12,"totalWins":8},
              "3v3":{"rank":0,"leagueName":null,"totalGames":0,"totalWins":0},
              "4v4":{"rank":0,"leagueName":null,"totalGames":0,"totalWins":0},
              "Archon":{"rank":0,"leagueName":null,"totalGames":0,"totalWins":0}
            },
            "totalRankedSeasonGamesPlayed":424
          },
          "career":{"terranWins":12,"zergWins":9842,"protossWins":31,"totalCareerGames":14210,
            "totalGamesThisSeason":424,"current1v1LeagueName":"GRANDMASTER","currentBestTeamLeagueName":"DIAMOND",
            "best1v1Finish":{"leagueName":"GRANDMASTER","timesAchieved":38},
            "bestTeamFinish":{"leagueName":"MASTER","timesAchieved":2}},
          "swarmLevels":{"level":412,
            "terran":{"level":45,"maxLevelPoints":150000,"currentLevelPoints":82000},
            "zerg":{"level":322,"maxLevelPoints":150000,"currentLevelPoints":12000},
            "protoss":{"level":45,"maxLevelPoints":150000,"currentLevelPoints":5000}},
          "campaign":{"difficultyCompleted":{"wings-of-liberty":"BRUTAL","heart-of-the-swarm":"HARD"}},
          "categoryPointProgress":[{"categoryId":"4325382","pointsEarned":2210},{"categoryId":"4325410","pointsEarned":980}],
          "achievementShowcase":["91475320766632","91475035553845"],
          "earnedRewards":[
            {"rewardId":"97399582669","selected":true,"achievementId":"91475320766632","category":"Portrait"},
            {"rewardId":"2009110693","selected":false}
          ],
          "earnedAchievements":[
            {"achievementId":"91475320766632","completionDate":1.58058432E9,
             "numCompletedAchievementsInSeries":3,"totalAchievementsInSeries":5,"isComplete":true,"inProgress":false,
             "criteria":[{"criterionId":"91475320766633"},{"criterionId":"91475320766634"}]},
            {"achievementId":"91475035553845","completionDate":0,
             "numCompletedAchievementsInSeries":0,"totalAchievementsInSeries":1,"isComplete":false,"inProgress":true,
             "criteria":[],"nextProgressEarnedQuantity":40,"nextProgressRequiredQuantity":100}
          ]
        }
        """;

        /// <summary>
        /// The portrait of a legacy profile, as returned by the legacy profile endpoints.
        /// </summary>
        public const string LegacyPortrait = """
        {"x":-90,"y":-180,"w":90,"h":90,"offset":14,"url":"https://static.starcraft2.com/starport/portraits-1-90.jpg"}
        """;

        /// <summary>
        /// Deserializes the way consumers of the package do, with the default
        /// <see cref="JsonSerializer"/> options, which match property names case sensitively.
        /// </summary>
        public static T Parse<T>(string json) => JsonSerializer.Deserialize<T>(json);
    }
}
