using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class claSentence
    {
        public string strSentence; //Предложение.
        public int intCountSentenceInText; //Количество таких предложений в тексте.
        public int intCountWordInSentence; //Количество слов в предложениии.
        public int intCountCharactersInSentence; //Количество символов в предложениии.




        public claSentence(string strSentence, int intCountSentenceInText, int intCountWordInSentence, int intCountCharactersInSentence)
        {
            this.strSentence = strSentence; //Предложение.
            this.intCountSentenceInText = intCountSentenceInText; //Количество таких предложений в тексте.
            this.intCountWordInSentence = intCountWordInSentence; //Количество слов в предложениии.
            this.intCountCharactersInSentence = intCountCharactersInSentence; //Количество символов в предложениии.
        }
    }
}
