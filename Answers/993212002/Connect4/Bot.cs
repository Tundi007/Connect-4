using System.Security.Cryptography;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
namespace Connect4;

class Bot
{

    private static bool upgradedBot_Bool = false;

    private static bool clumsyBot_Bool = false;

    private static int playerID_Int = 1;

    private static int botID_Int = 2;

    public static int Bot_Function()
    {

        int[] cost_IntArray = new int[5];

        int bestCost_Int = -10;

        int bestMove_Int = -1;

        for (int elementColumn_Int = 0; elementColumn_Int < 5; elementColumn_Int++)
        {

            int botMaxPieces_Int = -10;

            int playerMaxPieces_Int = 0;

            if(GameBoard.ElementValidColumn_Function(GameBoard.GameBoardStatus_Function(), elementColumn_Int, out int elementRow_Int))
            {

                Matrix<float> botBoard_FloatMatrix = Matrix<float>.Build.DenseOfMatrix(GameBoard.GameBoardStatus_Function());

                Vector<float> elementVector_FloatVector = Vector<float>.Build.Dense(5);

                botBoard_FloatMatrix.
                    Column(elementColumn_Int).CopyTo(elementVector_FloatVector);

                elementVector_FloatVector[elementRow_Int] = botID_Int;

                botBoard_FloatMatrix.SetColumn(elementColumn_Int,elementVector_FloatVector);

                botMaxPieces_Int = Max_Function(botBoard_FloatMatrix, botID_Int, playerID_Int, false);

                for (int playerColumn_Int = 0; playerColumn_Int < 5; playerColumn_Int++)
                {

                    if(GameBoard.ElementValidColumn_Function(botBoard_FloatMatrix, playerColumn_Int, out int playerRow_Int))
                    {

                        Matrix<float> playerBoard_FloatMatrix = Matrix<float>.Build.DenseOfMatrix(botBoard_FloatMatrix);

                        playerBoard_FloatMatrix[playerRow_Int,playerColumn_Int] = playerID_Int;
                        
                        int min_Int = Max_Function(playerBoard_FloatMatrix, playerID_Int, botID_Int, true);

                        if(playerMaxPieces_Int < min_Int)
                            playerMaxPieces_Int = min_Int;

                    }
                    
                }

            }
            
            if(upgradedBot_Bool)
                if(botMaxPieces_Int > 3)
                    return elementColumn_Int;
                else if(playerMaxPieces_Int > 3)
                {

                    playerMaxPieces_Int = 100;

                }

            if(clumsyBot_Bool & botMaxPieces_Int != -10)
            {

                playerMaxPieces_Int += RandomNumberGenerator.GetInt32(0,2);

                playerMaxPieces_Int -= RandomNumberGenerator.GetInt32(0,2);

                botMaxPieces_Int += RandomNumberGenerator.GetInt32(0,2);

                botMaxPieces_Int -= RandomNumberGenerator.GetInt32(0,2);

            }

            cost_IntArray[elementColumn_Int] = botMaxPieces_Int - playerMaxPieces_Int;

        }

        for (int index_Int = 0; index_Int < 5; index_Int++)
        {

            if(bestCost_Int < cost_IntArray[index_Int])
            {

                bestMove_Int = index_Int;

                bestCost_Int = cost_IntArray[index_Int];                    
                
            }

        }

        return bestMove_Int;
    
    }

    private static int Max_Function(Matrix<float> max_FloatMatrix, int countID_Int, int skipID_Int, bool countZero_Bool)
    {

        int highestCount_Int = 0;

        if(upgradedBot_Bool)
        {            

            Matrix<float> mirror_SingleMatrix = Matrix<float>.Build.Dense(5,5,0);

            for (int i = 0; i < 5; i++)
            {

                mirror_SingleMatrix[4-i,i] = 1;
                
            }

            highestCount_Int = VectorElementCount_Function(max_FloatMatrix.Diagonal(), countID_Int, skipID_Int, false);

            int mirroredDiagonal_Int = VectorElementCount_Function(max_FloatMatrix.Multiply(mirror_SingleMatrix).Diagonal(), countID_Int, skipID_Int,false);

            if (highestCount_Int < mirroredDiagonal_Int)
                highestCount_Int = mirroredDiagonal_Int;
            
        }

        for (int index_Int = 0; index_Int < 5; index_Int++)
        {

            bool playerTrick_Bool = false;

            if(countZero_Bool & upgradedBot_Bool)
                playerTrick_Bool = true;

            int countRow_Int = VectorElementCount_Function(max_FloatMatrix.Row(index_Int), countID_Int, skipID_Int, playerTrick_Bool);

            if (highestCount_Int < countRow_Int)
                highestCount_Int = countRow_Int;

            int countColumn_Int = VectorElementCount_Function(max_FloatMatrix.Column(index_Int), countID_Int, skipID_Int, false);

            if (highestCount_Int < countColumn_Int)
                highestCount_Int = countColumn_Int;

        }

        return highestCount_Int;

    }

    private static int VectorElementCount_Function(Vector<float> array_FloatVector, int elementID_Int, int elementSkip_Int, bool countZero_Bool)
    {

        List<float> list_FloatList = [..array_FloatVector];

        int highestCount_Int = 0;

        if(upgradedBot_Bool)
        {

            if(!list_FloatList.Contains(0))
                return -10;

            if(list_FloatList.FindAll(x => x != elementSkip_Int).Count < 4)
                return -10;

        }

        while(list_FloatList.Count > 1)
        {

            list_FloatList = list_FloatList.SkipWhile(x => x != elementID_Int).ToList();

            int temp1_Int = list_FloatList.TakeWhile(x => x == elementID_Int && x != 0).Count();

            if(countZero_Bool)
            {

                list_FloatList.TakeWhile(x => x == elementID_Int || x == 0).TakeWhile(x => x == elementID_Int);

                int temp2_Int = list_FloatList.SkipWhile(x => x == elementID_Int).TakeWhile(x => x == 0).Count();

                int temp3_Int = list_FloatList.SkipWhile(x => x == elementID_Int).SkipWhile(x => x == 0).TakeWhile(x => x == elementID_Int).Count();

                if(temp1_Int + temp2_Int + temp3_Int > 3)
                        temp1_Int += temp3_Int;

            }

            if(temp1_Int > highestCount_Int)
                highestCount_Int = temp1_Int;

            list_FloatList = list_FloatList.Skip(temp1_Int).ToList();

        }

        return highestCount_Int;
    
    }

    public static string BotSet_Function(bool difficulty_Bool, bool dumbMode_Bool, int bot_Int, int player_Int)
    {

        string botInfo_String = "Bot: ";

        playerID_Int = player_Int;

        botID_Int = bot_Int;
        
        upgradedBot_Bool = difficulty_Bool;

        clumsyBot_Bool = dumbMode_Bool;

        if(upgradedBot_Bool)
            botInfo_String += "[Advanced] ";
        else
            botInfo_String += "[Normal] ";

        if(clumsyBot_Bool)
            botInfo_String += "[Clumsy]";

        return botInfo_String;
    
    }

}