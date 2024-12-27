namespace snakem;

class Program
{
    static void Main(string[] args)
    {


        int starting_x = GLOBALLS.SIZE_X / 2;
        int starting_y = GLOBALLS.SIZE_Y / 2;
        Snake snake = new(starting_x, starting_y);
        Field field = new(GLOBALLS.SIZE_X, GLOBALLS.SIZE_Y, snake);
        field.Draw();

        int step = GLOBALLS.step_starting;
        while (true)
        {
            
            Thread.Sleep(step);
            if (!snake.TryMove('w')) { Console.WriteLine("GAY, OVER"); Thread.Sleep(13000);  break; };
            
            
            step = (int)(step * .9);

            Console.Clear();
            field.Refresh();
            field.Draw();
        }
    }

    
    

}
