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
		
		private int _height;
		private int _width;
		private List<SparseMatrixEntry> _matrixMembers;


		public SparseMatrix(int height, int width)
		{
			if (height > 0 && width > 0)
			{
				_matrixMembers = new List<SparseMatrixEntry>();
				_height = height;
				_width = width;
			}
			else
			{
				throw new ArgumentException();
			}
		}

		public int this[int i, int j]
		{
			get
			{
				foreach (SparseMatrixEntry entry in _matrixMembers)
				{
					if (entry.CoordinateX == i & entry.CoordinateY == j)
					{
						return entry.Value;
					}
				}
				throw new ArgumentException("can't retrieve zero");
                
			}
			set
			{
				if (value != 0)
				{
					_matrixMembers.Add(new SparseMatrixEntry(i, j, value));
				}
                else
                {
					throw new ArgumentException("can't make zero a member of the matrix");
                }
			}
		}

		public override string ToString()
		{

			_matrixMembers = _matrixMembers.OrderBy(x => x.CoordinateX)
					.ThenBy(x => x.CoordinateY).ToList(); // this ensures that the MatrixMembers is always sorted from low to high for the ToString method.

			int currentItem = 0;
			int tempX = _matrixMembers[currentItem].CoordinateX;
			int tempY = _matrixMembers[currentItem].CoordinateY;
			int tempValue = _matrixMembers[currentItem].Value;

			StringBuilder stringBuilder = new StringBuilder("");

			for (int i = 0; i < _height; i++)
			{
				for (int j = 0; j < _width; j++)
				{
					if (i == tempX && j == tempY)
					{
						stringBuilder.Append(tempValue);
						if (currentItem != _matrixMembers.Count - 1) // to prevent OutOfRange exception
						{
							currentItem++;
							tempX = _matrixMembers[currentItem].CoordinateX;
							tempY = _matrixMembers[currentItem].CoordinateY;
							tempValue = _matrixMembers[currentItem].Value;
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
			foreach (SparseMatrixEntry sparse in this._matrixMembers)
			{
				if (sparse.Value != 0)
				{
					yield return sparse.Value;
				}
				else
				{
					throw new ArgumentException("can't return zero");
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (SparseMatrixEntry sparse in this._matrixMembers)
			{
				if (sparse.Value != 0)
				{
					yield return sparse.Value;
				}
                else
                {
					throw new ArgumentException("can't return zero");
                }
			}
		}

		public IEnumerable<(int, int, int)> GetNozeroElements()
		{
			_matrixMembers = _matrixMembers.OrderBy(x => x.CoordinateX)
					.ThenBy(x => x.CoordinateY).ToList(); // sorts the list by columns then rows
			List<SparseMatrixEntry> listOfTuples = new List<SparseMatrixEntry>();
			foreach (SparseMatrixEntry entry in _matrixMembers)
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
				return _width * _height - _matrixMembers.Count;
			}
			else
			{
				foreach (SparseMatrixEntry entry in _matrixMembers)
				{
					if (entry.Value == value)
					{
						count++;
					}
				}
				return count;
			}
		}
	}
}