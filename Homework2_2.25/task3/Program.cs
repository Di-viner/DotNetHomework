using System;
namespace Eratosthenes
{
    class Solution
    {
        public bool[] selectPrime(int n)
        {
            bool[] isPrime = new bool[n + 1];
            for (int i = 0; i < isPrime.Length; i++)
                isPrime[i] = true;
            for (int i = 2; i * i <= n; i++) 
                for (int j = i * i; j <= n; j += i) 
                    isPrime[j] = false;
            return isPrime;              
        }
    }
    class Task3
    {
        public static void Main(string[] args)
        {
            const int n = 100;
            Solution solution = new Solution();
            Console.WriteLine("Prime numbers between 2 and " + n + " are: ");
            bool[] res = solution.selectPrime(100);
            for (int i = 2; i <= 100; i++)
                if (res[i])
                    Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
