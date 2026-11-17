# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and this project
adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Releases before 11.0.0 predate this file. See the
[version history on NuGet](https://www.nuget.org/packages/StarCraft2Models/#versions-body-tab) and
the git log for those.

## [Unreleased]

## [11.0.0]

Moves the library to .NET 11 and maps the rest of the StarCraft II profile response. The models in
this release were checked field by field against the documented response shapes of the endpoints
they map.

### Breaking

- **The library now targets .NET 11.** 9.0.0 targeted .NET 9. Projects on .NET 10 or earlier
  cannot consume 11.0.0.
- **`ProfilePortrait` now serializes with the API's lower case names**, `x`, `y`, `w`, `h`,
  `offset` and `url`, rather than `X`, `Y` and so on. See Fixed below. Code that serialized a
  `ProfilePortrait` and read the json back by the old names needs to follow.

### Added

`PlayerProfile` used to map only the `summary` of `/sc2/profile/{regionId}/{realmId}/{profileId}`.
It now maps the whole response:

| Property | Model |
| --- | --- |
| `snapshot` | `ProfileSnapshot`, `SeasonSnapshot`, `LadderSnapshot` |
| `career` | `ProfileCareer`, `LeagueFinish` |
| `swarmLevels` | `SwarmLevels`, `RaceSwarmLevel` |
| `campaign` | `ProfileCampaign` |
| `categoryPointProgress` | `CategoryPointProgress` |
| `achievementShowcase` | `List<string>` |
| `earnedRewards` | `EarnedReward` |
| `earnedAchievements` | `EarnedAchievement`, `AchievementCriterion` |

- The ladder modes are keyed `1v1`, `2v2`, `3v3`, `4v4` and `Archon` in the API. They map to
  `oneVsOne`, `twoVsTwo`, `threeVsThree`, `fourVsFour` and `archon` and serialize back under the
  API names.
- Collections default to empty rather than null when the response leaves them out.
- A test suite covering every model.

### Fixed

- `ProfilePortrait` never deserialized with `System.Text.Json`. The API sends its fields in lower
  case and the default options match names case sensitively, so every field read as 0 or null.
