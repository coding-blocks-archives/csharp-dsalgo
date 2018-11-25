using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksQueue
{
    class StackQue
    {
        public static int HistogramArea(int[] arr)
        {
            Stack<int> index = new Stack<int>();
            Stack<int> height = new Stack<int>();
            int bestArea = 0;
            for(int i = 0; i <= arr.Length; ++i)
            {
                int curHt = i == arr.Length ? -1 : arr[i]; 
                // when i == arr.Length
                int idx = i;
                while(height.Count != 0 && height.Peek() >= curHt)
                {
                    // I can take decision
                    int reqHt = height.Peek();
                    idx = index.Peek();
                    int reqWidth = i - idx;
                    int curArea = reqHt * reqWidth;
                    bestArea = Math.Max(bestArea, curArea);
                    height.Pop();
                    index.Pop();
                }
                index.Push(idx);
                height.Push(curHt);
            }
            return bestArea;
        }


        public static int[] PrevSmallerElement(int[] arr)
        {
            Stack<int> stk = new Stack<int>();
            int[] ans = new int[arr.Length];

            for (int i = 0; i < arr.Length; ++i)
            {
                while (stk.Count != 0 && stk.Peek() > arr[i])
                {
                    stk.Pop();
                }
                // either my stk is empty or I have a smaller element in the stack
                ans[i] = stk.Count == 0 ? int.MaxValue : stk.Peek();
                stk.Push(arr[i]);
            }
            return ans;
        }

        public static void MyMain()
        {
            //int[] arr = { 5, 6, 2, 0, 4, 7, 1 };
            //var ans = PrevSmallerElement(arr);
            //foreach (int x in arr)
            //{
            //    Console.Write(x + " ");
            //}
            //Console.WriteLine();

            //foreach (int x in ans)
            //{
            //    Console.Write(x + " ");
            //}

            int[] arr = { 6, 5 };
            int bestArea = HistogramArea(arr);
            Console.WriteLine(bestArea);
        }
    }
}
