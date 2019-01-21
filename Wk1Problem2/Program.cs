using System;
using System.Collections.Generic;
using System.Linq;

namespace Wk1Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            if (input == null) return;
            var parentIndices = input.Split(' ');
            var nodes = new Node[n];

            for (var i = 0; i < n; i++)
            {
                nodes[i] = new Node(){ParentIndex = int.Parse(parentIndices[i])};
            }

            var root = -1;

            for (var i = 0; i < n; i++)
            {
                var parentIndex = nodes[i].ParentIndex;
                if (parentIndex == -1)
                {
                    root = i;
                    nodes[i].Level = 1;
                    continue;
                }
                
                nodes[parentIndex].AddChild(nodes[i]);
            }
            
            var queue =  new Queue<Node>();
            
            queue.Enqueue(nodes[root]);

            var maxLevel = 1;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Level > maxLevel)
                {
                    maxLevel = current.Level;
                }

                if (current.Children.Count <= 0) continue;
                foreach (var c in current.Children)
                {
                    c.Level = current.Level + 1;
                        
                    queue.Enqueue(c);
                }
            }
            
            Console.WriteLine(maxLevel);
            
        }
    }

    class Node
    {
        private readonly List<Node> _children = new List<Node>();

        public int ParentIndex { get; set; }
        public int Level { get; set; }

        public List<Node> Children => _children;

        public void AddChild(Node node)
        {
            this._children.Add(node);
        }
        
        
        
    }
}