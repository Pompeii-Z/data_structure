using System;

namespace Test
{
    internal class Program
    {
        //单例 冒泡 有序链表合并
        static void Main(string[] args)
        {
            //有数组[1, 2, 3....99, 100],请不使用循环倒序打印数组内容
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            PushArr(nums, nums.Length);
            Console.WriteLine("\n");

            int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.WriteLine(MaxArr(arr));


            int[] arr1 = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            //BubleSort(arr1, arr1.Length);
            //Console.WriteLine("冒泡：");
            //foreach (var item in arr1)
            //{
            //    Console.Write(item);
            //}

        }

        public static void BubleSort(int[] arr, int length)
        {
            bool isSwaped = false;
            for (int i = 0; i < length - 1; i++)
            {
                isSwaped = false;
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        isSwaped = true;
                    }
                }

                if (!isSwaped)
                {
                    break;
                }
            }

        }

        public static void PushArr(int[] arr, int length)
        {
            if (length > 0)
            {
                Console.Write(arr[length - 1]);
                PushArr(arr, length - 1);
            }
        }

        public static int MaxArr(int[] arr)
        {
            int cur = arr[0];
            int max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                cur = Math.Max(arr[i], cur + arr[i]);//将当前元素包含到现有子数组中，或者从当前元素开始新的子数组。
                if (cur > max)
                {
                    max = cur;
                }
            }

            return max;
        }



    }
}
