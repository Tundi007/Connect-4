namespace Connect4;

class Program
{

    private static int PID_Int = 1;

    static void Main(string[] args)
    {

        do
        {

            Game.SideSelect_Function();

            Game.Load_Function();

        }while(Game.Rematch_Function());
        
    }
    
}