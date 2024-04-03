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
        private List<(int x, int y)> snake = new List<(int x, int y)>();   
        private readonly IMapBuilder _map;
        public (int x, int y) PreviousTail { get; set; }

        public SnakeBody(int x, int y, IMapBuilder map)
        {
            CurrentDirection = Direction.Right;
            _map = map;
            snake.Add((x, y));
        }

        public void GrowBody()
        {
            var lastPosition = snake.Last();
            snake.Add(lastPosition);
        }

        public void UpdateSnakePosition()
        {
            var nextPosition = Move(CurrentDirection, snake[0]);
            
            if (!_map.IsWithinBounds(CurrentDirection, nextPosition))
                nextPosition = _map.GetWrappedPosition(CurrentDirection, nextPosition);

            PreviousTail = snake[snake.Count - 1];
            AddToHead(nextPosition);
        }

        private void AddToHead((int x, int y) position)
        {
            snake.Reverse();
            snake.Add(position);

            snake.Reverse();
            snake.RemoveAt(snake.Count - 1);
        }

        public List<(int x, int y)> GetSnakePosition()
        {
            return snake;
        }
                
    }
}
