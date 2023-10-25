using System;
using System.Collections.Generic;

namespace S
{
    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(val);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
    ///115.最小栈
    public class MinStack
    {
        Stack<int> stack;
        Stack<int> minStack;
        int min;
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
            min = int.MaxValue;
        }

        public void Push(int val)
        {
            stack.Push(val);
            if (minStack.Count > 0)
            {
                minStack.Push(Math.Min(val, minStack.Peek()));
            }
            else
            {
                minStack.Push(val);
            }
        }

        public void Pop()
        {
            minStack.Pop();
            stack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}
