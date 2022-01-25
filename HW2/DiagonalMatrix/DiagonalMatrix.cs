using System;
using System.Text;

namespace DiagonalMatrixProject
{
	public class DiagonalMatrix
	{
		public int[] DiagonalMatrixMembers { get; set; }
		public int Size { get;}

		public DiagonalMatrix(params int[] array)
		{
			if (array != null)
			{
				Size = array.Length;
				DiagonalMatrixMembers = new int[Size];
				for (int i = 0; i < Size; i++)
				{
					DiagonalMatrixMembers[i] = array[i];
				}
			}
			else
            {
				DiagonalMatrixMembers = new int[0];
				Size = 0;
            }

		}

		public int this[int i, int j]
		{
			get
			{
				if (i != j)
				{
					return 0;
				}
				if (i == Size || j == Size || i < 0 || j < 0 || i >= Size || j>= Size)
				{
					return 0;
				}
				else
				{
					return DiagonalMatrixMembers[i];
				}
			}
			set
			{
				if (i == j && i < Size && j < Size && i>= 0 && j>=0)
				{
					DiagonalMatrixMembers[i] = value;
				}

			}
		}

		public int Track()
		{
			int temp = 0;
			foreach (int number in DiagonalMatrixMembers)
			{
				temp = temp + number;
			}
			return temp;
		}

        public override string ToString()
        {
			var stringToPrint = new StringBuilder();
			int temp = Size;
			int temp1 = Size-1;
			int temp2 = 0;

			for (int j = 0; j < Size; j++)
			{

                for (int z = 0; z < temp2; z++) // numbers of zero in front
                {
					stringToPrint.Append("0");

				}

                stringToPrint.Append(this.DiagonalMatrixMembers[j]); // the number on the diagonal

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

        public override bool Equals(object obj)
		{
			var comparedObject = (DiagonalMatrix)obj;

			if (comparedObject.Size == this.Size) //checks size first
            {
				for(int i = 0; i<Size; i++)
                {
					if(comparedObject.DiagonalMatrixMembers[i] != this.DiagonalMatrixMembers[i]) // if atleast one i member of this array is not equal to compared Diagonal Matrix i member of its array, then return false
                    {
						return false;
                    }
                }
				return true; // if the for loop is completed and the above condition isn't changed, return true
            }
			return false; // if the sizes arent equal, return false
		}
    }
}



