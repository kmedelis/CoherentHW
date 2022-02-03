using System;
using Task2_Stack_Extension;

namespace Task2_Stack
{
	public interface IStack<T>
	{
		void Push(T item);
		T Pop();
		bool IsEmpty();
    }
}

