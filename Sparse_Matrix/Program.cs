using Sparse_Matrix;
using System;
using System.Text;
using System.Linq;
using System.Collections;
using Sparse_Matrix;
using System.Diagnostics;

SparseMatrix sparseMatrix = new SparseMatrix(6,6);

sparseMatrix[4, 1] = 5;
sparseMatrix[0, 4] = 2;
sparseMatrix[0, 0] = 3;


foreach(int sparse in sparseMatrix)
{
    Console.WriteLine(sparse); // returns the correct values
}

Console.WriteLine(sparseMatrix.ToString()); // prints out the matrix correctly

Console.WriteLine(sparseMatrix.GetCount(3)); // returns 1
Console.WriteLine(sparseMatrix.GetCount(0)); // returns 33

foreach ((int, int, int) element in sparseMatrix.GetNozeroElements()) //is this the correct implementation? it definitely works, but I am not sure whether it's correct
{
    Console.WriteLine(element); 
}

