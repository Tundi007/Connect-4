using System.Security.Cryptography;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
namespace Connect4;

class Bot
{

    private static bool upgradedBot_Bool = false;

    private static bool visible_Bool = false;

    private static int playerID_Int = 1;

    private static int botID_Int = 2;

    public static int Bot_Function()
    {

        int bestCost_Int = -10000;

        int bestMove_Int = -1;

        int[] botMaxPieces_Int = new int[5];

        int[] playerMaxPieces_Int = new int[5];

        for (int elementColumn_Int = 0; elementColumn_Int < 5; elementColumn_Int++)
        {

            botMaxPieces_Int[elementColumn_Int] = -100;

            if(GameBoard.ElementValidColumn_Function(GameBoard.GameBoardStatus_Function(), elementColumn_Int, out int elementRow_Int))
            {

                playerMaxPieces_Int[elementColumn_Int] = -100;

                Matrix<float> botBoard_FloatMatrix = Matrix<float>.Build.DenseOfMatrix(GameBoard.GameBoardStatus_Function());

                Vector<float> elementVector_FloatVector = Vector<float>.Build.Dense(5);

                botBoard_FloatMatrix.
                    Column(elementColumn_Int).CopyTo(elementVector_FloatVector);

                elementVector_FloatVector[elementRow_Int] = botID_Int;

                botBoard_FloatMatrix.SetColumn(elementColumn_Int,elementVector_FloatVector);

                if(upgradedBot_Bool)
                    botMaxPieces_Int[elementColumn_Int] = Upgraded_Function(botBoard_FloatMatrix, botID_Int,playerID_Int);
                else
                    botMaxPieces_Int[elementColumn_Int] = Max_Function(botBoard_FloatMatrix, botID_Int,playerID_Int);
            
                if(botMaxPieces_Int[elementColumn_Int] == 100)
                    return elementColumn_Int;


                for (int playerColumn_Int = 0; playerColumn_Int < 5; playerColumn_Int++)
                {

                    if(GameBoard.ElementValidColumn_Function(botBoard_FloatMatrix, playerColumn_Int, out int playerRow_Int))
                    {

                        int min_Int = 0;

                        Matrix<float> playerBoard_FloatMatrix = Matrix<float>.Build.DenseOfMatrix(botBoard_FloatMatrix);

                        playerBoard_FloatMatrix[playerRow_Int,playerColumn_Int] = playerID_Int;

                        if(upgradedBot_Bool)
                            min_Int = Upgraded_Function(playerBoard_FloatMatrix, playerID_Int, botID_Int);
                        else
                            min_Int = Max_Function(playerBoard_FloatMatrix, playerID_Int,botID_Int);

                        if(min_Int == 100)
                            min_Int = 50;

                        if(playerMaxPieces_Int[elementColumn_Int] < min_Int)
                            playerMaxPieces_Int[elementColumn_Int] = min_Int;

                        if(visible_Bool)
                        {

                            Console.Clear();
                            
                            MyUI.ShowMenu_Function(playerBoard_FloatMatrix,-1);

                            System.Console.WriteLine("Bot: " + botMaxPieces_Int[elementColumn_Int] + " | Player: " + min_Int);

                            Thread.Sleep(100);

                        }

                    }
                    
                }

            }

        }

        for (int index_Int = 0; index_Int < 5; index_Int++)
        {

            if(bestCost_Int < botMaxPieces_Int[index_Int] - playerMaxPieces_Int[index_Int])
            {

                bestMove_Int = index_Int;

                bestCost_Int = botMaxPieces_Int[index_Int] - playerMaxPieces_Int[index_Int];
                
            }

        }

        System.Console.WriteLine(bestMove_Int);

        return bestMove_Int;
    
    }

    private static int Upgraded_Function(Matrix<float> botBoard_FloatMatrix, int ID_Int, int avoidID_Int)
    {

        int temp1_Int = UpgradedMax_Function(botBoard_FloatMatrix, ID_Int, avoidID_Int);

        int temp2_Int = Max_Function(botBoard_FloatMatrix, ID_Int,avoidID_Int);

        int return_Int;

        if (temp2_Int > temp1_Int)
            return_Int = temp2_Int;
        else
            return_Int = temp1_Int;

        if(return_Int == 100)
        Console.ReadKey();            

        return return_Int;

    }

    private static int Max_Function(Matrix<float> max_FloatMatrix, int ID_Int, int avoidID_Int)
    {

            Matrix<float> mirror_SingleMatrix = Matrix<float>.Build.Dense(5,5,0);

            for (int i = 4; i > -1; i--)
            {

                mirror_SingleMatrix[4-i, i] = 1;
                
            }

        int highestCount_Int = VectorElementCount_Function(max_FloatMatrix.Diagonal(), ID_Int, avoidID_Int);

        int mirroredDiagonal_Int = VectorElementCount_Function(max_FloatMatrix.Multiply(mirror_SingleMatrix).Diagonal(), ID_Int,avoidID_Int);

        if (highestCount_Int < mirroredDiagonal_Int)
            highestCount_Int = mirroredDiagonal_Int;

        for (int index_Int = 0; index_Int < 5; index_Int++)
        {

            int countRow_Int = VectorElementCount_Function(max_FloatMatrix.Row(index_Int), ID_Int, avoidID_Int);

            if (highestCount_Int < countRow_Int)
                highestCount_Int = countRow_Int;

            int countColumn_Int = VectorElementCount_Function(max_FloatMatrix.Column(index_Int), ID_Int, avoidID_Int);

            if (highestCount_Int < countColumn_Int)
                highestCount_Int = countColumn_Int;

        }

        return highestCount_Int;

    }
    
