using System;
using System.Collections.Generic;

namespace Wk1Problem1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input == null) return;
            var stack = new Stack<CodeChar>();
            var i = 0;
            for(i = 0; i < input.Length; i++)
            {
                var c = input[i];
                switch (c)
                {
                    case '[':
                    case '(':
                    case '{':
                        stack.Push(new CodeChar(){ Value = c, Position = i + 1});
                        break;
                    case ']':
                    case ')':
                    case '}':
                    {
                        if (stack.Count == 0)
                        {
                            Console.WriteLine(i + 1);
                            return;
                        }

                        var top = stack.Pop();
                        if ((top.Value == '[' && c != ']') ||
                            (top.Value == '(' && c != ')') ||
                            (top.Value == '{' && c != '}'))
                        {
                            Console.WriteLine(i + 1);
                            return;
                        }

                        break;
                    }
                    default:
                        break;
                }
            }

            if (stack.Count != 0)
            {
                Console.WriteLine(stack.Peek().Position);
                return;
            }
            Console.WriteLine("Success");

        }
    }

    internal struct CodeChar
    {
        public char Value;
        public int Position;
    }
}