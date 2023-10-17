using System.Collections;

namespace Up
{
    /**
     * 232. 用栈实现队列
     * 需要两个栈。一个输入栈一个输出栈。输入栈负责接收，每次Pop时需要把输入栈所有元素先输入到输出栈中在输出。Peek同理。
     *  
    */

    internal class MyQueue
    {
        Stack stackIn;
        Stack stackOut;

        public MyQueue()
        {
            stackIn = new Stack();
            stackOut = new Stack();
        }

        public void Push(int x)
        {
            stackIn.Push(x);
        }

        public int Pop()
        {
            JoinStackIn();
            return (int)stackOut.Pop();
        }

        public int Peek()
        {
            JoinStackIn();
            return (int)stackOut.Peek();
        }

        public bool Empty()
        {
            if (stackIn.Count == 0 && stackOut.Count == 0)
            {
                return true;
            }
            return false;
        }

        private void JoinStackIn()
        {
            if (stackOut.Count != 0)
                return;
            while (stackIn.Count != 0)
            {
                stackOut.Push(stackIn.Pop());
            }
        }
    }
}
