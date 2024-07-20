using System;

namespace _006希尔排序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 5, 2, 9, 3, 4, 6, 7 };
            ShellSort(nums);
            Console.WriteLine(string.Join(", ", nums)); // 输出排序后的数组

            #region 知识点一 希尔排序的基本原理 分成多个子序列，分别进行插入排序
            //希尔排序是
            //插入排序的升级版，必须先掌握插入排序

            //希尔排序的原理
            //将整个待排序序列
            //分割成为若干子序列
            //分别进行插入排序

            //总而言之
            //希尔排序对插入排序的升级主要就是加入了一个步长的概念
            //通过步长每次可以把原序列分为多个子序列
            //对子序列进行插入排序

            //在极限情况下可以有效降低普通插入排序的时间复杂度(部分有序)
            //提升算法效率

            #endregion

            #region 知识点二 代码实现
            int[] arr = new int[] { 8, 7, 1, 5, 4, 2, 6, 3, 9 };
            //InsetSort(arr1);
            //Console.WriteLine(string.Join(", ", arr));
            // 学习希尔排序的前提条件
            // 先掌握插入排序

            // 第一步：实现插入排序 
            //InsertSort()

            // 第二步：确定步长1
            // 基本规则：每次步长变化都是/2
            //步长：每次除以2，直到步长<=0结束 最小步长为1
            for (int step = arr.Length / 2; step > 0; step /= 2)
            {
                // 第三步：执行插入排序
                for (int i = step; i < arr.Length; i++)
                {
                    int currentNum = arr[i];
                    //i-step 代表和子序列中 已排序区元素一一比较
                    int sortIndex = i - step;
                    while (sortIndex >= 0 && arr[sortIndex] > currentNum)//升序 
                    {
                        //代表移步长个位置 代表子序列中的下一个位置
                        arr[sortIndex + step] = arr[sortIndex];
                        //一个步长单位的比较
                        sortIndex -= step;
                    }
                    //找到位置拆入元素
                    arr[sortIndex + step] = currentNum;
                }
            }

            Console.WriteLine(string.Join(", ", arr));
            #endregion

            #region 总结
            //基本原理
            //设置步长
            //步长不停缩小
            //到1排序后结束

            //具体排序方式
            //插入排序原理

            //套路写法
            //三层循环
            //一层获取步长
            //一层获取未排序区元素
            //一层找到合适位置插入

            //注意事项
            //步长确定后
            //会将所有子序列进行插入排序
            #endregion
        }

        public static void InsetSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int currentNum = arr[i];
                int sortIndex = i - 1;
                while (sortIndex >= 0 && arr[sortIndex] > currentNum)//升序 已排序区中元素大于未排序中的元素 current
                {
                    arr[sortIndex + 1] = arr[sortIndex];
                    --sortIndex;
                }
                //找到位置拆入元素
                arr[sortIndex + 1] = currentNum;
            }
        }

        public static void ShellSort(int[] array)
        {
            int n = array.Length;

            // 初始的间隔（gap）设置为数组长度的一半，然后逐渐减小间隔（步长）
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // 对每个间隔分组进行插入排序(开始插入排序)
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j = i;
                    while (j >= gap && array[j - gap] > temp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = temp;
                }
            }
        }
    }
}
