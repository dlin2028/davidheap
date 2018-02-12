using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidHeaps
{
    class HeapNode<T> where T : IComparable
    {
        public T Item;

        public HeapNode<T> Parent;
        public HeapNode<T> LeftNode;
        public HeapNode<T> RightNode;

        public HeapNode(T item)
        {
            Item = item;
            LeftNode = null;
            RightNode = null;
        }
    }
}
