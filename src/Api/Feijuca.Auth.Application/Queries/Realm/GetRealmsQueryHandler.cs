using Feijuca.Auth.Application.Mappers;
using Feijuca.Auth.Application.Responses;
using Feijuca.Auth.Domain.Interfaces;
using LiteBus.Queries.Abstractions;

namespace Feijuca.Auth.Application.Queries.Realm
{
    public class GetRealmsQueryHandler(IRealmRepository _realmRepository, IConfigRepository configRepository) : IQueryHandler<GetRealmsQuery, IEnumerable<RealmResponse>>
    {
        public async Task<IEnumerable<RealmResponse>> HandleAsync(GetRealmsQuery request, CancellationToken cancellationToken)
        {
            var config = await configRepository.GetConfigAsync();
            var realms = await _realmRepository.GetAllAsync(cancellationToken);
            return realms.ToResponse(config.ServerSettings.Url);
        }
    }
}
