using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Data_Structures.DataStructures.Stack.Problems
{
    public class ExpressionEvaluation
    {
        private char[] Operators = {'*', '/', '+', '-', '*', '(', ')'};

        public void Evaluation(string expression)
        {
            string postFixEx = ConvertToPostfix(expression);
            StackWithLinkedList<double> stack = new StackWithLinkedList<double>();

            foreach (var item in postFixEx)
            {
                if (!Operators.Contains(item))
                {
                    double val = double.Parse(item.ToString());
                    stack.push(val);
                }

                else
                {
                    double lastNumber = Convert.ToDouble(stack.getTop());
                    stack.pop();

                    double firstNumber = Convert.ToDouble(stack.getTop());
                    stack.pop();

                    double result = 0.0;

                    switch (item)
                    {
                        case '*':
                            result = firstNumber * lastNumber;
                            break;

                        case '/':
                            result = firstNumber / lastNumber;
                            break;

                        case '+':
                            result = firstNumber + lastNumber;
                            break;

                        case '-':
                            result = firstNumber - lastNumber;
                            break;
                    }

                    stack.push(result);
                }
            }

            Console.WriteLine(stack.getTop());
        }

        private string ConvertToPostfix(string expression)
        {
            StackWithLinkedList<char> stack = new StackWithLinkedList<char>(); 
            List<char> result = new List<char>();

            foreach(var item in expression.ToArray())
            {
                if (!Operators.Contains(item) && item != ' ')
                    result.Add(item);
                
                else if (item != ' ')
                {
                    if (stack.isEmpty())
                        stack.push(item);
                    else
                    {
                        if (ss(item, stack.getTop()))
                            stack.push(item);
                        else if (item == ')')
                        {
                            while (stack.getTop() != '(')
                            {
                                if (stack.getTop() != ')')
                                    result.Add(stack.getTop());
                                
                                stack.pop();
                            }

                            stack.pop();
                        }
                        else if (stack.getTop() == '(')
                        {
                            stack.push(item);
                        }
                        else
                        {
                            result.Add(stack.getTop());
                            stack.pop();
                            stack.push(item);
                        }
                    }

                }
            }

            while(!stack.isEmpty())
            {
                result.Add(stack.getTop());
                stack.pop();
            }

            return new string(result.ToArray());
        }

        private bool ss(char x, char stackTop)
        {
            if (x == '*' || x == '/' && stackTop == '+' || stackTop == '-' || x == '(')
                return true;
            else if (x == '(')
                return true;
            else
                return false;
        }
    }
}