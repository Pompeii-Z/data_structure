namespace 递归
{
    internal class Program
    {
        /*
        递归的定义：
            一个函数自己调用自己
        递归要满足的三个条件：
            1. 递归必须有一个明确的终止条件
            2. 该函数处理的问题规模必须在递减
            3. 这个转化必须是可解的
         */

        static void Main(string[] args)
        {
            int sum = Factorialfor(5);
            int sum1 = Factorial(5);
            int sum2 = Sum(5);
            System.Console.WriteLine(sum2);
        }

        private static int Sum(int n)
        {
            if (1 == n)
                return 1;
            else
                return n + Sum(n - 1);
        }
        private static int Factorial(int n)
        {
            if (n == 1)
                return 1;
            else
                return Factorial(n - 1) * n;
        }

        private static int Factorialfor(int n)
        {
            int sum = 1;
            for (int i = 1; i <= n; i++)
            {
                sum *= i;
            }
            return sum;
        }

    }
}
