using SnakeKaboomDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SnakeKaboomDemo.Services
{
    public class FoodGenerator
    {
        private readonly (int x, int y) _screenDimensions;        
        public Dictionary<(int x, int y), Food> foodStore;
        private List<Food> snakeFood;

        public FoodGenerator((int x, int y) screenDimensions)
        {
            foodStore = new Dictionary<(int x, int y), Food>();
            _screenDimensions = (screenDimensions.x - 2, screenDimensions.y - 2);

            CreateSnakeFood();
        }

        private void CreateSnakeFood()
        {
            snakeFood = new List<Food>()
            {
                new Food("Rat", 20, 2, 'R'),
                new Food("Mouse", 20, 2, 'M'),
                new Food("Bird", 10, 4, 'B'),
                new Food("Egg", 40, 1, 'E')
            };
        }

        public void SpawnFood()
        {
            var foodLocation = GetRandomLocation();
            var food = snakeFood[new Random().Next(snakeFood.Count)];
            foodStore[foodLocation] = food;            
        }

        private (int x, int y) GetRandomLocation()
        {
            Random random = new Random();
            var x = random.Next(2, _screenDimensions.x);
            var y = random.Next(2, _screenDimensions.y);

            return (x, y);
        }

        public Dictionary<(int x, int y), Food> GetFoodPositions()
        {
            return foodStore;
        }
    }
}
