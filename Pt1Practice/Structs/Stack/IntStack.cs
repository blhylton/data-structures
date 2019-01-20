using Pt1Practice.Structs.SinglyLinkedList;

namespace Pt1Practice.Structs.Stack
{
    public class IntStack
    {
        private readonly IntLinkedList _list = new IntLinkedList();

        public IntStack(){}

        /// <summary>
        /// Push value to stack
        /// </summary>
        /// <param name="value">Value to push</param>
        public void Push(int value)
        {
            _list.PushFront(value);
        }

        /// <summary>
        /// Read top of stack
        /// </summary>
        /// <returns>Value at the top of the stack</returns>
        public int Top()
        {
            return _list.ReadFront();
        }

        /// <summary>
        /// Remove value at top of stack
        /// </summary>
        /// <returns>Value removed from stack</returns>
        public int Pop()
        {
            return _list.PopFront();
        }

        /// <summary>
        /// Test if stack is empty
        /// </summary>
        /// <returns>Boolean value indicating if stack is empty</returns>
        public bool IsEmpty()
        {
            return _list.IsEmpty();
        }
    }
}