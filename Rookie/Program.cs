using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Up;

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
            //SumDistance(nums, s, 3);
            //ValidMountainArray(nums);

            int[] ints = { -1, -100, 3, 99 };
            // Rotate(ints, 2);

            int[][] values = new int[3][] {
                new int[]{ 1,3,5,7 },
                new int[]{ 10,11,16,20 },
                new int[]{ 23,30,34,60 },
            };
            int[][] values1 = new int[2][] {
                new int[]{ 1 },
                new int[]{ 3},
            };
            //SearchMatrix(values1, 0);

            MergeAlternately("abc", "bnvmm");
            #endregion

            string s1 = EntityParser("&amp; is an HTML entity but &ambassador; is not.");
            Console.WriteLine(s1);
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
                return time + 1;
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
        /// 70.爬楼梯 TODO：DP 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            return 0;
        }

        /// <summary>
        /// 2.两数相加
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode current = dummyHead;
            int carry = 0;
            //在新链表上操作
            while (l1 != null || l2 != null)
            {
                int x = (l1 != null) ? l1.val : 0;
                int y = (l2 != null) ? l2.val : 0;
                int sum = x + y + carry;

                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            //最后一次，处理最后的商
            if (carry > 0)
            {
                current.next = new ListNode(carry);
            }

            return dummyHead.next;

        }

        /// <summary>
        /// 215.数组中的第K个最大元素 TODO：堆排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        //public int FindKthLargest(int[] nums, int k)
        //{

        //}

        /// <summary>
        /// 374.猜数字的大小 二分法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GuessNumber(int n)
        {
            int left = 1; int right = n;
            while (left <= right)
            {
                int mid = left + (right - left + 1) / 2;
                int temp = guess(mid);
                if (temp == 0)
                {
                    return mid;
                }
                else if (temp == 1)
                {
                    left = mid + 1;
                }
                else if (temp == -1)
                {
                    right = mid - 1;
                }
            }
            return right;

        }
        //上题模拟接口 返回1（大了） 0（正确） -1（小了）
        int guess(int num)
        {
            return -1;
        }

        /// <summary>
        /// 278.第一个错误的版本 二分法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }
        //模拟是否为错误版本
        bool IsBadVersion(int num)
        {
            return false;
        }

        /// <summary>
        /// 103.二叉树的锯齿形层序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> resultList = new List<IList<int>>();
            if (root == null) return resultList;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            bool isVerse = false; //是否逆序

            while (queue.Count > 0)
            {
                int count = queue.Count;
                List<int> tempList = new List<int>();
                while (count > 0)
                {
                    TreeNode node = queue.Dequeue();
                    //不用tempList.Reverse();，可以逆序时使用Insert插入到前面。
                    tempList.Add(node.val);
                    count--;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                isVerse = !isVerse;
                if (!isVerse)
                    tempList.Reverse();

                resultList.Add(tempList);
            }
            return resultList;
        }

        /// <summary>
        /// 125.验证回文串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                //过滤非字母和数字的元素
                while (left < right && !char.IsLetterOrDigit(s[left]))
                    left++;
                while (left < right && !char.IsLetterOrDigit(s[right]))
                    right--;
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    return false;
                left++;
                right--;
            }
            return true;
        }

        /// <summary>
        /// 2525.根据规则将箱子分类
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mass"></param>
        /// <returns></returns>
        public string CategorizeBox(int length, int width, int height, int mass)
        {
            int d = 10000;
            int v = 1000000000;
            long curV = (long)length * width * height;
            if ((length >= d || width >= d || height >= d || curV >= v) && mass >= 100)
            {
                return "Both";
            }
            else if (mass >= 100)
            {
                return "Heavy";
            }
            else if (length >= d || width >= d || height >= d || curV >= v)
            {
                return "Bulky";
            }
            return "Neither";
        }

        /// <summary>
        /// 58.最后一个单词的长度
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) // 检查字符串是否为空或仅包含空格
            {
                return 0; // 字符串为空或仅包含空格，最后一个单词长度为0
            }

            char[] cS = s.TrimEnd().ToCharArray(); // 去除字符串末尾空格并转换为字符数组
            int slow = 0;

            for (int i = 0; i < cS.Length; i++)
            {
                if (cS[i] != ' ')
                {
                    if (slow != 0)
                    {
                        cS[slow++] = ' ';
                    }
                    while (i < cS.Length && cS[i] != ' ')
                    {
                        cS[slow++] = cS[i++];
                    }
                }
            }
            Array.Resize(ref cS, slow);

            int l = cS.Length - 1;
            int count = 0;
            while (l >= 0 && cS[l] != ' ')
            {
                count++;
                l--;
            }
            return count;
        }

        /// <summary>
        /// 2678.老人的数目
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public static int CountSeniors(string[] details)
        {
            int count = 0;
            for (int i = 0; i < details.Length; i++)
            {
                if (int.Parse(details[i].Substring(11, 2)) > 60)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 461.汉明距离
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int HammingDistance(int x, int y)
        {
            int z = x ^ y;//异或  1 0 为1，否则为0。
            int count = 0;
            while (z != 0)
            {
                //统计1的个数
                if ((z & 1) == 1)//按位与操作 都为1为1 否则为0
                {
                    count++;
                }
                z >>= 1;
            }
            return count;
        }

        /// <summary>
        /// LCR 133.位1的个数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n != 0)
            {
                if ((n & 1) == 1)
                {
                    count++;
                }
                n >>= 1;
            }
            return count;
        }

        /// <summary>
        /// 75.颜色分类
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int cur = 0;
            while (cur <= right)
            {
                if (nums[cur] == 0)
                {
                    int temp = nums[cur];
                    nums[cur] = nums[left];
                    nums[left] = temp;
                    cur++;
                    left++;
                }
                else if (nums[cur] == 2)
                {
                    int temp = nums[cur];
                    nums[cur] = nums[right];
                    nums[right] = temp;
                    right--;
                }
                else
                    cur++;
            }
        }

        /// <summary>
        /// 9.回文数
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            char[] charArray = x.ToString().ToCharArray();
            return IsPalindromeT(charArray);
        }

        /// <summary>
        /// 判断数组是否为回文数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        private static bool IsPalindromeT<T>(T[] array)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                if (EqualityComparer<T>.Default.Equals(array[left], array[right]))//比较泛型对象是否相等
                {
                    left++;
                    right--;
                }
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 234.回文链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindromeList(ListNode head)
        {
            List<int> array = new List<int>();
            while (head != null)
            {
                array.Add(head.val);
                head = head.next;
            }
            int[] arr = array.ToArray();
            return IsPalindromeT(arr);
        }

        /// <summary>
        /// 56.合并区间
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        //public int[][] Merge(int[][] intervals)
        //{

        //}
        /// <summary>
        /// 189.轮转数组 -->思路：剑指Offer58-II.左旋转字符串
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public static void Rotate(int[] nums, int k)
        {
            if (nums.Length == 1)
                return;
            k %= nums.Length;//k大于数组长度的情况
            Reverse(nums, 0, nums.Length - 1);//翻转整个
            Reverse(nums, 0, k - 1);//翻转前k个
            Reverse(nums, k, nums.Length - 1);//剩余
        }
        //该题思路来源：左旋转字符串
        private static void Reverse(int[] nums, int start, int end)
        {
            int left = start;
            int right = end;
            while (left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }

        /// <summary>
        /// 114.二叉树展开为链表
        /// </summary>
        /// <param name="root"></param>
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;
            List<TreeNode> list = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                list.Add(node);

                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }

            for (int i = 1; i < list.Count; i++)
            {
                root.left = null;
                root.right = list[i];
                root = root.right;
            }
        }

        /// <summary>
        /// 148.排序链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            ListNode dummyNode = new ListNode();
            ListNode cur = dummyNode;
            List<int> r = new List<int>();
            while (head != null)
            {
                r.Add(head.val);
                head = head.next;
            }

            r.Sort();

            for (int i = 0; i < r.Count; i++)
            {
                cur.next = new ListNode(r[i]);
                cur = cur.next;
            }
            return dummyNode.next;
        }

        /// <summary>
        /// 2520.统计能整除数字的位数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int CountDigits(int num)
        {
            int count = 0;
            string s = num.ToString();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if (num % int.Parse(s[i].ToString()) == 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 35.搜索插入位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = (right - left) / 2 + left;
            while (left <= right)
            {
                mid = (right - left) / 2 + left;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        /// <summary>
        /// 74.搜索二维矩阵
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return false;

            int m = matrix.Length;
            int n = matrix[0].Length;

            int left = 0;
            int right = m * n - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int midValue = matrix[mid / n][mid % n];//第几组第几个

                if (midValue == target)
                {
                    return true;
                }
                else if (midValue < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }

        /// <summary>
        /// 2558.从数量最多的堆取走礼物
        /// </summary>
        /// <param name="gifts"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long PickGifts(int[] gifts, int k)
        {
            //使用库函数
            //找到前k个最大的数，并改变礼物数量
            long res = 0;
            for (int i = 0; i < k; i++)
            {
                int index = Array.IndexOf(gifts, gifts.Max());
                gifts[index] = (int)Math.Sqrt(gifts[index]);
            }
            for (int i = 0; i < gifts.Length; i++)
            {
                res += gifts[i];
            }
            return res;
        }

        /// <summary>
        /// 49.字母异位词分组
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> resList = new List<IList<string>>();
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            //将字符串排序后，把顺序相同的单词加入同一个List。
            for (int i = 0; i < strs.Length; i++)
            {
                char[] c = strs[i].ToCharArray();
                Array.Sort(c);
                string str = new string(c);
                if (!dic.ContainsKey(str))
                {
                    dic[str] = new List<string>();
                }
                //将字母相同的异位词加入
                dic[str].Add(strs[i]);
            }
            foreach (var item in dic)
            {
                resList.Add(item.Value);
            }
            return resList;
        }

        /// <summary>
        /// 128.最长连续序列
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 1)
                return 1;
            if (nums.Length == 0)
                return 0;
            //nlogn 
            //排序后，模拟
            Array.Sort(nums);
            int max = int.MinValue;
            int count = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                //前一个比当前小1
                if (nums[i - 1] + 1 == nums[i]) count++;
                else if (nums[i - 1] == nums[i]) continue;//相等继续遍历
                else count = 1; //重置

                //记录最长的连续序列长度
                if (count > max) max = count;
            }
            if (count > max) max = count;
            return max;
        }

        /// <summary>
        /// 274.H指数
        /// 275.H指数Ⅱ
        /// </summary>
        /// <param name="citations"></param>
        /// <returns></returns>
        public int HIndex(int[] citations)
        {
            /*
             将科学家某个时段（也可是全部）的论文，按被引次数从高往低排，然后每篇论文得到一个序号，将每篇论文的序号和被引次数进行比较，找到序号h，使得这一篇论文的序号h小于或等于它的被引次数，而下一篇论文（序号为h＋1）的序号大于它的被引次数。
             */
            Array.Sort(citations);
            Array.Reverse(citations);
            int h;
            int n = citations.Length;
            for (h = 0; h < n; h++)
            {
                if (citations[h] <= h)
                    return h;
            }
            if (citations[n - 1] >= n)
                return n;
            return 0;
        }

        //二叉搜索树（Binary Search Tree，BST）是一种特殊类型的二叉树，其中每个节点的左子树中的节点值都比该节点小，右子树中的节点值都比该节点大。
        /// <summary>
        /// 230. 二叉搜索树中第K小的元素
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(TreeNode root, int k)
        {
            //因为这是一个二叉搜索树，所以采用中序遍历（升序），返回第k-1个元素。
            List<int> result = new List<int>();
            dfs(root, result);
            return result[k - 1];
        }
        void dfs(TreeNode treeNode, List<int> res)
        {
            if (treeNode == null)
                return;
            dfs(treeNode.left, res);
            res.Add(treeNode.val);
            dfs(treeNode.right, res);
        }

        /// <summary>
        /// 1768. 交替合并字符串
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public static string MergeAlternately(string word1, string word2)
        {
            if (word1.Length <= 0)
                return word2;
            else if (word2.Length <= 0)
                return word1;

            char[] w1 = word1.ToCharArray();
            char[] w2 = word2.ToCharArray();
            int w1Length = w1.Length;
            int w2Length = w2.Length;
            string res = "";

            int c = w1Length - w2Length;
            if (c == 0)
            {
                for (int i = 0; i < w1Length; i++)
                {
                    res += w1[i].ToString() + w2[i].ToString();
                }
            }
            else if (c > 0)
            {
                for (int i = 0; i < w2Length; i++)
                {
                    res += w1[i].ToString() + w2[i].ToString();
                }
                res += word1.Substring(w2Length, c);
            }
            else
            {
                for (int i = 0; i < w1Length; i++)
                {
                    res += w1[i].ToString() + w2[i].ToString();
                }
                res += word2.Substring(w1Length, Math.Abs(c));
            }
            return res;
        }
        //优化版本
        public static string MergeAlternately1(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1))
                return word2;
            else if (string.IsNullOrEmpty(word2))
                return word1;

            int minLength = Math.Min(word1.Length, word2.Length);
            var result = new StringBuilder(minLength * 2); // 优化预分配空间

            for (int i = 0; i < minLength; i++)
            {
                result.Append(word1[i]);
                result.Append(word2[i]);
            }

            if (word1.Length > minLength)
                result.Append(word1, minLength, word1.Length - minLength);
            else if (word2.Length > minLength)
                result.Append(word2, minLength, word2.Length - minLength);

            return result.ToString();
        }

        /// <summary>
        /// 1071.字符串的最大公因子
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public string GcdOfStrings(string str1, string str2)
        {
            if (str1 + str2 != str2 + str1)//判断是否有公共前缀
            {
                return "";
            }
            return str1.Substring(0, gcd(str1.Length, str2.Length));
        }
        //辗转相除法：计算a,b的最大公约数，也就是计算两个字符串的长度的最大公约数
        private int gcd(int a, int b)
        {
            return b == 0 ? a : gcd(b, a % b);
        }

        /// <summary>
        /// 1431. 拥有最多糖果的孩子
        /// </summary>
        /// <param name="candies"></param>
        /// <param name="extraCandies"></param>
        /// <returns></returns>
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int max = int.MinValue;//最大糖果数
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] > max)
                {
                    max = candies[i];
                }
            }
            List<bool> result = new List<bool>();
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] + extraCandies >= max)
                    result.Add(true);
                else
                    result.Add(false);
            }
            return result;
        }

        /// <summary>
        /// 2095. 删除链表的中间节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteMiddle(ListNode head)
        {
            if (head.next == null)
                return null;
            ListNode slow = head;
            ListNode fast = head.next.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            //slow.next为应该删除的中间节点
            slow.next = slow.next.next;
            return head;
        }

        /// <summary>
        /// 1410. HTML 实体解析器
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EntityParser(string text)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>() {
                {"&quot;", "\""},
                {"&apos;", "'"},
                {"&amp;", "&"},
                {"&gt;", ">"},
                {"&lt;", "<"},
                {"&frasl;", "/"} };
            StringBuilder sb = new StringBuilder();
            char[] cText = text.ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (cText[i] == '&')//处理特殊符号
                {
                    StringBuilder temp = new StringBuilder();
                    int right = i;
                    while (right < text.Length && cText[right] != ';')
                    {
                        temp.Append(cText[right]);
                        right++;
                    }
                    temp.Append(';');
                    if (dic.ContainsKey(temp.ToString()))
                    {
                        sb.Append(dic[temp.ToString()]);
                        i = right;
                    }
                    else//不在字典中 照常处理
                    {
                        sb.Append(cText[i]);
                    }
                }
                else
                {
                    sb.Append(cText[i]);
                }
            }
            return sb.ToString();
        }


    }
}
