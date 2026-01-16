namespace Feijuca.Auth.Models
{
    public sealed record FeijucaAuthConfiguration
    {
        public required string Url { get; init; }
    }
}
