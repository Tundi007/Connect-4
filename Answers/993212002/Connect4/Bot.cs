using MathNet.Numerics.LinearAlgebra;
namespace Connect4;

public class MyBot
{

    private static int BID_Int = -1;

    private static int PID_Int = -1;

    private static bool firstMove = true;

    public static void IDInit_Function(int inputBID_Int, int inputPID_Int)
    {

        BID_Int = inputBID_Int;

        PID_Int = inputPID_Int;

    }

    public static int Bot_Function(Matrix<Single> copyBoard_SingleMatrix)
    {

        return MinMax_Function(copyBoard_SingleMatrix); ;

    }

    private static int MinMax_Function(Matrix<Single> copyBoard_SingleMatrix)
    {

        int bestMoveCost_Int = -5;

        int bestNextMove_Int = -5;

        for (int nextMove_Int = 0; nextMove_Int < 5; nextMove_Int++)
        {

            Matrix<Single> appliedBoard_SingleMatrix = Matrix<Single>.Build.Dense(5, 5, 0);

            copyBoard_SingleMatrix.CopyTo(appliedBoard_SingleMatrix);

            MyMatrix.ApplyMove_Function(appliedBoard_SingleMatrix, nextMove_Int, BID_Int).CopyTo(appliedBoard_SingleMatrix);

            (int botMaxPiece_int, int playerMaxPiece_Int) = MaxPiece_Function(appliedBoard_SingleMatrix);

            int botMaxPoint_int = botMaxPiece_int - playerMaxPiece_Int;

            int playerMaxPoint_Int = PlayerMaxPoints_Function(appliedBoard_SingleMatrix);

            if (botMaxPoint_int - playerMaxPoint_Int > bestMoveCost_Int)
                (bestMoveCost_Int, bestNextMove_Int) =
                    (botMaxPoint_int - playerMaxPoint_Int, nextMove_Int);

        }

        return bestNextMove_Int;

    }

    public static (int, int) MaxPiece_Function(Matrix<Single> appliedBoard_SingleMatrix)
    {

        (int botMaxPieces_Int, int playerMaxPieces_Int) = (0, 0);

        for (int corner_Int = 0; corner_Int < 4; corner_Int++)
        {

            Matrix<Single> copy_SingleMatrix = Matrix<Single>.Build.Dense(4, 4, 0);

            Matrix<Single> copy2_SingleMatrix = Matrix<Single>.Build.Dense(4, 4, 0);

            MyMatrix.FourByFour_Function(appliedBoard_SingleMatrix, corner_Int).CopyTo(copy_SingleMatrix);

            copy_SingleMatrix.CopyTo(copy2_SingleMatrix);

            for (int index_Int = 0; index_Int < 4; index_Int++)
            {                

                copy2_SingleMatrix.Column(index_Int).TakeWhile(x => x == BID_Int).Count();

                if(false);

                copy2_SingleMatrix.Row(index_Int).TakeWhile(x => x == PID_Int).Count();



            }

        }

        return (0, 0);

    }

    private static int PlayerMaxPoints_Function(Matrix<Single> appliedBoard_SingleMatrix)
    {

        int playerMaxPoint_Int = -5;

        return playerMaxPoint_Int;

    }

}