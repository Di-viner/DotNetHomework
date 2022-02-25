using System;
namespace primeNumber
{
    class Solution
    {
        public void printPrimeNumber(int n)         //打印小于n的素数
        {
            for(int i = 2; i * i <= n; i++)
            {
                while(n % i == 0)
                {
                    Console.Write(i + " ");
                    n /= i;
                }
            }
            if (n > 1)
                Console.WriteLine(n);
        }
    }
    class Task1
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please input the number n:");
                int n = int.Parse(Console.ReadLine());      //输入n

                Solution solution1 = new Solution();        //实例Solution对象
                solution1.printPrimeNumber(n);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }           
        }
    }
}
