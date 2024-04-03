using SnakeKaboomDemo.Enums;
using SnakeKaboomDemo.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TestSnakaboom.Mechanics
{
    public class TestMovement
    {
        private Movement movement = new Movement();

        [Theory]
        [InlineData(1, 1, Direction.Right, 2, 1)]
        [InlineData(1, 1, Direction.Down, 1, 2)]
        [InlineData(2, 2, Direction.Left, 1, 2)]
        [InlineData(2, 2, Direction.Up, 2, 1)]
        public void Move_ShouldChangeCoordinate_WhenMovingInDirection(int x, int y, Direction direction, int exp_x, int exp_y)
        {
            var actual = movement.Move(direction, (x, y));

            var expected = (exp_x, exp_y);

            Assert.Equal(expected, actual);
        }
    }
}
