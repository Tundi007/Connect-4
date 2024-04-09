namespace Connect4;

class Program
{

    private static int PID_Int = 1;

    static void Main(string[] args)
    {

        do
        {

            MyGame.SideSelect_Function();

            MyGame.Load_Function();

        } while (MyGame.Rematch_Function());

    }

}