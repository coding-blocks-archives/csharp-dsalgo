using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class KSmallestNumbers
    {
        class ReverseInteger : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                if (a > b)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }


        public static void PrintKSmallest(int[] arr, int k)
        {
            SortedList<int, int> maxHeap = new SortedList<int, int>(new ReverseInteger());      // ascending order by default
             
            for(int i = 0; i < k; ++i)
            {
                maxHeap.Add(arr[i], arr[i]);
            }

            for(int i = k; i < arr.Length; ++i)
            {
                maxHeap.Add(arr[i], arr[i]);
                maxHeap.RemoveAt(0);
            }

            foreach (var item in maxHeap)
            {
                Console.WriteLine(item);
            }
        }

        public static void MyMain()
        {
            int[] arr = { 5, 4, 7, 1, 8, 3, 4 };
            PrintKSmallest(arr, 3);
        }
    }
}
