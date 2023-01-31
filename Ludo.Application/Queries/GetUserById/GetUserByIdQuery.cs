using Ludo.Application.VIewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Queries.GetUserById
{
    public class GetUserByIdQuery: IRequest<UserViewModel>
    {
        public GetUserByIdQuery(int id)
        {
            UserId = id;
        }

        public int UserId { get; set; }
    }
}
