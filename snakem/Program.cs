namespace snakem;

class Program
{
    static void Main(string[] args)
    {

        int starting_x = GLOBALLS.SIZE_X / 2;
        int starting_y = GLOBALLS.SIZE_Y / 2;
        Snake snake = new(starting_x, starting_y);
        Bodypart apple = new(GLOBALLS.APPLE);
        Field field = new(GLOBALLS.SIZE_X, GLOBALLS.SIZE_Y, snake, apple);
        bool isGrowing = field.Refresh();
        field.Draw();

        Stack<char> allKeysPressed = new();
        KeyCatcher.CatchKeys(allKeysPressed);
        char keyPressed = 'w';
        char lastKeyPressed;

        int step = GLOBALLS.step_starting;
        while (true)
        {
            lastKeyPressed = keyPressed;
            keyPressed = KeyCatcher.ReadKeys(allKeysPressed, step, lastKeyPressed).Result;
            if (!GLOBALLS.ACCEPTABLE_KEYS.Contains(keyPressed)) { keyPressed = lastKeyPressed; }


            if (!snake.TryMove(keyPressed, isGrowing)) { GameOver(); break; };

            isGrowing = field.Refresh();
            if (isGrowing) { step = (int)(step * GLOBALLS.step_multipluer); };
            Console.Clear();
            field.Draw();
        }
    }

    static void GameOver()
    {
        Console.Clear();
        Console.WriteLine("GAY, OVER");
        Thread.Sleep(13000);
    }

    

}
