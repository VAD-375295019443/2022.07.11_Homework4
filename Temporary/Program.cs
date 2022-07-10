using System;
using System.Text.RegularExpressions;

namespace Strings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string x = "...fghfh jgj, bjkhkh%66) hhhj?";

            //string strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])";
            string strPattern = @"(\.\.\.)|[\?\!\.\""\'\,\:\;]";
            MatchCollection strMatchCollection = Regex.Matches(x, strPattern); //Создаем коллекцию предложений.


            /*
            var z = x.Split(" ");
            */



            for(int i = 0; i < strMatchCollection.Count; i++)
            {
                Console.WriteLine(strMatchCollection[i]);
            }
            



        }
    }
}