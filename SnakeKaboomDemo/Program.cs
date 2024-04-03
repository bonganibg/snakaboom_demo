using SnakeKaboomDemo.Enums;
using SnakeKaboomDemo.Services;

MapBuilder mapBuilder = new MapBuilder(50, 120);
SnakeBody snake = new SnakeBody(1, 1, mapBuilder);

mapBuilder.CreateScreenBoundaries();
mapBuilder.BuildMap();

Run();

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
}