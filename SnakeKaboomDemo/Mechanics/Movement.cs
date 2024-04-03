using SnakeKaboomDemo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeKaboomDemo.Mechanics
{
    public class Movement
    {
        public (int x, int y) Move(Direction direction, (int x, int y) currentPosition)
        {
            switch(direction)
            {
                case Direction.Left:
                    return (currentPosition.x - 1, currentPosition.y);
                case Direction.Right:
                    return (currentPosition.x + 1, currentPosition.y);
                case Direction.Up:
                    return (currentPosition.x, currentPosition.y - 1);
                case Direction.Down:
                    return (currentPosition.x, currentPosition.y + 1);
            }

            throw new Exception("Invalid Direction");
        }        
    }
}
