using SnakeKaboomDemo.Enums;
using SnakeKaboomDemo.Services;

MapBuilder mapBuilder = new MapBuilder(50, 120);
SnakeBody snake = new SnakeBody(1, 1, mapBuilder);
FoodGenerator foodGen = new FoodGenerator((120, 50));


mapBuilder.CreateScreenBoundaries();
mapBuilder.BuildMap();

Thread gameThread = new Thread(Run);
Thread foodThread = new Thread(FoodGenerator);

gameThread.Start();
foodThread.Start();


void FoodGenerator()
{
	while (true)
	{
        foodGen.SpawnFood();
        PrintFoodPositions();
		Thread.Sleep(5000);
    }
}

void PrintFoodPositions()
{
	var currentFood = foodGen.GetFoodPositions();
	foreach (var key in currentFood.Keys)
	{
		mapBuilder.DrawMapObject(key, currentFood[key].Icon);

	}
}

void Run()
{
	while(true)
	{		
		if (Console.KeyAvailable)
		{
			var key = Console.ReadKey();

			var direction = GetKeyDirection(key);

			if (direction != Direction.Neutral)
				snake.CurrentDirection= direction;
		}

        snake.UpdateSnakePosition();
        DrawSnakeOnMap();

        Thread.Sleep(100);
	}
}

Direction GetKeyDirection(ConsoleKeyInfo keyPressed)
{
	switch (keyPressed.Key.ToString())
	{
		case "DownArrow":
			return Direction.Down;
		case "UpArrow":
			return Direction.Up;
		case "LeftArrow":
			return Direction.Left;
		case "RightArrow":
			return Direction.Right;
	}

	return Direction.Neutral;
}

void DrawSnakeOnMap()
{
	foreach (var position in snake.GetSnakePosition())
	{
		mapBuilder.DrawMapObject(position, 'o');
	}

	// Remove tail from map 
	mapBuilder.DrawMapObject(snake.PreviousTail, ' ');
}