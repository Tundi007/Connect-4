using MathNet.Numerics.LinearAlgebra;

namespace Connect4;

class Program
{

    static void Main(string[] args)
    {     

        do
        {

            MyGame.SideSelect_Function();

            MyGame.Load_Function();

        } while (MyGame.Rematch_Function());

    }

}