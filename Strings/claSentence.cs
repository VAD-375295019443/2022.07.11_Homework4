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
        public List<string> strWordList = new List<string>(); //Коллекция слов.
        public List<string> strPunctuationMarkList = new List<string>(); //Коллекция символов.

        public claSentence(string strName)
        {
            this.strSentence = strName;
        }
    }
}
