using System;

namespace _004归并排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 9, 3, 4, 6, 7 };
            MergeSort(arr);
            Console.WriteLine(string.Join(", ", arr)); // 输出排序后的数组

        }
        public static void MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int middle = array.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[array.Length - middle];

            // 将原数组拆分为左右两个子数组
            for (int i = 0; i < middle; i++)
                left[i] = array[i];

            for (int i = middle; i < array.Length; i++)
                right[i - middle] = array[i];

            // 递归对左右子数组进行归并排序
            MergeSort(left);
            MergeSort(right);

            // 合并左右子数组
            Merge(left, right, array);
        }

        private static void Merge(int[] left, int[] right, int[] result)
        {
            int i = 0, j = 0, k = 0;

            // 将左右子数组合并为一个有序数组
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    result[k] = left[i];
                    i++;
                }
                else
                {
                    result[k] = right[j];
                    j++;
                }
                k++;
            }

            // 处理剩余的元素
            while (i < left.Length)
            {
                result[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                result[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
