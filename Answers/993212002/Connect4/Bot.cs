namespace Connect4;
// public class MyBot2
// {

//     private static int BID_Int = -1;

//     private static int PID_Int = -1;

//     public static void IDInit_Function(int inputBID_Int, int inputPID_Int)
//     {

//         BID_Int = inputBID_Int;

//         PID_Int = inputPID_Int;

//     }

//     public static int Bot_Function(Matrix<Single> copyBoard_SingleMatrix)
//     {

//         return MinMax_Function(copyBoard_SingleMatrix); ;

//     }

//     private static int MinMax_Function(Matrix<Single> copyBoard_SingleMatrix)
//     {

//         int bestMoveCost_Int = -5;

//         int bestNextMove_Int = -5;

//         for (int nextMove_Int = 0; nextMove_Int < 5; nextMove_Int++)
//         {

//             Matrix<Single> appliedBoard_SingleMatrix = Matrix<Single>.Build.Dense(5, 5, 0);

//             copyBoard_SingleMatrix.CopyTo(appliedBoard_SingleMatrix);

//             MyMatrix2.ApplyMove_Function(appliedBoard_SingleMatrix, nextMove_Int, BID_Int).CopyTo(appliedBoard_SingleMatrix);

//             (int botMaxPiece_int, int playerMaxPiece_Int) = MaxPiece_Function(appliedBoard_SingleMatrix);

//             int botMaxPoint_int = botMaxPiece_int - playerMaxPiece_Int;

//             int playerMaxPoint_Int = PlayerMaxPoints_Function(appliedBoard_SingleMatrix);

//             if(botMaxPoint_int - playerMaxPoint_Int > bestMoveCost_Int)
//             {
//                 (bestMoveCost_Int, bestNextMove_Int) =
//                     (botMaxPoint_int - playerMaxPoint_Int, nextMove_Int);
                
//                 System.Console.WriteLine( "points: "+ botMaxPoint_int + " spot chosen: " + nextMove_Int);

//                 System.Console.WriteLine("-----------------------------------");

//             }            

//         }

//         return bestNextMove_Int;

//     }

//     private static int PlayerMaxPoints_Function(Matrix<Single> appliedBoard_SingleMatrix)
//     {

//         int playerMaxPoint_Int = -5;

//         for (int nextMove_Int = 0; nextMove_Int < 5; nextMove_Int++)
//         {

//             Matrix<Single> copyBoard_SingleMatrix = Matrix<Single>.Build.Dense(5, 5, 0);

//             appliedBoard_SingleMatrix.CopyTo(copyBoard_SingleMatrix);

//             MyMatrix2.ApplyMove_Function(copyBoard_SingleMatrix, nextMove_Int, BID_Int).CopyTo(copyBoard_SingleMatrix);

//             (int botMaxPiece_int, int playerMaxPiece_Int) = MaxPiece_Function(copyBoard_SingleMatrix);

//             playerMaxPoint_Int = Compare_Function(playerMaxPoint_Int , playerMaxPiece_Int - botMaxPiece_int);

//         }

//         return playerMaxPoint_Int;

//     }

//     public static (int, int) MaxPiece_Function(Matrix<Single> appliedBoard_SingleMatrix)
//     {

//         (int botMaxPieces_Int, int playerMaxPieces_Int) = (0, 0);

//         for (int corner_Int = 0; corner_Int < 4; corner_Int++)
//         {

//             Matrix<Single> fourByFour_SingleMatrix = Matrix<Single>.Build.Dense(4, 4, 0);

//             MyMatrix2.FourByFour_Function(appliedBoard_SingleMatrix, corner_Int).CopyTo(fourByFour_SingleMatrix);

//             Vector<Single> vector_SingleVector = Vector<Single>.Build.Dense(4,0);

//             fourByFour_SingleMatrix.Diagonal().CopyTo(vector_SingleVector);

//             (botMaxPieces_Int, playerMaxPieces_Int) =
//                 IDCheckVector_Function(vector_SingleVector,botMaxPieces_Int, playerMaxPieces_Int);

//             for (int index_Int = 0; index_Int < 4; index_Int++)
//             {

//                 fourByFour_SingleMatrix.Column(index_Int).CopyTo(vector_SingleVector);

//                 (botMaxPieces_Int, playerMaxPieces_Int) =
//                     IDCheckVector_Function(vector_SingleVector, botMaxPieces_Int, playerMaxPieces_Int);

//                 fourByFour_SingleMatrix.Row(index_Int).CopyTo(vector_SingleVector);

//                 (botMaxPieces_Int, playerMaxPieces_Int) =
//                     IDCheckVector_Function(vector_SingleVector,botMaxPieces_Int, playerMaxPieces_Int);
                
//             }

//         }

//         return (botMaxPieces_Int, playerMaxPieces_Int);

//     }

//     private static (int, int) IDCheckVector_Function(Vector<Single> vector_SingleVector, int botMaxPieces_Int, int playerMaxPieces_Int)
//     {

//         while (vector_SingleVector.Contains(PID_Int) | vector_SingleVector.Contains(BID_Int))
//         {

//             if(MyMatrix2.CountID_Function(vector_SingleVector, 0) != 0)
//             for (int index_Int = 0; index_Int < MyMatrix2.CountID_Function(vector_SingleVector, 0); index_Int++)
//             {

//                 vector_SingleVector[Find_Function(vector_SingleVector,0) + index_Int] = 3;

//             }

//             if(MyMatrix2.CountID_Function(vector_SingleVector, BID_Int) != 0)
//             {

//                 botMaxPieces_Int = Compare_Function(botMaxPieces_Int, MyMatrix2.CountID_Function(vector_SingleVector, BID_Int));

//                 for (int index_Int = 0; index_Int < MyMatrix2.CountID_Function(vector_SingleVector, BID_Int); index_Int++)
//                 {

//                     vector_SingleVector[Find_Function(vector_SingleVector,BID_Int) + index_Int] = 3;

//                 }

//             }

//             if(MyMatrix2.CountID_Function(vector_SingleVector, PID_Int) != 0)
//             {

//                 botMaxPieces_Int = Compare_Function(botMaxPieces_Int, MyMatrix2.CountID_Function(vector_SingleVector, PID_Int));

//                 for (int index_Int = 0; index_Int < MyMatrix2.CountID_Function(vector_SingleVector, PID_Int); index_Int++)
//                 {

//                     vector_SingleVector[Find_Function(vector_SingleVector,BID_Int) + index_Int] = 3;

//                 }

//             }

//         }

//         return (botMaxPieces_Int, playerMaxPieces_Int);
    
//     }

//     private static int Find_Function(Vector<Single> vector_SingleVector, int ID_Int)
//     {

//         return vector_SingleVector.Find(x => x.Equals(ID_Int)).Item1;
    
//     }

//     private static int Compare_Function(int main_Int,int temp_int)
//     {

//         if(main_Int < temp_int) return temp_int;

//         return main_Int;
    
//     }

// }

class Bot
{

    

}