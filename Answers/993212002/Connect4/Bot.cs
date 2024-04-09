using MathNet.Numerics.LinearAlgebra;
namespace Connect4;

public class MyBot
{

    private static int BID_Int = -1;

    private static int PID_Int = -1;

    public static void IDInit_Function(int inputBID_Int,int inputPID_Int)
    {

        BID_Int = inputBID_Int;

        PID_Int = inputPID_Int;
    
    }

    public static int Bot_Function(Matrix<Single> copyBoard_SingleMatrix)
    {

        return MinMax_Function(copyBoard_SingleMatrix);;

    }

    private static int MinMax_Function(Matrix<Single> copyBoard_SingleMatrix)
    {

        int bestMoveCost_Int = -5;

        int bestNextMove_Int = -5;

        for (int nextMove_Int = 0; nextMove_Int < 4; nextMove_Int++)
        {

            Matrix<Single> copy_SingleMatrix = Matrix<Single>.Build.Dense(5, 5, 0);

            copyBoard_SingleMatrix.CopyTo(copy_SingleMatrix);

            copy_SingleMatrix = MyMatrix.ApplyMove_Function(copy_SingleMatrix, nextMove_Int, BID_Int);

            (int botMaxPiece_int, int playerMaxPiece_Int) = MaxPiece_Function(copy_SingleMatrix);

            int botMaxPoint_int = botMaxPiece_int - playerMaxPiece_Int;

            int playerMaxPoint_Int = PlayerMaxPoints_Function(copy_SingleMatrix);

            if(botMaxPoint_int - playerMaxPoint_Int > bestMoveCost_Int)
                (bestMoveCost_Int, bestNextMove_Int) =
                    (botMaxPoint_int - playerMaxPoint_Int, nextMove_Int);

        }

        return bestNextMove_Int;

    }

    private static int PlayerMaxPoints_Function(Matrix<Single> copy_SingleMatrix)
    {

        int playerMaxPoint_Int = -5;

        for (int nextMove_Int = 0; nextMove_Int < 4; nextMove_Int++)
        {

            Matrix<Single> copyCopy_SingleMatrix = Matrix<Single>.Build.Dense(5, 5, 0);

            copy_SingleMatrix.CopyTo(copyCopy_SingleMatrix);

            (int tempBotMaxPiece_int,int tempPlayerMaxPiece_int) =
                MaxPiece_Function
                    (MyMatrix.ApplyMove_Function(copyCopy_SingleMatrix, nextMove_Int, PID_Int));

            int tempPlayerMaxPoint_int = tempPlayerMaxPiece_int - tempBotMaxPiece_int;

            if(tempPlayerMaxPoint_int > playerMaxPoint_Int) playerMaxPoint_Int = tempPlayerMaxPoint_int;

        }

        return playerMaxPoint_Int;

    }

    public static (int,int) MaxPiece_Function(Matrix<Single> copy_SingleMatrix)
    {        

        Matrix<Single> copyCopy_SingleMatrix = Matrix<Single>.Build.Dense(4,4,0);

        copy_SingleMatrix.CopyTo(copyCopy_SingleMatrix);

        Tuple<int, int, Single> coord_IntIntSingleTuple;

        while((coord_IntIntSingleTuple =
            copyCopy_SingleMatrix.Find(x => x == BID_Int, Zeros.AllowSkip)) != null)
        {

            int x_Int = coord_IntIntSingleTuple.Item1;

            int y_Int = coord_IntIntSingleTuple.Item2;
            
            copyCopy_SingleMatrix[x_Int,y_Int] = 0;
            
        }

        copy_SingleMatrix.Find(x => x == PID_Int, Zeros.AllowSkip);

        for (int corner_Int = 0; corner_Int < 4; corner_Int++)
        {

            MyMatrix.FourByFour_Function(copy_SingleMatrix,corner_Int);
            
        }

        return (0,0);

    }

}