using SnakeKaboomDemo.Enums;
using SnakeKaboomDemo.Mechanics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnakeKaboomDemo.Services
{
    public class SnakeBody : Movement
    {        
        public Direction CurrentDirection { get; set; }
        private List<(int x, int y)> snake;           
        private readonly IMapBuilder _map;

        public SnakeBody(int x, int y, IMapBuilder map)
        {
            snake = new List<(int x, int y)>();
            snake.Add((x, y));
            
            _map = map;
        }

        public void GrowBody()
        {
            var lastPosition = snake.Last();
            snake.Add(lastPosition);
        }

        public void UpdateSnakeOnMap()
        {
            var nextPosition = Move(CurrentDirection, snake.First());
            
            if (!_map.IsWithinBounds(CurrentDirection, nextPosition))
                nextPosition = _map.GetWrappedPosition(CurrentDirection, nextPosition);

            snake.Add(nextPosition);
            snake.RemoveAt(snake.Count - 1);
        }

                
    }
}
