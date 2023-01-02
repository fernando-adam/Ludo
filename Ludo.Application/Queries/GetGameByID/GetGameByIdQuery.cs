using Ludo.Application.VIewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
