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
        public int intCountLetterInText; //Количество таких букв в тексте.

        public claLetter(string strLetter, int intCountLetterInText)
        {
            this.strLetter = strLetter; //Буква.
            this.intCountLetterInText = intCountLetterInText; //Количество таких букв в тексте.
        }
    }
}
