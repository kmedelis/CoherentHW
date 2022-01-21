using System;
using Task2_Stack_Extension;

namespace Task2_Stack

{
    public class MyStack<T> : IStack<T>
    {
        public T[] arrayStack { get; set; }
        private int _stackSize;
        public int index;


        public MyStack()
        {
            _stackSize = 1;
            int index = 0;
            arrayStack = new T[_stackSize];
        }

        public bool IsEmpty()
        {
            if (index == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Pop()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("Exception: Empty stack"); // don't know much about exceptions yet, but I think this is apropriate use of them.
            }
            index--;
            T temp = arrayStack[index];
            return temp;
        }

        public void Push(T obj)
        {
            if (index == _stackSize)
            {
                _stackSize = _stackSize * 2;
                T[] tempArray = new T[_stackSize];
                Array.Copy(arrayStack, 0, tempArray, 0, index);
                arrayStack = tempArray;
            }
            arrayStack[index] = obj;
            index++;
        }
    }
}
