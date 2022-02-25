using System;
namespace Toeplitz
{
    class Solution
    {
        public bool isToeplitz(int[,] a)
        {
            for (int i = 1; i < a.GetLength(0); i++) 
            {
                for (int j = 1; j < a.GetLength(1); j++)
                    if (a[i, j] != a[i - 1, j - 1]) 
                        return false;
            }
            return true;
        }
    }
    class Task4
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input the length of the Matrix:");   //输入二维数组的长度和宽度
                string[] str = Console.ReadLine().Split(' ');           
                int m = int.Parse(str[0]);
                int n = int.Parse(str[1]);
                int[,] array = new int[m, n];                           //构建二维数组array[m,n]
                for (int i = 0; i < m; i++)                             //读入二维数组每行数据，以空格间隔
                {
                    Console.Write("Input the data of Row " + i + " split by ' ':");
                    str = Console.ReadLine().Split(' ');
                    for (int j = 0; j < n; j++)
                        array[i, j] = int.Parse((str[j]));
                }
                Solution solution = new Solution();
                if (solution.isToeplitz(array))
                    Console.WriteLine("The matrix is Toeplitz matrix!");
                else
                    Console.WriteLine("The matrix is NOT Toeplitz matrix! ");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
    }
}
