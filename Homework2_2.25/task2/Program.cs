using System;
namespace caculateArray
{
    class Solution
    {
        public void caculateArray(int[] a, ref int max, ref int min, ref int avg, ref int sum)  //计算最大值、最小值、平均数、和
        {                           //完成对数组a的相关操作，形参为引用类型ref
            max = int.MinValue;
            min = int.MaxValue;
            foreach(int i in a)
            {
                max = max > i? max: i;
                min = min < i? min: i;
                sum += i;
            }
            avg = sum/a.Length;
        }
    }
    class Task2
    {
        static void Main(string[] args)
        {
            int max = 0, min = 0, avg = 0, sum = 0;                             //局部变量
            try
            {
                Console.Write("Input some integer numbers(split by ' '):");                   //输入数据，使用空格分隔
                string[] str = Console.ReadLine().Split(' ');
                int[] a = new int[str.Length];
                for(int i = 0; i < str.Length; i++)
                    a[i] = int.Parse(str[i]);
                Solution solution = new Solution();
                solution.caculateArray(a, ref max, ref min, ref avg, ref sum);  //调用solution的方法并打印结果
                Console.WriteLine("max: " + max + "\nmin: " + min + "\navg: " + avg + "\nsum: " + sum);
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
