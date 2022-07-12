using System;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.ComponentModel;

namespace Strings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> listSentence = new List<string>() { };

            var listSentence = strMatchCollection.ToList(); //Копируем коллекцию предложений в лист предложений (для универсальности).
            Console.WriteLine("Распарсили на предложения");

            //Сортируем предложения.
            var listSentenceSort = listSentence.OrderBy(x => x.Value).ToList();

            //Убираем дубликаты предложения.
            var listSentenceNoDuplicates = listSentenceSort.Distinct().ToList();

            //Количество каждого предложения в тесте.
            List<int> listSentenceCountInText = new List<int>(listSentenceNoDuplicates.Count);
            Console.WriteLine($"Предложений {listSentenceSort.Count}");
            Console.WriteLine($"Предложений {listSentenceNoDuplicates.Count}");

            for (int int1 = 0; int1 <= listSentenceNoDuplicates.Count - 1; int1++)
            {
                listSentenceCountInText.Add(listSentenceSort.Count(x => x.Value == listSentenceNoDuplicates[int1].Value));
            }







            /*
            
            //string[] sArr1 = { "First ", "Second ", "Third " };

            List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };
            Console.WriteLine(string.Join(" ", ages));



            /*
            List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };


            var distinctAges = ages.Distinct().ToList();

            Console.WriteLine($"gggggggg {distinctAges.Count}");

            int z = 55;
            int numberUnvaccinated = ages.Count(x => x == z);

            Console.WriteLine($"ssssssssss {numberUnvaccinated}");
            */















        }

        /*
        //Парсинг текста на слова.
        strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])";
        strMatchCollection = Regex.Matches(strText, strPattern); //Создаем коллекцию слов.

        if (strMatchCollection.Count > 0)
        {
            for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
            {
                listWord.Add(new claWord(strMatchCollection[int1].Value)); //Заполняем лист слов.
            }
        }
        Console.WriteLine("Слова");


        //Парсинг текста на буквы.
        strPattern = @"[\w-[\d]]";
        strMatchCollection = Regex.Matches(strText, strPattern); //Создаем коллекцию букв.

        if (strMatchCollection.Count > 0)
        {
            for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
            {
                listLetter.Add(new claLetter(strMatchCollection[int1].Value)); //Заполняем лист букв.
            }
        }
        Console.WriteLine("Буквы");


        //Парсинг текста на знаки препинания.
        strPattern = @"(\.\.\.)|[\?\!\.\""\'\,\:\;]";
        strMatchCollection = Regex.Matches(strText, strPattern); //Создаем коллекцию знаков препинания.

        if (strMatchCollection.Count > 0)
        {
            for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
            {
                listPunctuationMark.Add(new claPunctuationMark(strMatchCollection[int1].Value)); //Заполняем лист знаков препинания.
            }
        }
        Console.WriteLine("Знаки");
        */














        /*
        string strSentencePath = @"d:\Sentence.txt";

        if(strSentenceCollection.Count>0)
        {
            for (int int1=0; int1<=strSentenceCollection.Count-1; int1++)
            {
                if(int1==0)
                {
                    File.WriteAllText(strSentencePath, strSentenceCollection[int1].Value);
                }
                else
                {
                    File.AppendAllText(strSentencePath, "\n" + strSentenceCollection[int1].Value);
                }
            }
        }
        */










        //File.Delete(strSentencePath);



        //var varSorting = strSentenceCollection.OrderBy(x => x.Value).ToList();






        /*
        string x = strText;

        for (int i = 0; i <= strSentenceCollection.Count-1; i++)
        {
            //Console.WriteLine(strSentenceCollection[i].Value);


            x = x.Remove(x.IndexOf(strSentenceCollection[i].Value), strSentenceCollection[i].Value.Length);


            //x = x.Replace(strMatchCollection[i].Value, "");

        }

        Console.WriteLine(x);
        */


    }
}