namespace snakem;

class Field
{
    public int x { get; }
    public int y { get; }
    private char[,] field;
    public Snake snake;
    public Field(byte x, byte y, Snake snake)
    {
        this.x = x;
        this.y = y;
        this.snake = snake;
        field = new char[x, y];
        Refresh();
    }
    public char this[int x, int y]
    {
        get { return field[x, y]; }
        set { field[x, y] = value; }
    }
    public void Refresh()
    {
        for (int x = 0; x < this.x; ++x) { for (int y = 0; y < this.y; ++y) { field[x, y] = GLOBALLS.TILE; } };
        Bodypart current = snake.head;
        for (int i = 0; i < snake.length; ++i)
        {
            field[current.X, current.Y] = current.pic;
            current = current.next;
        }
    }
    public void Draw()
    {
        int index = 0;
        for (byte y = 0; y < this.y; ++y)
        {
            for (byte x = 0; x < this.x; ++x)
            {
                Console.Write(field[x, y]);
                ++index;
            }
            Console.Write('\n');
        }
    }

}