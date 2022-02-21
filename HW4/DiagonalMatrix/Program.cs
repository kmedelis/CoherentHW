// See https://aka.ms/new-console-template for more information
using DiagonalMatrixProject;
using DiagonalMatrix;
using System;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");


GenericDiagonalMatrix<int> diagonal = new GenericDiagonalMatrix<int>(4);
GenericDiagonalMatrix<int> diagonal2 = new GenericDiagonalMatrix<int>(5);



diagonal[0, 0] = 1;
diagonal2[0, 0] = 1;

diagonal[1, 1] = 2;
diagonal2[1, 1] = 1;

diagonal[2, 2] = 4;
diagonal2[2, 2] = 2;

diagonal[3, 3] = 5;
diagonal2[3, 3] = 4;

diagonal2[4, 4] = 3;

static T conditionAdd<T>(T a, T b)
{
    dynamic first = a;
    dynamic second = b;
    return first + second;
}


GenericDiagonalMatrix<int> diagonal3 = diagonal.ExtendMatrix(conditionAdd, diagonal2);

Console.WriteLine(diagonal3); //outputs the cororect matrix with {2,3,6,9,3}

GenericDiagonalMatrix<int> diagonal4 = new GenericDiagonalMatrix<int>(5);

MatrixTracker<int> tracker = new MatrixTracker<int>(diagonal4);

diagonal4[0, 0] = 1;
diagonal4[1, 1] = 2;
diagonal4[3, 3] = 1;
diagonal4[3, 3] = 4;

Console.WriteLine(diagonal4); // returns {1,2,4}

tracker.Undo();

Console.WriteLine(diagonal4); // returns {1,2,1}


GenericDiagonalMatrix<int> diagonal5 = new GenericDiagonalMatrix<int>(5);

MatrixTracker<int> tracker2 = new MatrixTracker<int>(diagonal5);

tracker2.Undo();

Console.WriteLine(diagonal5);