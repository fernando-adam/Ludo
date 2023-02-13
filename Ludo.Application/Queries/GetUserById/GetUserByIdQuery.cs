using Ludo.Application.VIewModels;
using MediatR;

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
