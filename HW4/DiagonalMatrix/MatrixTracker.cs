using System;
using DiagonalMatrixProject;
using System.Collections.Generic;
using DiagonalMatrix;


namespace DiagonalMatrix
{
	public class MatrixTracker<T>
	{
		public GenericDiagonalMatrix<T> DiagonalMatrix;

		private int _lastCoordinateI;
		private int _lastCoordinateJ;

		public MatrixTracker(GenericDiagonalMatrix<T> obj)
		{
			DiagonalMatrix = obj;
			DiagonalMatrix.OnElementChangeEvent += this.Tracker;
		}

        public void Tracker(object sender, ElementChanged<T> elementChanged)
        {
			_lastCoordinateI = elementChanged.I;
			_lastCoordinateJ = elementChanged.J;
		}

		public void Undo() 
		{
			DiagonalMatrix[_lastCoordinateI, _lastCoordinateJ] = default(T);
		}

	}
}
