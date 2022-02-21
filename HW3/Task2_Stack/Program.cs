using Task2_Stack;
using Task2_Stack_Extension;

Console.WriteLine("Hello, World!");

MyStack<int> stack1 = new MyStack<int>();



stack1.Push(123);
stack1.Push(22);
stack1.Push(3);

Console.WriteLine(stack1.Pop()); // pops the last number 3
Console.WriteLine(stack1.Pop());
Console.WriteLine(stack1.Pop());
//Console.WriteLine(stack1.Pop()); // throws an exception because trying to pop empty stack

MyStack<string> stack2 = new MyStack<string>();

stack2.Push("asd");
stack2.Push("hohoho");
stack2.Push("labasvakaras");

MyStack<string> stack2reversed;

stack2reversed = stack2.ReverseStack(); // this creates completely new stack from stack2, just reversed

Console.WriteLine(stack2reversed.Pop()); //this pops asd, because this is reversed stack2
Console.WriteLine(stack2.Pop()); //this pops labasvakaras because this is the original stack2








