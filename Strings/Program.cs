using System;
using System.Text.RegularExpressions;

namespace Strings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string strPath = @"d:\sample.txt";

            if (File.Exists(strPath) == true) //Если файл существует.
            {
                string strText =  File.ReadAllText(strPath); //Читаем данные из файла в переменную.

                string strPattern = @"((\.\.\.)|[0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s]])((т.п.|т.д.|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\""|\!\""|\?\""|\.\.\.\'|\.\'|\!\'|\?\'|\.\.\.|[\.\!\?])";

                MatchCollection strMatchCollection = Regex.Matches(strText, strPattern, RegexOptions.Multiline);

                for (int i = 0; i <= 300; i++)
                {
                    Console.WriteLine(strMatchCollection[i].Value);


                    
                    
                    
                    //Console.WriteLine("{0} => {1}", mc[i].Groups[0].Value.Length, mc[i].Groups[0].Value);
                }
                //Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Запрашиваемый файл отсутствует.");
            }
        }
    }
}