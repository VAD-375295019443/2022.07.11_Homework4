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
        public int intWordCount = 0; //Количество таких слов в тексте.

        public claWord(string strWord)
        {
            this.strWord = strWord;
        }
    }
}
