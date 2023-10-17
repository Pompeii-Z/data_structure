namespace _003插入排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 5, 1, 6, 8, 12, 81, 23 };
            InsertionSort(nums);
            //foreach (var item in nums)
            //{
            //    System.Console.WriteLine(item);
            //}
        }
        /*
        核心思想是逐个将未排序元素插入已排序部分，从左至右逐步构建有序序列。
        步骤：
        1.从第二个元素开始，将其视为当前元素，存储在变量current中。
        2.从当前元素开始，与已排序的元素逐一比较，如果已排序元素大于current，则将已排序元素右移一个位置。
        3.继续向前比较，直到找到current的正确位置，然后将其插入到这个位置。
        4.重复上述步骤，逐个插入未排序元素，直到整个数组有序。

        特点：
        1.简单理解和实现
        2.稳定性：它是一种稳定的排序算法，即相等元素的相对位置不会改变，有利于保持相等元素的相对次序。

        缺点：
        1.低效性：平均和最坏情况时间复杂度为O(n^2)
        2.不适用于逆序数据
        3.缺乏适应性：插入排序不适应数据的初始状态。它无论数据是否部分有序，都需要执行相同数量的比较和移动操作。这在某些情况下是不必要的，因为有些数据集可能已经接近排序状态。
        4.稳定性带来的额外开销：虽然稳定性是插入排序的一个优点，但这也意味着它需要在比较相等元素时执行额外的操作，这可能会增加执行时间。
         */

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];
                int j = i - 1;

                // 将当前元素插入到已排序部分的正确位置
                while (j >= 0 && array[j] > current)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = current;
            }
        }
    }
}
