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
        public int intSentenceCharactersCount; //Количество символов в предложениии.
        public int intSentenceWordCount; //Количество слов в предложениии.

        public claSentence(string strSentence, int intSentenceCharactersCount, int intSentenceWordCount)
        {
            this.strSentence = strSentence; //Предложение.
            this.intSentenceCharactersCount = intSentenceCharactersCount; //Количество символов в предложениии.
            this.intSentenceWordCount = intSentenceWordCount; //Количество слов в предложениии.
        }
    }
}
