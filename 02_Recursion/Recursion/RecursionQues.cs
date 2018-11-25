using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class RecursionQues
    {
        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;   // base case
            }
            // n = 5
            int smallFact = Factorial(n - 1);   // recursive statement
            int curFact = n * smallFact;
            return curFact;
        }

        public static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            int prev = Fibonacci(n - 1);
            int superPrev = Fibonacci(n - 2);
            return prev + superPrev;
        }

        public static void SwapElements(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public static void bubbleSort(int[] arr, int beginIdx, int endIdx)
        {
            if (beginIdx >= endIdx)
            {
                // no elements in the array
                // or I can say its an invalid range
                return;
            }

            bubbleSort(arr, beginIdx + 1, endIdx);
            if (arr[beginIdx] > arr[beginIdx + 1])
            {
                SwapElements(ref arr[beginIdx], ref arr[beginIdx + 1]);
                bubbleSort(arr, beginIdx + 1, endIdx);
            }
        }

        static bool CanPlace(int[,] board, int x, int y, int num, int dim)
        {
            for (int i = 0; i < dim; ++i)
            {
                if (board[x, i] == num) return false;    // along row
                if (board[i, y] == num) return false;   // along col
            }
            int bigBoxX = x - x % 3;
            int bigBoxY = y - y % 3;
            for (int i = bigBoxX; i < bigBoxX + 3; ++i)
            {
                for (int j = bigBoxY; j < bigBoxY + 3; ++j)
                {
                    if (board[i, j] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool SolveSudoku(int[,] board, int xcoord, int ycoord, int dim)
        {
            if (xcoord >= dim)
            {
                // rows have ended
                return true;
            }

            if (ycoord >= dim)
            {
                return SolveSudoku(board, xcoord + 1, 0, dim);
            }

            if (board[xcoord, ycoord] != 0)
            {
                // (x, y) cell is fixed
                return SolveSudoku(board, xcoord, ycoord + 1, dim);
            }

            for (int num = 1; num <= 9; ++num)
            {
                if (CanPlace(board, xcoord, ycoord, num, dim) == true)
                {
                    board[xcoord, ycoord] = num;
                    bool success = SolveSudoku(board, xcoord, ycoord + 1, dim);
                    if (success == true)
                    {
                        return true;
                    }
                    board[xcoord, ycoord] = 0;  // backtracking
                }
            }
            return false;
        }

        public static void TestRun()
        {
            //var input = Console.ReadLine();
            //int n = int.Parse(input);
            //int ans = Factorial(n);
            //Console.WriteLine(ans);

            //var input = Console.ReadLine();
            //int n = int.Parse(input);
            //int ans = Fibonacci(n);
            //Console.WriteLine(ans);

            //int[] arr = { 5, 4, 3, 2, 1 };
            //bubbleSort(arr, 0, 4);
            //for(int i = 0; i < arr.Length; ++i)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            int[,] board =
            {
                {7, 8, 0, 4, 0, 0, 1, 2, 0 },
                {6, 0, 0, 0, 7, 5, 0, 0, 9 },
                {0, 0, 0, 6, 0, 1, 0, 7, 8 },
                {0, 0, 7, 0, 4, 0, 2, 6, 0 },
                {0, 0, 1, 0, 5, 0, 9, 3, 0 },
                {9, 0, 4, 0, 6, 0, 0, 0, 5 },
                {0, 7, 0, 3, 0, 0, 0, 1, 2 },
                {1, 2, 0, 0, 0, 7, 4, 0, 0 },
                {0, 4, 9, 2, 0, 6, 0, 0, 7 }
            };
            SolveSudoku(board, 0, 0, 9);
            for (int row = 0; row < 9; ++row)
            {
                for (int col = 0; col < 9; ++col)
                {
                    Console.Write(board[row, col]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
