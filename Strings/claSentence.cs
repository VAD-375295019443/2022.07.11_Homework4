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
        public int intSentenceCount = 0; //Количество таких предложений в тексте.
        public int intSentenceWordCount = 0; //Количество слов в предложениии.
        public int intSentenceLetterCount = 0; //Количество букв в предложениии.
        public int intSentencePunctuationMarkCount = 0; //Количество знаков препинания в предложениии.
        public int intSentenceCharactersCount = 0; //Количество символов в предложениии.

        public claSentence(string strSentence)
        {
            this.strSentence = strSentence; //Предложение.
        }
    }
}
