using System;

namespace _005快速排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 9, 3, 4, 6, 7 };
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(", ", arr)); // 输出排序后的数组
        }
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);

                // 递归排序基准元素左边的子数组
                QuickSort(array, low, pivotIndex - 1);

                // 递归排序基准元素右边的子数组
                QuickSort(array, pivotIndex + 1, high);
            }
        }

        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    // 交换array[i]和array[j]
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            // 将基准元素放到正确的位置
            int temp2 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp2;

            return i + 1;
        }

    }
}
