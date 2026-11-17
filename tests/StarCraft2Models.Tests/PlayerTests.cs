namespace StarCraft2Models.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Deserializes_the_player_account_response()
        {
            Player[] players = Payloads.Parse<Player[]>(Payloads.PlayerAccount);

            Assert.Equal(2, players.Length);

            Player eu = players[0];
            Assert.Equal("SamplePlayer", eu.name);
            Assert.Equal("https://starcraft2.blizzard.com/profile/2/1/315071", eu.profileUrl);
            Assert.EndsWith("/portraits/1-24.jpg", eu.avatarUrl);
            Assert.Equal("315071", eu.profileId);
            Assert.Equal(2, eu.regionId);
            Assert.Equal(1, eu.realmId);

            Assert.Equal("7052911", players[1].profileId);
            Assert.Equal(1, players[1].regionId);
        }

        [Fact]
        public void Deserializes_the_profile_metadata_response()
        {
            Player player = Payloads.Parse<Player>(Payloads.ProfileMetadata);

            Assert.Equal("SamplePlayer", player.name);
            Assert.Equal("315071", player.profileId);
            Assert.Equal(2, player.regionId);
            Assert.Equal(1, player.realmId);
        }

        [Fact]
        public void The_profile_metadata_response_is_not_a_player_profile()
        {
            // The metadata endpoint is flat, it has no summary. Reading it as a PlayerProfile silently
            // produces an empty profile rather than failing, which is easy to miss.
            PlayerProfile profile = Payloads.Parse<PlayerProfile>(Payloads.ProfileMetadata);

            Assert.Null(profile.summary);
        }

        [Fact]
        public void An_account_without_profiles_is_an_empty_array()
        {
            Assert.Empty(Payloads.Parse<Player[]>("[]"));
        }
    }
}
