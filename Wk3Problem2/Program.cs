using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Wk3Problem2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input == null) return;
            var splitInput = input.Split(' ');
            var n = long.Parse(splitInput[0]);
            var m = long.Parse(splitInput[1]);
            
            input = Console.ReadLine();
            if (input == null) return;
            splitInput = input.Split(' ');
            var numInput = new Queue<long>();
            foreach (var t in splitInput)
            {
                numInput.Enqueue(long.Parse(t));
            }

            var threads = new Thread[n];
            for (var i = 0; i < n; i++)
            {
                threads[i] = new Thread(i);
            }
            
            var h = new Heap(n);
            h.BuildHeap(threads);
            
            
            
            for (var i = 0; i < m; i++)
            {
                var currentThread = h.ExtractMin();
                var time = currentThread.Time;
                currentThread.Time += numInput.Dequeue();
                h.Insert(currentThread);
                
                Console.WriteLine(currentThread.Idx + " " + time);
            }
        }

        private class Heap
        {
            private readonly long _maxSize;
    
            public Heap(long maxSize)
            {
                this._maxSize = maxSize;
                this.Arr = new Thread[maxSize];
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
    
            public void Insert(Thread i)
            {
    
                if (this.Size == this._maxSize)
                {
                    throw new Exception();
                }
                
                this.Arr[this.Size] = i;
                this.SiftUp(this.Size);
                this.Size++;
            }
    
            public void BuildHeap(Thread[] arr)
            {
                this.Arr = arr;
                this.Size = arr.Length;
                for (var i = (long)Math.Floor((double) Arr.Length / 2); i >= 0; i--)
                {
                    SiftDown(i);
                }
            }
    
            private void SiftUp(long i)
            {
                while (i > 0 && this.Arr[Parent(i)].Time > this.Arr[i].Time)
                {
                    
                    var temp = Arr[Parent(i)];
                    Arr[Parent(i)] = Arr[i];
                    Arr[i] = temp;
                    i = Parent(i); 
                }
            }
    
            public Thread ExtractMin()
            {
                var result = this.Arr[0];
                this.Arr[0] = this.Arr[this.Arr.Length - 1];
                SiftDown(0);
                this.Size--;
                return result;
            }
    
            private void SiftDown(long i)
            {
                while (true)
                {
                    var maxIndex = i;
                    var l = LeftChild(i);
                    var r = RightChild(i);
                    if (l < this._maxSize && (Arr[l].Time < Arr[maxIndex].Time || (Arr[l].Time == Arr[maxIndex].Time && Arr[l].Idx < Arr[maxIndex].Idx)))
                    {
                        maxIndex = l;
                    }
    
                    if (r < this._maxSize && (Arr[r].Time < Arr[maxIndex].Time || (Arr[r].Time == Arr[maxIndex].Time && Arr[r].Idx < Arr[maxIndex].Idx)))
                    {
                        maxIndex = r;
                    }
    
                    if (i != maxIndex)
                    {
                        var temp = Arr[maxIndex];
                        Arr[maxIndex] = Arr[i];
                        Arr[i] = temp;
                        i = maxIndex;
                        continue;
                    }
    
                    break;
                }
            }
    
            private long Size { get; set; } = 0;

            public Thread[] Arr { get; private set; }
        }

        private class Thread
        {
            public Thread(long idx)
            {
                this.Idx = idx;
                this.Time = 0;
            }

            public long Idx { get; }

            public long Time { get; set; }
        }
    }
}