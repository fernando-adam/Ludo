using Ludo.Application.Queries.GetAllGames;
using Ludo.Core.Entities;
using Ludo.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.UnitTests.Application.Queries
{
    public class GetAllGamesCommandHandlerTests
    {
        [Fact]
        public async Task ThreeGamesExist_Executed_ReturnThreeGameViewModels()
        {
            //Arrange
            var games = new List<Game>
            {
                new Game("test name 1","test description 1","test category","test publisher","test language",2,2,2),
                new Game("test name 2","test description 2","test category","test publisher","test language",2,2,2),
                new Game("test name 3","test description 3","test category","test publisher","test language",2,2,2)
            };
            var gameRepositoryMock = new Mock<IGameRepository>();

            gameRepositoryMock.Setup(g => g.GetAllAsync().Result).Returns(games);

            var getAllGamesQuery = new GetAllGamesQuery();
            var getAllGamesQueryHandler = new GetAllGamesQueryHandler(gameRepositoryMock.Object);
            //Act

            var gameViewModelList = await getAllGamesQueryHandler.Handle(getAllGamesQuery, new CancellationToken());

            //Assert

            Assert.NotNull(gameViewModelList);
            Assert.NotEmpty(gameViewModelList);
            Assert.Equal(3, gameViewModelList.Count);

            gameRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
