using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class Sentence
    {
        public string Sentence; //Предложение.
        public int CountSentenceInText; //Количество таких предложений в тексте.
        public int CountWordInSentence; //Количество слов в предложениии.
        public int CountCharactersInSentence; //Количество символов в предложениии.




        public Sentence(string Sentence, int CountSentenceInText, int CountWordInSentence, int CountCharactersInSentence)
        {
            this.Sentence = Sentence; //Предложение.
            this.CountSentenceInText = CountSentenceInText; //Количество таких предложений в тексте.
            this.CountWordInSentence = CountWordInSentence; //Количество слов в предложениии.
            this.CountCharactersInSentence = CountCharactersInSentence; //Количество символов в предложениии.
        }
    }
}
