using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Strings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string strTextPath = @"d:\sample.txt";

            if (File.Exists(strTextPath) == true) //Если файл существует.
            {
                string strPattern;
                MatchCollection strMatchCollection;

                string strText = File.ReadAllText(strTextPath); //Читаем данные из файла в переменную.
                Console.WriteLine("Прочитали из файла");

                strText = strText.Replace("\n", " "); //Удаляем все ентеры (в тексте вогон не нужных/случайных).
                Console.WriteLine("Удалили энтеры");



                F_voiWord(strText);

                
                
                /*
                //Сортируем предложения.
                var listSentenceSort = listSentence.OrderBy(x => x).ToList();
                Console.WriteLine($"Сортировали {listSentenceSort.Count}");
                */



            }
            else
            {
                Console.WriteLine("Запрашиваемый файл отсутствует.");
            }
        }

        //Парсинг текста на предложения.
        public static void F_voiSentence(ref string f_strText)
        {
            string strPattern; //Паттерн.
            MatchCollection colMatchCollection; //Коллекция слов.
            MatchCollection colMatchCollectionWord; //Коллекция предложений.

            string strSentence; //Предложение.
            int intSentenceCharactersCount; //Количество символов в предложениии.
            int intSentenceWordCount; //Количество слов в предложениии.

            strPattern = @"((\.\.\.)|[0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s]])((Sr.|Jr.|Mrs.|Mr.|Dr.|.exe|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\""|\!\""|\?\""|\.\.\.\'|\.\'|\!\'|\?\'|\.\.\.|[\.\!\?])"; //Regex предложений.
            colMatchCollection = Regex.Matches(f_strText, strPattern); //Коллекция предложений.

            List<string> listMatchCollection = new List<string>(colMatchCollection.Count); //Лист предложений.
            for (int int1 = 0; int1 <= colMatchCollection.Count - 1; int1++)
            {
                listMatchCollection.Add(colMatchCollection[int1].Value); //Заполняем лист предложений.
            }

            var listMatchCollectionDistinct = listMatchCollection.Select(x => x).Distinct().ToList(); //Лист предложений без повторов.

            List<claSentence> listSentenceDistinct = new List<claSentence>(listMatchCollection.Count); //Лист экземпляров предложений без повторов.

            for (int int1 = 0; int1 <= listMatchCollectionDistinct.Count - 1; int1++)
            {
                strSentence = listMatchCollectionDistinct[int1]; //Предложение.
                intSentenceCharactersCount = strSentence.Length; //Количество символов в предложениии.
                colMatchCollectionWord = Regex.Matches(strSentence, strPattern); //Коллекция слов.
                intSentenceWordCount = colMatchCollectionWord.Count; //Количество слов в предложениии.

                listSentenceDistinct.Add(new claSentence(strSentence, intSentenceCharactersCount, intSentenceWordCount));  //Заполняем лист предложений без повторов.
            }

            f_strText = string.Join(" ", colMatchCollection); //После парсинга возвращаем все предложения в strText (чистый текст без оставшейся абры-кадабры после парсинга).
            
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Файлы
        }





        //Парсинг текста на слова.
        public static void F_voiWord(string f_strText)
        {
            string strPattern; //Паттерн.
            MatchCollection colMatchCollection; //Коллекция слов.

            string strWord; //Слово.
            int intWordCount; //Количество таких слов в тексте.

            strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])"; //Regex слов.
            colMatchCollection = Regex.Matches(f_strText, strPattern); //Коллекция слов.
            
            List<string> listMatchCollection = new List<string>(colMatchCollection.Count); //Лист слов.
            for (int int1 = 0; int1 <= colMatchCollection.Count - 1; int1++)
            {
                listMatchCollection.Add(colMatchCollection[int1].Value); //Заполняем лист слов.
            }
            
            var listMatchCollectionDistinct = listMatchCollection.Select(x => x).Distinct().ToList(); //Коллекция слов без повторов.

            List<claWord> listWordDistinct = new List<claWord>(listMatchCollection.Count); //Лист слов без повторов.



            var zzzz = listMatchCollection.OrderBy(x => x).ToList();


            for (int int1 = 0; int1 <= zzzz.Count - 1; int1++)
            {
                




            }







                string strText = string.Join(" ", listMatchCollection); //После парсинга возвращаем все слова в strText.
            strText = " " + f_strText + " ";

            MatchCollection colWord;

            for (int int1 = 0; int1 <= listMatchCollectionDistinct.Count - 1; int1++)
            {
                strWord = listMatchCollectionDistinct[int1]; //Слово.
                Console.WriteLine(strWord);
                strPattern = @" "+ strWord + @" ";
                colWord = Regex.Matches(strText, strPattern); //Коллекция слов.
                
                intWordCount = colWord.Count; //Количество таких слов в тексте.

                listWordDistinct.Add(new claWord(strWord, intWordCount));  //Заполняем лист слов без повторов.
            }

            Console.WriteLine("ok");


            /*
            for (int int1 = 0; int1 <= listMatchCollectionDistinct.Count - 1; int1++)
            {
                strWord = listMatchCollectionDistinct[int1]; //Слово.
                intWordCount = listMatchCollection.RemoveAll(x => x == strWord); //Количество таких слов в тексте.

                listWordDistinct.Add(new claWord(strWord, intWordCount));  //Заполняем лист слов без повторов.
            }
            */
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Файлы
        }





        //Парсинг текста на буквы.
        public static void F_voiLetter(string f_strText)
        {
            string strPattern; //Паттерн.
            MatchCollection colMatchCollection; //Коллекция букв.

            string strLetter; //Буква.
            int intLetterCount; //Количество таких букв в тексте.

            strPattern = @"[\w-[\d]]"; //Regex букв.
            colMatchCollection = Regex.Matches(f_strText, strPattern); //Коллекция букв.

            List<string> listMatchCollection = new List<string>(colMatchCollection.Count); //Лист букв.
            for (int int1 = 0; int1 <= colMatchCollection.Count - 1; int1++)
            {
                listMatchCollection.Add(colMatchCollection[int1].Value); //Заполняем лист букв.
            }

            var listMatchCollectionDistinct = listMatchCollection.Select(x => x).Distinct().ToList(); //Коллекция букв без повторов.

            List<claLetter> listLetterDistinct = new List<claLetter>(listMatchCollection.Count); //Лист букв без повторов.

            for (int int1 = 0; int1 <= listMatchCollectionDistinct.Count - 1; int1++)
            {
                strLetter = listMatchCollectionDistinct[int1]; //Буква.
                intLetterCount = listMatchCollection.RemoveAll(x => x == strLetter); //Количество таких букв в тексте.

                listLetterDistinct.Add(new claLetter(strLetter, intLetterCount));  //Заполняем лист букв без повторов.
            }






            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Файлы
        }





        //Парсинг текста на знаки препинания.
        public static void F_voiPunctuationMark(ref string f_strText)
        {
            string strPattern; //Паттерн.
            MatchCollection colMatchCollection; //Коллекция знаков препинания.

            string strPunctuationMark; //Знак препинания.
            int intPunctuationMarkCount; //Количество таких знаков препинания в тексте.

            strPattern = @"(\.\.\.)|[\?\!\.\""\'\,\:\;]"; //Regex знаков препинания.
            colMatchCollection = Regex.Matches(f_strText, strPattern); //Коллекция знаков препинания.

            List<string> listMatchCollection = new List<string>(colMatchCollection.Count); //Лист знаков препинания.
            for (int int1 = 0; int1 <= colMatchCollection.Count - 1; int1++)
            {
                listMatchCollection.Add(colMatchCollection[int1].Value); //Заполняем лист знаков препинания.
            }

            var listMatchCollectionDistinct = listMatchCollection.Select(x => x).Distinct().ToList(); //Коллекция знаков препинания без повторов.

            List<claPunctuationMark> listPunctuationMarkDistinct = new List<claPunctuationMark>(listMatchCollection.Count); //Лист знаков препинания без повторов.

            for (int int1 = 0; int1 <= listMatchCollectionDistinct.Count - 1; int1++)
            {
                strPunctuationMark = listMatchCollectionDistinct[int1]; //Знак препинания.
                intPunctuationMarkCount = listMatchCollection.RemoveAll(x => x == strPunctuationMark); //Количество таких знаков препинания в тексте.

                listPunctuationMarkDistinct.Add(new claPunctuationMark(strPunctuationMark, intPunctuationMarkCount));  //Заполняем лист знаков препинания без повторов.
            }






            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Файлы
        }





    }
}