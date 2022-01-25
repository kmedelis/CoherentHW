using System;	
namespace DiagonalMatrixProject
{
	static class DiagonalSum
	{
		public static DiagonalMatrix Extend(this DiagonalMatrix obj, DiagonalMatrix obj2)
		{
			int diagonalSize = obj.Size > obj2.Size ? obj.Size : obj2.Size;
			int[] diagonalExtended = new int[diagonalSize];

			for (int i = 0; i < diagonalSize; i++)
			{
				diagonalExtended[i] = obj[i, i] + obj2[i, i];
			}
			return new DiagonalMatrix(diagonalExtended);
		}
	}
}

