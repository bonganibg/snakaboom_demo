using SnakeKaboomDemo.Enums;
using SnakeKaboomDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TestSnakaboom.Services
{
    public class TestSnakeBody
    {
        private SnakeBody snake;
        private readonly IMapBuilder _map;

        public TestSnakeBody()
        {
            _map = new MapBuilder(5,5);
            snake = new SnakeBody(3, 3, _map);
        }

        [Fact]
        public void GrowBody_ShouldAddMoreItemsToList()
        {
            var initialLength = snake.GetSnakePosition().Count;
            var expected = initialLength + 1;

            // Add a new boy part
            snake.GrowBody();

            // Check the new length 
            var actual = snake.GetSnakePosition().Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdateSnakePosition_HeadXCoodMustINcrememnt_WhenDirectionIsRight()
        {
            var snake = new SnakeBody(1, 1, _map);
            snake.CurrentDirection = Direction.Right;

            var initialPosition = snake.GetSnakePosition()[0];
            var expectedPosition = (initialPosition.x + 1, initialPosition.y);

            snake.UpdateSnakePosition();

            var actualPosition = snake.GetSnakePosition()[0];


            Assert.True(expectedPosition == actualPosition, $"Initial Position: {initialPosition}\n" +
                                            $"Expected: {expectedPosition}" +
                                            $"\nActual: {actualPosition}");
        }

        [Fact]
        public void UpdateSnakePosition_HeadXCoodMustDecrememnt_WhenDirectionIsLeft()
        {
            var snake = new SnakeBody(3, 1, _map);
            snake.CurrentDirection = Direction.Left;

            var initialPosition = snake.GetSnakePosition()[0];
            var expectedPosition = (initialPosition.x - 1, initialPosition.y);

            snake.UpdateSnakePosition();

            var actualPosition = snake.GetSnakePosition()[0];


            Assert.True(expectedPosition == actualPosition, $"Initial Position: {initialPosition}\n" +
                                            $"Expected: {expectedPosition}" +
                                            $"\nActual: {actualPosition}");
        }

        [Fact]
        public void UpdateSnakePosition_HeadYCoodMustIncrememnt_WhenDirectionIsDown()
        {
            var snake = new SnakeBody(1, 1, _map);
            snake.CurrentDirection = Direction.Down;

            var initialPosition = snake.GetSnakePosition()[0];
            var expectedPosition = (initialPosition.x, initialPosition.y + 1);

            snake.UpdateSnakePosition();

            var actualPosition = snake.GetSnakePosition()[0];


            Assert.True(expectedPosition == actualPosition, $"Initial Position: {initialPosition}\n" +
                                            $"Expected: {expectedPosition}" +
                                            $"\nActual: {actualPosition}");
        }

        [Fact]
        public void UpdateSnakePosition_HeadXCoodMustDecrememnt_WhenDirectionIsUp()
        {
            var snake = new SnakeBody(1, 3, _map);
            snake.CurrentDirection = Direction.Up;

            var initialPosition = snake.GetSnakePosition()[0];
            var expectedPosition = (initialPosition.x, initialPosition.y - 1);

            snake.UpdateSnakePosition();

            var actualPosition = snake.GetSnakePosition()[0];


            Assert.True(expectedPosition == actualPosition, $"Initial Position: {initialPosition}\n" +
                                            $"Expected: {expectedPosition}" +
                                            $"\nActual: {actualPosition}");
        }
    }
}
