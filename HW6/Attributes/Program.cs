using System.Reflection;
using Attributes;

Console.WriteLine("Hello, World!");

TestObject test = new TestObject(123, "asd", 456);
TestObjectNoAttribute test2 = new TestObjectNoAttribute(123);

Logger logger = new Logger();

logger.Track(test, "thisFile");
