using System;
using Task2_Stack;

namespace Task2_Stack_Extension
{
    public static class ExtensionMethods
    {
        public static Stack<T> ReverseStack<T>(this IStack<T> stackToReverse)
        {
            Stack<T> tempStack = new Stack<T>();
            while (!stackToReverse.IsEmpty())
            {
                tempStack.Push(stackToReverse.Pop());
            }
            return tempStack;
        }
    }
}