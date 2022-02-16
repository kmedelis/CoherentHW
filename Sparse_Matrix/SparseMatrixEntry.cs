using System;
namespace Sparse_Matrix
{
	public class SparseMatrixEntry
	{
		public int CoordinateX;
		public int CoordinateY;
		public int Value;

		public SparseMatrixEntry(int coordinateX, int coordinateY, int value)
		{
			CoordinateX = coordinateX;
			CoordinateY = coordinateY;
			Value = value;
		}
	}
}

