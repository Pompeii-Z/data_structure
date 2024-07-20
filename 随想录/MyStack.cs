using System.Collections;

namespace Up
{
    /**
     * 225. 用队列实现栈
     * 单队列，在入队时把元素从头再加入到队尾。就可以让队尾变成栈顶
     *  
    */
    internal class MyStack
    {
        Queue queue;

        public MyStack()
        {
            queue = new Queue();
        }

        public void Push(int x)
        {
            queue.Enqueue(x);

            for (int index = 0; index < queue.Count - 1; index++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        public int Pop()
        {
            return (int)queue.Dequeue();
        }

        public int Top()
        {
            return (int)queue.Peek();
        }

        public bool Empty()
        {
            return queue.Count == 0;
        }


        public void Traverse()
        {
            foreach (var item in queue)
            {
                System.Console.WriteLine(item);
            }
        }

    }
}
