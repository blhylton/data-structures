using Pt1Practice.Structs.SinglyLinkedList;

namespace Pt1Practice.Structs.Queue
{
    public class IntQueue
    {
        private readonly IntLinkedList _list;

        public IntQueue(){}

        /// <summary>
        /// Adds value to end of queue
        /// </summary>
        /// <param name="value">Value to add</param>
        public void Enqueue(int value)
        {
            _list.PushBack(value);
        }

        /// <summary>
        /// Remove value from front of queue
        /// </summary>
        /// <returns>Value removed from queue</returns>
        public int Dequeue()
        {
            return _list.PopFront();
        }

        /// <summary>
        /// Test if queue is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _list.IsEmpty();
        }
    }
}