using System.Text.Json;

namespace StarCraft2Models.Tests
{
    public class ProfilePortraitTests
    {
        [Fact]
        public void Deserializes_the_lower_case_api_fields()
        {
            // The API sends x, y, w, h, offset and url in lower case. Without explicit json names the
            // PascalCase properties never matched under the default, case sensitive, options.
            ProfilePortrait portrait = Payloads.Parse<ProfilePortrait>(Payloads.LegacyPortrait);

            Assert.Equal(-90, portrait.X);
            Assert.Equal(-180, portrait.Y);
            Assert.Equal(90, portrait.W);
            Assert.Equal(90, portrait.H);
            Assert.Equal(14, portrait.Offset);
            Assert.Equal("https://static.starcraft2.com/starport/portraits-1-90.jpg", portrait.Url);
        }

        [Fact]
        public void Serializes_with_the_api_field_names()
        {
            string json = JsonSerializer.Serialize(Payloads.Parse<ProfilePortrait>(Payloads.LegacyPortrait));

            Assert.Equal(
                """{"x":-90,"y":-180,"w":90,"h":90,"offset":14,"url":"https://static.starcraft2.com/starport/portraits-1-90.jpg"}""",
                json);
        }
    }
}
