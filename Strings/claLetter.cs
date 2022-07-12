using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class claLetter
    {
        public string strLetter; //Буква.
        public int intLetterCount; //Количество таких букв в тексте.

        public claLetter(string strLetter, int intLetterCount)
        {
            this.strLetter = strLetter; //Буква.
            this.intLetterCount = intLetterCount; //Количество таких букв в тексте.
        }
    }
}
