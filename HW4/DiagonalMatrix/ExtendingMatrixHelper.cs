using System;
using DiagonalMatrixProject;
using System.Collections.Generic;
using DiagonalMatrix;

namespace DiagonalMatrix
{
	public static class ExtendingMatrixHelper
	{

		public static GenericDiagonalMatrix<T> ExtendMatrix<T>(this GenericDiagonalMatrix<T> obj, Func<T, T, T> condition, GenericDiagonalMatrix<T> obj2)
		{
			int objSize = obj.Size;
			int objSize2 = obj2.Size;
			int diagonalSize = objSize > objSize2 ? objSize : objSize2;

			T[] diagonalExtended = new T[diagonalSize];
			var toReturnMatrix = new GenericDiagonalMatrix<T>(diagonalExtended.Length);

			for (int i = 0; i < objSize; i++)
			{
				toReturnMatrix[i, i] = condition.Invoke(obj[i, i], obj2[i, i]);
			}
			if (objSize > objSize2) // this deals with the situation when matrix 1 > matrix 2 and continues adding elements
			{
				for (int i = objSize2; i < objSize; i++)
				{
					toReturnMatrix[i, i] = obj2[i, i];
				}
			}
			if (objSize < objSize2) // this deals with the situation when matrix 1 < matrix 2 and continues adding elements 
			{
				{
					for (int i = objSize; i < objSize2; i++)
					{
						toReturnMatrix[i, i] = obj2[i, i];
					}
				}
			}
			return toReturnMatrix;
		}
	}
}



