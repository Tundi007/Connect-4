using MathNet.Numerics.LinearAlgebra;
namespace Connect4;

public class MyMatrix
{
    
    private readonly Matrix<Single> mainMatrix_SingleMatrix;

    public MyMatrix()
    {

        mainMatrix_SingleMatrix = Matrix<Single>.Build.Dense(5,5,0);

    }

    private bool Eligibility_Function(int nextMove_Int)
    {

        if(mainMatrix_SingleMatrix.Column(nextMove_Int).Contains(0))return true;

        return false;
    
    }

    public bool ApplyMove_Function(int nextMove_Int, int ID_Int)
    {

        if(!Eligibility_Function(nextMove_Int)) return false;

        int indexOfNextMove_Int = mainMatrix_SingleMatrix.Column(nextMove_Int).ToList().IndexOf(0);

        mainMatrix_SingleMatrix[indexOfNextMove_Int,nextMove_Int] = ID_Int;

        return true;
    
    }

    public Matrix<Single> GetMatrix_Function()
    {

        return mainMatrix_SingleMatrix;   
        
    
    }

    public static Matrix<Single> ApplyMove_Function(Matrix<Single> matrix_SingleMatrix, int nextMove_Int, int ID_Int)
    {

        if(!Eligibility_Function(matrix_SingleMatrix,nextMove_Int)) return Matrix<Single>.Build.Dense(1,1,-1);

        int indexOfNextMove_Int = matrix_SingleMatrix.Column(nextMove_Int).ToList().IndexOf(0);

        matrix_SingleMatrix[indexOfNextMove_Int,nextMove_Int] = ID_Int;

        return matrix_SingleMatrix;
    
    }

    private static bool Eligibility_Function(Matrix<Single> matrix_SingleMatrix,int nextMove_Int)
    {

        if(matrix_SingleMatrix.Column(nextMove_Int).Contains(0))return true;

        return false;
    
    }

    public static Matrix<Single> FourByFour_Function(Matrix<Single> matrix_SingleMatrix, int corner_Int)
    {

        Matrix<Single> fourByFour_SingleMatrix = Matrix<Single>.Build.Dense(4,4,0);

        if(corner_Int == 0)fourByFour_SingleMatrix = matrix_SingleMatrix.SubMatrix(0,4,0,4);

        if(corner_Int == 1)fourByFour_SingleMatrix = matrix_SingleMatrix.SubMatrix(0,4,1,4);

        if(corner_Int == 2)fourByFour_SingleMatrix = matrix_SingleMatrix.SubMatrix(1,4,1,4);

        if(corner_Int == 3)fourByFour_SingleMatrix = matrix_SingleMatrix.SubMatrix(1,4,0,4);        

        return fourByFour_SingleMatrix;

    }

}