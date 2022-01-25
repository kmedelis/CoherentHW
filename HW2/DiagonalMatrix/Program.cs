// See https://aka.ms/new-console-template for more information
using DiagonalMatrixProject;

DiagonalMatrix matrix = new DiagonalMatrix(1,2,3,4); // creates new diagonal matrix

DiagonalMatrix matrix1 = new DiagonalMatrix(1,2,3);

Console.WriteLine(matrix[1,1]); // prints out the value located at coordinates 1,1

matrix[1, 1] = 10; // sets a new value for coordinates 1,1

Console.WriteLine(matrix[1, 1]); //prints the new value

Console.WriteLine(matrix.Track()); // returns 18 because 1+10+3+4

Console.WriteLine(matrix.ToString());

Console.WriteLine(matrix.Size);

Console.WriteLine(matrix.DiagonalMatrixMembers[1]);
Console.WriteLine(matrix1.DiagonalMatrixMembers[1]);

Console.WriteLine(matrix.Equals(matrix1)); // returns false because matrix[1,1] = 10

matrix[1, 1] = 2;

Console.WriteLine(matrix.Equals(matrix1)); // returns true because matrix[1,1] = 2

Console.WriteLine(matrix.ToString());

DiagonalMatrix newDiagonal = matrix.Extend(matrix1); // extends the matrix array with matrix 1 by creating a new diagonal matrix

Console.WriteLine(newDiagonal.ToString());

