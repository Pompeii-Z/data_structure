using System;

namespace _001冒泡排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 6, 3, 5, 4, 7, 8, 9 };
            BubbleSort(nums);

            Student[] Students = { new Student("张三", 81), new Student("利三", 29), new Student("王五", 19), new Student("赵一", 25) };
            Tsort(Students, Student.CompareScore);//将Student.CompareScore传递给委托
            //foreach (var item in Students)
            //{
            //    Console.WriteLine(item);
            //}
        }

        /*
         * 通过多次比较相邻元素，并交换它们的位置，使得较大（或较小）的元素逐渐“冒泡”到数组的一端，从而实现排序的目的
            优点：
            1.简单理解和实现
            2.稳定性：作为稳定排序算法，保持相等元素相对位置。

            缺点：
            1.低效性：时间复杂度为O(n^2)，其中n是待排序元素的数量。
            2.低效率：即使在最佳情况下，即数组已经有序，冒泡排序也需要进行n-1次比较。这意味着它不具备“早停”特性，不管数据的有序程度如何，都需要执行完所有的比较和交换。
            3.不适合大规模数据
            4.缺乏适应性：冒泡排序不适应数据的初始状态。它不管数据是否部分有序，都会按照固定的方式执行相同数量的比较和交换。
         */

        /// <summary>
        /// 冒泡排序升序，当后面某次比较没有发生交换 说明数组已经有序，可以提前退出。
        /// </summary>
        /// <param name="nums"></param>
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped; // 用于标记是否发生了交换

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // 交换arr[j]和arr[j+1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true; // 标记发生了交换
                    }
                }
                // 如果在一轮中没有发生交换，说明数组已经有序，可以提前退出
                if (!swapped)
                    break;
            }
        }

        /// <summary>
        /// 冒泡排序 泛型
        /// </summary>
        /// <param name="students"></param>
        public static void Tsort<T>(T[] Arr, Func<T, T, bool> compareMethod)
        {
            for (int i = 0; i < Arr.Length - 1; i++)
            {
                for (int j = 0; j < Arr.Length - 1 - i; j++)
                {
                    if (compareMethod(Arr[j], Arr[j + 1]))//比较
                    {
                        T temp = Arr[j];
                        Arr[j] = Arr[j + 1];
                        Arr[j + 1] = temp;
                    }
                }
            }
        }
    }


    public class Student
    {
        string name;
        int score;
        public string Name { get => name; set => name = value; }
        public int Score { get => score; set => score = value; }
        public Student(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
        public override string ToString()
        {
            return Name + ":" + Score;
        }
        public static bool CompareScore(Student s1, Student s2)
        {
            if (s1.Score > s2.Score)
                return true;
            else
                return false;
        }
    }
    public class Enemy
    {
        string name;
        int hit;
        public string Name { get => name; set => name = value; }
        public int Hit { get => hit; set => hit = value; }
        public Enemy(string name, int hit)
        {
            this.Name = name;
            this.Hit = hit;
        }
        public override string ToString()
        {
            return Name + ":" + Hit;
        }
        public static bool CompareScore(Enemy s1, Enemy s2)
        {
            if (s1.Hit > s2.Hit)
                return true;
            else
                return false;
        }
    }

}
