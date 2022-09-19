using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    public class ParenthesesService : IParenthesesService
    {
        public ParenthesesService() { }
        public bool checkParaentheses(string input)
        {
            if (input == null) {
                return false;
            }

            var paraCount = 0;
            var charInputArr = input.ToCharArray();

            foreach (char c in charInputArr) {
                switch (c) 
                {
                    case ')':
                        paraCount--;
                        break;
                    case '(':
                        paraCount++;
                        break;
                    default:
                        break;
                }
                if (paraCount < 0) 
                {
                    return false;
                }
            }
            return paraCount == 0;

        }
    }
}
