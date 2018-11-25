using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    class HashingPractice
    {
        public static int GetMajorityElement(int[] arr)
        {
            // int, count
            Dictionary<int, int> countMap = new Dictionary<int, int>();
            foreach (var val in arr)
            {
                if (countMap.ContainsKey(val))
                {
                    countMap[val]++;
                }
                else
                {
                    countMap[val] = 1;
                }
            }

            foreach(KeyValuePair<int, int> kvp in countMap)
            {
                if (kvp.Value > arr.Length / 2) return kvp.Key;
            }
            return -1;
        }

        public static int VotingAlgorithm(int[] arr)
        {
            int reqEle = -1;
W
            foreach(int val in arr)
            {
                if (val == reqEle)
                {
                    ++count;
                }
                else
                {
                    --count;
                }
                if (count == 0)
                {
                    reqEle = val;
                    count = 1;
                }
            }
            count = 0;
            foreach (var val in arr)
            {
                if (val == reqEle) ++count;
            }

            return count > arr.Length / 2 ? reqEle : -1;
        }

        public static void MyMain()
        {
            int[] arr = { 7, 89, 3, 3, 1, 4, 3, 3, 3 };
            //int ans = GetMajorityElement(arr);
            int ans = VotingAlgorithm(arr);
            Console.WriteLine(ans);

        }
    }
}
