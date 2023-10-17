using System;

namespace down
{
    //707.设计链表https://leetcode.cn/problems/design-linked-list/description/

    /// <summary>
    /// 单链表定义
    /// </summary>
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

    internal class MyLinkedList
    {
        //个数
        public int size;
        //虚拟头节点
        ListNode head;
        //初始化链表
        public MyLinkedList()
        {
            size = 0;
            head = new ListNode(0);
        }

        #region 随想录写法
        ////获取第index个节点的数值，注意index是从0开始的，第0个节点就是头结点
        //public int Get(int index)
        //{
        //    //如果index非法，返回-1
        //    if (index < 0 || index >= size)
        //    {
        //        return -1;
        //    }
        //    ListNode currentNode = head;
        //    //包含一个虚拟头节点，所以查找第 index+1 个节点
        //    for (int i = 0; i <= index; i++)
        //    {
        //        currentNode = currentNode.next;
        //    }
        //    return currentNode.val;
        //}

        ////在链表最前面插入一个节点，等价于在第0个元素前添加
        //public void AddAtHead(int val)
        //{
        //    AddAtIndex(0, val);
        //}

        ////在链表的最后插入一个节点，等价于在(末尾+1)个元素前添加
        //public void AddAtTail(int val)
        //{
        //    AddAtIndex(size, val);
        //}

        //// 在第 index 个节点之前插入一个新节点，例如index为0，那么新插入的节点为链表的新头节点。
        //// 如果 index 等于链表的长度，则说明是新插入的节点为链表的尾结点
        //// 如果 index 大于链表的长度，则返回空
        //public void AddAtIndex(int index, int val)
        //{
        //    if (index > size)
        //    {
        //        return;
        //    }
        //    if (index < 0)
        //    {
        //        index = 0;
        //    }
        //    size++;
        //    //找到要插入节点的前驱
        //    ListNode pred = head;
        //    for (int i = 0; i < index; i++)
        //    {
        //        pred = pred.next;
        //    }
        //    ListNode toAdd = new ListNode(val);
        //    toAdd.next = pred.next;
        //    pred.next = toAdd;
        //}

        ////删除第index个节点
        //public void DeleteAtIndex(int index)
        //{
        //    if (index < 0 || index >= size)
        //    {
        //        return;
        //    }
        //    size--;
        //    if (index == 0)
        //    {
        //        head = head.next;
        //        return;
        //    }
        //    ListNode pred = head;
        //    for (int i = 0; i < index; i++)
        //    {
        //        pred = pred.next;
        //    }
        //    pred.next = pred.next.next;
        //}

        //public void Traverse()
        //{
        //    ListNode currentNode = head.next; // 跳过虚拟头节点，从第一个实际节点开始

        //    while (currentNode != null)
        //    {
        //        Console.WriteLine("值：" + currentNode.val + "!"); // 打印当前节点的值
        //        currentNode = currentNode.next; // 移动到下一个节点
        //    }
        //    Console.WriteLine("长度：" + size);
        //}
        #endregion

        //下标从0开始，获取该索引对应的节点的值
        public int Get(int index)
        {
            int value = -1;
            if (index >= size || index < 0)
            {
                return value;
            }

            ListNode temp;
            temp = head.next;
            for (int i = 0; i <= index; i++)
            {
                value = temp.val;
                temp = temp.next;
            }
            return value;
        }

        //将值为val的节点插入到第一个节点之前，该节点成为第一个节点。
        public void AddAtHead(int val)
        {
            ListNode newHead = new ListNode(val, null)
            {
                next = head.next
            };
            head.next = newHead;
            size++;
        }

        //将值为val的节点插入到末尾
        public void AddAtTail(int val)
        {
            ListNode newHead = new ListNode(val, null);

            ListNode temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newHead;
            size++;
        }

        //将值为val的节点插入至下标为index的节点之前，如果index == 链表长度则追加至末尾，如果index>链表长度那么该节点不会插入。
        public void AddAtIndex(int index, int val)
        {
            if (index > size || index < 0)
            {
                return;
            }

            if (index == size)
            {
                AddAtTail(val);
                return;
            }

            ListNode newHead = new ListNode(val, null);

            ListNode temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }
            newHead.next = temp.next;
            temp.next = newHead;
            size++;

        }

        //下标有效则删除目标节点
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index > size - 1)
            {
                return;
            }

            if (index == 0)
            {
                head.next = head.next.next;
                size--;
                return;
            }

            ListNode temp;
            temp = head.next;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.next;
            }
            temp.next = temp.next.next;
            size--;

        }

        /// <summary>
        /// 遍历 测试方法
        /// </summary>
        public void Traverse()
        {
            ListNode currentNode = head.next; // 跳过虚拟头节点，从第一个实际节点开始

            while (currentNode != null)
            {
                Console.WriteLine("值：" + currentNode.val + "!"); // 打印当前节点的值
                currentNode = currentNode.next; // 移动到下一个节点
            }
            Console.WriteLine("长度：" + size);
        }

    }
}

