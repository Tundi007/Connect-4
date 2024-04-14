using MathNet.Numerics.LinearAlgebra;
namespace Connect4;

class Bot
{

    public static int Bot_Function(int botID_Int, int playerID_Int)
    {

        int[][] minMax_IntArray2D = new int[5][];

        int bestMoveCost_Int = 0;

        int bestNextMove_Int = -1;

        for (int elementColumn_Int = 0; elementColumn_Int < 5; elementColumn_Int++)
        {

            minMax_IntArray2D[elementColumn_Int]= new int[2];

            if(GameBoard.ElementValidColumn_Function(GameBoard.GameBoardStatus_Function(), elementColumn_Int, out int elementRow_Int))
            {

                Matrix<float> botBoard_FloatMatrix = Matrix<float>.Build.DenseOfMatrix(GameBoard.GameBoardStatus_Function());

                Vector<float> elementVector_FloatVector = Vector<float>.Build.Dense(5);

                botBoard_FloatMatrix.
                    Column(elementColumn_Int).CopyTo(elementVector_FloatVector);

                elementVector_FloatVector[elementRow_Int] = botID_Int;

                botBoard_FloatMatrix.SetColumn(elementColumn_Int,elementVector_FloatVector);

                minMax_IntArray2D[elementColumn_Int][1] = Max_Function(botBoard_FloatMatrix, botID_Int, playerID_Int) + 3;

                for (int playerColumn_Int = 0; playerColumn_Int < 5; playerColumn_Int++)
                {

                    if(GameBoard.ElementValidColumn_Function(botBoard_FloatMatrix, playerColumn_Int, out int playerRow_Int))
                    {

                        Matrix<float> playerBoard_FloatMatrix = Matrix<float>.Build.DenseOfMatrix(botBoard_FloatMatrix);

                        Vector<float> playerVector_FloatVector = Vector<float>.Build.Dense(5);

                        botBoard_FloatMatrix.
                            Column(playerColumn_Int).CopyTo(playerVector_FloatVector);

                        playerVector_FloatVector[playerRow_Int] = playerID_Int;

                        playerBoard_FloatMatrix.SetColumn(playerColumn_Int, playerVector_FloatVector);

                        // System.Console.WriteLine();

                        // System.Console.WriteLine(GameBoard.GameBoardStatus_Function());

                        // System.Console.WriteLine(botBoard_FloatMatrix);

                        // System.Console.WriteLine(playerBoard_FloatMatrix);

                        // System.Console.WriteLine();

                        // Console.ReadKey();

                        // Console.Clear();
                        
                        int min_Int = Max_Function(playerBoard_FloatMatrix, playerID_Int, botID_Int);

                        if(minMax_IntArray2D[elementColumn_Int][0] < min_Int)
                            minMax_IntArray2D[elementColumn_Int][0] = min_Int;

                    }
                    
                }

            }

        }

        for (int index_Int = 0; index_Int < 5; index_Int++)
        {

            if(bestMoveCost_Int < (minMax_IntArray2D[index_Int][1] - minMax_IntArray2D[index_Int][0]))
            {                

                System.Console.WriteLine($"bot's move{minMax_IntArray2D[index_Int][1]} | player best move:{minMax_IntArray2D[index_Int][0]} | cost:{minMax_IntArray2D[index_Int][1] - minMax_IntArray2D[index_Int][0]}");
                
                bestNextMove_Int = index_Int;

                bestMoveCost_Int = minMax_IntArray2D[index_Int][1] - minMax_IntArray2D[index_Int][0];
                
            }
            
        }

        return bestNextMove_Int;
    
    }

    private static int Max_Function(Matrix<float> max_FloatMatrix, int countID_Int, int skipID_Int)
    {

        int highestCount_Int;        

        {

            Vector<float> diagonal_FloatVector = Vector<float>.Build.Dense(5);

            max_FloatMatrix.Diagonal().CopyTo(diagonal_FloatVector);
            
            highestCount_Int = VectorElementCount_Function(diagonal_FloatVector, countID_Int, skipID_Int);
            
        }

        for (int index_Int = 0; index_Int < 5; index_Int++)
        {

            Vector<float> column_FloatVector = Vector<float>.Build.Dense(5);

            Vector<float> row_FloatVector = Vector<float>.Build.Dense(5);

            max_FloatMatrix.Row(index_Int).CopyTo(row_FloatVector);

            max_FloatMatrix.Column(index_Int).CopyTo(column_FloatVector);

            int countRow_Int = VectorElementCount_Function(row_FloatVector, countID_Int, skipID_Int);

            if (highestCount_Int < countRow_Int)
                highestCount_Int = countRow_Int;

            int countColumn_Int = VectorElementCount_Function(column_FloatVector, countID_Int, skipID_Int);

            if (highestCount_Int < countColumn_Int)
                highestCount_Int = countColumn_Int;

        }

        return highestCount_Int;

    }

    private static int VectorElementCount_Function(Vector<float> array_FloatVector, int elementID_Int, int elementSkip_Int)
    {

        List<float> list_FloatList = [..array_FloatVector];

        int highestCount_Int = 0;

        while(list_FloatList.Count > 1)
        {

            list_FloatList = list_FloatList.SkipWhile(x => x == 0 | x == elementSkip_Int).ToList();

            int temp_Int = list_FloatList.TakeWhile(x => x == elementID_Int).Count();

            if(temp_Int > highestCount_Int)
                highestCount_Int = temp_Int;

            list_FloatList = list_FloatList.Skip(temp_Int).ToList();

        }

        return highestCount_Int;
    
    }

}