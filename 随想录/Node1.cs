namespace Up
{
    //116.填充每个节点的下一个右侧节点指针  默认函数定义
    //117.填充每个节点的下一个右侧节点指针II
    internal class Node1
    {
        public int val;
        public Node1 left;
        public Node1 right;
        public Node1 next;

        public Node1() { }

        public Node1(int _val)
        {
            val = _val;
        }

        public Node1(int _val, Node1 _left, Node1 _right, Node1 _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
