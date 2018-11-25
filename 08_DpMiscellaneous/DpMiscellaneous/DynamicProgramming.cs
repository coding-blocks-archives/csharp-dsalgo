using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpMiscellaneous
{
    class DynamicProgramming
    {
        public static bool isPalindrome(string str, int be, int en)
        {
            while(be < en)
            {
                if (str[be] != str[en]) return false;
                ++be;
                --en;
            }
            return true;
        }

        public static int PalindromePartitionDP(string str)
        {
            int strLen = str.Length;
            int[,] dp = new int[strLen, strLen];
            bool[,] isPal = new bool[strLen, strLen];

            // setting the base cases
            for(int i = 0; i < strLen; ++i)
            {
                isPal[i, i] = true;
            }

            for(int len = 2; len <= strLen; ++len)
            {
                int srtIdx = 0;
                int maxSrt = strLen - len;
                while(srtIdx <= maxSrt)
                {
                    int endIdx = srtIdx + len - 1;
                    if (len == 2)
                    {
                        isPal[srtIdx, endIdx] = str[srtIdx] == str[endIdx];
                    }
                    else
                    {
                        isPal[srtIdx, endIdx] = str[srtIdx] == str[endIdx] &&
                                                isPal[srtIdx + 1, endIdx - 1];
                    }

                    if (isPal[srtIdx, endIdx])
                    {
                        dp[srtIdx, endIdx] = 0;
                    }
                    else
                    {
                        int res = int.MaxValue;
                        for(int cutAt = srtIdx; cutAt < endIdx; ++cutAt)
                        {
                            res = Math.Min(dp[srtIdx, cutAt] + dp[cutAt + 1, endIdx] + 1, res);
                        }
                        dp[srtIdx, endIdx] = res;
                    }
                    ++srtIdx;
                }
            }
            return dp[0, strLen - 1];

        }

        public static int PalindromePartitionRec(string str, int beginIdx, int endIdx)
        {
            if (beginIdx >= endIdx)
            {
                return 0;
            }

            if (isPalindrome(str, beginIdx, endIdx)) return 0;

            int ans = int.MaxValue;
            for(int cutAt = beginIdx; cutAt < endIdx; ++cutAt)
            {
                if (isPalindrome(str, beginIdx, cutAt))
                {
                    int remAns = PalindromePartitionRec(str, cutAt + 1, endIdx);
                    ans = Math.Min(ans, remAns + 1);
                }
            }
            return ans;
        }


        public static void MyMain()
        {
            //string str = "aac";
            //int ans = PalindromePartitionRec(str, 0, 2);
            //string str = "ababbbabbababa";
            //int ans = PalindromePartitionRec(str, 0, 13);
            string str = "abbdd";
            int ans = PalindromePartitionDP(str);
            Console.WriteLine(ans);
        }
    }
}
