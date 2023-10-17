using System;

namespace _002选择排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 9, 1, 4, 9, 10 };
            SelectSort(nums);
            //foreach (var item in nums)
            //{
            //    Console.WriteLine(item);
            //}
        }
        /*
            不断从未排序的序列中选择最小元素，然后将其放置在已排序序列的末尾。

            算法特点：
            不稳定性：选择排序是不稳定的排序算法，即相同元素可能在排序过程中改变相对位置。
            原地排序：是一种原地排序算法，不需要额外的辅助空间，只需几个变量来辅助交换元素。
            时间复杂度：O(n^2)，其中n是元素的个数，不适用于大规模数据的排序。

            优点：
            简单、直观，容易实现。
            不需要额外的空间，是原地排序算法。
            缺点：
            时间复杂度高，不适用于大规模数据的排序。
            不稳定，可能改变相同元素的相对位置。       
         */
        public static void SelectSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int minIndex = i; // 假设当前索引的元素是最小值

                for (int j = i + 1; j < nums.Length; j++)//剩余未排序序列
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j; // 找到更小的元素的索引
                    }
                }

                // 交换元素
                int temp = nums[i];
                nums[i] = nums[minIndex];
                nums[minIndex] = temp;
            }
        }

    }
}
