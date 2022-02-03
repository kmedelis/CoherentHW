using System;
using Task2_Stack;

namespace Task2_Stack_Extension
{
    public static class ExtensionMethods
    {
        public static MyStack<T> ReverseStack<T>(this MyStack<T> stackToReverse)
        {
            var temp = new List<T>(); // using list to reverse stack
            MyStack<T> reversedStack = new MyStack<T>(); // this is the stack to return
            MyStack<T> tempStack = new MyStack<T>(); // this is a temporary stack

            while (stackToReverse.index > 0)
            {
                var tempRemove = stackToReverse.Pop(); //remove from original stack
                temp.Add(tempRemove); // add to the list
                tempStack.Push(tempRemove); // push from the temporary stack

            }

            foreach (T i in temp)
            {
                stackToReverse.Push(tempStack.Pop()); // we do this so that the original stackToReverse becomes not empty
                reversedStack.Push(i); // we do this to reverse the stack and then we return it.
            }

            return reversedStack;
        }
    }

}