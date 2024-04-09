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

// public static (int,int) MaxPiece_Function(Matrix<Single> copy_SingleMatrix)
//     {

//         int mostBotPiece_Int = -1;

//         int mostPlayerPiece_Int = -1;

//         int tempMostPlayerPiece_Int;

//         int tempMostBotPiece_Int;

//         for (int row_Int = 0; row_Int < 5; row_Int++)
//         {

//             tempMostBotPiece_Int = 0;

//             tempMostPlayerPiece_Int = 0;

//             for (int index_Int = 0; index_Int < 5; index_Int++)
//             {

//                 if (copy_SingleMatrix.Row(row_Int)[index_Int] == BID_Int)
//                 {

//                     tempMostBotPiece_Int++;

//                     if (mostPlayerPiece_Int < tempMostPlayerPiece_Int)
//                         (mostPlayerPiece_Int, tempMostPlayerPiece_Int) =
//                             (tempMostPlayerPiece_Int, 0);

//                 }
//                 else
//                 if (copy_SingleMatrix.Row(row_Int)[index_Int] == 0)
//                 {

//                     if (mostPlayerPiece_Int < tempMostPlayerPiece_Int)
//                         (mostPlayerPiece_Int, tempMostPlayerPiece_Int) =
//                             (tempMostPlayerPiece_Int, 0);

//                     if (mostPlayerPiece_Int < tempMostPlayerPiece_Int)
//                         (mostBotPiece_Int, tempMostBotPiece_Int) =
//                             (tempMostBotPiece_Int, 0);

//                 }
//                 else
//                 {

//                     tempMostPlayerPiece_Int++;

//                     if (mostPlayerPiece_Int < tempMostPlayerPiece_Int)

//                         (mostBotPiece_Int, tempMostBotPiece_Int) =
//                             (tempMostBotPiece_Int, 0);

//                 }

//             }

//         }

//         for (int column_Int = 0; column_Int < 5; column_Int++)
//         {

//             tempMostBotPiece_Int = 0;

//             tempMostPlayerPiece_Int = 0;

//             for (int index_Int = 0; index_Int < 5; index_Int++)
//             {

//                 if (copy_SingleMatrix.Column(column_Int)[index_Int] == BID_Int)
//                 {

//                     tempMostBotPiece_Int++;

//                     if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
//                         (mostPlayerPiece_Int, tempMostPlayerPiece_Int) =
//                             (tempMostPlayerPiece_Int, 0);

//                 }
//                 else
//                 if (copy_SingleMatrix.Column(column_Int)[index_Int] == 0)
//                 {

//                     if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
//                         (mostPlayerPiece_Int, tempMostPlayerPiece_Int) =
//                             (tempMostPlayerPiece_Int, 0);

//                     if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
//                         (mostBotPiece_Int, tempMostBotPiece_Int) =
//                             (tempMostBotPiece_Int, 0);

//                 }
//                 else
//                 {

//                     tempMostPlayerPiece_Int++;

//                     if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)

//                         (mostBotPiece_Int, tempMostBotPiece_Int) =
//                             (tempMostBotPiece_Int, 0);

//                 }

//             }

//         }

        // for (int diagonal_Int = 0; diagonal_Int < 2; diagonal_Int++)
        // {

        //     tempMostBotPiece_Int = 0;

        //     tempMostPlayerPiece_Int = 0;

        //     for (int index_Int = 0; index_Int < 5 - diagonal_Int; index_Int++)
        //     {

        //         if (copy_SingleMatrix[index_Int + diagonal_Int, index_Int] == BID_Int)
        //         {

        //             tempMostBotPiece_Int++;

        //             if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
        //                 (mostPlayerPiece_Int, tempMostPlayerPiece_Int) =
        //                     (tempMostPlayerPiece_Int, 0);

        //         }
        //         else
        //         if (copy_SingleMatrix[index_Int + diagonal_Int, index_Int] == 0)
        //         {

        //             if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
        //                 (mostPlayerPiece_Int, tempMostPlayerPiece_Int) =
        //                     (tempMostPlayerPiece_Int, 0);

        //             if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
        //                 (mostBotPiece_Int, tempMostBotPiece_Int) =
        //                     (tempMostBotPiece_Int, 0);

        //         }
        //         else
        //         {

        //             tempMostPlayerPiece_Int++;

        //             if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)

        //                 (mostBotPiece_Int, tempMostBotPiece_Int) =
        //                     (tempMostBotPiece_Int, 0);

        //         }

        //     }

        //     for (int reverseIndex_Int = 4; reverseIndex_Int >= 0; reverseIndex_Int--)
        //     {

        //         if (copy_SingleMatrix[reverseIndex_Int - diagonal_Int, reverseIndex_Int] == BID_Int)
        //         {

        //             tempMostBotPiece_Int++;

        //             if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
        //                 (mostPlayerPiece_Int, tempMostPlayerPiece_Int) =
        //                     (tempMostPlayerPiece_Int, 0);

        //         }
        //         else
        //         if (copy_SingleMatrix[reverseIndex_Int - diagonal_Int, reverseIndex_Int] == 0)
        //         {

        //             if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
        //                 (mostPlayerPiece_Int, tempMostPlayerPiece_Int) =
        //                     (tempMostPlayerPiece_Int, 0);

        //             if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
        //                 (mostBotPiece_Int, tempMostBotPiece_Int) =
        //                     (tempMostBotPiece_Int, 0);

        //         }
        //         else
        //         {

        //             tempMostPlayerPiece_Int++;

        //             if(mostPlayerPiece_Int<tempMostPlayerPiece_Int)
        //                 (mostBotPiece_Int, tempMostBotPiece_Int) =
        //                     (tempMostBotPiece_Int, 0);

        //         }

        //     }

        // }

        return (mostBotPiece_Int, mostPlayerPiece_Int);

    }

public static (int,int) CalculatePieces_Function()
{

    return (0,0);

}

}