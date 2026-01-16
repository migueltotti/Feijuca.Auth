using Feijuca.Auth.Application.Requests.Realm;
using Mattioli.Configurations.Models;
using MediatR;

namespace Feijuca.Auth.Application.Queries.Realm
{
    public record EnableRealmCommand(EnableRealmRequest EnableRealmRequest) : IRequest<Result<bool>>;
}