    private static int UpgradedMax_Function(Matrix<float> max_FloatMatrix, int ID_Int, int avoidID_Int)
    {

        int highestCount_Int = 0;

        int corner1_Int = 0;

        int corner2_Int = 0;

        Matrix<float> mirror_SingleMatrix = Matrix<float>.Build.Dense(4,4,0);

        for (int i = 3; i > -1; i--)
        {

            mirror_SingleMatrix[3-i, i] = 1;
            
        }

        for (int repeat_Int = 0; repeat_Int < 4; repeat_Int++)
        {

            Matrix<float> copy_FloatMatrix = Matrix<float>.Build.DenseOfMatrix(max_FloatMatrix.SubMatrix(corner1_Int,4,corner2_Int,4));

            Matrix<float> mirrorCopy_FloatMatrix = Matrix<float>.Build.DenseOfMatrix(max_FloatMatrix.SubMatrix(corner1_Int,4,corner2_Int,4).Multiply(mirror_SingleMatrix));

            if(corner2_Int == 1)
                corner1_Int--;
            else
            if(corner1_Int == 1)
                corner2_Int++;
            else
                corner1_Int++;

            if(copy_FloatMatrix.Diagonal().ToList().All(x => x == ID_Int))
                return 100;

            if(mirrorCopy_FloatMatrix.Diagonal().ToList().All(x => x == ID_Int))
                return 100;

            int diagonal_Int = UpgradedVectorElementCount_Function(copy_FloatMatrix.Diagonal(), ID_Int,avoidID_Int);

            int mirroredDiagonal_Int = UpgradedVectorElementCount_Function(mirrorCopy_FloatMatrix.Diagonal(), ID_Int,avoidID_Int);

            if(diagonal_Int > highestCount_Int)
                highestCount_Int = diagonal_Int;

            if(mirroredDiagonal_Int > highestCount_Int)
                highestCount_Int = mirroredDiagonal_Int;

            if(diagonal_Int == 4 | mirroredDiagonal_Int == 4)
                return 100;

            for (int index_Int = 0; index_Int < 4; index_Int++)
            {

                int countRow_Int = UpgradedVectorElementCount_Function(copy_FloatMatrix.Row(index_Int), ID_Int,avoidID_Int);

                if (highestCount_Int < countRow_Int)
                    highestCount_Int = countRow_Int;

                int countColumn_Int = UpgradedVectorElementCount_Function(copy_FloatMatrix.Column(index_Int), ID_Int,avoidID_Int);

                if (highestCount_Int < countColumn_Int)
                    highestCount_Int = countColumn_Int;

            }
            
        }

        return highestCount_Int;

    }

    private static int VectorElementCount_Function(Vector<float> array_FloatVector, int elementID_Int , int avoidID_Int)
    {

        List<float> list_FloatList = [..array_FloatVector];

        int highestCount_Int = 0;

        if(upgradedBot_Bool)
            if(list_FloatList.FindAll(x => x == avoidID_Int).Count > 1)
                return 0;
            else
            if(list_FloatList.FindAll(x => x == avoidID_Int).Count == 1)
                if(list_FloatList.IndexOf(avoidID_Int) != 0 & list_FloatList.IndexOf(avoidID_Int) != 4)
                    return 0;
                else
                if(list_FloatList.FindAll(x => x == elementID_Int ).Count > 3)
                    return 100;
                else{;}
            else
            if(list_FloatList.FindAll(x => x == elementID_Int ).Count > 3)
                return 100;

        while(list_FloatList.Count > 1)
        {

            list_FloatList = list_FloatList.SkipWhile(x => x != elementID_Int).ToList();

            int temp_Int = list_FloatList.TakeWhile(x => x == elementID_Int).Count();

            if(temp_Int > highestCount_Int)
                highestCount_Int = temp_Int;

            list_FloatList = list_FloatList.Skip(temp_Int).ToList();

        }

        return highestCount_Int;
    
    }
    
    private static int UpgradedVectorElementCount_Function(Vector<float> array_FloatVector, int elementID_Int, int avoidID_Int)
    {

        List<float> list_FloatList = [..array_FloatVector];

        int highestCount_Int = 0;

        if(list_FloatList.FindAll(x => x == avoidID_Int).Count > 0)
            return 0;

        if(list_FloatList.All(x => x == elementID_Int))
            return 100;

        while(list_FloatList.Count > 1)
        {

            list_FloatList = list_FloatList.SkipWhile(x => x == 0).ToList();

            int temp1_Int = list_FloatList.TakeWhile(x => x == elementID_Int && x != 0).Count();

            if(temp1_Int > highestCount_Int)
                highestCount_Int = temp1_Int;

            list_FloatList = list_FloatList.Skip(temp1_Int).ToList();

        }

        return highestCount_Int;
    
    }

    public static string BotSet_Function(bool difficulty_Bool, bool Show_Bool, int bot_Int, int player_Int)
    {

        string botInfo_String = "Bot: ";

        if((player_Int, bot_Int) == (0 , 0))
        {
            
            if(upgradedBot_Bool)
                botInfo_String += "[Advanced] ";
            else
                botInfo_String += "[Normal] ";

            if(visible_Bool)
                botInfo_String += "[Visible]";

            return botInfo_String;

        }

        playerID_Int = player_Int;

        botID_Int = bot_Int;
        
        upgradedBot_Bool = difficulty_Bool;

        visible_Bool = Show_Bool;

        if(upgradedBot_Bool)
            botInfo_String += "[Advanced] ";
        else
            botInfo_String += "[Normal] ";

        if(visible_Bool)
            botInfo_String += "[Visible]";

        return botInfo_String;
    
    }

}