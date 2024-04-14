using MathNet.Numerics.LinearAlgebra;
namespace Connect4;
// public class MyMatrix2
// {

//     private readonly Matrix<Single> mainMatrix_SingleMatrix;

//     public MyMatrix2()
//     {

//         mainMatrix_SingleMatrix = Matrix<Single>.Build.Dense(5, 5, 0);

//     }

//     private bool Eligibility_Function(int nextMove_Int)
//     {

//         if (mainMatrix_SingleMatrix.Column(nextMove_Int).Contains(0)) return true;

//         return false;

//     }

//     public bool ApplyMove_Function(int nextMove_Int, int ID_Int)
//     {

//         if (!Eligibility_Function(nextMove_Int)) return false;

//         int indexOfNextMove_Int = mainMatrix_SingleMatrix.Column(nextMove_Int).ToList().IndexOf(0);

//         mainMatrix_SingleMatrix[indexOfNextMove_Int, nextMove_Int] = ID_Int;

//         return true;

//     }

//     public Matrix<Single> GetMatrix_Function()
//     {

//         return mainMatrix_SingleMatrix;


//     }

//     public static Matrix<Single> ApplyMove_Function(Matrix<Single> matrix_SingleMatrix, int nextMove_Int, int ID_Int)
//     {

//         if (!matrix_SingleMatrix.Column(nextMove_Int).Contains(0)) return Matrix<Single>.Build.Dense(1, 1, -1);

//         Matrix<Single> outputMatrix_SingleMatrix = Matrix<Single>.Build.Dense(5,5,0);

//         matrix_SingleMatrix.CopyTo(outputMatrix_SingleMatrix);

//         int indexOfNextMove_Int = matrix_SingleMatrix.Column(nextMove_Int).ToList().IndexOf(0);

//         outputMatrix_SingleMatrix[indexOfNextMove_Int, nextMove_Int] = ID_Int;

//         return outputMatrix_SingleMatrix;

//     }

//     public static Matrix<Single> FourByFour_Function(Matrix<Single> matrix_SingleMatrix, int corner_Int)
//     {

//         Matrix<Single> fourByFour_SingleMatrix = Matrix<Single>.Build.Dense(4, 4, 0);

//         if (corner_Int == 0) matrix_SingleMatrix.SubMatrix(0, 4, 0, 4).CopyTo(fourByFour_SingleMatrix);

//         if (corner_Int == 1) matrix_SingleMatrix.SubMatrix(0, 4, 1, 4).CopyTo(fourByFour_SingleMatrix);

//         if (corner_Int == 2) matrix_SingleMatrix.SubMatrix(1, 4, 1, 4).CopyTo(fourByFour_SingleMatrix);

//         if (corner_Int == 3) matrix_SingleMatrix.SubMatrix(1, 4, 0, 4).CopyTo(fourByFour_SingleMatrix);

//         return fourByFour_SingleMatrix;

//     }

//     public static int CountID_Function(Vector<Single> vector_SingleVector, int ID_Int)
//     {

//         return vector_SingleVector.SkipWhile(x => x.Equals(3)).TakeWhile(x => x.Equals(ID_Int)).Count();
        
    
//     }

// }


class GameBoard
{

    private static Matrix<float> gameBoard_FloatMatrix = Matrix<float>.Build.Dense(5,5,0);

    public static void GameBoardReset_Function()
    {
    
        gameBoard_FloatMatrix = Matrix<float>.Build.Dense(5,5,0);
    
    }

    public static Matrix<float> GameBoardStatus_Function()
    {
    
        return gameBoard_FloatMatrix;
    
    }

    public static bool ElementPlace_Function(int elementRow_Int,int elementColumn_Int, int elementValue_Int)
    {
        
        if(elementRow_Int < 5 & elementRow_Int > -1 & elementColumn_Int < 5 & elementColumn_Int > -1)
        {

            gameBoard_FloatMatrix[elementRow_Int,elementColumn_Int] = elementValue_Int;

            return true;

        }

        return false;
    
    }

    public static bool ElementValidColumn_Function(Matrix<float>matrix_FloatMatrix, int column_Int, out int output_Int)
    {

        output_Int = -1;

        bool success_Bool = false;

        if(column_Int < 0 & column_Int > 4)
        return success_Bool;

        if(matrix_FloatMatrix.Column(column_Int).Contains(0))
        {

            success_Bool = true;
            
            output_Int = matrix_FloatMatrix.Column(column_Int).ToList().IndexOf(0);

        }

        return success_Bool;
    
    }

    public static bool SubMatrix_Function(Matrix<float> matrix_FloatMatrix,int subCorner_Int,out Matrix<float> output_FloatMatrix)
    {
        
        int columnIndex_Int;

        int rowIndex_Int;

        output_FloatMatrix = Matrix<float>.Build.Dense(4,4,-1);

        switch (subCorner_Int)
        {

            case 1:
                (rowIndex_Int, columnIndex_Int) = (0, 0);
                break;

            case 2:
                (rowIndex_Int, columnIndex_Int) = (1, 0);
                break;

            case 3:
                (rowIndex_Int, columnIndex_Int) = (0, 1);
                break;

            case 4:
                (rowIndex_Int, columnIndex_Int) = (1, 1);
                break;

            default:
                return false;
                
        }

        matrix_FloatMatrix.SubMatrix(rowIndex_Int, 4, columnIndex_Int, 4).CopyTo(output_FloatMatrix);

        return true;
    
    }

}