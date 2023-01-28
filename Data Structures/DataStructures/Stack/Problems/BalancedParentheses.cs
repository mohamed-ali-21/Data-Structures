using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Structures.DataStructures;

namespace Data_Structures.SolveProblems
{
    public class BalancedParentheses
    {
        public bool IsBalanced(string str)
        {
            StackWithArray<char> s = new StackWithArray<char>(100);

            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{' || str[i] == '(' || str[i] == '[')
                    s.Push(str[i]);
                else if (str[i] == '}' || str[i] == ')' || str[i] == ']')
                {
                    if(s.IsEmpty() || !IsPair(s.GetTop(), str[i]))
                        return false;

                    s.Pop();
                }
            }

            return s.IsEmpty();
        }

        private bool IsPair(char open, char close)
        {
            if (open == '{' && close == '}')
                return true;

            if (open == '(' && close == ')')
                return true;    

            if (open == '[' && close == ']')
                return true;

            return false;
        }
    }
}