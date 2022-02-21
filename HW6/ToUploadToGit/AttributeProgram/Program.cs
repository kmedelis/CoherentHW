using System.Reflection;
using AttributesLibrary;
using System;
using Attributes;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        TestObject test = new TestObject(123, "asd", 456);
        TestObjectNoAttribute test2 = new TestObjectNoAttribute(123);

        Logger logger = new Logger();

        logger.Track(test, "thisFile");
        logger.Track(test2, "test"); // this doesnt print because it doesn't have trackingentity
    }
}
