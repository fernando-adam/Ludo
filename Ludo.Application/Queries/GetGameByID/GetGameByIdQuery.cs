using Ludo.Application.VIewModels;
using MediatR;

namespace Ludo.Application.Queries.GetGameByID
{
    public class GetGameByIdQuery: IRequest<GameViewModel>
    {
        public GetGameByIdQuery(int id) 
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
