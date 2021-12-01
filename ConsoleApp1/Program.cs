using System;

namespace ConsoleApp1
{
    public delegate int MathHandler(int a, int b); 
    class Program
    {
        public static int Sum(int a, int b)
        {
            Console.WriteLine("Sum starts");
            return a + b;
        }
        public static int Difference(int a, int b)
        {
            Console.WriteLine("Difference starts");
            return a - b;
        }
        static void Main(string[] args)
        {
            MathHandler mathHandler = new MathHandler(Sum);
            mathHandler += Difference;
            MathHandler mathHandler2 = new MathHandler(Sum);
            
            MyMath test = new MyMath();
            test.MathEvent += mathHandler;
            test.MathEvent += mathHandler2;
            test.DoWork(5,2);
        }
    }
    class MyMath
    {
        public event MathHandler MathEvent;
        public void DoWork(int a, int b)
        {
            if (MathEvent != null)
            {
                foreach (var item in MathEvent.GetInvocationList())
                {
                    Console.WriteLine(item.DynamicInvoke(a,b));
                }
            }
        }
    }
}
