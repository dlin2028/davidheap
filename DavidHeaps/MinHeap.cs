using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidHeaps
{
    class MinHeap<T> where T : IComparable
    {
        private HeapNode<T> head;
        public int Count;
        public int Capacity = 10;
        public HeapNode<T>[] Array;

        public MinHeap()
        {
            Array = new HeapNode<T>[Capacity];
        }

        public void Resize(int size)
        {
            var newArray = new HeapNode<T>[size];
            for (int i = 0; i < size; i++)
            {
                newArray[i] = Array[i];
            }
        }

        public void HeapifyUp(T item)
        {
            Count++;
            if (Count >= Capacity)
            {
                Resize(Capacity *= 2);
            }

            HeapNode<T> node = new HeapNode<T>(item);
            if (head == null)
            {
                head = node;
                Array[0] = head;
                return;
            }
            node.Parent = Array[(Count - 1) / 2];


            if (node.Parent.LeftNode == null)
            {
                node.Parent.LeftNode = node;
            }
            else
            {
                node.Parent.RightNode = node;
            }
            Array[Count - 1] = node;

            heapifyUp(Count - 1);
        }
        private void heapifyUp(int index)
        {
            HeapNode<T> parent = Array[(index - 1) / 2];
            HeapNode<T> currentNode = Array[index];
            if (parent.Item.CompareTo(currentNode.Item) > 0)
            {
                T temp = parent.Item;
                parent.Item = currentNode.Item;
                currentNode.Item = temp;
                heapifyUp((index - 1) / 2);
            }
        }

        public void HeapifyDown()
        {
            Count--;
            if (Count <= Capacity / 4)
            {
                Resize(Capacity /= 2);
            }
            head = Array[Count];

            heapifyDown(Count);
        }
        private void heapifyDown(int index)
        {
            HeapNode<T> currentNode = Array[index];

            HeapNode<T> leftNode = null;
            if (index * 2 + 1 > Count)
            {
                leftNode = Array[index * 2 + 1];
            }
            if(leftNode == null)
            {
                return;
            }

            HeapNode<T> rightNode = null;
            if (index * 2 + 2 > Count)
            {
                rightNode = Array[index * 2 + 2];
            }
            if(rightNode == null)
            {
                T temp = leftNode.Item;
                leftNode.Item = currentNode.Item;
                currentNode.Item = temp;
                heapifyUp(index * 2 + 1);
                return;
            }

            //if the left node is greater than right node
            if (leftNode.Item.CompareTo(rightNode.Item) > 0)
            {
                T temp = leftNode.Item;
                leftNode.Item = currentNode.Item;
                currentNode.Item = temp;
                heapifyUp(index * 2 + 1);
            }
            else
            {
                T temp = rightNode.Item;
                leftNode.Item = currentNode.Item;
                currentNode.Item = temp;
                heapifyUp(index * 2 + 2);
            }
        }
    }
}
