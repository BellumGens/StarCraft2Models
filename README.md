# StarCraft2Models

[![Publish](https://github.com/BellumGens/StarCraft2Models/actions/workflows/publish.yml/badge.svg)](https://github.com/BellumGens/StarCraft2Models/actions/workflows/publish.yml)
[![.NET](https://github.com/BellumGens/StarCraft2Models/actions/workflows/dotnet.yml/badge.svg)](https://github.com/BellumGens/StarCraft2Models/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/BellumGens/StarCraft2Models/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/BellumGens/StarCraft2Models/actions/workflows/codeql-analysis.yml)
[![NuGet](https://img.shields.io/nuget/v/StarCraft2Models)](https://www.nuget.org/packages/StarCraft2Models/)

.NET models for StarCraft 2 battle.net API entities.

## Models

Property names match the wire format, so the models deserialize with the default
`System.Text.Json` options. Where the API uses names that are not valid C# identifiers, such as
the `1v1` ladder mode, the property carries a `[JsonPropertyName]` with the API name.

| Model | Endpoint |
| --- | --- |
| `Player[]` | `/sc2/player/{accountId}` |
| `Player` | `/sc2/metadata/profile/{regionId}/{realmId}/{profileId}` |
| `PlayerProfile` | `/sc2/profile/{regionId}/{realmId}/{profileId}` |
| `ProfilePortrait` | The `portrait` of the legacy profile endpoints |

`PlayerProfile` covers the whole profile response: `summary`, the current season's ladder
`snapshot`, `career`, `swarmLevels`, `campaign`, `categoryPointProgress`, `achievementShowcase`,
`earnedRewards` and `earnedAchievements`.

The metadata endpoint returns the same flat shape as an entry of the player endpoint, not a
`PlayerProfile`. Deserializing it into `PlayerProfile` does not fail, it just leaves `summary` null.

```csharp
using System.Text.Json;
using StarCraft2Models;

PlayerProfile profile = JsonSerializer.Deserialize<PlayerProfile>(json);
string league = profile.snapshot?.seasonSnapshot?.oneVsOne?.leagueName; // null when unranked
```

## Testing

```
dotnet test
```

The test suite covers the payload shapes the models map, including the quirks that are easy to
regress: the `1v1` and `Archon` ladder mode keys, unranked modes reported with a null league, the
achievement `completionDate` the API sends in exponent notation, and the lower case legacy
portrait fields.

## Releasing

Releases go out through GitHub Actions. Publishing a GitHub Release runs
[`publish.yml`](.github/workflows/publish.yml), which builds, runs the tests, packs and pushes to
NuGet.org.

Record what changed in [`CHANGELOG.md`](CHANGELOG.md) before you cut the release, so the release
notes and the changelog agree.

The release tag is the version. Tag a release `v11.0.0`, and that is the version the package, the
assembly and the file version all carry, so there is no version to bump in the csproj. The
`<Version>` in `StarCraft2Models/StarCraft2Models.csproj` is only the local default for
`dotnet build` and `dotnet pack` runs on your machine. Prereleases work the same way, tag them
`v11.0.0-beta.1`. A tag that is not a version fails the workflow before anything is published.

### Authentication

The workflow authenticates to NuGet.org with
[Trusted Publishing](https://learn.microsoft.com/nuget/nuget-org/trusted-publishing), so there is
no API key stored in the repository. The job mints a GitHub OIDC token, NuGet.org exchanges it for
an API key that lives a few minutes, and that key is used for the single push. Nothing long lived
exists to leak or rotate.

It needs a one time setup on NuGet.org, under your account, Trusted Publishing:

| Field | Value |
| --- | --- |
| Package owner | `kdinev` |
| Repository owner | `BellumGens` |
| Repository | `StarCraft2Models` |
| Workflow file | `publish.yml` |

The workflow file name has to match, so renaming `publish.yml` means updating the policy too.
If the NuGet.org account ever changes, set a `NUGET_USER` repository variable rather than editing
the workflow. The push uses `--skip-duplicate`, so re-running a release that already shipped is a
no-op rather than a failure.
