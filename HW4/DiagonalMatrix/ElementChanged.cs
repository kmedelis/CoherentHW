using System;
using DiagonalMatrixProject;
using System.Collections.Generic;


namespace DiagonalMatrix
{
	public class ElementChanged<T>
	{
		public int I;
		public int J;
		public T Oldvalue { get; set; }
		public T Newvalue { get; set; }

		public ElementChanged(int i, int j, T oldvalue, T newvalue)	
		{
			I = i;
			J = j;
			Oldvalue = oldvalue;
			Newvalue = newvalue;
		}
	}
}

