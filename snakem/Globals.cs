using System.Collections.ObjectModel;

namespace snakem;

public static class GLOBALLS
{
    public const int step_starting = 500;
    public const double step_multipluer = 0.92;
    public const int SIZE_X = 26;
    public const int SIZE_Y = 26;
    public const char TILE = '·';
    public const ConsoleColor TILE_COLOUR = ConsoleColor.DarkGray;
    public const char HEAD = '@';
    public const char BODY = 'O';
    public const char TAIL = 'o';
    public const ConsoleColor SNAKE_COLOUR = ConsoleColor.Green;
    public const char APPLE = '*';
    public const ConsoleColor APPLE_COLOUR = ConsoleColor.Red;
    public static readonly ReadOnlyCollection<char> ACCEPTABLE_KEYS = new ReadOnlyCollection<char>(new[] { 'w', 'a', 's', 'd' });
}
