using System.Collections.ObjectModel;

namespace snakem;

public static class GLOBALLS
{
    public const int step_starting = 500;
    public const double step_multipluer = 0.92;
    public const int SIZE_X = 42;
    public const int SIZE_Y = 28;
    public const char TILE = '.';
    public const char HEAD = '@';
    public const char BODY = 'o';
    public const char TAIL = '°';
    public const char APPLE = '*';
    public static readonly ReadOnlyCollection<char> ACCEPTABLE_KEYS = new ReadOnlyCollection<char>(new[] { 'w', 'a', 's', 'd' });
}
