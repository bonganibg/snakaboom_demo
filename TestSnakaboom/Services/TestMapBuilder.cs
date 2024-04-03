using SnakeKaboomDemo.Enums;
using SnakeKaboomDemo.Services;
using Xunit.Sdk;

namespace TestSnakaboom.Services
{
    public class TestMapBuilder
    {
        private readonly IMapBuilder _map;
        private (int x, int y) boundaries = (5, 5);

        public TestMapBuilder()
        {
            _map = new MapBuilder(boundaries.x, boundaries.y);
        }

        [Theory]
        [InlineData(2,2)]
        [InlineData(2, 3)]
        [InlineData(3, 3)]
        public void IsWithinBounds_ShouldReturnTrueWhenCurrentPositionIsInBound(int x, int y)
        {   
            Direction direction = Direction.Left;
            var actual = _map.IsWithinBounds(direction, (x, y));

            Assert.True(actual);
        }

        [Theory]
        [InlineData(0, 0, Direction.Up)]
        [InlineData(0, 3, Direction.Left)]
        [InlineData(4, 2, Direction.Right)]
        [InlineData(1, 4, Direction.Down)]
        public void IsWithinBounds_ShouldReturnFalse_ValuesGreaterThanBounds(int x, int y, Direction direction)
        {
            var actual = _map.IsWithinBounds(direction, (x, y));

            Assert.False(actual, $"Position ({x}, {y}) Direction {direction}");
        }

        [Theory]
        [InlineData(0, 2, Direction.Left)]
        [InlineData(5, 2, Direction.Right)]
        [InlineData(2, 0, Direction.Up)]
        [InlineData(2, 5, Direction.Down)]
        public void GetWrappedPosition_ShouldWrapValue_WhenHitsBoundry(int x, int y, Direction direction)
        {
            var position = (x, y);
            var actual = _map.GetWrappedPosition(direction, position);

            var expected = (0, 0);

            switch (direction)
            {
                case Direction.Left:
                    expected = (boundaries.x - 1, position.y);
                    break;
                case Direction.Right:
                    expected = (1, position.y);
                    break;
                case Direction.Up:
                    expected = (position.x, boundaries.y - 1);
                    break;
                case Direction.Down:
                    expected = (position.x, 1);
                    break;
            }

            Assert.Equal(expected, actual);
        }
    }
}
