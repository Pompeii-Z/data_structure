using System;

namespace _004归并排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 2, 9, 3, 4, 6, 7 };
            //MergeSort(nums);
            Console.WriteLine(string.Join(", ", nums)); // 输出排序后的数组

            nums = Merge(nums);
            Console.WriteLine(string.Join(", ", nums)); // 输出排序后的数组

            #region 知识点一 归并排序基本原理
            //归并 = 递归 + 合并

            //数组分左右
            //左右元素相比较
            //满足条件放入新数组
            //一侧用完放对面

            //递归不停分
            //分完再排序
            //排序结束往上走
            //边走边合并
            //走到头顶出结果

            //归并排序分成两部分
            //1.基本排序规则
            //2.递归平分数组

            //递归平分数组:
            //不停进行分割
            //长度小于2停止
            //开始比较
            //一层一层向上比

            //基本排序规则：
            //左右元素进行比较
            //依次放入新数组中
            //一侧没有了另一侧直接放入新数组
            #endregion

        }
        #region 知识点二 代码实现
        //第一步：
        //基本排序规则
        //左右元素相比较
        //满足条件放进去
        //一侧用完直接放
        public static int[] Sort(int[] left, int[] right)
        {
            //先准备一个新数组
            int[] arr = new int[left.Length + right.Length];
            int leftIndex = 0;
            int rightIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                //左侧放完，直接放右侧    
                if (leftIndex >= left.Length)
                {
                    arr[i] = right[rightIndex];
                    //已经如入一个右侧元素进入新数组
                    rightIndex++;
                }
                else if (rightIndex >= right.Length)
                {
                    arr[i] = left[leftIndex];
                    //已经如入一个左侧元素进入新数组
                    leftIndex++;
                }
                else if (left[leftIndex] < right[rightIndex])
                {
                    arr[i] = left[leftIndex];
                    //已经如入一个左侧元素进入新数组
                    leftIndex++;
                }
                else
                {
                    arr[i] = right[rightIndex];
                    //已经如入一个右侧元素进入新数组
                    rightIndex++;
                }
            }
            return arr;
        }

        //第二步：
        //递归平分数组
        //结束条件为长度小于2
        public static int[] Merge(int[] arr)
        {
            //递归结束条件
            if (arr.Length < 2)
                return arr;
            //1.数组分两段 得到中间索引
            int mid = arr.Length / 2;
            //2.初始化左右数组
            //左右数组
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];
            //初始化左右数组内容
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < mid)
                    left[i] = arr[i];
                else
                    right[i - mid] = arr[i];
            }
            //3.开始递归(递归也是栈的应用)
            //也就是左右数组不停分割，返回从最小数组(最后分割最先进入)Sort排序
            return Sort(Merge(left), Merge(right));
        }

        #region
        /*
         在递归过程中，最后分割的子数组会最先进入排序阶段，因为它们的长度最小。
        所以，左右数组不停地分割，
        最后分割的子数组会先进入排序阶段，
        然后逐层向上合并，直到最终得到排序后的数组。
         */
        #endregion

        #endregion

        #region 知识点三 总结
        //理解递归逻辑
        //一开始不会执行sort函数的
        //要先找到最小容量数组时(分割到长度为1的数组停止)
        //才会回头递归调用sort进行排序

        //基本原理
        //归并 = 递归 + 合并
        //数组分左右
        //左右元素相比较
        //一侧用完放对面
        //不停放入新数组

        //递归不停分
        //分完再排序
        //排序结束往上走
        //边走边合并

        //套路写法
        //两个函数
        //一个基本排序规则
        //一个递归平分数组

        //注意事项
        //排序规则函数 在 平分数组函数
        //内部return调用
        #endregion

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
