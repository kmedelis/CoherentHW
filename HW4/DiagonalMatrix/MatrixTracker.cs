using System;
using DiagonalMatrixProject;
using System.Collections.Generic;
using DiagonalMatrix;


namespace DiagonalMatrix
{
	public class MatrixTracker<T>
	{
		public GenericDiagonalMatrix<T> DiagonalMatrix;

		public int lastCoordinateI;
		public int lastCoordinateJ;

		public MatrixTracker(GenericDiagonalMatrix<T> obj)
		{
			DiagonalMatrix = obj;
			DiagonalMatrix.OnElementChangeEvent += this.Tracker;
		}

        public void Tracker(object sender, ElementChanged<T> elementChanged)
        {
			lastCoordinateI = elementChanged.I;
			lastCoordinateJ = elementChanged.J;
		}

		public void Undo() // does this method has to have an ability to restore all changes made to diagonal matrix? Because if yes, I would have to store the
			// OldValue and NewValue and Coordinates from ElementChange into an array so I would know how to properly undo them in a row. 
		{
			DiagonalMatrix[lastCoordinateI, lastCoordinateJ] = default(T);
		}

	}
}

