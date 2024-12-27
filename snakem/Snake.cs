namespace snakem;

class Snake
{
    public Bodypart head { get; }
    public int length { get; set; }
    public int apples_eaten = 0;
    public Snake(int x, int y)
    {
        Bodypart head = new(x, y, GLOBALLS.HEAD);
        head.next = new(x, y + 1, GLOBALLS.BODY);
        head.next.next = new(x, y + 2, GLOBALLS.BODY);
        head.next.next.next = new(x, y + 3, GLOBALLS.TAIL, true);
        length = 4;
        this.head = head;
    }
    public bool TryMove(char direction, bool isgrowing = false)
    {
        try { Move(direction, isgrowing); }
        catch (AccessViolationException) { return false; }
        return true;
    }
    public void Move(char direction, bool isgrowing = false)
    {
        if (isEatingItsTail()) { throw new AccessViolationException(); };
        (int x, int y) new_position = FindWhereToMove(direction);
        int new_x = new_position.x;
        int new_y = new_position.y;
        Bodypart current = head;
        int old_x;
        int old_y;
        for (int i = 0; i < length; ++i)
        {
            if (isgrowing && current.next.istail)
            {
                Bodypart tail = current.next;
                current.next = new Bodypart(current.X, current.Y, GLOBALLS.BODY);
                current.X = new_x;
                current.Y = new_y;
                current.next.next = tail;
                break;
            }
            else if (!current.istail)
            {
                old_x = current.X;
                old_y = current.Y;
                current.X = new_x;
                current.Y = new_y;
                new_x = old_x;
                new_y = old_y;
                current = current.next;
            }
            else { current.X = new_x; current.Y = new_y; }
        }
        if (isgrowing) {++length; ++apples_eaten; }

    }
    private (int, int) FindWhereToMove(char direction)
    {
        switch (direction) {
            case 'w': return (head.X, head.Y - 1);
            case 's': return (head.X, head.Y + 1);
            case 'a': return (head.X - 1, head.Y);
            case 'd': return (head.X + 1, head.Y);
            default: return (head.X, head.Y);
        }
    }
    public bool isOn(int x, int y)
    {
        Bodypart current = head;
        for (int i = 0; i < length; ++i)
        { 
            if (current.X == x && current.Y == y) { return true; }
            current = current.next;
        }
        return false;
    }
    public bool isOnHead(int x, int y)
    {
        if (head.X == x && head.Y == y) { return true; }
        return false;
    }
    public bool isEatingItsTail()
    {
        Bodypart current = head.next;
        for (int i = 1; i < length; ++i)
        {
            if (current.X == head.X && current.Y == head.Y) { return true; }
            current = current.next;
        }
        return false;
    }

}