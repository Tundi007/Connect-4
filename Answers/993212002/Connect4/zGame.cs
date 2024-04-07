using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Connect4;

// using MathNet.Numerics;
class Game
{

    private static readonly Matrix<BigInteger> gameBoard_BigIntegerMatrix = Matrix<BigInteger>.Build.Dense(5,5,0);

    public static void Game_Function()
    {

        int placement_Int = -1;

        if(placement_Int==-1)
        {

            placement_Int = ;

        }

        if(!gameBoard_BigIntegerMatrix.Column(placement_Int).Contains(0));

        gameBoard_BigIntegerMatrix[gameBoard_BigIntegerMatrix.Column(placement_Int).ToList().IndexOf(0),placement_Int] = 1;

    }

}