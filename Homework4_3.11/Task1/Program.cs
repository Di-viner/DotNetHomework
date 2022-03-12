using System;
namespace Node                              
{
    public class Node<T>                        //Node<T>为泛型链表类的节点
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>                  //泛型链表类
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail == null)
                head = tail = n;
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)                  //为泛型链表类添加ForEach方法，对链表每一个元素执行action函数委托
        {
            for(Node<T> temp = head; temp != null; temp = temp.Next)
                action(temp.Data);
        }
    }
    public class Task1
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();                         //随机数种子
            GenericList<int> list = new GenericList<int>();     //泛型链表实例对象
            int max = int.MinValue;                             //整数最大值
            int min = int.MaxValue;                             //整数最小值
            int sum = 0;
            for(int i = 0; i < 20; i++)                         //随机添加元素
                list.Add(rand.Next(100));

            list.ForEach(x => Console.WriteLine(x));            //打印出链表的全部元素
            list.ForEach(x => max = max > x ? max : x);         //求出最大值
            list.ForEach(x => min = x < min ? x : min);         //求出最小值;
            list.ForEach(x => sum += x);                        //求和

            Console.WriteLine($"Maximum of the List: {max}");
            Console.WriteLine($"Minimum of the List: {min}");
            Console.WriteLine($"Sum of The List: {sum}");
        }
    }
}