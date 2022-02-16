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
		private Dictionary<(int height, int width), int> _matrixMembers;


		public SparseMatrix(int height, int width)
		{
			if (height > 0 && width > 0)
			{
				_matrixMembers = new Dictionary<(int height, int width), int>();
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
				if (!_matrixMembers.ContainsKey((i, j)))  // if there is no such value return 0
				{
					return 0;
				}
				else
				{
					return _matrixMembers[(i, j)];
				}
			}
			set
			{
				if (value != 0)
				{
					_matrixMembers.Add((i, j), value);
				}
				if (value == 0)
				{
					if (_matrixMembers.ContainsKey((i, j))) // this allows to zero out values
					{
						_matrixMembers.Remove((i, j));
					}
				}
			}
		}


		public override string ToString() // redoing this because I realized I can simply use get property get because it now returns 0.
		{
			StringBuilder matrixOutput = new StringBuilder();
			for (int i = 0; i < _height; i++)
			{
				for (int j = 0; j < _width; j++)
				{
					matrixOutput.Append(this[i, j]);
				}
				matrixOutput.Append("\n");
			}
			return matrixOutput.ToString();

		}

		public IEnumerator<int> GetEnumerator()
		{
			for (int i = 0; i < _height; i++)
			{
				for (int j = 0; j < _width; j++)
				{
					yield return this[i, j];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int GetCount(int value)
		{
			if (value == 0)
			{
				return _width * _height - _matrixMembers.Count;
			}
			else
			{
				return _matrixMembers.Count(x => x.Value == value);
			}
		}

		public IEnumerable<(int, int, int)> GetNoZeroElements()
		{
			foreach (KeyValuePair<(int, int), int> member in _matrixMembers)
			{
				yield return (member.Key.Item1, member.Key.Item2, member.Value);
			}
		}
	}
}