using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Strings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string f_strText = "Gjkl ljlj, h kjkjkjj. Hjkhds f  jjl lj ;; k sk? sfsdf, fdjfjh";



            //string strPattern = @"((\.\.\.)|[0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s]])((Sr.|Jr.|Mrs.|Mr.|Dr.|.exe|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\""|\!\""|\?\""|\.\.\.\'|\.\'|\!\'|\?\'|\.\.\.|[\.\!\?])?"; //Regex предложений.
            string strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])?"; //Regex слов.
            MatchCollection matchWord = Regex.Matches(f_strText, strPattern); //Коллекция слов.

            for(int int1=0; int1 <= matchWord.Count-1; int1++)
            {
                Console.WriteLine(matchWord[int1].Value);

            }



        }
    }
}
