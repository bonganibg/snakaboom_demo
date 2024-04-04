using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeKaboomDemo.Models
{
    public struct Food
    {
        public string Name { get; internal set; }
        public int ShelfLife { get; set; }
        public int Points { get; internal set; }
        public char Icon { get; internal set; }

        public Food(string name, int shelfLife, int points, char icon)
        {
            Name = name;
            ShelfLife = shelfLife;
            Points = points;
            Icon = icon;
        }
    }
}
