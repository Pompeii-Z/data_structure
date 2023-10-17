using System;

namespace 希尔排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 9, 3, 4, 6, 7 };
            ShellSort(arr);
            Console.WriteLine(string.Join(", ", arr)); // 输出排序后的数组
        }
        public static void ShellSort(int[] array)
        {
            int n = array.Length;

            // 初始的间隔（gap）设置为数组长度的一半，然后逐渐减小间隔
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // 对每个间隔分组进行插入排序
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
        }

    }
}
