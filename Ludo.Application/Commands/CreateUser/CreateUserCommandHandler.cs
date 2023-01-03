using Ludo.Core.Entities;
using Ludo.Core.Interfaces;
using Ludo.Core.Services;
using Ludo.Infra.Persistance;
using Ludo.Infra.Persistence.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private IUserRepository _userRepository;
        private IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(
                request.FirstName,
                request.LastName,
                request.Email,
                passwordHash,
                request.Role,
                request.BirthDate);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
