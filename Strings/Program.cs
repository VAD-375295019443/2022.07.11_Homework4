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
                string strText = "2.6 Мама ела, кашу... Папа т.п. 2.5 ел мед! 568...";

                    
                    
                //File.ReadAllText(strPath); //Читаем данные из файла в переменную.
                //Console.WriteLine(strText.Length);




                string text = strText;
                //"It real sent your at. Amounted all shy set why followed declared? Repeated of endeavor mr position kindness offering ignorant so up. Simplicity are melancholy preference considered saw companions. Disposal on outweigh do speedily in on. Him ham although thoughts entirely drawings. Acceptance unreserved old admiration projection nay yet him. Lasted am so before on esteem vanity oh."; //текст на разбор
                //string pattern = @"[^.?!]{31,}(?=[.?!])"; //шаблон регулярного выражения


                string pattern = @"((\.\.\.)|[0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s]])((т.п.|т.д.|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\.\.|[\.\!\?])";


                //@"[^\s]((т.п.|т.д.|[0-9]{1,}.[0-9]{1,})|[^.!?])*((\.\.\.)|[.!?])";

                //+++++    @"[^\s][0-9а-яА-Я\s,:;]((т.п.|т.д.)|[^.!?])*[\.!?]";\s,:;

                //@"[A-Z|А-Я|0-9|a-z|а-я].*[^?!.][.!?]";
                //@"[A-Z|А-Я|0-9]((т.п.|т.д.|пр.)|[^?!.]|\([^\)]*\))*[.?!]";

                //@"^[A-Z|А-Я|0-9][.?!]$";


                //@"[A-Z|А-Я|0-9] ((т.п.|т.д.|пр.) | [^?!.\(] | \([^\)]*\))*      [.?!]";



                MatchCollection mc = Regex.Matches(text, pattern, RegexOptions.Multiline);

                Console.WriteLine($"ВСЕГО {mc.Count}");

                for (int i = 0; i <= mc.Count - 1; i++)
                {
                    Console.WriteLine(mc[i].Value);


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