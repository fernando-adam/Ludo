using Ludo.Application.VIewModels;
using MediatR;
namespace Ludo.Application.Queries.GetAdvertisementById
{
    public class GetAdvertisementByIdQuery : IRequest<AdvertisementViewModel>
    {
        public GetAdvertisementByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
