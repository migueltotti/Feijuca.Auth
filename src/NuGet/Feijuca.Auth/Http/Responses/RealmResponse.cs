namespace Feijuca.Auth.Http.Responses
{
    public record RealmResponse(string Realm, string Issuer, string DisplayName, bool Enabled);
}
