using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class claWord
    {
        public string strWord; //Слово.
        public int intCountWordInText; //Количество таких слов в тексте.

        public claWord(string strWord, int intCountWordInText)
        {
            this.strWord = strWord; //Слово.
            this.intCountWordInText = intCountWordInText; //Количество таких слов в тексте.
        }
    }
}
