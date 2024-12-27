namespace snakem;

class Field
{
    public int x { get; }
    public int y { get; }
    private char[,] field;
    public Snake snake;
    public Bodypart apple;
    private Random random = new Random();
    public Field(byte x, byte y, Snake snake, Bodypart apple)
    {
        this.x = x;
        this.y = y;
        this.snake = snake;
        this.apple = apple;
        field = new char[x, y];
        PlaceApple();
    }
    public char this[int x, int y]
    {
        get { return field[x, y]; }
        set { field[x, y] = value; }
    }
    public void PlaceApple()
    {
        while (true)
        {
            apple.X = random.Next(0, GLOBALLS.SIZE_X);
            apple.Y = random.Next(0, GLOBALLS.SIZE_Y);
            if (!snake.isOn(apple.X, apple.Y)) { break; }
        }
    }
    public bool Refresh()
    {
        for (int x = 0; x < this.x; ++x) { for (int y = 0; y < this.y; ++y) { field[x, y] = GLOBALLS.TILE; } };
        bool isGrowing = false;
        if (snake.isOnHead(apple.X, apple.Y)) { isGrowing = true; PlaceApple(); }

        Bodypart current = snake.head;
        for (int i = 0; i < snake.length; ++i)
        {
            field[current.X, current.Y] = current.pic;
            current = current.next;
        }
        field[apple.X, apple.Y] = apple.pic;
        return isGrowing;
    }
    public void Draw()
    {
        int index = 0;
        for (int y = 0; y < this.y; ++y)
        {
            for (int x = 0; x < this.x; ++x)
            {
                if (field[x, y] == GLOBALLS.TILE) { Console.ForegroundColor = GLOBALLS.TILE_COLOUR; }
                else if (field[x, y] == GLOBALLS.APPLE) { Console.ForegroundColor = GLOBALLS.APPLE_COLOUR; }
                else { Console.ForegroundColor = GLOBALLS.SNAKE_COLOUR; }
                Console.Write(field[x, y]);
                Console.ResetColor();
                Console.Write(' ');
                ++index;
            }
            Console.Write('\n');
        }
    }

}