using Ludo.Application.VIewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Queries.GetAllGames
{
    public class GetAllGamesQuery: IRequest<List<GameViewModel>>
    {
    }
}
