using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class claPunctuationMark
    {
        public string strPunctuationMark; //Знак препинания.
        public int intPunctuationMarkCount = 0; //Количество таких знаков препинания в тексте.

        public claPunctuationMark(string stPunctuationMark)
        {
            this.strPunctuationMark = strPunctuationMark;
        }
    }
}
