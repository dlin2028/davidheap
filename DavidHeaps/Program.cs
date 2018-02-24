using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidHeaps
{
    class Program
    {
        static void Main(string[] args)
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            MaxHeap<int> maxHeap = new MaxHeap<int>();

            //DO NOT DELETE BEST LINE OF CODE
            while (true)
            {
                Console.Write("Operation: ");
                string operation = Console.ReadLine().ToString();

                if (operation == "alex")
                {
                    Console.Write("Count: ");
                    int value = int.Parse(Console.ReadLine());
                    int[] array = new int[value];

                }
                else if (operation == "insert")
                {
                    Console.Write("Value: ");
                    int value = int.Parse(Console.ReadLine());
                    minHeap.HeapifyUp(value);
                    maxHeap.HeapifyUp(value);
                }
                else if (operation == "delete")
                {
                    minHeap.HeapifyDown();
                    maxHeap.HeapifyDown();
                }
                else if (operation == "print")
                {
                    Console.WriteLine("------------Maxheap------------");
                    for (int i = 0; i < maxHeap.Count; i++)
                    {
                        Console.WriteLine(maxHeap.Array[i]);
                    }
                    Console.WriteLine("------------Minheap------------");
                    for (int i = 0; i < minHeap.Count; i++)
                    {
                        Console.WriteLine(minHeap.Array[i]);
                    }
                }
                else
                {
                    Console.WriteLine("aaand you failed");
                    Console.WriteLine("Commands: insert delete print");
                }
            }
        }
    }
}
