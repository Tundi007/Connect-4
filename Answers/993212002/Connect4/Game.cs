using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Connect4;

class Game
{

    private static int player_Int;

    private static int bot_Int;

    private static string error_String = "";
    
    public static void SideSelect_Function()
    {

        (player_Int, bot_Int) = (1, 2);

        while (!MyUI.UserInterface_Function("Select Your Side(Use Arrow Keys):", "O", "X", player_Int, out int output_Int))
        {

            if (output_Int == -1) PrematureExit_Function();

            if (output_Int == 2 | output_Int == 1) (player_Int, bot_Int) = (bot_Int, player_Int);

        }

    }

    public static void Load_Function()
    {

        System.Console.WriteLine("your side is: " + player_Int);

        Console.ReadKey(true);

        // string loading_String = "[                    ]";        

        // bool loading_Bool = true;

        // for (int loading_Int = 2; loading_Int < 23; loading_Int++)
        // {            

        //     Console.Clear();            

        //     System.Console.Write("Loading");

        //     System.Console.Write(loading_String);

        //     if(loading_Int == 22)System.Console.WriteLine("100%");
        //     else System.Console.WriteLine((int)((double)loading_Int/23*100)+"%");

        //     loading_String = loading_String[..(loading_Int-1)] + "-" + loading_String[(loading_Int)..];

        //     if(loading_Int == 4)Thread.Sleep(200);

        //     if(loading_Bool)
        //     {

        //         if(loading_Int%1==0)Thread.Sleep(1);

        //         if(loading_Int%3==0)Thread.Sleep(30);

        //         if(loading_Int%5==0)Thread.Sleep(100);

        //         if(loading_Int%6==0)Thread.Sleep(200);

        //         if(loading_Int%7==0)Thread.Sleep(300);

        //         if(loading_Int%10==0)
        //         {

        //             Thread.Sleep(400);

        //             loading_Bool = false;

        //         }

        //     }else Thread.Sleep(5);

        // }

        // for (int loading_Int = 3; loading_Int > 0; loading_Int--)
        // {

        //     System.Console.WriteLine("Game Starting In " + loading_Int + "...");

        //     Thread.Sleep(900);

        // }

        // Thread.Sleep(300);

        // Console.Clear();

        Game_Function();

    }

    public static void Game_Function()
    {

        GameBoard.GameBoardReset_Function();
    
        error_String = "";

        bool gameOver_Bool = false;

        while (!gameOver_Bool)
        {

            while (true)
            {

                int elementColumn_Int = MyUI.GameInterface_Function(error_String, GameBoard.GameBoardStatus_Function());

                error_String = "";

                if (elementColumn_Int == -1) PrematureExit_Function();

                if(GameBoard.ElementValidColumn_Function(
                    GameBoard.GameBoardStatus_Function(), elementColumn_Int, out int elementRow_Int ))
                    if(GameBoard.ElementPlace_Function(elementRow_Int, elementColumn_Int, player_Int)) break;

                error_String = $"Can't Place There (Column: {elementColumn_Int + 1})";

            }

            Console.ReadKey();

            if(CheckGoal_Function(out int winner_int))
            {

                if(winner_int == player_Int) System.Console.WriteLine("Congrats, You Won!");

                if(winner_int == bot_Int) System.Console.WriteLine("You Lost, Better Luck Next Time!");

                gameOver_Bool = true;

            }

        }
    
    }
    
    private static bool CheckGoal_Function(out int winner_int)
    {

        winner_int = -1;

        for (int corner_Int = 0; corner_Int < 4; corner_Int++)
        {

            GameBoard.SubMatrix_Function(GameBoard.GameBoardStatus_Function(),
                corner_Int, out Matrix<float> fourByFour_SingleMatrix);

            for (int ID_Int = 1; ID_Int < 3; ID_Int++)
            {

                if(fourByFour_SingleMatrix.Diagonal().All(x => x == ID_Int))
                {

                    winner_int = ID_Int;

                    return true;

                }

                for (int index_Int = 0; index_Int < 4; index_Int++)
                {

                    if(fourByFour_SingleMatrix.Row(index_Int).All(x => x == ID_Int))
                    {

                        winner_int = ID_Int;

                        return true;

                    }

                    if(fourByFour_SingleMatrix.Column(index_Int).All(x => x == ID_Int))
                    {

                        winner_int = ID_Int;

                        return true;

                    }
                    
                }

            }

        }

        return false;

    }

    private static void PrematureExit_Function()
    {

        Console.Clear();

        System.Console.WriteLine("Have A Nice Day!");

        Thread.Sleep(300);

        Environment.Exit(0);

    }

    public static bool Rematch_Function()
    {

        int option_Int = 1;

        while(!MyUI.UserInterface_Function("Rematch?", "No", "Yes", option_Int, out int output_Int))
        {

            option_Int = output_Int;

            if (option_Int == -1) PrematureExit_Function();

        }

        if (option_Int == 2) return true;

        return false;

    }

}