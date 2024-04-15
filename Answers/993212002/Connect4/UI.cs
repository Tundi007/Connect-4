using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
namespace Connect4;

class MyUI
{

    public static bool UserInterface_Function(string menu_String, string firstOption_String, string secondOption_String, int pointer_Int, out int output_Int)
    {

        output_Int = pointer_Int;

        Console.Clear();

        System.Console.WriteLine(menu_String);

        if (pointer_Int == 1) System.Console.Write("->");

        System.Console.WriteLine(firstOption_String);

        if (pointer_Int == 2) System.Console.Write("->");

        System.Console.WriteLine(secondOption_String);

        switch (Console.ReadKey(true).Key)
        {

            case ConsoleKey.Enter:
                Console.Clear();
                return true;

            case ConsoleKey.Escape:
                output_Int = -1;
                break;

            case ConsoleKey.UpArrow:
                output_Int = 1;
                break;

            case ConsoleKey.DownArrow:
                output_Int = 2;
                break;

            default:
                break;

        }

        return false;

    }

    public static int GameInterface_Function(string error_String, Matrix<Single> gameBoard_SingleMatrix)
    {

        return KeyMenu_Function(error_String, gameBoard_SingleMatrix);

    }

    private static int KeyMenu_Function(string error_String, Matrix<Single> menuItems_ArrayString2D)
    {

        (int menuPointerColumn_Int, string hint_String) =
            (0, "Use Arrow Keys To Navigate, \"Enter\" To Select, \"Escape\" To Go Back");

        while (true)
        {

            Console.Clear();

            if (!string.IsNullOrWhiteSpace(error_String)) System.Console.WriteLine(error_String);

            error_String = "";

            ShowMenu_Function(menuItems_ArrayString2D, menuPointerColumn_Int);

            System.Console.WriteLine(hint_String);

            hint_String =
                "Use Arrow Keys To Navigate, \"Enter\" To Select, \"Escape\" To Exit";

            switch (Console.ReadKey(true).Key)
            {

                case ConsoleKey.Enter: Console.Clear(); return menuPointerColumn_Int;

                case ConsoleKey.Escape: Console.Clear(); return -1;

                case ConsoleKey.LeftArrow:
                    {

                        if (menuPointerColumn_Int < 1) break;

                        menuPointerColumn_Int--;

                    }
                    break;

                case ConsoleKey.RightArrow:
                    {

                        if (menuPointerColumn_Int > 3) break;

                        menuPointerColumn_Int++;

                    }
                    break;

                default:
                    hint_String = "Undefined Input, " + hint_String;
                    break;

            }

        }

    }

    public static void ShowMenu_Function(Matrix<Single> menuItems_ArrayString2D, int menuPointerColumn_Int)
    {

        System.Console.WriteLine();

        for (int columnNumber_Int = 0; columnNumber_Int < 5; columnNumber_Int++)
        {

            if (columnNumber_Int == menuPointerColumn_Int)
            {

                System.Console.Write("  V   ");

            }
            else
            {

                System.Console.Write("      ");

            }

        }

        System.Console.WriteLine();

        for (int rowNumber_Int = 4; rowNumber_Int > -1; rowNumber_Int--)
        {

            for (int columnNumber_Int = 0; columnNumber_Int < 5; columnNumber_Int++)
            {

                if (menuItems_ArrayString2D[rowNumber_Int, columnNumber_Int] == 1)
                {

                    System.Console.Write("| O | ");

                }
                if (menuItems_ArrayString2D[rowNumber_Int, columnNumber_Int] == 2)
                {

                    System.Console.Write("| X | ");

                }

                if (menuItems_ArrayString2D[rowNumber_Int, columnNumber_Int] == 0)
                {

                    System.Console.Write("| - | ");

                }

            }

            System.Console.WriteLine();

        }

    }


}