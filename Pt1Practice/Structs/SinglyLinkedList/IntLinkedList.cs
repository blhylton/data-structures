using System;

namespace Pt1Practice.Structs.SinglyLinkedList
{
    /// <summary>
    /// A linked list specifically for handling integers.
    /// </summary>
    public unsafe class IntLinkedList
    {
        private IntNode* _head = null;
        private IntNode* _tail = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public IntLinkedList(){}

        /// <summary>
        /// Add new given integer value to the front of the linked list
        /// </summary>
        /// <param name="value">Value to Add</param>
        public void PushFront(int value)
        {
            var insertNode = new IntNode {Value = value};

            if (_head != null)
            {
                insertNode.Next = _head;

            }

            _head = &insertNode;

            if (_tail == null)
            {
                _tail = &insertNode;
            }

            return;
        }

        /// <summary>
        /// Read the front of the linked list.
        /// </summary>
        /// <returns>The value at the head of the list</returns>
        public int ReadFront()
        {
            return _head->Value;
        }

        /// <summary>
        /// Remove first element in linked list
        /// </summary>
        /// <returns>Value of element removed</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int PopFront()
        {
            if (_head == null)
            {
                throw new IndexOutOfRangeException("Attempted to remove value from empty list");
            }
            
            var returnValue = _head->Value;
            
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
                return returnValue;
            }
            
            _head = _head->Next;

            return returnValue;
        }

        /// <summary>
        /// Add new integer value to the end of the linked list
        /// </summary>
        /// <param name="value">Value to add</param>
        public void PushBack(int value)
        {
            var insertValue = new IntNode {Value = value};
            if (_head == null)
            {
                _head = &insertValue;
                _tail = &insertValue;
                return;
            }

            if (_head == _tail)
            {
                _head->Next = &insertValue;
                _tail = &insertValue;
                return;
            }

            _tail->Next = &insertValue;
            _tail = &insertValue;
            return;
        }

        /// <summary>
        /// Read the last value of the linked list
        /// </summary>
        /// <returns>The value at the tail of the list</returns>
        public int ReadBack()
        {
            return _tail->Value;
        }

        /// <summary>
        /// Remove last item from the linked list
        /// </summary>
        /// <returns>Value of the removed item</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public int PopBack()
        {
            if (_head == null)
            {
                throw new IndexOutOfRangeException("Attempted to remove value from empty list");
            }

            var returnValue = _tail->Value;

            if (_head == _tail)
            {
                _head = null;
                _tail = null;

                return returnValue;
            }

            var current = _head;
            while (true)
            {
                if (current->Next != _tail) continue;
                current->Next = null;
                _tail = current;
                return returnValue;
            }
        }

        /// <summary>
        /// Test if a value exists in the linked list
        /// </summary>
        /// <param name="value">Value to test against</param>
        /// <returns></returns>
        public bool Exists(int value)
        {
            var current = _head;
            while (current != null)
            {
                if (current->Value == value)
                {
                    return true;
                }

                current = current->Next;
            }

            return false;
        }

        /// <summary>
        /// Test if linked list is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _head == null;
        }
    }
}