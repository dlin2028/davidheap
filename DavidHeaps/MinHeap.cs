using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidHeaps
{
    class MinHeap<T> where T : IComparable
    {
        public int Count;
        public int Capacity = 10;
        public T[] Array;

        public MinHeap()
        {
            Array = new T[Capacity];
        }

        public void Resize(int size)
        {
            Capacity = size;
            var newArray = new T[size];

            for (int i = 0; i < Array.Length; i++)
            {
                newArray[i] = Array[i];
            }

            Array = newArray;
        }

        public void HeapifyUp(T item)
        {
            Count++;
            if (Count >= Capacity - 2)
            {
                Resize(Capacity *= 2);
            }

            if (Array[0] == null)
            {
                Array[0] = item;
                return;
            }
            Array[Count - 1] = item;

            heapifyUp(Count - 1);
        }
        private void heapifyUp(int index)
        {
            T parent = Array[(index - 1) / 2];
            T currentNode = Array[index];
            if (parent.CompareTo(currentNode) > 0)
            {
                T temp = parent;
                parent = currentNode;
                currentNode = temp;

                Array[index] = currentNode;
                Array[(index - 1) / 2] = parent;

                heapifyUp((index - 1) / 2);
            }

            Array[index] = currentNode;
            Array[(index - 1) / 2] = parent;
        }

        public void HeapifyDown()
        {
            Count--;
            if (Count <= Capacity / 4)
            {
                Resize(Capacity /= 2);
            }
            Array[0] = Array[Count];
            Array[Count] = default(T);

            heapifyDown(0);
        }
        private void heapifyDown(int index)
        {
            T currentNode = Array[index];
            T leftNode = Array[index * 2 + 1];
            T rightNode = Array[index * 2 + 2];

            if (Count > index * 2)
            {
                return;
            }
            if (Count > index * 2 + 1)
            {
                if (currentNode.CompareTo(leftNode) < 0)
                {
                    return;
                }
                T temp = leftNode;
                leftNode = currentNode;
                currentNode = temp;

                Array[index * 2 + 1] = leftNode;
                Array[index] = currentNode;

                heapifyDown(index * 2 + 1);

            }

            //if the left node is less than right node
            if (leftNode.CompareTo(rightNode) < 0)
            {
                if (currentNode.CompareTo(leftNode) < 0)
                {
                    return;
                }
                T temp = leftNode;
                leftNode = currentNode;
                currentNode = temp;

                Array[index * 2 + 1] = leftNode;
                Array[index] = currentNode;

                heapifyDown(index * 2 + 1);
            }
            else if (rightNode.CompareTo(currentNode) < 0)
            {
                T temp = rightNode;
                rightNode = currentNode;
                currentNode = temp;

                Array[index * 2 + 2] = rightNode;
                Array[index] = currentNode;

                heapifyDown(index * 2 + 2);
            }
        }
    }
}
