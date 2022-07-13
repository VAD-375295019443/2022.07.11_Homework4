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
        public int intCountPunctuationMarkInText; //Количество таких знаков препинания в тексте.

        public claPunctuationMark(string strPunctuationMark, int intCountPunctuationMarkInText)
        {
            this.strPunctuationMark = strPunctuationMark; //Знак препинания.
            this.intCountPunctuationMarkInText = intCountPunctuationMarkInText; //Количество таких знаков препинания в тексте.
        }
    }
}
