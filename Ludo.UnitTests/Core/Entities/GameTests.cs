using Ludo.Core.Entities;

namespace Ludo.UnitTests.Core.Entities
{
    public class GameTests
    {
        [Fact]
        public void TestIfGameUpdateWorks()
        {
            var game = new Game(
                "Test name",
                "Description name",
                "test category",
                "test publisher",
                "language test",
                2,
                2,
                10);

            Assert.Equal("Test name", game.Title);
            Assert.Equal("Description name", game.Description);


            game.Update("Title update", "description update");

            Assert.Equal("Title update", game.Title);
            Assert.Equal("description update", game.Description);
            Assert.NotNull(game.Title);
            Assert.NotNull(game.Description);

        }
    }
}
