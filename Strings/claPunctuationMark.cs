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
        public int intPunctuationMarkCount; //Количество таких знаков препинания в тексте.

        public claPunctuationMark(string strPunctuationMark, int intPunctuationMarkCount)
        {
            this.strPunctuationMark = strPunctuationMark; //Знак препинания.
            this.intPunctuationMarkCount = intPunctuationMarkCount; //Количество таких знаков препинания в тексте.
        }
    }
}
