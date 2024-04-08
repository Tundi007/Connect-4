using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
namespace Connect4;

// using MathNet.Numerics;
class Game
{

    private static int PID_Int = 1;

    private static int BID_Int = 2;

    private static string error_String = "";

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
    
        while(UI.UserInterface_Function("Rematch?","No","Yes",option_Int,out int output_Int))
        {

            option_Int = output_Int;

            if(option_Int == -1) PrematureExit_Function();
            
        }

        if(option_Int == 2) return true;

        return false;
    
    }

    public static void SideSelect_Function()
    {

        while(UI.UserInterface_Function("Select Your Side(Use Arrow Keys):","O","X",PID_Int,out int output_Int))
        {

            if(output_Int == -1) PrematureExit_Function();

            PID_Int = output_Int;

        }
    
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

        Thread.Sleep(300);

        Console.Clear();

        Game_Function();
    
    }

    private static void Game_Function()
    {

        Matrix<BigInteger> gameBoard_BigIntegerMatrix = Matrix<BigInteger>.Build.Dense(5,5,0);

        error_String = "";

        bool gameOver_Bool = false;

        while(!gameOver_Bool)
        {

            int elementPlacement_Int = -1;
            
            while(true){

                elementPlacement_Int = UI.GameInterface_Function(error_String,gameBoard_BigIntegerMatrix);

                if(elementPlacement_Int == -1) PrematureExit_Function();

                if(Eligibility_Function(gameBoard_BigIntegerMatrix.Column(elementPlacement_Int), out int elementLevel_Int)) 
                {

                    Placement_Function(gameBoard_BigIntegerMatrix,elementPlacement_Int,elementLevel_Int,PID_Int);                    

                    break;
                    
                }
                else error_String =$"Can't Place There (Column: {elementPlacement_Int+1})";
            
            }

            Bot_Function(gameBoard_BigIntegerMatrix);

        }

    }
    
    private static Matrix<BigInteger> Bot_Function(Matrix<BigInteger> gameBoard_BigIntegerMatrix)
    {

        for (int elementPlacement_Int = 0; elementPlacement_Int < 5; elementPlacement_Int++)
        {

            if(Eligibility_Function(gameBoard_BigIntegerMatrix.Column(elementPlacement_Int),out int elementLevel_Int))
            {
                
                CalculateCost_Function(Placement_Function(gameBoard_BigIntegerMatrix,elementPlacement_Int,elementLevel_Int,BID_Int));
                
            }
            
        }

        return gameBoard_BigIntegerMatrix;
    
    }
    
    private static bool Eligibility_Function(MathNet.Numerics.LinearAlgebra.Vector<BigInteger> column_BigIntegerVector, out int elementLevel_Int)
    {

        elementLevel_Int = -1;

        if(column_BigIntegerVector.Contains(0))
        {

            elementLevel_Int = column_BigIntegerVector.ToList().IndexOf(0);
            
            return true;
            
        }
        else return false;
    
    }

    private static Matrix<BigInteger> Placement_Function(Matrix<BigInteger> gameBoard_BigIntegerMatrix,int elementPlacement_Int,int elementLevel_Int, int ID_Int)
    {

        gameBoard_BigIntegerMatrix[elementLevel_Int,elementPlacement_Int] = ID_Int;

        return gameBoard_BigIntegerMatrix;
    
    }

    private static int FindElements_Function(MathNet.Numerics.LinearAlgebra.Vector<BigInteger> vector_BigIntegerVector, out BigInteger[] tidyColumn_BigIntegerVector)
    {


        return (tidyColumn_BigIntegerVector = vector_BigIntegerVector.Where(x=> x==1|x==2).ToArray()).Length;
        
    
    }

    private static void CalculateCost_Function(Matrix<BigInteger> gameBoard_BigIntegerMatrix)
    {

        int pidCount_Int = -1;

        int bidCount_Int = -1;

        for (int dimension_Int = 0; dimension_Int < 5; dimension_Int++)
        {
            
            int pidCountTemp_Int = 0;
        
            int bidCountTemp_Int = 0;
    
            for (int row_Int = 0; row_Int < FindElements_Function(gameBoard_BigIntegerMatrix.Row(row_Int), out BigInteger[] row_BigIntegerArray); row_Int++)
            {

                if(row_BigIntegerArray[row_Int]==BID_Int)
                {

                    if(pidCount_Int < pidCountTemp_Int)
                        (pidCount_Int, pidCountTemp_Int) =
                            (pidCountTemp_Int, 0);
                    
                    bidCountTemp_Int++;
                    
                }
                else
                if(row_BigIntegerArray[row_Int]==PID_Int)
                {
 
                    if(bidCount_Int < bidCountTemp_Int)
                        (bidCount_Int, bidCountTemp_Int) =
                            (bidCountTemp_Int, 0);

                    pidCountTemp_Int++;
                    
                }
                
            }

            for (int column_Int = 0; column_Int < gameBoard_BigIntegerMatrix.Column(column_Int).MinimumIndex()+1; column_Int++)
            {


                
            }
            
        }
    
    }

}