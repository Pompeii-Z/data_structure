using System;

namespace _007堆排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 2, 9, 3, 4, 6, 7 };
            HeapSort(arr);
            Console.WriteLine(string.Join(", ", arr)); // 输出排序后的数组
        }
        public static void HeapSort(int[] array)
        {
            int n = array.Length;

            // 构建最大堆
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            // 依次将堆顶元素移动到数组末尾，并调整堆
            for (int i = n - 1; i > 0; i--)
            {
                // 交换堆顶元素和当前未排序部分的最后一个元素
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // 调整堆，将最大元素移至堆顶
                Heapify(array, i, 0);
            }
        }

        private static void Heapify(int[] array, int n, int root)
        {
            int largest = root; // 假定根节点最大
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            // 如果左子节点大于根节点，更新最大值的索引
            if (left < n && array[left] > array[largest])
                largest = left;

            // 如果右子节点大于根节点，更新最大值的索引
            if (right < n && array[right] > array[largest])
                largest = right;

            // 如果最大值不是根节点，交换根节点和最大值
            if (largest != root)
            {
                int swap = array[root];
                array[root] = array[largest];
                array[largest] = swap;

                // 递归调整受影响的子树
                Heapify(array, n, largest);
            }
        }
    }
}
