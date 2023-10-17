using System.Collections.Generic;

namespace Up
{
    //239. 滑动窗口最大值
    internal class myDequeue
    {
        //单调递减队列
        private LinkedList<int> linkedList = new LinkedList<int>();

        //
        public void Enqueue(int n)
        {
            while (linkedList.Count > 0 && linkedList.Last.Value < n)
            {
                linkedList.RemoveLast();
            }
            linkedList.AddLast(n);
        }

        //第一个即为最大值
        public int Max()
        {
            return linkedList.First.Value;
        }

        public void Dequeue(int n)
        {
            if (linkedList.First.Value == n)
            {
                linkedList.RemoveFirst();
            }
        }
    }
}
