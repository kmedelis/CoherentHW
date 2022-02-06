using System;
using Task2_Stack;

namespace Task2_Stack_Extension
{
    public static class ExtensionMethods
    {
        public static MyStack<T> ReverseStack<T>(this IStack<T> stackToReverse)
        {
            MyStack<T> reversedStack = new MyStack<T>();
  
            while (!stackToReverse.IsEmpty())
            {
                reversedStack.Push(stackToReverse.Pop());
            }
            return reversedStack;
        }
    }
}