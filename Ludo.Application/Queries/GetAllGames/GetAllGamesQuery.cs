using Ludo.Application.VIewModels;
using MediatR;

namespace Ludo.Application.Queries.GetAllGames
{
    public class GetAllGamesQuery: IRequest<List<GameViewModel>>
    {
    }
}
