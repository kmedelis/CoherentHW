using System;
using System.Text;
using DiagonalMatrix;

namespace DiagonalMatrixProject
{
	public class GenericDiagonalMatrix<T>
	{
		private T[] _diagonalMatrix { get; set; }
		private readonly int _size;
        public event EventHandler<ElementChanged<T>> OnElementChangeEvent;

		public GenericDiagonalMatrix(int size)
		{
			if (size < 0)
			{
				throw new ArgumentException();
			}
			if (size >= 0)
			{
				_diagonalMatrix = new T[size];
				_size = size;
			}

		}

        public GenericDiagonalMatrix(T[] diagonalExtended)
        {
            _diagonalMatrix = diagonalExtended;
        }

        public T this[int i, int j]
		{
			get
			{
				if (i != j)
				{
					return default(T);
				}
				if (i == _size || j == _size || i < 0 || j < 0 || i >= _size || j >= _size)
				{
					throw new IndexOutOfRangeException();
				}
				else
				{
					return _diagonalMatrix[i];
				}
			}
			set
			{
				if (i == j && i < _size && j < _size && i >= 0 && j >= 0)
				{
					T oldvalue = _diagonalMatrix[i];
					T newvalue = value;
					_diagonalMatrix[i] = value;
					if (!EqualityComparer<T>.Default.Equals(oldvalue, newvalue))
					{
						OnElementChangeEvent?.Invoke(this, new ElementChanged<T>(i, j, oldvalue, newvalue));

					}
				}
				
			}
		}

		public override string ToString()
		{
			var stringToPrint = new StringBuilder();
			int temp = _size;
			int temp1 = _size - 1;
			int temp2 = 0;

			for (int j = 0; j < _size; j++)
			{

				for (int z = 0; z < temp2; z++) // numbers of zero in front
				{
					stringToPrint.Append("0");

				}

				stringToPrint.Append(this._diagonalMatrix[j]); // the number on the diagonal

				for (int z = 0; z < temp1; z++) // the number of zeroes after 
				{
					stringToPrint.Append("0");

				}

				stringToPrint.Append("\n");
				temp2++;
				temp1--;
			}


			return stringToPrint.ToString();
		}


	}
}