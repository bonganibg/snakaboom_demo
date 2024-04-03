using SnakeKaboomDemo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeKaboomDemo.Services
{
    public class MapBuilder : IMapBuilder
    {
        public int Height { get; internal set; }
        public int Width { get; internal set; }

        public MapBuilder(int height, int width)
        {
            Height = height;
            Width = width;

            CreateScreenBoundaries();
        }

        /// <summary>
        /// Sets the screen boundraies
        /// </summary>
        public void CreateScreenBoundaries()
        {
            Console.WindowHeight = Height;
            Console.WindowWidth = Width;
            Console.SetBufferSize(Width, Height);
        }

        /// <summary>
        /// Builds the map boundaries
        /// </summary>
        public void BuildMap()
        {
            // Set the horizontal border
            for (int i = 0; i < Width - 1; i++)
            {
                DrawMapObject((i, Height - 1), '+');
                DrawMapObject((i, 0), '+');
            }

            // Draw verital border
            for (int i = 0; i < Height; i++)
            {
                DrawMapObject((Width - 1, i), '+');
                DrawMapObject((0, i), '+');
            }
        }

        /// <summary>
        /// Adds a map object at a specified position
        /// </summary>
        /// <param name="position"> Where the item should be placed </param>
        /// <param name="value"> The characters to be included </param>
        private void DrawMapObject((int x, int y) position, char value)
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.Write(value);
        }


        /// <summary>
        /// Checks if the character is currently within the map boundaries
        /// </summary>
        /// <param name="direction"> Where the player is facing </param>
        /// <param name="currentPosition"> Where the character currently is </param>
        /// <returns></returns>
        public bool IsWithinBounds(Direction direction, (int x, int y) currentPosition)
        {
            if (direction == Direction.Left || direction == Direction.Right)
                return currentPosition.x >= Width || currentPosition.x <= 0 ? false : true;

            return currentPosition.y >= Height || currentPosition.y <= 0 ? true : false;
        }

        /// <summary>
        /// Get the new position of the snakes head if it goes beyond the boundaries
        /// </summary>
        /// <param name="direction"> The direction that the head is going in </param>
        /// <param name="currentPosition"> The current position of the head </param>
        /// <returns> The wrapped position of the snakes head </returns>
        /// <exception cref="Exception"></exception>
        public (int x, int y) GetWrappedPosition(Direction direction, (int x, int y) currentPosition)
        {
            switch(direction)
            {
                case Direction.Left:
                    return (Width - 2, currentPosition.y);
                case Direction.Right:
                    return (1, currentPosition.y);
                case Direction.Up:
                    return (currentPosition.x, Height - 2);
                case Direction.Down:
                    return (currentPosition.x, 1);                                    
            }

            throw new Exception("Direction not found");
        }
    }
}
