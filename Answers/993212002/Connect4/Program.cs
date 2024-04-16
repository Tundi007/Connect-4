namespace Connect4;

class Program2
{

    static void Main(string[] args)
    {     

        do
        {

            Game.Load_Function();

        }while(Game.Rematch_Function());

        Console.Clear();

        System.Console.WriteLine("Have A Nice Day!");

        Thread.Sleep(300);

    }

}