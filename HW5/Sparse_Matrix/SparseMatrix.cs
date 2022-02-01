using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Diagnostics;
using Sparse_Matrix;

namespace Sparse_Matrix
{
	public class SparseMatrix : IEnumerable<int>
	{

		public int Height;
		public int Width;
		public List<SparseMatrixEntry> MatrixMembers;


		public SparseMatrix(int height, int width)
		{
			MatrixMembers = new List<SparseMatrixEntry>();
			Height = height;
			Width = width;
		}

		public int this[int i, int j]
		{
			get
			{
				foreach (SparseMatrixEntry entry in MatrixMembers)
				{
					if (entry.CoordinateX == i & entry.CoordinateY == j)
					{
						return entry.Value;
					}
				}
				return 0;
			}
			set
			{
				MatrixMembers.Add(new SparseMatrixEntry(i, j, value));
			}
		}

		public override string ToString()
		{

			MatrixMembers = MatrixMembers.OrderBy(x => x.CoordinateX)
					.ThenBy(x => x.CoordinateY).ToList(); // this ensures that the MatrixMembers is always sorted from low to high for the ToString method.

			int currentItem = 0;
			int tempX = MatrixMembers[currentItem].CoordinateX;
			int tempY = MatrixMembers[currentItem].CoordinateY;
			int tempValue = MatrixMembers[currentItem].Value;

			StringBuilder stringBuilder = new StringBuilder("");

			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					if (i == tempX && j == tempY) 
					{
						stringBuilder.Append(tempValue);
						if (currentItem != MatrixMembers.Count-1) // to prevent OutOfRange exception
						{
							currentItem++;
							tempX = MatrixMembers[currentItem].CoordinateX;
							tempY = MatrixMembers[currentItem].CoordinateY;
							tempValue = MatrixMembers[currentItem].Value;
						}
					}
					else
					{
						stringBuilder.Append("0");
					}
				}
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}

        public IEnumerator<int> GetEnumerator()
        {
			foreach (SparseMatrixEntry sparse in this.MatrixMembers)
            {
				yield return sparse.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			foreach (SparseMatrixEntry sparse in MatrixMembers)
			{
				yield return sparse.Value;

			}
		}

		public IEnumerable<(int, int, int)> GetNozeroElements()
        {
			MatrixMembers = MatrixMembers.OrderBy(x => x.CoordinateX)
					.ThenBy(x => x.CoordinateY).ToList(); // sorts the list by columns then rows
			List<SparseMatrixEntry> listOfTuples = new List<SparseMatrixEntry>();
			foreach(SparseMatrixEntry entry in MatrixMembers)
            {
				(int, int, int) tuple = (entry.CoordinateX, entry.CoordinateY, entry.Value);
				yield return tuple;
			}
		}

		public int GetCount(int value)
        {
			int count = 0;

			if (value == 0)
            {
				return Width * Height - MatrixMembers.Count;
            }
			else
            {
				foreach(SparseMatrixEntry entry in MatrixMembers)
                {
					if(entry.Value == value)
                    {
						count++;
                    }
                }
				return count;
            }
		}
	}
}