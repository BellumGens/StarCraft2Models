using System.Text.Json;

namespace StarCraft2Models.Tests
{
    public class PlayerProfileTests
    {
        private static PlayerProfile Profile() => Payloads.Parse<PlayerProfile>(Payloads.Profile);

        [Fact]
        public void Deserializes_the_summary()
        {
            PlayerProfileSummary summary = Profile().summary;

            Assert.NotNull(summary);
            Assert.Equal("315071", summary.id);
            Assert.Equal(1, summary.realm);
            Assert.Equal("SamplePlayer", summary.displayName);
            Assert.EndsWith("/portraits/1-24.jpg", summary.portrait);
            Assert.EndsWith("/decals/0-0.jpg", summary.decalTerran);
            Assert.EndsWith("/decals/0-1.jpg", summary.decalProtoss);
            Assert.EndsWith("/decals/0-2.jpg", summary.decalZerg);
            Assert.Equal(412, summary.totalSwarmLevel);
            Assert.Equal(7925, summary.totalAchievementPoints);
        }

        [Fact]
        public void Deserializes_the_ladder_snapshot()
        {
            ProfileSnapshot snapshot = Profile().snapshot;

            Assert.Equal(424, snapshot.totalRankedSeasonGamesPlayed);

            LadderSnapshot oneVsOne = snapshot.seasonSnapshot.oneVsOne;
            Assert.Equal(3, oneVsOne.rank);
            Assert.Equal("GRANDMASTER", oneVsOne.leagueName);
            Assert.Equal(412, oneVsOne.totalGames);
            Assert.Equal(301, oneVsOne.totalWins);

            Assert.Equal("DIAMOND", snapshot.seasonSnapshot.twoVsTwo.leagueName);
            Assert.Equal(57, snapshot.seasonSnapshot.twoVsTwo.rank);
        }

        [Fact]
        public void Unranked_modes_have_a_zero_rank_and_no_league()
        {
            SeasonSnapshot season = Profile().snapshot.seasonSnapshot;

            foreach (LadderSnapshot mode in new[] { season.threeVsThree, season.fourVsFour, season.archon })
            {
                Assert.NotNull(mode);
                Assert.Equal(0, mode.rank);
                Assert.Null(mode.leagueName);
                Assert.Equal(0, mode.totalGames);
            }
        }

        [Fact]
        public void Deserializes_the_career()
        {
            ProfileCareer career = Profile().career;

            Assert.Equal(12, career.terranWins);
            Assert.Equal(9842, career.zergWins);
            Assert.Equal(31, career.protossWins);
            Assert.Equal(14210, career.totalCareerGames);
            Assert.Equal(424, career.totalGamesThisSeason);
            Assert.Equal("GRANDMASTER", career.current1v1LeagueName);
            Assert.Equal("DIAMOND", career.currentBestTeamLeagueName);
            Assert.Equal("GRANDMASTER", career.best1v1Finish.leagueName);
            Assert.Equal(38, career.best1v1Finish.timesAchieved);
            Assert.Equal("MASTER", career.bestTeamFinish.leagueName);
            Assert.Equal(2, career.bestTeamFinish.timesAchieved);
        }

        [Fact]
        public void Deserializes_the_swarm_levels()
        {
            SwarmLevels levels = Profile().swarmLevels;

            Assert.Equal(412, levels.level);
            Assert.Equal(45, levels.terran.level);
            Assert.Equal(322, levels.zerg.level);
            Assert.Equal(45, levels.protoss.level);
            Assert.Equal(150000, levels.terran.maxLevelPoints);
            Assert.Equal(82000, levels.terran.currentLevelPoints);
            // the overall level is the sum of the race levels
            Assert.Equal(levels.level, levels.terran.level + levels.zerg.level + levels.protoss.level);
        }

        [Fact]
        public void Deserializes_the_campaign_progress()
        {
            ProfileCampaign campaign = Profile().campaign;

            Assert.Equal(2, campaign.difficultyCompleted.Count);
            Assert.Equal("BRUTAL", campaign.difficultyCompleted["wings-of-liberty"]);
            Assert.Equal("HARD", campaign.difficultyCompleted["heart-of-the-swarm"]);
            Assert.False(campaign.difficultyCompleted.ContainsKey("legacy-of-the-void"));
        }

        [Fact]
        public void Deserializes_the_achievement_category_points_and_showcase()
        {
            PlayerProfile profile = Profile();

            Assert.Equal(2, profile.categoryPointProgress.Count);
            Assert.Equal("4325382", profile.categoryPointProgress[0].categoryId);
            Assert.Equal(2210, profile.categoryPointProgress[0].pointsEarned);

            Assert.Equal(new[] { "91475320766632", "91475035553845" }, profile.achievementShowcase);
        }

