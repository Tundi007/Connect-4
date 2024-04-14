namespace Connect4;

class Program2
{

    static void Main(string[] args)
    {     

        do
        {

            Game.SideSelect_Function();

            Game.Load_Function();

        } while (Game.Rematch_Function());

    }

}