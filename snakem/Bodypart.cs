namespace snakem;

class Bodypart
{
    private int x;
    public int X
    {
        get { return x; }
        set { x = value; if (x < 0) throw new AccessViolationException(); }
    }
    private int y;
    public int Y
    {
        get { return y; }
        set { y = value; if (y < 0) throw new AccessViolationException(); }
    }
    public char pic { get; }
    public Bodypart? next { get; set; }
    public readonly bool istail = false;
    public Bodypart(char pic) { this.pic = pic; }
    public Bodypart(int x, int y, char pic, bool istail = false)
    {
        X = x;
        Y = y;
        this.pic = pic;
        this.istail = istail;
    }
}