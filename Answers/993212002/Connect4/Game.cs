namespace Connect4;
// class MyGame2
// {

//     private static int PID_Int = 1;

//     private static int BID_Int = 2;

//     private static string error_String = "";

//     private static void PrematureExit_Function()
//     {

//         Console.Clear();

//         System.Console.WriteLine("Have A Nice Day!");

//         Thread.Sleep(300);

//         Environment.Exit(0);

//     }

//     public static bool Rematch_Function()
//     {

//         int option_Int = 1;

//         while(!MyUI.UserInterface_Function("Rematch?", "No", "Yes", option_Int, out int output_Int))
//         {

//             option_Int = output_Int;

//             if (option_Int == -1) PrematureExit_Function();

//         }

//         if (option_Int == 2) return true;

//         return false;

//     }

//     public static void SideSelect_Function()
//     {

//         while (!MyUI.UserInterface_Function("Select Your Side(Use Arrow Keys):", "O", "X", PID_Int, out int output_Int))
//         {

//             if (output_Int == -1) PrematureExit_Function();

//             if (output_Int == 2) (PID_Int, BID_Int) = (BID_Int, PID_Int);

//             if (output_Int == 1) (PID_Int, BID_Int) = (BID_Int, PID_Int);

//         }

//         MyBot2.IDInit_Function(PID_Int, BID_Int);

//     }

//     public static void Load_Function()
//     {

//         System.Console.WriteLine("your side is: " + PID_Int);

//         Console.ReadKey(true);

//         // string loading_String = "[                    ]";        

//         // bool loading_Bool = true;

//         // for (int loading_Int = 2; loading_Int < 23; loading_Int++)
//         // {            

//         //     Console.Clear();            

//         //     System.Console.Write("Loading");

//         //     System.Console.Write(loading_String);

//         //     if(loading_Int == 22)System.Console.WriteLine("100%");
//         //     else System.Console.WriteLine((int)((double)loading_Int/23*100)+"%");

//         //     loading_String = loading_String[..(loading_Int-1)] + "-" + loading_String[(loading_Int)..];

//         //     if(loading_Int == 4)Thread.Sleep(200);

//         //     if(loading_Bool)
//         //     {

//         //         if(loading_Int%1==0)Thread.Sleep(1);

//         //         if(loading_Int%3==0)Thread.Sleep(30);

//         //         if(loading_Int%5==0)Thread.Sleep(100);

//         //         if(loading_Int%6==0)Thread.Sleep(200);

//         //         if(loading_Int%7==0)Thread.Sleep(300);

//         //         if(loading_Int%10==0)
//         //         {

//         //             Thread.Sleep(400);

//         //             loading_Bool = false;

//         //         }

//         //     }else Thread.Sleep(5);

//         // }

//         // for (int loading_Int = 3; loading_Int > 0; loading_Int--)
//         // {

//         //     System.Console.WriteLine("Game Starting In " + loading_Int + "...");

//         //     Thread.Sleep(900);

//         // }

//         // Thread.Sleep(300);

//         // Console.Clear();

//         Game_Function();

//     }

//     private static void Game_Function()
//     {

//         MyMatrix2 gameBoard_MyMatrix = new();

//         error_String = "";

//         bool gameOver_Bool = false;

//         while (!gameOver_Bool)
//         {

//             while (true)
//             {

//                 int nextMove_Int = MyUI.GameInterface_Function(error_String, gameBoard_MyMatrix.GetMatrix_Function());

//                 error_String = "";

//                 if (nextMove_Int == -1) PrematureExit_Function();

//                 if (gameBoard_MyMatrix.ApplyMove_Function(nextMove_Int, PID_Int)) break;

//                 error_String = $"Can't Place There (Column: {nextMove_Int + 1})";

//             }

//             System.Console.WriteLine("Hi");

//             gameBoard_MyMatrix.ApplyMove_Function(MyBot2.Bot_Function(gameBoard_MyMatrix.GetMatrix_Function()), BID_Int);

//             System.Console.WriteLine("Bye");

//             int winnder_Int = CheckGoal_Function(gameBoard_MyMatrix.GetMatrix_Function());

//             if (winnder_Int == PID_Int)
//             {
                
//                 Console.WriteLine("You Won!");
                
//                 gameOver_Bool = true;
                
//             }

//             if (winnder_Int == BID_Int)
//             {
                
//                 Console.WriteLine("Game Over!");
                
//                 gameOver_Bool = true;
                
//             }

//             Console.ReadKey();

//         }

//     }

//     private static int CheckGoal_Function(Matrix<Single> matrix_SingleMatrix)
//     {

//         Matrix<Single> fourByFour_SingleMatrix = Matrix<Single>.Build.Dense(4, 4, 0);

//         for (int corner_Int = 0; corner_Int < 4; corner_Int++)
//         {

//             fourByFour_SingleMatrix = MyMatrix2.FourByFour_Function(matrix_SingleMatrix, corner_Int);

//             if (fourByFour_SingleMatrix.Diagonal().All(x => x == PID_Int))
//                 return PID_Int;

//             if (fourByFour_SingleMatrix.Diagonal().All(x => x == BID_Int))
//                 return BID_Int;

//             for (int indexFor_Int = 0; indexFor_Int < 4; indexFor_Int++)
//             {

//                 if (fourByFour_SingleMatrix.Column(indexFor_Int).All(x => x == PID_Int))
//                     return PID_Int;

//                 if (fourByFour_SingleMatrix.Row(indexFor_Int).All(x => x == PID_Int))
//                     return PID_Int;

//                 if (fourByFour_SingleMatrix.Column(indexFor_Int).All(x => x == BID_Int))
//                     return BID_Int;

//                 if (fourByFour_SingleMatrix.Row(indexFor_Int).All(x => x == BID_Int))
//                     return BID_Int;

//             }

//         }

//         return 0;

//     }

// }