using System;
using System.Collections.Generic;

namespace 逆波兰表达式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string infixExpression = "A+B*(C-D)/E";
            string postfixExpression = Convert(infixExpression);

            Console.WriteLine("中缀表达式：{0}", infixExpression);
            Console.WriteLine("后缀表达式：{0}", postfixExpression);
        }

        public static string Convert(string infixExpression)
        {
            // 定义运算符栈
            Stack<char> operatorStack = new Stack<char>();

            // 定义输出队列
            Queue<char> outputQueue = new Queue<char>();

            // 遍历中缀表达式
            foreach (char c in infixExpression)
            {
                // 判断是否是操作数
                if (IsOperand(c))
                {
                    // 将操作数加入输出队列
                    outputQueue.Enqueue(c);
                }
                else if (IsOperator(c))
                {
                    // 判断运算符的优先级
                    while (operatorStack.Count > 0 && HasHigherPrecedence(c, operatorStack.Peek()))
                    {
                        // 将优先级更高的运算符弹出并加入输出队列
                        outputQueue.Enqueue(operatorStack.Pop());
                    }

                    // 将当前运算符加入运算符栈
                    operatorStack.Push(c);
                }
                else if (c == '(')
                {
                    // 将左括号加入运算符栈
                    operatorStack.Push(c);
                }
                else if (c == ')')
                {
                    // 将右括号弹出并加入输出队列，直到遇到左括号
                    while (operatorStack.Peek() != '(')
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }

                    // 弹出左括号
                    operatorStack.Pop();
                }
            }

            // 将运算符栈中剩余的运算符弹出并加入输出队列
            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            // 将输出队列中的字符拼接成后缀表达式
            string postfixExpression = "";
            while (outputQueue.Count > 0)
            {
                postfixExpression += outputQueue.Dequeue();
            }

            return postfixExpression;
        }

        private static bool IsOperand(char c)
        {
            return char.IsLetterOrDigit(c);
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }

        private static bool HasHigherPrecedence(char op1, char op2)
        {
            int op1Precedence = GetPrecedence(op1);
            int op2Precedence = GetPrecedence(op2);

            return op1Precedence > op2Precedence;
        }

        private static int GetPrecedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 0;
            }
        }
    }
}