        [Fact]
        public void Deserializes_the_earned_rewards()
        {
            List<EarnedReward> rewards = Profile().earnedRewards;

            Assert.Equal(2, rewards.Count);
            Assert.Equal("97399582669", rewards[0].rewardId);
            Assert.True(rewards[0].selected);
            Assert.Equal("91475320766632", rewards[0].achievementId);
            Assert.Equal("Portrait", rewards[0].category);

            // achievementId and category are optional
            Assert.False(rewards[1].selected);
            Assert.Null(rewards[1].achievementId);
            Assert.Null(rewards[1].category);
        }

        [Fact]
        public void Deserializes_a_completed_achievement()
        {
            EarnedAchievement achievement = Profile().earnedAchievements[0];

            Assert.Equal("91475320766632", achievement.achievementId);
            Assert.True(achievement.isComplete);
            Assert.False(achievement.inProgress);
            Assert.Equal(3, achievement.numCompletedAchievementsInSeries);
            Assert.Equal(5, achievement.totalAchievementsInSeries);
            Assert.Equal(new[] { "91475320766633", "91475320766634" }, achievement.criteria.Select(c => c.criterionId));
            Assert.Equal(0, achievement.nextProgressEarnedQuantity);
            Assert.Equal(0, achievement.nextProgressRequiredQuantity);
        }

        [Fact]
        public void The_completion_date_is_read_from_exponent_notation()
        {
            // The API sends completionDate as a float, e.g. 1.58058432E9, which an integer property
            // cannot read. It is seconds since the Unix epoch.
            double completionDate = Profile().earnedAchievements[0].completionDate;

            Assert.Equal(1580584320d, completionDate);
            Assert.Equal(new DateTimeOffset(2020, 2, 1, 19, 12, 0, TimeSpan.Zero),
                DateTimeOffset.FromUnixTimeSeconds((long)completionDate));
        }

        [Fact]
        public void Deserializes_an_achievement_in_progress()
        {
            EarnedAchievement achievement = Profile().earnedAchievements[1];

            Assert.False(achievement.isComplete);
            Assert.True(achievement.inProgress);
            Assert.Empty(achievement.criteria);
            Assert.Equal(40, achievement.nextProgressEarnedQuantity);
            Assert.Equal(100, achievement.nextProgressRequiredQuantity);
        }

        [Fact]
        public void A_summary_only_profile_still_deserializes()
        {
            PlayerProfile profile = Payloads.Parse<PlayerProfile>("""
            {"summary":{"id":"1234567","realm":1,"displayName":"TestPlayer","totalSwarmLevel":0,"totalAchievementPoints":0}}
            """);

            Assert.Equal("1234567", profile.summary.id);
            Assert.Null(profile.snapshot);
            Assert.Null(profile.career);
            Assert.Null(profile.swarmLevels);
            Assert.Null(profile.campaign);
        }

        [Fact]
        public void Absent_collections_come_back_empty_rather_than_null()
        {
            PlayerProfile profile = Payloads.Parse<PlayerProfile>("""{"summary":{"id":"1"}}""");

            Assert.Empty(profile.categoryPointProgress);
            Assert.Empty(profile.achievementShowcase);
            Assert.Empty(profile.earnedRewards);
            Assert.Empty(profile.earnedAchievements);
            Assert.Empty(new ProfileCampaign().difficultyCompleted);
            Assert.Empty(new EarnedAchievement().criteria);
        }

        [Fact]
        public void Unknown_fields_are_ignored()
        {
            PlayerProfile profile = Payloads.Parse<PlayerProfile>("""
            {"summary":{"id":"1","clanTag":"BG"},"someFutureSection":{"value":1}}
            """);

            Assert.Equal("1", profile.summary.id);
        }

        [Fact]
        public void Serializes_with_the_api_field_names()
        {
            // Round tripping matters to consumers that cache or forward the profile as json.
            string json = JsonSerializer.Serialize(Profile());

            Assert.Contains("\"1v1\":", json);
            Assert.Contains("\"Archon\":", json);
            Assert.DoesNotContain("oneVsOne", json);

            PlayerProfile roundTripped = Payloads.Parse<PlayerProfile>(json);
            Assert.Equal("GRANDMASTER", roundTripped.snapshot.seasonSnapshot.oneVsOne.leagueName);
            Assert.Equal("BRUTAL", roundTripped.campaign.difficultyCompleted["wings-of-liberty"]);
            Assert.Equal(1580584320d, roundTripped.earnedAchievements[0].completionDate);
        }
    }
}
