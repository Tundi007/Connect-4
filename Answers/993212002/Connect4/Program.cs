namespace Connect4;

class Program
{

    private static int PID_Int = 1;

    static void Main(string[] args)
    {

        do
        {

            SideSelect_Function();

            Game.GetPlayerID_Function();

            Game.Load_Function();

        }while(Rematch_Function());
        
    }

    private static bool Rematch_Function()
    {

        int option_Int = 1;
    
        while(UI.UserInterface_Function("Rematch?","No","Yes",option_Int,out int output_Int))
        {

            option_Int = output_Int;

            if(option_Int == -1) PrematureExit_Function();
            
        }

        if(option_Int == 2) return true;

        return false;
    
    }

    private static void SideSelect_Function()
    {

        while(UI.UserInterface_Function("Select Your Side(Use Arrow Keys):","O","X",PID_Int,out int output_Int))
        {

            if(output_Int == -1) PrematureExit_Function();

            PID_Int = output_Int;

        }
    
    }

    public static int PlayerID_Function()
    {

        return PID_Int;

    }

    public static void PrematureExit_Function()
    {

        Console.Clear();

        System.Console.WriteLine("Have A Nice Day!");

        Thread.Sleep(300);
    
        Environment.Exit(0);
    
    }
    
}