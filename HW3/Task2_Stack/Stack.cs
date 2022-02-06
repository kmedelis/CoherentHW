using System;
using Task2_Stack_Extension;

namespace Task2_Stack

{
    public class MyStack<T> : IStack<T>
    {
        private T[] _arrayStack { get; set; }
        private int _stackSize;
        private int _index;


        public MyStack()
        {
            _stackSize = 1;
            int _index = 0;
            _arrayStack = new T[_stackSize];
        }

        public bool IsEmpty()
        {
            return _index == 0;
        }

        public T Pop()
        {
            if (_index == 0)
            {
                throw new InvalidOperationException("Exception: Empty stack"); // don't know much about exceptions yet, but I think this is apropriate use of them.
            }
            _index--;
            T temp = _arrayStack[_index];
            return temp;
        }

        public void Push(T obj)
        {
            if (_index == _stackSize)
            {
                _stackSize = _stackSize * 2;
                T[] tempArray = new T[_stackSize];
                Array.Copy(_arrayStack, 0, tempArray, 0, _index);
                _arrayStack = tempArray;
            }
            _arrayStack[_index] = obj;
            _index++;
        }
    }
}
