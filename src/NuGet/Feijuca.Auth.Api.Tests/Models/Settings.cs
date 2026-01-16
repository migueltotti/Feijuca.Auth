using Feijuca.Auth.Models;

namespace Feijuca.Auth.Api.Tests.Models;

public class Settings
{
    public required FeijucaAuthConfiguration Feijuca { get; init; }
}
