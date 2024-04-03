using SnakeKaboomDemo.Enums;

namespace SnakeKaboomDemo.Services
{
    public interface IMapBuilder
    {
        int Height { get; }
        int Width { get; }

        void BuildMap();
        void CreateScreenBoundaries();
        bool IsWithinBounds(Direction direction, (int x, int y) currentPosition);
        (int x, int y) GetWrappedPosition(Direction direction, (int x, int y) currentPosition);

    }
}