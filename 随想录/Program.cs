using down;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Up
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region test1
            //int[] nums = { 1, 2, 3, 4, 5, 9 };
            //int target = 4;
            //int result = Search(nums, target);
            //System.Console.WriteLine(result);

            //int[] nums = { 3, 2, 2, 3 };
            //int target = 2;
            //int result = RemoveElement(nums, target);
            //Console.WriteLine(result);

            //GenerateMatrix(3);

            //MyLinkedList myLinkedList = new MyLinkedList();
            //myLinkedList.AddAtIndex(0, 10);
            //myLinkedList.Traverse();
            //myLinkedList.AddAtIndex(0, 20);
            //myLinkedList.AddAtIndex(1, 30);
            //myLinkedList.Get(0);
            //myLinkedList.AddAtHead(7);
            //myLinkedList.DeleteAtIndex(2);
            #endregion
            #region 链表测试
            //ListNode node5 = new ListNode(4);
            //ListNode node4 = new ListNode(2, node5);
            //ListNode node3 = new ListNode(1, node4);
            //ListNode node2 = new ListNode(9, node3);
            //ListNode node1 = new ListNode(0, node2);

            //ListNode Bnode1 = new ListNode(3, node4);

            //SwapPairs1(node1);
            //RemoveNthFromEnd(node1, 2);
            //GetIntersectionNode(node1, Bnode1);
            #endregion
            #region test2
            //IsAnagram("ab", "a");
            //int[] index = { 1, 2, 3, 2, 3, 4, 5, 6 };
            //int[] index1 = { 1, 2, 3 };
            //Intersection(index, index1);
            //int[] test = { 3, 2, 4 };
            //int target = 6;
            //TwoSum(test, target);

            //string a = "abc";
            //string b = "abc";
            //CanConstruct(a, b);
            #endregion
            #region test3
            //char[] chars = { 'a', 'b', 'c' };
            //ReverseString(chars);

            //string s = "  hello world  nihao  ";
            //ReverseStr(s, 4);
            //PathEncryption("We are happy");
            //ReverseWords(s);
            // StrStr("abcandbabcdabcacda", "abcdabca");
            //StrStrKMP("cdabcacda", "abcac");

            //RepeatedSubstringPattern("ababab");
            //RepeatedSubstringPattern1("abcabcabcabc");
            #endregion
            #region 栈和队列
            //MyQueue obj = new MyQueue();
            //obj.Push(1);
            //obj.Push(2);
            //int para = obj.Peek();
            //int para1 = obj.Pop();
            //bool para2 = obj.Empty();
            //Console.WriteLine(para + "---" + para1 + "---" + para2);

            //MyStack myStack = new MyStack();
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Top();
            ////myStack.Traverse();
            //int va = myStack.Pop();
            //Console.WriteLine(va);
            //myStack.Empty();

            RemoveDuplicates("abbaca");
            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };
            MaxSlidingWindow(nums, 3);
            #endregion

        }

        #region 数组
        /// <summary>
        /// 704.二分查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchB(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 704.二分查找 二分法求解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = (left + right) / 2;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// 27.移除元素  快慢指针（双指针法）
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement(int[] nums, int val)
        {
            //int count = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i]!=val)
            //    {
            //        nums[count++] = nums[i];
            //    }
            //}
            //return count;

            //快慢指针 慢指针指向新数组
            int slow = 0;
            for (int fast = 0; fast < nums.Length; fast++)
            {
                if (val != nums[fast])
                {
                    nums[slow++] = nums[fast];
                }
            }
            return slow;
        }

        /// <summary>
        /// 977.有序数组的平方 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortedSquares(int[] nums)
        {
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    nums[i] *= nums[i];
            //}
            //Array.Sort(nums);
            //return nums;

            int[] result = new int[nums.Length];
            int k = nums.Length - 1;
            for (int i = 0, j = nums.Length - 1; i <= j;)//逗号操作符 初始化了两个变量
            {
                if (nums[i] * nums[i] > nums[j] * nums[j])
                {
                    result[k--] = nums[i] * nums[i];
                    i++;
                }
                else
                {
                    result[k--] = nums[j] * nums[j];
                    j--;
                }
            }
            return result;
        }

        /// <summary>
        /// 209.长度最小的子数组
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MinSubArrayLen(int target, int[] nums)
        {
            int result = int.MaxValue;     //最后长度
            int sLength = 0;    //当前长度
            int left = 0;       //左指针
            int sum = 0;        //区间值

            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];
                while (sum >= target)   //当和大于目标值
                {
                    sLength = right - left + 1; //临时长度
                    result = result > sLength ? sLength : result;
                    sum -= nums[left++];        //left向右，缩小区间
                }
            }
            return result == int.MaxValue ? 0 : result;
        }

        /// <summary>
        /// 59.螺旋矩阵Ⅱ
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[][] GenerateMatrix(int n)
        {
            int up = 0, down = n - 1, left = 0, right = n - 1;
            int num = 1;

            //int[,] result = new int[n, n];

            //交错数组
            int[][] result = new int[n][];

            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            while (true)
            {
                for (int i = left; i <= right; i++)
                {
                    result[up][i] = num++;
                    //result[up, i] = num++;
                    Console.WriteLine(result[up][i] + "++");
                }
                if (++up > down)//改变内圈的起始位置
                    break;

                for (int i = up; i <= down; i++)
                {
                    result[i][right] = num++;
                    //result[i, right] = num++;
                    Console.WriteLine(result[i][right] + "..");
                }
                if (--right < left)
                    break;

                for (int i = right; i >= left; i--)
                {
                    result[down][i] = num++;
                    //result[down, i] = num++;
                    Console.WriteLine(result[down][i] + "--");
                }
                if (--down < up)
                    break;

                for (int i = down; i >= up; i--)
                {
                    result[i][left] = num++;
                    //result[i, left] = num++;
                    Console.WriteLine(result[i][left] + "**");
                }
                if (++left > right)
                    break;
            }
            return result;
        }
        #endregion

        #region 链表
        /// <summary>
        /// 链表的定义
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        //public class ListNode
        //{
        //    public int val;
        //    public ListNode next;
        //    public ListNode(int val = 0, ListNode next = null)
        //    {
        //        this.val = val;
        //        this.next = next;
        //    }
        //}

        /// <summary>
        /// 203.移除链表元素 画图理解
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        //虚拟头节点
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode dummy = new ListNode(0); // 创建一个虚拟头节点
            dummy.next = head;
            ListNode prev = dummy;      //引用
            ListNode current = head;

            while (current != null)
            {
                if (current.val == val)
                {
                    prev.next = current.next;
                    current = prev.next;
                }
                else
                {
                    prev = current;
                    current = current.next;
                }
            }
            return dummy.next;
        }
        public ListNode RemoveElements1(ListNode head, int val)
        {
            ListNode dummyNode = new ListNode(0, head);
            ListNode temp = dummyNode;

            while (temp.next != null)
            {
                if (temp.next.val == val)
                {
                    temp.next = temp.next.next;
                }
                else
                {
                    temp = temp.next;
                }
            }
            return dummyNode.next;
        }
        //原链表基础上删除
        public ListNode RemoveElements2(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }
            if (head == null)
            {
                return head;
            }

            ListNode pre = head;
            ListNode cur = head.next;

            while (cur != null)
            {
                if (cur.val == val)
                {
                    pre.next = cur.next;
                }
                else
                {
                    pre = cur;
                }
                cur = cur.next;
            }
            return head;

        }

        /// <summary>
        /// 206.反转链表 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseListNode(ListNode head)
        {
            ListNode cur = head;
            ListNode pre = null;
            ListNode temp;

            while (cur != null)
            {
                temp = cur.next;
                //每轮让cur指向pre,并往后先移动pre再移动cur的位置。
                cur.next = pre;     //改变指向
                pre = cur;
                cur = temp;
            }
            return pre;
        }
        //递归写法
        public ListNode ReverseList1(ListNode head)
        {
            return ReverseNode(null, head);
        }
        private ListNode ReverseNode(ListNode pre, ListNode cur)
        {
            if (cur == null)
            {
                return pre;
            }

            ListNode temp = null;
            temp = cur.next;
            cur.next = pre;

            //（更新）移动pre cur的位置
            return ReverseNode(cur, temp);

        }

        /// <summary>
        /// 24.两两交换链表中的节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            ListNode dummyHead = new ListNode(0, head);
            ListNode cur = dummyHead;

            ListNode temp1;
            ListNode temp2;
            ListNode temp3;

            while (cur.next != null && cur.next.next != null)
            {
                temp1 = cur.next;           //需要交换的第一个节点
                temp2 = cur.next.next;      //需要交换的第一个节点
                temp3 = cur.next.next.next; //两个节点后面的节点

                cur.next = temp2;
                temp2.next = temp1;
                temp1.next = temp3;

                cur = cur.next.next;
            }
            return dummyHead.next;
        }
        //递归解法
        //递归特性：先进后出
        public static ListNode SwapPairs1(ListNode head)
        {
            //终止条件
            if (head == null || head.next == null) return head;
            // 获取当前节点的下一个节点
            ListNode next = head.next;
            // 进行递归
            ListNode newNode = SwapPairs1(next.next);
            // 这里进行交换，两两互换
            next.next = head;
            head.next = newNode;

            return next;
        }

        /// <summary>
        /// 19.删除链表的倒数第N个节点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummyHead = new ListNode(0, head);
            ListNode temp = dummyHead;

            int count = 0;

            while (temp.next != null)
            {
                temp = temp.next;
                count++;
            }

            Console.WriteLine(count);

            //找到要删除的前一个节点
            temp = dummyHead;
            for (int i = 0; i < count - n; i++)
            {
                temp = temp.next;
            }
            temp.next = temp.next.next;

            return dummyHead.next;
        }
        //快慢指针解法
        public static ListNode RemoveNthFromEnd1(ListNode head, int n)
        {
            //如果要删除倒数第n个节点，让fast移动n步，然后让fast和slow同时移动，直到fast指向链表末尾。删掉slow所指向的节点就可以了。
            ListNode dummpHead = new ListNode(0, head);
            ListNode fastNode = dummpHead;//是否走到末尾
            ListNode slowNode = dummpHead;//要删除节点的前一个节点

            //fast先走n步
            while (n-- != 0 && fastNode != null)
            {
                fastNode = fastNode.next;
            }

            while (fastNode.next != null)
            {
                fastNode = fastNode.next;
                slowNode = slowNode.next;
            }
            slowNode.next = slowNode.next.next;
            return dummpHead.next;
        }

        /// <summary>
        /// 面试题 02.07. 链表相交
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
        /// 用于获取链表的长度
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
        /// 141.环形链表 快慢指针
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 142.环形链表Ⅱ https://leetcode.cn/problems/linked-list-cycle-ii/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                //快慢指针，找到相遇点，判断是否有环
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)//相遇点
                {   // 有环
                    ListNode index1 = fast; //相遇节点
                    ListNode index2 = head; //头节点
                    // 两个指针，从头结点和相遇结点，各走一步，直到相遇，相遇点即为环入口
                    // 该结论通过推导得出
                    while (index1 != index2)
                    {
                        index1 = index1.next;
                        index2 = index2.next;
                    }
                    return index1;
                }
            }
            return null;
        }

        #endregion

        #region 哈希表

        /// <summary>
        /// 242.有效的字母异位词
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            //也可以使用数组实现
            Dictionary<string, int> alphabet = new Dictionary<string, int>();

            //将S的字母存入，第二个参数为对应字母的个数。
            for (int i = 0; i < s.Length; i++)
            {
                if (!alphabet.ContainsKey(s.Substring(i, 1)))
                {
                    alphabet.Add(s.Substring(i, 1), 1);
                }
                else
                {
                    alphabet[s.Substring(i, 1)]++;
                }
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (!alphabet.ContainsKey(t.Substring(i, 1)))
                {
                    return false;
                }
                else
                {
                    alphabet[t.Substring(i, 1)]--;
                    if (alphabet[t.Substring(i, 1)] < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 349.两个数组的交集
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            set1 = Insert(nums1);
            set2 = Insert(nums2);

            set1.IntersectWith(set2);//做交集运算
            return set1.ToArray();
        }
        /// <summary>
        /// 将数组插入到HashSet
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static HashSet<int> Insert(int[] nums)
        {
            HashSet<int> one = new HashSet<int>();
            foreach (int num in nums)
            {
                one.Add(num);//重复的元素无法添加，会被忽略
            }
            return one;
        }

        /// <summary>
        /// 202.快乐数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsHappy(int n)
        {
            HashSet<int> set = new HashSet<int>();
            while (n != 1 && !set.Contains(n))//有和为1的数/出现已经保存过的数（无限循环）
            { //判断避免循环
                set.Add(n);
                n = GetSum(n);
            }
            return n == 1;
        }

        /// <summary>
        /// 求这个数各个位上平方和
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int GetSum(int n)
        {
            int sum = 0;
            //每位数的换算
            while (n > 0)
            {
                sum += (n % 10) * (n % 10);
                n /= 10;
            }
            return sum;
        }

        /// <summary>
        /// 1.两数之和 哈希表Dictionary
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            //值和下标
            Dictionary<int, int> numsDic = new Dictionary<int, int>();
            int[] result = new int[2];
            //key为值 value为下标
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numsDic.ContainsKey(nums[i]))
                {
                    numsDic.Add(nums[i], i);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int temp = target - nums[i];
                if (numsDic.ContainsKey(temp) && numsDic[temp] != i)//这个数不能和数组里的数是同一个
                {
                    result[0] = i;
                    result[1] = numsDic[temp];
                    return result;
                }
            }

            return new int[2];
        }

        /// <summary>
        /// 454.四数相加Ⅱ
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="nums3"></param>
        /// <param name="nums4"></param>
        /// <returns></returns>
        #region 解题步骤
        /*
        1.首先定义 一个Dictionary，key放a和b两数之和，value 放a和b两数之和出现的次数。
        2.遍历大A和大B数组，统计两个数组元素之和，和出现的次数，放到map中。
        3.定义int变量count，用来统计 a+b + c + d = 0 出现的次数。
        4.在遍历大C和大D数组，找到如果 0 - (c + d) 在map中出现过的话，就用count把map中key对应的value也就是出现次数统计出来。
        5.最后返回统计值 count 就可以了
        */
        #endregion
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            int count = 0;
            Dictionary<int, int> sumAB = new Dictionary<int, int>();
            //将1，2数组两数之和和出现次数存入字典
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    int sumTemp = nums1[i] + nums2[j];
                    if (!sumAB.ContainsKey(sumTemp))
                    {
                        sumAB.Add(sumTemp, 1);
                    }
                    else
                    {
                        sumAB[sumTemp]++;
                    }
                }
            }
            //计算0-(3+4)数组的两数之和，判断得出和是否在先前字典中存储过。出现过则将key对应的value存入count。
            for (int i = 0; i < nums3.Length; i++)
            {
                for (int j = 0; j < nums4.Length; j++)
                {
                    int nSum = 0 - (nums3[i] + nums4[j]);
                    if (sumAB.ContainsKey(nSum))
                    {
                        count += sumAB[nSum];
                    }
                }
            }
            return count;

        }

        /// <summary>
        /// 383.赎金信 与 242.有效的字母异位词 类似
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            if (magazine.Length < ransomNote.Length)
                return false;

            Dictionary<string, int> alphabet = new Dictionary<string, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (alphabet.ContainsKey(magazine.Substring(i, 1)))
                {
                    alphabet[magazine.Substring(i, 1)]++;
                }
                else
                {
                    alphabet.Add(magazine.Substring(i, 1), 1);
                }
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (alphabet.ContainsKey(ransomNote.Substring(i, 1)))
                {
                    alphabet[ransomNote.Substring(i, 1)]--;
                    if (alphabet[ransomNote.Substring(i, 1)] < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //数组解法，更加简单高效
        public bool CanConstruct1(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length) return false;
            int[] letters = new int[26];//a-z
            //因为都是字母。ASCLII码 a=97。a-a=0,z-a=25;对应数组下标
            foreach (char c in magazine)
            {
                letters[c - 'a']++;
            }
            foreach (char c in ransomNote)
            {
                letters[c - 'a']--;
                if (letters[c - 'a'] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 15.三数之和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))//去重：nums[i] != nums[i - 1]) 第一个数不能是之前遍历过的 
                {
                    int target = -nums[i];//假设a,b,c，最外层为数a,target为b+c之和。
                    HashSet<int> seen = new HashSet<int>();

                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        int complement = target - nums[j];//comlement 为c的另一差值。

                        if (seen.Contains(complement))//如果之前有一个差值包含在哈希表中，则代表i,complement,j为组合数
                        {
                            result.Add(new List<int> { nums[i], complement, nums[j] });

                            while (j < nums.Length - 1 && nums[j] == nums[j + 1])//去重：跳过与j相同的元素
                            {
                                j++;
                            }
                        }
                        else
                        {
                            seen.Add(nums[j]);      //去重：哈希不会重复添加相同的数。
                        }
                    }
                }
            }
            return result;
        }
        //双指针法
        public IList<IList<int>> ThreeSum1(int[] nums)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0)     //不满足跳过
                    break;

                if (i > 0 && nums[i] == nums[i - 1]) //i去重
                    continue;

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum > 0)
                    {
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else// ==0
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });
                        //left的值和它右边的比较，相同则++跳过
                        while (left < right && nums[left] == nums[left + 1])//left去重
                        {
                            left++;
                        }

                        while (left < right && nums[right] == nums[right - 1])//right去重
                        {
                            right--;
                        }
                        //移动指针
                        left++;
                        right--;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 18.四数之和 双指针法。在三数之和的基础上多一个for循环，注意target为任意值。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var result = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                // nums[i] > target 直接返回, 剪枝操作
                if (nums[i] > 0 && nums[i] > target)
                {
                    return result;
                }

                if (i > 0 && nums[i] == nums[i - 1]) //i去重
                    continue;

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) //j去重
                        continue;

                    int left = j + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum > target)
                        {
                            right--;
                        }
                        else if (sum < target)
                        {
                            left++;
                        }
                        else// ==target
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                            //left的值和它右边的比较，相同则++跳过
                            while (left < right && nums[left] == nums[left + 1])//left去重
                            {
                                left++;
                            }

                            while (left < right && nums[right] == nums[right - 1])//right去重
                            {
                                right--;
                            }
                            //移动指针
                            left++;
                            right--;
                        }
                    }
                }

            }
            return result;
        }

        #endregion

        #region 字符串

        #region 反转字符串
        /// <summary>
        /// 344.反转字符串
        /// </summary>
        /// <param name="s"></param>
        public static void ReverseString(char[] s)
        {
            //API:Array.Reverse(s);
            //for (int i = 0; i < s.Length / 2; i++)
            //{
            //    char temp = s[i];
            //    s[i] = s[s.Length - i - 1];
            //    s[s.Length - i - 1] = temp;
            //}

            //7.0特性。元组（Tuple）和元组赋值语法的特性
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                (s[i], s[j]) = (s[j], s[i]);//交换
            }

            //双指针法
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }

        /// <summary>
        /// 541. 反转字符串II
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string ReverseStr(string s, int k)
        {
            char[] chars = s.ToArray();
            int count2k = s.Length / (2 * k);//2k有多少组
            int rm = s.Length % (2 * k);    //剩余的数长度

            int left = 0;
            int right = k - 1;
            //每个2k组中的前k个互换
            for (int i = 1; i <= count2k; i++)
            {
                ReverseCArray(chars, left, right);
                left = 2 * k * i;
                right = left + k - 1;
            }
            //剩余字符大于等于k少于2k
            if (rm < 2 * k && rm >= k)
            {
                left = 2 * k * count2k;
                right = left + k - 1;
                ReverseCArray(chars, left, right);
            }
            else if (rm < k && rm > 1)//剩余字符少于k
            {
                left = 2 * k * count2k;
                right = s.Length - 1;
                ReverseCArray(chars, left, right);
            }

            string ss = new string(chars);
            return ss;
        }
        /// <summary>
        /// 常用：反转字符数组
        /// </summary>
        /// <param name="chars">需要反转的数组</param>
        /// <param name="left">起始点</param>
        /// <param name="right">终止点</param>
        public static void ReverseCArray(char[] chars, int left, int right)
        {
            while (left < right)
            {
                (chars[left], chars[right]) = (chars[right], chars[left]);
                left++;
                right--;
            }
        }

        /// <summary>
        /// LCR 122. 路径加密 原题：剑指Offer 05.替换空格  "点".替换为"空格" 空格替换成"%20"
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string PathEncryption(string path)
        {
            #region "点".替换为"空格"
            //char[] charPath = path.ToArray();
            //for (int i = 0; i < charPath.Length; i++)
            //{
            //    if (charPath[i] == '.')
            //    {
            //        charPath[i] = ' ';
            //    }
            //}
            //string p = new string(charPath);
            //return p;
            #endregion

            #region 空格替换成"%20"
            //空格替换成"%20" StringBuilder做法
            //StringBuilder stringBuilder = new StringBuilder();
            //for (int i = 0; i < path.Length; i++)
            //{
            //    if (path[i] == ' ')
            //    {
            //        stringBuilder.Append("%20");
            //    }
            //    else
            //    {
            //        stringBuilder.Append(path[i]);
            //    }
            //}
            //Console.WriteLine(stringBuilder.ToString());
            //return stringBuilder.ToString();
            #endregion

            #region 双指针写法
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == ' ')
                {
                    sb.Append("  ");//扩容 空格替换%20 需要三个字符，遇到空格，扩充两个字符大小。
                }
            }

            //有空格情况 定义两个指针
            int left = path.Length - 1;//左指针：指向原始字符串最后一个位置
            path += sb.ToString();
            int right = path.Length - 1;//右指针：指向扩展字符串的最后一个位置
            char[] chars = path.ToCharArray();
            while (left >= 0)
            {
                if (chars[left] == ' ')
                {
                    chars[right--] = '0';
                    chars[right--] = '2';
                    chars[right] = '%';
                }
                else
                {
                    //从后向前填充元素，避免了从前向后填充元素时，每次添加元素都要将添加元素之后的所有元素向后移动的问题
                    chars[right] = chars[left];
                }
                left--;
                right--;
            }
            string p = new string(chars);
            Console.WriteLine(p);
            return p;

            #endregion
        }

        /// <summary>
        /// 151.翻转字符串里的单词
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseWords(string s)
        {
            char[] cS = s.ToCharArray();
            //1.去除多余空格,首尾没有多余空格，且单词间只有一个空格。   --->思路：27.移除元素
            int slow = 0;   //填充新的数组，循环结束表示去除了多余空格后的大小。
            for (int i = 0; i < s.Length; i++)
            {
                if (cS[i] != ' ')//不是空格就处理
                {
                    if (slow != 0)//补上单词间的空格，还没有单词加入则不加空格。
                    {
                        cS[slow++] = ' ';
                    }
                    while (i < cS.Length && cS[i] != ' ')//遇上空格代表这个单词结束了
                    {
                        cS[slow++] = cS[i++];//单词加入
                    }
                }
            }
            Array.Resize(ref cS, slow);//重新设置数组的大小，将数组多余的部分剔除。

            //2.将整个字符串反转
            ReverseCArray(cS, 0, slow - 1);

            //3.将每个单词反转回来
            int start = 0;
            for (int i = 0; i <= cS.Length; i++)
            {
                if (i == cS.Length || cS[i] == ' ')//到达空格或者串尾
                {
                    ReverseCArray(cS, start, i - 1);
                    start = i + 1;//重置下一个单词的下标
                }
            }

            string ss = new string(cS);
            Console.WriteLine(ss);
            return ss;
        }
        /// <summary>
        /// LCR 182. 动态口令 原题：剑指Offer58-II.左旋转字符串
        /// </summary>
        /// <param name="password"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string DynamicPassword(string password, int target)
        {
            //思路比代码重要！！！
            char[] chars = password.ToCharArray();
            //反转前target个子串
            ReverseCArray(chars, 0, target - 1);
            //反转target到末尾的子串
            ReverseCArray(chars, target, chars.Length - 1);
            //反转整个字符串
            ReverseCArray(chars, 0, chars.Length - 1);

            return new string(chars);
        }

        #endregion

        #region BF KMP
        /// <summary>
        /// 实现strStr() 28. 找出字符串中第一个匹配项的下标
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public static int StrStr(string haystack, string needle)
        {
            //BF
            int left = 0;
            int right = needle.Length;
            while (left <= haystack.Length - needle.Length)
            {
                if (haystack.Substring(left, right) == needle)//注意 第二个参数为长度。
                {
                    return left;
                }
                left++;
            }
            return -1;
        }
        public static int StrStrKMP(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            if (needle.Length > haystack.Length || string.IsNullOrEmpty(haystack))
            {
                return -1;
            }

            return KMP(haystack, needle);
        }
        private static int KMP(string haystack, string needle)
        {
            int[] next = GetNext(needle);
            int hIndex = 0;
            int nIndex = 0;

            while (hIndex < haystack.Length)
            {
                if (needle[nIndex] == haystack[hIndex])//当匹配到字符相等时，各自++ 匹配下一个。
                {
                    nIndex++;
                    hIndex++;
                    if (nIndex == needle.Length)//匹配完毕
                    {
                        return hIndex - nIndex;
                    }
                }
                else if (nIndex > 0)//匹配到不同字符，子串当前索引大于0，则从next数组中获取子串开始匹配的位置。
                {
                    nIndex = next[nIndex - 1];
                }
                else//nIndex==0 则移动下一个主串位置继续匹配
                {
                    hIndex++;
                }
            }
            return -1;
        }
        public static int[] GetNext(string pattern)
        {
            int[] next = new int[pattern.Length];
            next[0] = 0;
            int j = 0;
            int i = 1;
            while (i < pattern.Length)
            {
                if (pattern[j] == pattern[i])
                {
                    j++;
                    next[i] = j;
                    i++;
                }
                else
                {
                    if (j == 0)
                    {
                        next[i] = 0;
                        i++;
                    }
                    else
                    {
                        j = next[j - 1];
                    }
                }
            }
            return next;
        }

        /// <summary>
        /// 459. 重复的子字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool RepeatedSubstringPattern(string s)
        {
            //不建议使用！
            for (int i = 1; i <= s.Length / 2; i++)
            {
                if (s.Length % i == 0)//切割出字符串的倍数不等于原字符串长度，跳过该子串。
                {
                    string subS = s.Substring(0, i);
                    string tempS = subS;
                    while (tempS.Length <= s.Length)
                    {
                        tempS += subS;
                        if (tempS == s)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool RepeatedSubstringPattern1(string s)
        {
            int n = s.Length;
            int[] lps = GetNext(s);

            // 最长重复子串的长度
            int len = lps[n - 1];

            // 检查是否有重复子串
            return len > 0 && n % (n - len) == 0;
            /*
                1,整个字符串 s 的长度 n 可以分成 (n - len) 个完整的重复周期，因为 n 被 (n - len) 整除，没有余数。
                2,因为每个周期的长度是 len，所以整个字符串 s 可以被分成 (n - len) 个完整的重复周期，每个周期都是最长重复子串的长度 len。
                3,这意味着字符串 s 是由最长重复子串重复构成的，因为它可以被分成多个相同长度的周期，每个周期都是重复的子串。
            */
        }

        #endregion

        #endregion

        #region 栈与队列
        //232. 用栈实现队列
        //225. 用队列实现栈

        /// <summary>
        /// 20. 有效的括号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            if (s.Length % 2 == 1) return false; // 字符串长度为单数，直接返回 false

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(')');
                }
                else if (s[i] == '[')
                {
                    stack.Push(']');
                }
                else if (s[i] == '{')
                {
                    stack.Push('}');
                }
                //情况二：遍历过程中，栈空了，但是还有没匹配的符号。
                //情况三：遍历过程中，发现栈中没有要匹配的符号
                else if (stack.Count == 0 || stack.Peek() != s[i])
                {
                    return false;
                }
                else
                {
                    stack.Pop();
                }
            }
            //情况一：栈不为空 还有没匹配完的符号
            return stack.Count == 0;

        }

        /// <summary>
        /// 1047. 删除字符串中的所有相邻重复项
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveDuplicates(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 || stack.Count == 0)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Peek() == s[i])//栈顶和待入栈的元素对比，相同就把栈顶元素移除，待入栈元素忽略入栈。
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(s[i]);
                    }
                }
            }
            StringBuilder sb = new StringBuilder();

            foreach (var item in stack)
            {
                sb.Append(item);
            }

            char[] charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
        //使用字符串直接作为栈，省去了栈还要转为字符串的操作
        public string RemoveDuplicates1(string s)
        {
            StringBuilder res = new StringBuilder();
            foreach (char c in s)
            {
                if (res.Length > 0 && res[res.Length - 1] == c)
                {
                    res.Remove(res.Length - 1, 1);
                }
                else
                {
                    res.Append(c);
                }
            }
            return res.ToString();
        }

        /// <summary>
        /// 150. 逆波兰表达式求值
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();

            foreach (string s in tokens)
            {
                int num;
                if (int.TryParse(s, out num)) //如果转换成功，将转换后的整数值赋给 num ，并返回 true。否则返回 false，并且 num 的值保持不变。
                {
                    // 如果是数字，将其推入堆栈
                    stack.Push(num);
                }
                else
                {
                    // 如果是运算符，执行相应的运算
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();

                    switch (s)
                    {
                        case "+": stack.Push(operand1 + operand2); break;
                        case "-": stack.Push(operand1 - operand2); break;
                        case "*": stack.Push(operand1 * operand2); break;
                        case "/": stack.Push(operand1 / operand2); break;
                    }
                }
            }

            // 只剩一个元素，弹出结果
            return stack.Pop();
        }

        /// <summary>
        /// 239. 滑动窗口最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            //记录索引的方式存储在双端队列
            if (nums.Length < 2)
                return nums;

            int[] result = new int[nums.Length - k + 1];    //存储结果的数组 代表有多少个滑动窗口
            LinkedList<int> deque = new LinkedList<int>();  //双端队列 

            for (int i = 0; i < nums.Length; i++)
            {
                // 超出窗口的长度时，删除队首。
                if (deque.Count > 0 && deque.First.Value < i - k + 1)
                {
                    deque.RemoveFirst();
                }

                //移除队列尾部小于当前元素的元素索引。
                while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                {
                    deque.RemoveLast();
                }

                // 将当前元素的索引加入队列
                deque.AddLast(i);

                // 记录当前窗口的最大值 i到达k-1时，表示已满足滑动窗口，开始记录值。
                if (i >= k - 1)
                {
                    result[i - k + 1] = nums[deque.First.Value];
                }
            }
            return result;
        }
        //随想录
        myDequeue window = new myDequeue();
        List<int> res = new List<int>();
        public int[] MaxSlidingWindow1(int[] nums, int k)
        {
            //记录索引对应的值的方式存储在双端队列
            for (int i = 0; i < k; i++)//处理前 k 个元素，初始化窗口
            {
                window.Enqueue(nums[i]);
            }
            res.Add(window.Max());
            // 处理剩余元素，滑动窗口
            for (int i = k; i < nums.Length; i++)
            {
                window.Dequeue(nums[i - k]);    // 从窗口中移除窗口左侧的元素（i-k位置的元素）
                window.Enqueue(nums[i]);        // 将当前元素加入窗口
                res.Add(window.Max());          // 将当前窗口的最大值添加到结果列表
            }
            return res.ToArray();
        }

        /// <summary>
        /// 347.前 K 个高频元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            //哈希表-统计出现频率 值出现的次数
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    dic[nums[i]]++;
                }
                else
                {
                    dic.Add(nums[i], 1);
                }
            }

            // 将字典中的键值对转化为一个List，以便进行排序
            List<KeyValuePair<int, int>> list = dic.ToList();

            // 使用Sort方法根据频率降序排序
            list.Sort((a, b) => b.Value.CompareTo(a.Value));

            // 添加频率最高的前k个元素
            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = list[i].Key; //i是List中的第i组key,value
            }
            return result;
        }
        #endregion

        #region 二叉树

        #region 前中后序 递归法
        /// <summary>
        /// 144.二叉树的前序遍历 根左右
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        List<int> treeNodeList = new List<int>();
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
                return treeNodeList;

            treeNodeList.Add(root.val);

            PreorderTraversal(root.left);
            PreorderTraversal(root.right);

            return treeNodeList;
        }
        /// <summary>
        /// 接上，封装了一层还是使用局部变量
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal1(TreeNode root)
        {
            List<int> resultList = new List<int>();
            Preorder(root, resultList);
            return resultList;
        }
        public void Preorder(TreeNode root, IList<int> result)
        {
            if (root == null)
                return;

            result.Add(root.val);           //根
            Preorder(root.left, result);    //左
            Preorder(root.right, result);   //右
        }

        /// <summary>
        /// 94.二叉树的中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> resultList = new List<int>();
            Inorder(root, resultList);
            return resultList;
        }
        private static void Inorder(TreeNode root, List<int> resultList)
        {
            if (root == null)
                return;

            Inorder(root.left, resultList);     //左
            resultList.Add(root.val);           //根
            Inorder(root.right, resultList);    //右
        }

        /// <summary>
        /// 145.二叉树的后序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> resultList = new List<int>();
            Postoder(root, resultList);
            return resultList;
        }
        private static void Postoder(TreeNode root, List<int> resultList)
        {
            if (root == null)
                return;

            Postoder(root.left, resultList);    //左
            Postoder(root.right, resultList);   //右
            resultList.Add(root.val);           //根
        }
        #endregion

        #region 前中后序 迭代法 栈实现
        /// <summary>
        /// 迭代法 前序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal2(TreeNode root)
        {
            //首先，创建一个空的 resultList 用于存储遍历结果。
            List<int> resultList = new List<int>();
            // 如果根节点 root 为空，直接返回空的 resultList。
            if (root == null)
                return resultList;

            //创建一个栈 stack，并将根节点 root 压入栈中。
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            //使用一个循环，不断执行以下操作，直到栈为空：
            //弹出栈顶节点 node。
            //将 node 的值添加到 resultList 中。
            //如果 node 的右子节点不为空，将右子节点压入栈中（因为前序遍历先处理左子树，再处理右子树）。
            //如果 node 的左子节点不为空，将左子节点压入栈中。
            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                resultList.Add(node.val);

                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }
            return resultList;
        }

        /// <summary>
        /// 94.二叉树的中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal1(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> result = new List<int>();
            //根节点开始
            TreeNode cur = root;
            while (cur != null || stack.Count != 0)
            {
                //先处理左子树
                if (cur != null)//移动到其的左子节点
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                else//开始处理栈中top元素，有右子节点就压栈
                {
                    cur = stack.Pop();
                    result.Add(cur.val);
                    cur = cur.right;
                }
            }
            return result;
        }

        /// <summary>
        /// 145.二叉树的后序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal1(TreeNode root)
        {
            List<int> resultList = new List<int>();
            if (root == null)
                return resultList;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                //代码：中，左右（栈结构）  --->  中，右左 
                resultList.Add(node.val);
                if (node.left != null) stack.Push(node.left);
                if (node.right != null) stack.Push(node.right);

            }
            //反转结果 就变成左 右 中
            resultList.Reverse();
            return resultList;
        }

        #endregion

        # region 前中后序 统一迭代法

        /// <summary>
        /// 94.二叉树的中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal2(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> result = new List<int>();
            if (root != null) stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode node = stack.Peek();
                if (node != null)
                {
                    stack.Pop();//将该节点弹出避免重复操作
                    if (node.right != null)   //添加 右
                        stack.Push(node.right);

                    stack.Push(node);//添加待处理的节点
                    stack.Push(null);//该节点访问过，但是还没有处理，加入null做标记

                    if (node.left != null)  //添加 左
                        stack.Push(node.left);
                }
                else//处理null，将下一节点放入结果集
                {
                    stack.Pop();        //处理null
                    node = stack.Pop(); //实际需要处理元素
                    result.Add(node.val);
                }
            }
            return result;
        }

        /// <summary>
        /// 迭代法 前序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal3(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> result = new List<int>();
            if (root != null) stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode node = stack.Peek();
                if (node != null)
                {
                    stack.Pop();//将该节点弹出避免重复操作
                    if (node.right != null)   //添加 右
                        stack.Push(node.right);

                    if (node.left != null)  //添加 左
                        stack.Push(node.left);

                    stack.Push(node);       //中
                    stack.Push(null);
                }
                else//处理null，将下一节点放入结果集
                {
                    stack.Pop();
                    node = stack.Pop();
                    result.Add(node.val);
                }
            }
            return result;
        }

        /// <summary>
        /// 145.二叉树的后序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal2(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> result = new List<int>();
            if (root != null) stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode node = stack.Peek();
                if (node != null)
                {
                    stack.Pop();//将该节点弹出避免重复操作

                    stack.Push(node);
                    stack.Push(null);

                    if (node.right != null)   //添加 右
                        stack.Push(node.right);

                    if (node.left != null)  //添加 左
                        stack.Push(node.left);
                }
                else//处理null，将下一节点放入结果集
                {
                    stack.Pop();
                    node = stack.Pop();
                    result.Add(node.val);
                }
            }
            return result;
        }

        #endregion

        #region 层序遍历专题 队列实现 在层序遍历的基础上修改代码即可

        /// <summary>
        /// 102.二叉树的层序遍历 队列实现 BFS 广度优先搜索
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            treeNodes.Enqueue(root);
            while (treeNodes.Count != 0)
            {
                List<int> tempList = new List<int>();
                int count = treeNodes.Count;
                while (count > 0)//处理每一层级
                {
                    TreeNode node = treeNodes.Dequeue();
                    tempList.Add(node.val);
                    count--;
                    if (node.left != null) treeNodes.Enqueue(node.left);
                    if (node.right != null) treeNodes.Enqueue(node.right);
                }
                result.Add(tempList);
            }
            return result;
        }
        // 也行但是leetcode上需要返回的list的列表
        public IList<int> LevelOrder1(TreeNode root)
        {
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            List<int> result = new List<int>();
            if (root == null) return result;

            treeNodes.Enqueue(root);
            while (treeNodes.Count > 0)
            {
                TreeNode node = treeNodes.Dequeue();
                result.Add(node.val);
                if (node.left != null) treeNodes.Enqueue(node.left);
                if (node.right != null) treeNodes.Enqueue(node.right);
            }
            return result;
        }

        /// <summary>
        /// 107.二叉树的层序遍历II
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            treeNodes.Enqueue(root);
            while (treeNodes.Count != 0)
            {
                List<int> tempList = new List<int>();
                int count = treeNodes.Count;
                while (count > 0)//处理每一层级
                {
                    TreeNode node = treeNodes.Dequeue();
                    tempList.Add(node.val);
                    count--;
                    if (node.left != null) treeNodes.Enqueue(node.left);
                    if (node.right != null) treeNodes.Enqueue(node.right);
                }
                //result.Insert(0, tempList);//一步搞定，使用API往前插入
                result.Add(tempList);
            }
            ReverseIList(result);
            return result;
        }
        /// <summary>
        /// 反转list 双指针
        /// </summary>
        /// <param name="result"></param>
        public void ReverseIList(IList<IList<int>> result)
        {
            int left = 0;
            int right = result.Count - 1;
            while (left < right)
            {
                IList<int> tempList = result[left];
                result[left] = result[right];
                result[right] = tempList;
                left++;
                right--;
            }
        }

        /// <summary>
        /// 199.二叉树的右视图
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            List<int> result = new List<int>();
            if (root == null) return result;

            treeNodes.Enqueue(root);
            while (treeNodes.Count != 0)
            {
                int count = treeNodes.Count;
                while (count > 0)
                {
                    TreeNode node = treeNodes.Dequeue();
                    if (count == 1)//剩一个代表遍历到该层的最后一个（也就是最右边的节点）
                    {
                        result.Add(node.val);//只加入该值
                    }
                    count--;
                    if (node.left != null) treeNodes.Enqueue(node.left);
                    if (node.right != null) treeNodes.Enqueue(node.right);
                }//处理每一层级
            }
            return result;
        }

        /// <summary>
        /// 637.二叉树的层平均值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<double> AverageOfLevels(TreeNode root)
        {
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            List<double> result = new List<double>();
            if (root == null) return result;

            treeNodes.Enqueue(root);
            while (treeNodes.Count != 0)
            {
                int count = treeNodes.Count;
                int tempCount = count; //记录count进入循环之前的值，或者把下层的while改成for循环 就不需要此变量。
                double sum = 0;
                while (count > 0)//处理每一层级
                {
                    TreeNode node = treeNodes.Dequeue();
                    sum += node.val;
                    count--;
                    if (node.left != null) treeNodes.Enqueue(node.left);
                    if (node.right != null) treeNodes.Enqueue(node.right);
                }
                double res = sum / tempCount;
                result.Add(res);
            }
            return result;
        }

        /// <summary>
        /// 429.N叉树的层序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            nodes.Enqueue(root);
            while (nodes.Count != 0)
            {
                List<int> tempList = new List<int>();
                int count = nodes.Count;
                while (count > 0)//处理每一层级
                {
                    Node node = nodes.Dequeue();
                    tempList.Add(node.val);
                    count--;
                    for (int i = 0; i < node.children.Count; i++)
                    {
                        nodes.Enqueue(node.children[i]);
                    }
                }
                result.Add(tempList);
            }
            return result;
        }

        /// <summary>
        /// 515.在每个树行中找最大值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> LargestValues(TreeNode root)
        {
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            List<int> result = new List<int>();
            if (root == null) return result;

            treeNodes.Enqueue(root);
            while (treeNodes.Count != 0)
            {
                int count = treeNodes.Count;
                int max = int.MinValue;
                while (count > 0)//处理每一层级
                {
                    TreeNode node = treeNodes.Dequeue();
                    if (node.val > max)
                    {
                        max = node.val;
                    }
                    count--;
                    if (node.left != null) treeNodes.Enqueue(node.left);
                    if (node.right != null) treeNodes.Enqueue(node.right);
                }
                result.Add(max);
            }
            return result;
        }

        /// <summary>
        /// 116.填充每个节点的下一个右侧节点指针
        /// 117.填充每个节点的下一个右侧节点指针II 队列做法。和上一题同解
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node1 Connect(Node1 root)
        {
            Queue<Node1> nodes = new Queue<Node1>();
            if (root == null) return root;

            nodes.Enqueue(root);
            while (nodes.Count != 0)
            {
                int count = nodes.Count;
                while (count > 0)//处理每一层级
                {
                    Node1 node = nodes.Dequeue();
                    if (count == 1)//该层最后一个节点指向null               
                        node.next = null;
                    else
                        node.next = nodes.Peek();//指向队列首节点
                    count--;

                    if (node.left != null) nodes.Enqueue(node.left);
                    if (node.right != null) nodes.Enqueue(node.right);
                }
            }
            return root;
        }

        /// <summary>
        /// 104.二叉树的最大深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            if (root == null) return 0;
            int maxDepth = 0;
            treeNodes.Enqueue(root);
            while (treeNodes.Count != 0)
            {
                int count = treeNodes.Count;
                while (count > 0)//处理每一层级
                {
                    TreeNode node = treeNodes.Dequeue();
                    count--;
                    if (node.left != null) treeNodes.Enqueue(node.left);
                    if (node.right != null) treeNodes.Enqueue(node.right);
                }
                maxDepth++;
            }
            return maxDepth;
        }

        /// <summary>
        /// 111.二叉树的最小深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            if (root == null) return 0;
            int minDepth = 0;
            treeNodes.Enqueue(root);
            while (treeNodes.Count != 0)
            {
                int count = treeNodes.Count;
                minDepth++;
                while (count > 0)//处理每一层级
                {
                    TreeNode node = treeNodes.Dequeue();
                    count--;
                    if (node.left != null) treeNodes.Enqueue(node.left);
                    if (node.right != null) treeNodes.Enqueue(node.right);

                    if (node.left == null && node.right == null) return minDepth;   //左右孩子都为null，表示为最近的叶子节点。
                }
            }
            return minDepth;
        }

        #endregion

        /// <summary>
        /// 226.翻转二叉树 前序递归，迭代写法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertTree(root.left);    //左
            InvertTree(root.right);   //右

            return root;
        }
        public TreeNode InvertTree1(TreeNode root)
        {
            if (root == null)
                return root;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();

                TreeNode temp = node.left;
                node.left = node.right;
                node.right = temp;

                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }
            return root;
        }

        /// <summary>
        /// 589. N叉树的前序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            List<int> resultList = new List<int>();
            if (root == null)
                return resultList;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                Node node = stack.Pop();

                resultList.Add(node.val); //根

                for (int i = node.children.Count - 1; i > 0; i--)
                {
                    stack.Push(node.children[i]);
                }
            }
            return resultList;
        }

        /// <summary>
        /// 590. N叉树的后序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Postorder(Node root)
        {
            List<int> resultList = new List<int>();
            if (root == null)
                return resultList;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                Node node = stack.Pop();
                for (int i = 0; i < node.children.Count; i++)
                {
                    stack.Push(node.children[i]);
                }
                resultList.Add(node.val);// 根
            }
            ReverseList(resultList); //反转结果数组得后序遍历
            return resultList;
        }
        /// <summary>
        /// 反转List<int>列表
        /// </summary>
        /// <param name="result"></param>
        public void ReverseList(List<int> result)
        {
            int left = 0;
            int right = result.Count - 1;
            while (left < right)
            {
                int temp = result[left];
                result[left] = result[right];
                result[right] = temp;
                left++;
                right--;
            }
        }

        /// <summary>
        /// 101. 对称二叉树 递归 迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return Compare(root.left, root.right);
        }
        public bool Compare(TreeNode left, TreeNode right)
        {
            //排除空节点
            if (left == null && right != null) return false;
            else if (right == null && left != null) return false;
            else if (left == null && right == null) return true;
            //排除值不相等
            else if (left.val != right.val) return false;

            //分别处理左右子树
            bool outside = Compare(left.left, right.right);   //外侧 左子树：左、 右子树：右
            bool inside = Compare(left.right, right.left);    //内侧 左子树：右、 右子树：左
            bool isSame = outside && inside;                  //返回值情况：左子树：中、 右子树：中 （逻辑处理）
            return isSame;
        }
        //栈 迭代
        public bool IsSymmetric1(TreeNode root)
        {
            if (root == null) return true;
            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root.left);
            stack.Push(root.right);

            while (stack.Count != 0)//判断是否为翻转
            {
                TreeNode leftNode = stack.Pop();
                TreeNode rightNode = stack.Pop();
                //都为空为对称，比较下一对
                if (leftNode == null && rightNode == null)
                    continue;

                // 左右一个节点为空，或者都不为空但数值不相同，返回false
                if (leftNode == null || rightNode == null || (leftNode.val != rightNode.val))
                    return false;

                //加入下一队比较的结点
                //外侧
                stack.Push(leftNode.left);
                stack.Push(rightNode.right);
                //内侧
                stack.Push(leftNode.right);
                stack.Push(rightNode.left);
            }
            return true;
        }

        /// <summary>
        /// 100.相同的树
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(p);
            stack.Push(q);

            while (stack.Count != 0)//判断是否为相同
            {
                TreeNode pNode = stack.Pop();
                TreeNode qNode = stack.Pop();
                //都为空为对称，比较下一对
                if (pNode == null && qNode == null)
                    continue;

                // 左右一个节点为空，或者都不为空但数值不相同，返回false
                if (pNode == null || qNode == null || (pNode.val != qNode.val))
                    return false;

                //压栈下一对
                stack.Push(pNode.left);
                stack.Push(qNode.left);
                stack.Push(pNode.right);
                stack.Push(qNode.right);
            }
            return true;
        }

        /// <summary>
        /// 572.另一个树的子树
        /// </summary>
        /// <param name="root"></param>
        /// <param name="subRoot"></param>
        /// <returns></returns>
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                //在root树找到与subroot相同的根节点。调用函数比较
                if (node.val == subRoot.val && IsSameTree(node, subRoot))
                {
                    return true;
                }
                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }
            return false;
        }

        /// <summary>
        /// 559.n叉树的最大深度 使用层序遍历最方便
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            if (root == null) return 0;

            int depth = 0;
            nodes.Enqueue(root);
            while (nodes.Count != 0)
            {
                depth++;
                int count = nodes.Count;
                while (count > 0)//处理每一层级
                {
                    Node node = nodes.Dequeue();
                    count--;
                    for (int i = 0; i < node.children.Count; i++)
                    {
                        nodes.Enqueue(node.children[i]);
                    }
                }
            }
            return depth;
        }

        /// <summary>
        /// 222.完全二叉树的节点个数
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodes(TreeNode root)
        {
            Queue<TreeNode> treeNodes = new Queue<TreeNode>();
            if (root == null) return 0;
            int sum = 0;
            treeNodes.Enqueue(root);
            while (treeNodes.Count != 0)
            {
                int count = treeNodes.Count;
                sum += count;
                while (count > 0)//处理每一层级
                {
                    TreeNode node = treeNodes.Dequeue();
                    count--;
                    if (node.left != null) treeNodes.Enqueue(node.left);
                    if (node.right != null) treeNodes.Enqueue(node.right);
                }
            }
            return sum;
        }

        //了解求二叉树深度 和 二叉树高度的差异
        //求深度适合用前序遍历，而求高度适合用后序遍历。
        /// <summary>
        /// 110.平衡二叉树 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            return CheckBalance(root) != -1;
        }
        //递归自下而上求解
        private int CheckBalance(TreeNode node)
        {
            if (node == null)
                return 0;

            //左子树
            int leftHeight = CheckBalance(node.left);
            if (leftHeight == -1)
                return -1;
            //右子树
            int rightHeight = CheckBalance(node.right);
            if (rightHeight == -1)
                return -1;

            // 如果当前节点不平衡，返回-1
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1;

            // 否则 返回当前节点的深度
            return Math.Max(leftHeight, rightHeight) + 1;// +1包含自身
        }

        /// <summary>
        /// 257. 二叉树的所有路径
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> result = new List<string>();
            Dfs(root, "", result);
            return result;
        }
        public void Dfs(TreeNode node, string path, List<string> res)
        {
            if (node != null)
            {
                StringBuilder sb = new StringBuilder(path);
                sb.Append(node.val.ToString());
                //当前点为叶子节点
                if (node.left == null && node.right == null)
                {
                    res.Add(sb.ToString());
                }
                else//当前节点不是叶子节点
                {
                    sb.Append("->");
                    Dfs(node.left, sb.ToString(), res);
                    Dfs(node.right, sb.ToString(), res);
                }
            }
        }

        /// <summary>
        /// 404.左叶子之和
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumOfLeftLeaves(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            int sum = 0;
            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                //判断是否为左叶子节点
                if (node.left != null && node.left.left == null && node.left.right == null)
                {
                    sum += node.left.val;
                }
                if (node.right != null) stack.Push(node.right);
                if (node.left != null) stack.Push(node.left);
            }
            return sum;
        }

        /// <summary>
        /// 513.找树左下角的值
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int result = int.MinValue;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                //层序遍历 第一个即为最左边的值 最后一轮时为最左最底层的值。
                result = queue.Peek().val;
                while (count > 0)
                {
                    TreeNode node = queue.Dequeue();
                    count--;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            return result;
        }

        /// <summary>
        /// 112. 路径总和
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            //求所有路径的更改版本
            return DFS(root, 0, targetSum) != -1;
        }
        public int DFS(TreeNode node, int cur, int targetSum)
        {
            if (node != null)
            {
                cur += node.val;
                //当前点为叶子节点
                if (node.left == null && node.right == null)
                {
                    if (cur == targetSum)
                        return 0;
                }
                else//当前节点不是叶子节点
                {
                    int leftResult = DFS(node.left, cur, targetSum);
                    if (leftResult == 0) return 0; // 若左子树找到目标值，直接返回
                    int rightResult = DFS(node.right, cur, targetSum);
                    if (rightResult == 0) return 0; // 若右子树找到目标值，直接返回
                }
            }
            return -1;
        }
        //做减法的递归
        public bool HasPathSum1(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            if (root.left == null && root.right == null)
            {
                return targetSum - root.val == 0;
            }
            //用减法判断 左右子树有任意一颗找到==0 的返回true。
            return HasPathSum1(root.left, targetSum - root.val) || HasPathSum1(root.right, targetSum - root.val);
        }
        /// <summary>
        /// 113.路径总和Ⅱ
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> path = new List<int>();
            FindPaths(root, targetSum, path, result);
            return result;
        }
        private void FindPaths(TreeNode node, int targetSum, List<int> path, List<IList<int>> result)
        {
            if (node == null) return;

            // 将当前节点的值添加到路径
            path.Add(node.val);

            // 如果是叶子节点并且路径和等于目标和，将路径添加到结果列表
            if (node.left == null && node.right == null && targetSum - node.val == 0)
            {
                result.Add(new List<int>(path));
            }
            else
            {
                // 否则，递归地在左右子树中查找路径
                FindPaths(node.left, targetSum - node.val, path, result);
                FindPaths(node.right, targetSum - node.val, path, result);
            }

            // 在返回之前，从路径中移除当前节点的值
            path.RemoveAt(path.Count - 1);
        }

        //暂停 
        /// <summary>
        /// 06.从中序与后序遍历序列构造二叉树
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            TreeNode node = new TreeNode();
            return node;
        }


        #endregion


        #region

        /// <summary>
        /// 77.组合
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        //public IList<IList<int>> Combine(int n, int k)
        //{


        //}



        #endregion




    }
}
