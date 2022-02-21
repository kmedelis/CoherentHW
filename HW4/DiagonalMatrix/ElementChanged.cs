using System;
using DiagonalMatrixProject;
using System.Collections.Generic;


namespace DiagonalMatrix
{
	public class ElementChanged<T> : EventArgs
	{
		public int I;
		public int J;
		public T OldValue { get; set; }
		public T NewValue { get; set; }

		public ElementChanged(int i, int j, T oldvalue, T newvalue)	
		{
			I = i;
			J = j;
			Oldvalue = oldvalue;
			Newvalue = newvalue;
		}
	}
}
