namespace snakem;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        int starting_x = GLOBALLS.SIZE_X / 2;
        int starting_y = GLOBALLS.SIZE_Y / 2;
        Snake snake = new(starting_x, starting_y);
        Bodypart apple = new(GLOBALLS.APPLE);
        Field field = new(GLOBALLS.SIZE_X, GLOBALLS.SIZE_Y, snake, apple);
        bool isGrowing = field.Refresh();
        field.Draw();

        Stack<char> allKeysPressed = new();
        KeyCatcher.CatchKeys(allKeysPressed);
        //this needs to stop
        char keyPressed = 'w';
        char lastKeyPressed;

        int step = GLOBALLS.step_starting;
        while (true)
        {
            lastKeyPressed = keyPressed;
            keyPressed = KeyCatcher.ReadKeys(allKeysPressed, step, lastKeyPressed).Result;
            if (!GLOBALLS.ACCEPTABLE_KEYS.Contains(keyPressed)) { keyPressed = lastKeyPressed; }


            if (!snake.TryMove(keyPressed, isGrowing)) { break; };

            isGrowing = field.Refresh();
            if (isGrowing) { step = (int)(step * GLOBALLS.step_multipluer); };
            Console.Clear();
            field.Draw();
        }

        GameOver(snake.apples_eaten);
    }

    static void GameOver(int score)
    {
        Console.Clear();
        string save_path = "save";
        if (!Directory.Exists(save_path)) { Directory.CreateDirectory(save_path); };
        Console.WriteLine("SCORE BOARD\n\n");
        string save_fail = Path.Combine(Directory.GetCurrentDirectory(), save_path, "fail.txt");
        if (!File.Exists(save_fail)) { File.Create(save_fail); }
        Dictionary<string, int> records = new();
        using (StreamReader reader = File.OpenText(save_fail))
        {
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                string[] line_split = line.Split(':');
                records.Add(line_split[0].Trim(), int.Parse(line_split[1]));
            }
        }
        //File.Delete(save_fail);
        //File.Create(save_fail);
        Console.Write("Enter your alias: ");
        string name = Console.ReadLine().ToUpper();
        if (name.Length > 7) { name = name.Substring(0, 7); }
        records.Add(name, score);
        //handle same name
        var records_ordered = records.OrderByDescending(k => k.Value);
        using (StreamWriter writer = File.CreateText(save_fail))
        { foreach ((string n, int s) in records_ordered) { writer.WriteLine($"{n} : {s}"); } }
        using (StreamReader reader = File.OpenText(save_fail))
        {
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null) { Console.WriteLine(line); }
        }
        Console.Write($"\n\nAre you hungry for apples? [y/n] ");
        char answer = Console.ReadKey(true).KeyChar;
        if (answer == 'y') { Main(); }
    }
}
