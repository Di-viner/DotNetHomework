using System;
namespace myApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            double x, y;
            char op;
            string str;

            Console.WriteLine("Please input two numbers");
            str = Console.ReadLine();
            string[] nums = str.Split(' ');
            x = Double.Parse(nums[0]);
            y = Double.Parse(nums[1]);

            Console.WriteLine("Please input an operator");
            op = Char.Parse(Console.ReadLine());
            switch (op)
            {
                case '+':
                    Console.WriteLine($"x + y: {x + y}");
                    break;
                case '-':
                    Console.WriteLine($"x - y: {x - y}");
                    break;
                case '*':
                    Console.WriteLine($"x * y: {x * y}");
                    break;
                case '/':
                    Console.WriteLine($"x / y: {x / y}");
                    break;
                case '%':
                    Console.WriteLine($"x % y: {x % y}");
                    break;
            }
        }
    }
}
