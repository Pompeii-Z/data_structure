using System;
using System.Collections.Generic;

namespace S
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            //int[] nums = { 3, 2, 3 };
            //int[] nums = { 2, 7, 11, 15 };
            //int target = 6;
            //Console.WriteLine(DistMoney(4, 2));
            //int[] result = TwoSum(nums, target);
            //Console.WriteLine(result[0] + ".." + result[1]);

            //int[] nums = { 1, 2, 3, 4 };
            //int[] result = RunningSum(nums);
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.WriteLine(result[i]);
            //}

            //int num = 7;
            //Console.WriteLine(NumberOfSteps(num));

            //ListNode listNode = new ListNode(8, null);
            //Console.WriteLine(MiddleNode(listNode).val);

            //string a = "aa";
            //string b = "ab";
            //Console.WriteLine(CanConstruct(a, b));
            #endregion
            #region
            //PassThePillow(4, 5);
            int[] nums = { 0, 3, 2, 1 };
            string s = "RLL";
            SumDistance(nums, s, 3);
            ValidMountainArray(nums);
            #endregion

        }

        /// <summary>
        /// 1.两数之和
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 1480.一维数组动态和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] RunningSum(int[] nums)
        {
            int[] runningSum = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    runningSum[i] += nums[j];
                }
            }
            return runningSum;
        }

        /// <summary>
        /// 1342.将数字变成0的操作次数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int NumberOfSteps(int num)
        {
            int count = 0;
            while (num != 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                    count++;
                }
                else
                {
                    num -= 1;
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 1672.最富有客户的资产总量
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static int MaximumWealth(int[][] accounts)
        {
            int sum = 0, sum1 = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                for (int j = 0; j < accounts[i].Length; j++)
                {
                    sum += accounts[i][j];
                    sum1 = sum > sum1 ? sum : sum1;
                    sum = 0;
                }
            }
            return sum1;
        }

        /// <summary>
        /// 412.Fizz Buzz
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> FizzBuzz(int n)
        {
            string[] result = new string[n];
            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0)
                {
                    result[i - 1] = "FizzBuzz";
                }
                else if (i % 3 == 0)
                {
                    result[i - 1] = "Fizz";
                }
                else if (i % 5 == 0)
                {
                    result[i - 1] = "Buzz";
                }
                else
                {
                    result[i - 1] = i.ToString();
                }
            }
            return result;
        }

        /// <summary>
        /// 383.赎金信
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public static bool CanConstruct(string ransomNote, string magazine)
        {

            char[] aRand = ransomNote.ToCharArray();
            char[] bRand = magazine.ToCharArray();
            Dictionary<char, int> map = new Dictionary<char, int>();

            if (bRand.Length < aRand.Length)
                return false;

            for (int i = 0; i < bRand.Length; i++)
            {
                if (!map.ContainsKey(bRand[i]))
                {
                    map.Add(bRand[i], 1);
                }
                else
                {
                    map[bRand[i]]++;
                }
            }

            for (int i = 0; i < aRand.Length; i++)
            {
                if (!map.ContainsKey(aRand[i]))
                {
                    return false;
                }
                else
                {
                    map[aRand[i]]--;
                    if (map[aRand[i]] < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 2582.递枕头
        /// </summary>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int PassThePillow(int n, int time)
        {
            if (time < n)
            {
                return time + 1;
            }
            else
            {
                int r = n - 1;
                int count = time / r;
                int rTime = time % r;

                if (count % 2 == 0)
                {
                    return rTime + 1;
                }
                else
                {
                    return n - rTime;
                }
            }
        }

        /// <summary>
        /// 链表的定义
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        /// <summary>
        /// 876.链表的中间结点  快慢指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode MiddleNode(ListNode head)
        {
            //快慢指针做法
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public static ListNode MiddleNode1(ListNode head)
        {
            //计算链表长度    
            int n = 0;
            ListNode temp = head;
            while (temp.next != null)
            {
                n++;
                temp = temp.next;
            }

            //取中间值，遍历至目标节点并返回
            int middle = n / 2 + 1;
            ListNode middleNode = head;
            for (int i = 0; i < middle; i++)
            {
                middleNode = middleNode.next;
            }
            return middleNode;

        }

        /// <summary>
        /// 121.买卖股票的最佳时机
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            int result = 0;
            int min = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (min > prices[i])
                {
                    min = prices[i];
                }
                else
                {
                    result = Math.Max(result, prices[i] - min);
                }
            }

            return result;


        }

        /// <summary>
        /// 2731.移动的机器人
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int SumDistance(int[] nums, string s, int d)
        {
            int n = s.Length;

            long[] pos = new long[n]; // 创建一个长整数数组pos，用于存储计算后的位置信息

            for (int i = 0; i < n; i++)
            {
                pos[i] = nums[i] + (s[i] == 'R' ? d : -d); // 计算移动d秒后的位置
            }

            Array.Sort(pos); // 对坐标数组进行排序

            long result = 0; // 初始化结果为0

            long mod = (long)Math.Pow(10, 9) + 7; // 计算模数 防止溢出

            for (int left = 0, right = n - 1; left < right; left++, right--)
            {
                result += (right - left) * (pos[right] - pos[left]); // 使用数学公式计算结果，所有的两两机器人的距离差的和
                result %= mod; // 每次计算后都取余数以防止溢出
            }

            return (int)result; // 返回结果（将结果转换为整数）
        }

        /// <summary>
        /// 1365.有多少小于当前数字的数字
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            #region 暴力
            //int[] result = new int[nums.Length];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for (int j = 0; j < nums.Length; j++)
            //    {
            //        if (i == j)
            //        {
            //            continue;
            //        }
            //        if (nums[i] > nums[j])
            //        {
            //            result[i]++;
            //        }
            //    }
            //}
            //return result;
            #endregion
            int[] newArray = new int[nums.Length];

            Array.Copy(nums, newArray, nums.Length);

            Array.Sort(newArray);//排序后的数组索引就是比前面数大的个数

            //存进字典，进一步处理数是相同的情况（数，索引）
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = nums.Length; i >= 0; i--)//从后往前遍历即可保留最左边数的索引
            {
                result[newArray[i]] = i;
            }

            //加入结果数组
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = result[nums[i]];
            }

            return newArray;
        }

        /// <summary>
        /// 941.有效的山脉数组
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool ValidMountainArray(int[] arr)
        {
            if (arr.Length < 3)
                return false;
            //定义左右指针从两边往中间移动
            int left = 0;
            int right = arr.Length - 1;

            while (arr[left] < arr[left + 1] && left + 1 < arr.Length)//注意是否越界
            {
                left++;
            }
            while (arr[right] < arr[right - 1] && right > 0)
            {
                right--;
            }

            if (left == right && left != 0 && right != arr.Length - 1)//两指针相同代表到达最大数位置。且要防止是递增或递减的情况，指针不能和初始化时相同
                return true;

            return false;
        }

        /// <summary>
        /// 136.只出现一次的数字 待使用异或 常数级空间解法
        /// 137.只出现一次的数字Ⅱ 默认其它元素一定出现了三次。所以直接用了。
        /// 137.只出现一次的数字Ⅱ TODO:可能要判断了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!result.ContainsKey(nums[i]))
                {
                    result.Add(nums[i], 1);
                }
                else
                {
                    result[nums[i]]++;
                }
            }
            foreach (var item in result)
            {
                if (item.Value == 1)
                {
                    return item.Key;
                }
            }
            return 0;
        }
        //260. 只出现一次的数字 III
        public int[] SingleNumber1(int[] nums)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!result.ContainsKey(nums[i]))
                {
                    result.Add(nums[i], 1);
                }
                else
                {
                    result[nums[i]]++;
                }
            }
            List<int> ans = new List<int>();
            foreach (var item in result)
            {
                if (item.Value == 1)
                {
                    ans.Add(item.Key);
                }
            }
            int[] newAns = ans.ToArray();
            return newAns;
        }

        /// <summary>
        /// 2652.倍数求和
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumOfMultiples(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0 || i % 7 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        /// <summary>
        /// 21.合并两个有序链表
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummyNode = new ListNode(0, null);
            ListNode cur = dummyNode;

            while (list1 != null && list2 != null)  // 修改循环条件
            {
                if (list2.val >= list1.val)
                {
                    cur.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    cur.next = list2;
                    list2 = list2.next;
                }
                cur = cur.next;
            }

            // 处理剩余的节点
            if (list1 != null)
            {
                cur.next = list1;
            }
            else if (list2 != null)
            {
                cur.next = list2;
            }

            return dummyNode.next;
        }

        /// <summary>
        /// 338.比特位计数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] CountBits(int n)
        {
            int[] ans = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                if (i == 0)
                    ans[i] = 0;
                int num = i;
                while (num > 0)
                {
                    if (num % 2 == 1)
                    {
                        ans[i]++;
                    }
                    num /= 2;
                }
            }
            return ans;
        }

        /// <summary>
        /// 169.多数元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int[] result = new int[nums.Length];
            int count = nums.Length / 2;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]]++;
                }
                else
                {
                    map.Add(nums[i], 1);
                }
            }
            foreach (var item in map)
            {
                if (item.Value > count)
                {
                    return item.Key;
                }
            }
            return 0;
        }

        /// <summary>
        /// 448.找到所有数组中消失的数字
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            HashSet<int> res = new HashSet<int>();

            List<int> ans = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                res.Add(nums[i]);

            }

            for (int i = 1; i <= nums.Length; i++)
            {
                if (!res.Contains(i))
                {
                    ans.Add(i);
                }
            }

            return ans;



        }

        /// <summary>
        /// 283.移动零
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            int slow = 0;
            for (int fast = 0; fast < nums.Length; fast++)
            {
                if (nums[fast] != 0)
                {
                    nums[slow++] = nums[fast];
                }
            }

            while (slow < nums.Length)
            {
                nums[slow] = 0;
                slow++;
            }
        }

        /// <summary>
        /// 160.相交链表
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            int countA = GetListNodeLength(headA);
            int countB = GetListNodeLength(headB);

            int n = Math.Abs(countA - countB);
            ListNode currentA = headA;
            ListNode currentB = headB;

            // 先将较长链表的指针向前移动n个节点
            if (countA > countB)
            {
                for (int i = 0; i < n; i++)
                {
                    currentA = currentA.next;
                }
            }
            else if (countA < countB)
            {
                for (int i = 0; i < n; i++)
                {
                    currentB = currentB.next;
                }
            }

            // 同时遍历两个链表，直到找到交点或者到达末尾
            while (currentA != null && currentB != null)
            {
                if (currentA == currentB)
                {
                    return currentA;
                }
                currentA = currentA.next;
                currentB = currentB.next;
            }

            return null;
        }
        /// <summary>
        /// 获取ListNode的长度
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static int GetListNodeLength(ListNode head)
        {
            int length = 0;
            ListNode current = head;

            while (current != null)
            {
                length++;
                current = current.next;
            }
            return length;
        }

        /// <summary>
        /// 70.爬楼梯 DP 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            return 0;
        }

    }
}
