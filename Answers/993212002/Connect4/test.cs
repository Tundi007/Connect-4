// using MathNet.Numerics.LinearAlgebra;

// Matrix<float> a = Matrix<float>.Build.Dense(5,5,1);

// for (int i = 3; i > -1; i--)
// {


//     a[i,4-i] = 0;


// }

// System.Console.WriteLine("1");

// System.Console.WriteLine($"matrix\n{a}");

// System.Console.WriteLine();

// System.Console.WriteLine($"diagonal\n{a.Diagonal()}");

// System.Console.WriteLine(a.Diagonal().All(x => x == 1));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 1\n{a.SubMatrix(0,4,0,4)}");

// System.Console.WriteLine(a.SubMatrix(0,4,0,4).Diagonal().All(x => x == 0));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 2\n{a.SubMatrix(1,4,0,4)}");

// System.Console.WriteLine(a.SubMatrix(1,4,0,4).Diagonal().All(x => x == 0));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 3\n{a.SubMatrix(0,4,1,4)}");

// System.Console.WriteLine(a.SubMatrix(0,4,1,4).Diagonal().All(x => x == 0));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 4\n{a.SubMatrix(1,4,1,4)}");

// System.Console.WriteLine(a.SubMatrix(1,4,1,4).Diagonal().All(x => x == 0));

// System.Console.WriteLine();

// Matrix<float> b = Matrix<float>.Build.Dense(5,5,0);

// for (int i = 0; i < 5; i++)
// {

//     b[4-i,i] = 1;

// }

// System.Console.WriteLine();

// System.Console.WriteLine("2");

// System.Console.WriteLine($"<a> multiply by \n{b}");

// b = b.Multiply(a);

// System.Console.WriteLine();

// System.Console.WriteLine($"matrix\n{b}");

// System.Console.WriteLine();

// System.Console.WriteLine($"diagonal\n{b.Diagonal()}");

// System.Console.WriteLine(b.Diagonal().All(x => x == 1));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 1\n{b.SubMatrix(0,4,0,4)}");

// System.Console.WriteLine(b.SubMatrix(0,4,0,4).Diagonal().All(x => x == 0));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 2\n{b.SubMatrix(1,4,0,4)}");

// System.Console.WriteLine(b.SubMatrix(1,4,0,4).Diagonal().All(x => x == 0));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 3\n{b.SubMatrix(0,4,1,4)}");

// System.Console.WriteLine(b.SubMatrix(0,4,1,4).Diagonal().All(x => x == 0));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 4\n{b.SubMatrix(1,4,1,4)}");

// System.Console.WriteLine(b.SubMatrix(1,4,1,4).Diagonal().All(x => x == 0));

// System.Console.WriteLine();

// Matrix<float> c = Matrix<float>.Build.Dense(5,5);

// for (int j = 0; j < 4; j++)
// {

//     c[j,j] = 1;

// }

// System.Console.WriteLine();

// System.Console.WriteLine("3");

// System.Console.WriteLine($"matrix\n{c}");

// System.Console.WriteLine();

// System.Console.WriteLine($"diagonal\n{c.Diagonal()}");

// System.Console.WriteLine();

// System.Console.WriteLine(c.Diagonal().All(x => x == 1));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 1\n{c.SubMatrix(0,4,0,4)}");

// System.Console.WriteLine(c.SubMatrix(0,4,0,4).Diagonal().All(x => x == 1));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 2\n{c.SubMatrix(1,4,0,4)}");

// System.Console.WriteLine(c.SubMatrix(1,4,0,4).Diagonal().All(x => x == 1));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 3\n{c.SubMatrix(0,4,1,4)}");

// System.Console.WriteLine(c.SubMatrix(0,4,1,4).Diagonal().All(x => x == 1));

// System.Console.WriteLine();

// System.Console.WriteLine($"sub 4\n{c.SubMatrix(1,4,1,4)}");

// System.Console.WriteLine(c.SubMatrix(1,4,1,4).Diagonal().All(x => x == 1));

// using MathNet.Numerics.LinearAlgebra;

// float[,] c = new float[4,4];

// for (int i = 3; i > -1;i--)
// {

//     for (int j = 3; j > -1; j--)
//     {

//         c[i,j] = i*j+(i-j)*(i+j);

//     }
    
// }

// Matrix<Single> a = Matrix<Single>.Build.DenseOfArray(c);

// Matrix<Single> b = Matrix<Single>.Build.Dense(4,4,0);

// for (int i = 3; i > -1;i--)
// {

//     b[3-i,i] = 1;
    
// }
// System.Console.WriteLine(a.Diagonal());

// System.Console.WriteLine(b);

// System.Console.WriteLine(a.Multiply(b).Diagonal());

// Matrix<float> mirror_SingleMatrix = Matrix<float>.Build.Dense(5,5,0);

// for (int i = 4; i > -1; i--)
// {

//     mirror_SingleMatrix[4-i, i] = 1;
    
// }

// System.Console.WriteLine(mirror_SingleMatrix);