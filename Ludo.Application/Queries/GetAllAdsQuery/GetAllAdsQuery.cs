using Ludo.Application.VIewModels;
using MediatR;

namespace Ludo.Application.Queries.GetAllAdsQuery
{
    public class GetAllAdsQuery : IRequest<List<AdvertisementViewModel>>
    {
    }
}
