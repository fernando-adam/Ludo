using Ludo.Application.Commands.CreateGameCommand;
using Ludo.Core.Entities;
using Ludo.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.UnitTests.Application.Commands
{
    public class CreateGameCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsValid_Executed_ReturnGameId()
        {
            //Arrange
            var gameRepository = new Mock<IGameRepository>();

            var createGameCommand = new CreateGameCommand()
            {
                Title = "Test",
                Description = "Test",
                Category = "Test",
                Publisher = "Test",
                Language = "Test",
                MinimumNumberOfPlayers = 1,
                MaximumNumberOfPlayers = 1,
                Age = 1,
            };

            var createGameCommandHandler = new CreateGameCommandHandler(gameRepository.Object);
            
            //Act
            var id = await createGameCommandHandler.Handle(createGameCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);
            gameRepository.Verify(pr => pr.AddAsync(It.IsAny<Game>()), Times.Once);
        }
    }
}
