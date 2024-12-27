namespace snakem;

static class KeyCatcher
{
    public static async void CatchKeys(Stack<char> allKeysPressed)
    {
        while (true)
        {
            await Task.Run(() => { allKeysPressed.Push(Console.ReadKey(true).KeyChar); });
        }
    }

    public static async Task<char> ReadKeys(Stack<char> allKeysPressed, int step, char beforeLastKeyPressed)
    {
        await Task.Delay(step);
        char lastKeyPressed;
        if (allKeysPressed.Count > 0)
        {
            lastKeyPressed = allKeysPressed.Pop();
            allKeysPressed.Clear();
            return lastKeyPressed;
        }
        else { return beforeLastKeyPressed; }
    }
}
