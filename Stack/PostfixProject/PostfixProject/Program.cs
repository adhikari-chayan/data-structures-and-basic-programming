using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string infix;
            Console.Write("Enter infix expression: ");
            infix = Console.ReadLine();

            string postfix = InfixToPostfix(infix);
            string prefix = InfixToPrefix(infix);
            Console.WriteLine($"Postfix expression is {postfix}");
            Console.WriteLine($"Postfix expression is {prefix}");
            // Console.WriteLine($"Value of expression is {EvaluateExpression(postfix)}");

            Console.ReadKey();
        }

        private static int EvaluateExpression(string postfix)
        {
            Stack<int> st = new Stack<int>();
            int x, y;
            for(int i=0;i<postfix.Length;i++)
            {
                if (Char.IsDigit(postfix[i]))
                    st.Push(Convert.ToInt32(Char.GetNumericValue(postfix[i])));

                else
                {
                    x = st.Pop();
                    y = st.Pop();
                    switch(postfix[i])
                    {
                        case '+':
                            st.Push(y + x);
                            break;
                        case '-':
                            st.Push(y - x);
                            break;
                        case '*':
                            st.Push(y * x);
                            break;
                        case '/':
                            st.Push(y / x);
                            break;
                        case '%':
                            st.Push(y % x);
                            break;
                        case '^':
                            st.Push(Convert.ToInt32(Math.Pow(y, x)));
                            break;
                    }
                }
            }
            return st.Pop();
        }

        private static string InfixToPostfix(string infix)
        {
            string postfix = "";
            Stack<char> st = new Stack<char>();

            char next, symbol;

            for(int i=0;i<infix.Length;i++)
            {
                symbol = infix[i];
                if (symbol == ' ' || symbol == '\t')
                    continue;

                switch(symbol)
                {
                    case '(':
                        st.Push(symbol);
                        break;

                    case ')':
                        while ((next = st.Pop()) != '(')
                            postfix = postfix + next;
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '%':
                    case '^':
                        while (st.Count() > 0 && Precedence(st.Peek()) >= Precedence(symbol))
                            postfix = postfix + st.Pop();
                        st.Push(symbol);
                        break;
                    default://operand
                        postfix = postfix + symbol;
                        break;
                }
            }

            while(st.Count != 0)
            {
                postfix = postfix + st.Pop();
            }
            return postfix;

        }

        private static string InfixToPrefix(string infix)
        {
            // stack for operators.  
            Stack<char> operators = new Stack<char>();

            // stack for operands.  
            Stack<String> operands = new Stack<String>();

            for (int i = 0; i < infix.Length; i++)
            {

                // If current character is an  
                // opening bracket, then  
                // push into the operators stack.  
                if (infix[i] == '(')
                {
                    operators.Push(infix[i]);
                }

                // If current character is a  
                // closing bracket, then pop from  
                // both stacks and push result  
                // in operands stack until  
                // matching opening bracket is  
                // not found.  
                else if (infix[i] == ')')
                {
                    while (operators.Count != 0 &&
                        operators.Peek() != '(')
                    {

                        // operand 1  
                        String op1 = operands.Peek();
                        operands.Pop();

                        // operand 2  
                        String op2 = operands.Peek();
                        operands.Pop();

                        // operator  
                        char op = operators.Peek();
                        operators.Pop();

                        // Add operands and operator  
                        // in form operator +  
                        // operand1 + operand2.  
                        String tmp = op + op2 + op1;
                        operands.Push(tmp);
                    }

                    // Pop opening bracket  
                    // from stack.  
                    operators.Pop();
                }

                // If current character is an  
                // operand then push it into  
                // operands stack.  
                else if (!isOperator(infix[i]))
                {
                    operands.Push(infix[i] + "");
                }

                // If current character is an  
                // operator, then push it into  
                // operators stack after popping  
                // high priority operators from  
                // operators stack and pushing  
                // result in operands stack.  
                else
                {
                    while (operators.Count != 0 &&
                        getPriority(infix[i]) <=
                            getPriority(operators.Peek()))
                    {

                        String op1 = operands.Peek();
                        operands.Pop();

                        String op2 = operands.Peek();
                        operands.Pop();

                        char op = operators.Peek();
                        operators.Pop();

                        String tmp = op + op2 + op1;
                        operands.Push(tmp);
                    }

                    operators.Push(infix[i]);
                }
            }

            // Pop operators from operators  
            // stack until it is empty and  
            // operation in add result of  
            // each pop operands stack.  
            while (operators.Count != 0)
            {
                String op1 = operands.Peek();
                operands.Pop();

                String op2 = operands.Peek();
                operands.Pop();

                char op = operators.Peek();
                operators.Pop();

                String tmp = op + op2 + op1;
                operands.Push(tmp);
            }

            // Final prefix expression is  
            // present in operands stack.  
            return operands.Peek();

        }

        private static int Precedence(char symbol)
        {
            switch(symbol)
            {
                case '(':
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                case '%':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 0;
            }
            
        }

        private static bool isOperator(char c)
        {
            return (!(c >= 'a' && c <= 'z') &&
                    !(c >= '0' && c <= '9') &&
                    !(c >= 'A' && c <= 'Z'));
        }

        // Function to find priority  
        // of given operator.  
       private static int getPriority(char C)
        {
            if (C == '-' || C == '+')
                return 1;
            else if (C == '*' || C == '/')
                return 2;
            else if (C == '^')
                return 3;
            return 0;
        }
    }
}
