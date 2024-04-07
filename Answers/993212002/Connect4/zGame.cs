using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
namespace Connect4;

// using MathNet.Numerics;
class Game
{

    private static int PID_Int = -1;

    private static Matrix<BigInteger> gameBoard_BigIntegerMatrix = Matrix<BigInteger>.Build.Dense(5,5,0);

    private static string error_String = "";

    public static void GetPlayerID_Function()
    {

        PID_Int = Program.PlayerID_Function();

    }

    public static void Load_Function()
    {
    
        string loading_String = "[                    ]";        

        bool loading_Bool = true;

        for (int loading_Int = 2; loading_Int < 23; loading_Int++)
        {            

            Console.Clear();            

            System.Console.Write("Loading");

            System.Console.Write(loading_String);

            if(loading_Int == 22)System.Console.WriteLine("100%");
            else System.Console.WriteLine((int)((double)loading_Int/23*100)+"%");
                
            loading_String = loading_String[..(loading_Int-1)] + "-" + loading_String[(loading_Int)..];

            if(loading_Int == 4)Thread.Sleep(200);

            if(loading_Bool)
            {

                if(loading_Int%1==0)Thread.Sleep(1);

                if(loading_Int%3==0)Thread.Sleep(30);

                if(loading_Int%5==0)Thread.Sleep(100);

                if(loading_Int%6==0)Thread.Sleep(200);

                if(loading_Int%7==0)Thread.Sleep(300);

                if(loading_Int%10==0)
                {
                    
                    Thread.Sleep(400);
                    
                    loading_Bool = false;
                
                }
            
            }else Thread.Sleep(5);
            
        }

        for (int loading_Int = 3; loading_Int > 0; loading_Int--)
        {

            System.Console.WriteLine("Game Starting In " + loading_Int + "...");

            Thread.Sleep(900);
            
        }

        Game.GetPlayerID_Function();

        Thread.Sleep(300);

        Console.Clear();

        Game_Function();
    
    }

    private static void Game_Function()
    {

        bool gameOver_Bool = false;

        while(!gameOver_Bool)
        {

            int placement_Int = UI.GameInterface_Function(error_String,gameBoard_BigIntegerMatrix);

            if(!gameBoard_BigIntegerMatrix.Column(placement_Int).Contains(0)) error_String =$"Can't Place There (Column: {placement_Int+1})";

            gameBoard_BigIntegerMatrix[gameBoard_BigIntegerMatrix.Column(placement_Int).ToList().IndexOf(0),placement_Int] = 1;



        }

    }

}