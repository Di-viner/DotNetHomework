using System;
using ShapeSpace;
namespace Factory
{
    class ShapeFactory                                      //Shape的简单工厂
    {
        public static Shape CreateShape(string str, params double[] length)
        {
            Shape shape;
            switch (str)
            {
                case "rectangle":
                    shape = new Rectangle(length[0], length[1]);
                    return shape;
                case "square":
                    shape = new Square(length[0]);
                    return shape;
                case "triangle":
                    shape = new Triangle(length[0], length[1], length[2]);
                    return shape;
                default: throw new ArgumentException("Shape Error.");
            }
        }
    }
    class Task2
    { 
        public static void Main(string[] args)
        {
            try
            {
                string[] str = { "rectangle", "square", "triangle" };   //表示三种类型
                Shape[] shapeArray = new Shape[10];                     //形状数组，有10个元素 
                double areaSum = 0;                                     //图形面积和
                int shapeNum = 0;                                       //已实例的图形数
                Random random = new Random();                           //随机数种子

                for (; shapeNum < 10;)                                  //实例10个图形
                {
                    Shape temp = ShapeFactory.CreateShape(str[random.Next(str.Length)], 20 * random.NextDouble(), 20 * random.NextDouble(), 20 * random.NextDouble());
                    if (temp.IsLegal())                                 //若图形参数合法，则将temp加入数组ShapeArray
                        shapeArray[shapeNum++] = temp;
                }
                for (int i = 0; i < shapeArray.Length; i++)             //输出10个图形的相关信息，并计算面积和
                {
                    Console.WriteLine("Type of Shape[" + i + "]:" + shapeArray[i].GetType().Name.ToString() + " Area:" + shapeArray[i].GetArea().ToString("f2"));
                    areaSum += shapeArray[i].GetArea();
                }
                Console.WriteLine();
                Console.WriteLine("Total Area:" + areaSum.ToString("f2")); //输出面积和
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            
        }
    }
}