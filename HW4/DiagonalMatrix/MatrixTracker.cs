using System;
using DiagonalMatrixProject;
using System.Collections.Generic;


namespace DiagonalMatrix
{
	public class MatrixTracker<T>
	{
		public GenericDiagonalMatrix<T> DiagonalMatrix;
		private ElementChanged<T> _changedargs;

		public MatrixTracker(GenericDiagonalMatrix<T> obj)
		{
			DiagonalMatrix = obj;
			DiagonalMatrix.OnElementChangeEvent += this.Tracker;
			_changedargs = null;
		}

		public void Tracker(object sender, ElementChanged<T> elementChanged)
		{
			_changedargs = elementChanged;
		}

		public void Undo()
		{
			if (_changedargs == null)
			{
				Console.WriteLine("The matrix is empty");
			}
			else
			{
				DiagonalMatrix[_changedargs.I, _changedargs.J] = _changedargs.Oldvalue;
			}
		}

	}
}
