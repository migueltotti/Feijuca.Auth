using Feijuca.Auth.Application.Responses;
using LiteBus.Queries.Abstractions;

namespace Feijuca.Auth.Application.Queries.Realm
{
    public record GetRealmsQuery() : IQuery<IEnumerable<RealmResponse>>;
}
