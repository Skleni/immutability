using System;

namespace Immutability
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = ImmutableStack<int>
                .Empty
                .Push(1)
                .Push(2)
                .Push(3);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            stack = stack.Pop();
            Console.WriteLine(stack.Peek());

            Console.ReadLine();
        }
    }
}
