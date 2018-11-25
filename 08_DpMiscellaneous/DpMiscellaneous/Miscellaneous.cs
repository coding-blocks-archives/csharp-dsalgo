using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpMiscellaneous
{
    class Miscellaneous
    {
        public static void MyMain()
        {
            //int[,] arr = new int[3, 4];
            //foreach (var x in arr) { Console.WriteLine(x); };

            int[][] mat = new int[5][];  //jagged array
            mat[0] = new int[] { 0, 0, 0, 1, 1, 1 };
            mat[1] = new int[] { 0, 0, 1, 1, 1, 1 };
            mat[2] = new int[] { 0, 0, 0, 0, 1, 1 };
            mat[3] = new int[] { 0, 1, 1, 1, 1, 1 };
            mat[4] = new int[] { 0, 0, 1, 1, 1, 1 };

            int[] arr = { 1, 2, 300 };
            int res = arr.FirstOrDefault(x => x > 2);
            Console.WriteLine(res);

            //foreach(var row in mat)
            //{
            //    row.LastOrDefault
            //}

        }
    }
}
