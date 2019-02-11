using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;

namespace Wk3Problem1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var maxSize = long.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            if (input == null) return;
            var splitInput = input.Split(' ');
            var numInput = new List<long>();
            var h = new Heap(maxSize);
            foreach (var t in splitInput)
            {
                numInput.Add(long.Parse(t));
            }
            h.BuildHeap(numInput.ToArray());
            Console.WriteLine(h.Swaps.Count);
            foreach (var o in h.Swaps)
            {
                Console.WriteLine(o[0] + " " + o[1]);
            }
        }
    }

    internal class Heap
    {
        private long[] _arr;
        private readonly long _maxSize;

        public Heap(long maxSize)
        {
            this._maxSize = maxSize;
            this.Swaps = new List<long[]>();
            this._arr = new long[maxSize];
        }

        private static long Parent(long i)
        {
            return (long)Math.Ceiling((decimal)i / 2) - 1;
        }

        private static long LeftChild(long i)
        {
            return (2 * i) + 1;
        }

        private static long RightChild(long i)
        {
            return (2 * i) + 2;
        }

        public void Insert(long i)
        {

            if (this.Size == this._maxSize)
            {
                throw new Exception();
            }
            
            this._arr[this.Size] = i;
            this.SiftUp(this.Size);
            this.Size++;
        }

        public void BuildHeap(long[] arr)
        {
            this._arr = arr;
            for (var i = (long)Math.Floor((double) _arr.Length / 2); i >= 0; i--)
            {
                SiftDown(i);
            }
        }

        private void SiftUp(long i)
        {
            while (i > 0 && this._arr[Parent(i)] > this._arr[i])
            {
                
                var temp = _arr[Parent(i)];
                _arr[Parent(i)] = _arr[i];
                _arr[i] = temp;
                i = Parent(i); 
            }
        }

        private void SiftDown(long i)
        {
            while (true)
            {
                var maxIndex = i;
                var l = LeftChild(i);
                var r = RightChild(i);
                if (l < this._maxSize && _arr[l] < _arr[maxIndex])
                {
                    maxIndex = l;
                }

                if (r < this._maxSize && _arr[r] < _arr[maxIndex])
                {
                    maxIndex = r;
                }

                if (i != maxIndex)
                {
                    var temp = _arr[maxIndex];
                    _arr[maxIndex] = _arr[i];
                    _arr[i] = temp;
                    this.Swaps.Add(new long[2] {i, maxIndex});
                    i = maxIndex;
                    continue;
                }

                break;
            }
        }

        private long Size { get; set; } = 0;

        public List<long[]> Swaps { get; }
    }
}