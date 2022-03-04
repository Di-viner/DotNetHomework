using System;
namespace ShapeSpace
{
    public abstract class Shape
    {
        public abstract double GetArea();       //计算面积
        public abstract bool IsLegal();         //判断图形是否合法
    }

    public class Rectangle:Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public override double GetArea()
        {
            if (!IsLegal())
                throw new Exception("长方形非法，长宽应大于0");
            return Length * Width;
        }
        public override bool IsLegal()
        {
            if (Length <= 0 || Width <= 0)
                return false;
            return true;
        }
    }
    public class Square:Shape
    {
        public double Side { get; set; }
        public Square(double side)
        {
            Side = side;
        }
        public override double GetArea()
        {
            if (!IsLegal())
                throw new Exception("正方形非法，边长应大于0");
            return Side * Side;
        }
        public override bool IsLegal()
        {
            if (Side <= 0)
                return false;
            return true;
        }
    }
    public class Triangle : Shape
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        public Triangle(double s1,double s2,double s3)
        {
            Side1 = s1;
            Side2 = s2;
            Side3 = s3;
        }
        public override double GetArea()
        {
            if (!IsLegal())
                throw new Exception("三角形非法");
            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }
        public override bool IsLegal()
        {
            if (Side1 <= 0 || Side2 <= 0 || Side3 <= 0)
                return false;
            if (Side1 + Side2 <= Side3 || Side1 + Side3 <= Side2 || Side2 + Side3 <= Side1)
                return false;
            return true;
        }
    }
    class Task1
    { 
        public static void Main(string[] args)
        {
            //无简单工厂时需要调用者知道三个类的构造函数后new实例对象
            try 
            {
                Triangle triangle1 = new Triangle(3.0, 4.0, 5.0);
                Rectangle rectangle1 = new Rectangle(20.0, 25.0);
                Square square1 = new Square(9.0);

                Console.WriteLine("长方形面积：" + rectangle1.GetArea());
                Console.WriteLine("正方形面积：" + square1.GetArea());
                Console.WriteLine("三角形面积：" + triangle1.GetArea());

                rectangle1.Width = 0;
                Console.WriteLine("长方形面积：" + rectangle1.GetArea());
                triangle1.Side1 = 1;
                Console.WriteLine("三角形面积：" + triangle1.GetArea());
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
    }

}

