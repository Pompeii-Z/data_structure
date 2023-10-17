using System.Collections.Generic;

namespace Up
{
    /// <summary>
    /// 429.N叉树的层序遍历 默认函数定义
    /// 589. N叉树的前序遍历
    /// 590. N叉树的后序遍历
    /// </summary>
    internal class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
