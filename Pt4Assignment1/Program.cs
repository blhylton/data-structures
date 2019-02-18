using System;
using System.Collections.Generic;

namespace Pt4Assignment1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var rand = new Random();
            const int p = 10000019;
            var a = rand.Next(1,32);
            var b = rand.Next(1, 32);

            var input = Console.ReadLine();
            if (input == null) return;
            var n = int.Parse(input);
            var m = 1000;
            var count = 0;

            var list = new List<PhoneBookEntry>[m];

            for (var i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                if (input == null) continue;
                var splitInput = input.Split(' ');
                var h = Hash(a, b, p, int.Parse(splitInput[1]), m);
                switch (splitInput[0])
                {
                    case "add":
                        
                        if (list[h] == null)
                        {
                            list[h] = new List<PhoneBookEntry>();
                        }

                        var entry = list[h].Find(e => e.Number == int.Parse(splitInput[1]));
                        if (entry == default(PhoneBookEntry))
                        {
                            list[h]
                                .Add(new PhoneBookEntry(
                                    int.Parse(splitInput[1]),
                                    splitInput[2]
                                ));    
                        }
                        else
                        {
                            entry.Name = splitInput[2];
                        }
                        
                        break;
                    case "find":
                        if(list[h] == null) Console.WriteLine("not found");
                        else
                        {
                            var value = list[h].Find(e => e.Number == int.Parse(splitInput[1]));
                            Console.WriteLine(value == default(PhoneBookEntry) ? "not found" : value.Name);
                        }
                        break;
                    case "del":
                        if (list[h] != null)
                        {
                            list[h].Remove(list[h].Find(e => e.Number == int.Parse(splitInput[1])));
                        }
                        break;
                    default:
                        break;
                }
            }
            
            
        }

        private static int Hash(int a, int b, int p, int x, int m)
        {
            return (((a * x) + b) % p) % m;
        }
    }

    internal class PhoneBookEntry
    {
        public PhoneBookEntry(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }

        public string Name { get; set; }
        public int Number { get; private set; }
    }
}