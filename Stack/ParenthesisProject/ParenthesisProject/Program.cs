using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParenthesisProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression;
            Console.Write("Enter an expression with parenthesis: ");
            expression = Console.ReadLine();

            if(IsValid(expression))
                Console.WriteLine("Valid Expression");
            else
                Console.WriteLine("Invalid Expression");

            Console.ReadLine();
        }

        private static bool IsValid(string expression)
        {
            Stack<char> st = new Stack<char>();
            //bool isValid = false;
            for(int i=0;i<expression.Length;i++)
            {
                if(expression[i]=='(' || expression[i]=='{' || expression[i]=='[')
                {
                    st.Push(expression[i]);
                }
                if(expression[i]==')'||expression[i]=='}'||expression[i]==']')
                {
                    if(st.Count()==0)
                    {
                        Console.WriteLine("Right Paranthesis more than left paranthesis");
                        return false;
                    }
                    else
                    {
                        char ch= st.Pop();
                        if(!MatchParenthesis(ch,expression[i]))
                        {
                            Console.WriteLine("Mismatched paranthesis");
                            Console.WriteLine($"Mismatched parenthesis are {ch} and {expression[i]}");
                            return false;
                        }
                        
                    }
                }
            }
            if(st.Count==0)
            {
                Console.WriteLine("Balanced Parenthesis");
                return true;
            }
            else
            {
                Console.WriteLine("Left paranthesis more than right paranthesis");
                return false;
            }


        }

        private static bool MatchParenthesis(char leftPar, char rightPar)
        {
            if (leftPar == '[' && rightPar == ']')
                return true;
            if (leftPar == '{' && rightPar == '}')
                return true;
            if (leftPar == '(' && rightPar == ')')
                return true;
            return false;
        }
    }
}
