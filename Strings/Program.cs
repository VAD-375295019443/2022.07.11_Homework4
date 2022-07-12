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


                






                //-------------------------------------------------------------


                
                
                
                
                
                
                
                
                
                
                
                
                //Сортируем предложения.
                var listSentenceSort = listSentence.OrderBy(x => x).ToList();
                Console.WriteLine($"Сортировали {listSentenceSort.Count}");



                //Убираем дубликаты предложения.
                var listSentenceNoDuplicates = listSentenceSort.Distinct().ToList();
                Console.WriteLine($"Дубликат {listSentenceNoDuplicates.Count}");

                















                //-------------------------------------------------------------





                strText = string.Join(" ", listSentence); //После парсинга возвращаем все предложения в strText (чистый текст без остатков после парсинга).
                Console.WriteLine("Обратно в файл");
                //-------------------------------------------------------------










                //-------------------------------------------------------------







                //-------------------------------------------------------------
                //Парсинг текста на слова.
                strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])"; //Regex слов.
                strMatchCollection = Regex.Matches(strText, strPattern); //Создаем коллекцию слов.

                var listWord = strMatchCollection.ToList(); //Копируем коллекцию слов в лист слов (для универсальности).
                Console.WriteLine("Распарсили на слова");
                //-------------------------------------------------------------

                //Сортируем слова.
                var listWordSort = listWord.OrderBy(x => x.Value);




                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //Количество каждого предложения в тесте.
                List<string> m = new List<string>(listSentenceSort);

                List<int> listSentenceCountInText = new List<int>(listSentenceNoDuplicates.Count);
                
                int z;
                for (int int1 = 0; int1 <= listSentenceNoDuplicates.Count - 1; int1++)
                {
                    listSentenceCountInText.Add(m.Count(x => x == listSentenceNoDuplicates[int1]));

                    z = m.RemoveAll(x => x == listSentenceNoDuplicates[int1]);

                    if (int1 == 1000 || int1 == 2000 || int1 == 3000 || int1 == 4000 || int1 == 5000 || int1 == 10000)
                    {
                        Console.WriteLine("ok");
                    }
                }












                //Парсинг текста на буквы.
                strPattern = @"[\w-[\d]]"; //Regex букв.
                strMatchCollection = Regex.Matches(strText, strPattern); //Создаем коллекцию букв.

                var listLetter = strMatchCollection.ToList(); //Копируем коллекцию букв в лист букв (для универсальности).
                Console.WriteLine("Распарсили на буквы");
                //-------------------------------------------------------------

                //Сортируем буквы.
                var listLetterSort = listLetter.OrderBy(x => x.Value).ToString;





                //Парсинг текста на знаки препинания.
                strPattern = @"(\.\.\.)|[\?\!\.\""\'\,\:\;]"; //Regex знаков препинания.
                strMatchCollection = Regex.Matches(strText, strPattern); //Создаем знаков препинания.

                var listPunctuationMark = strMatchCollection.ToList(); //Копируем коллекцию знаков препинания в лист знаков препинания (для универсальности).
                Console.WriteLine("Распарсили на знаки препинания");
                //-------------------------------------------------------------

                //Сортируем знаки препинания.
                var listPunctuationMarkSort = listPunctuationMark.OrderBy(x => x.Value).ToString;


















                //var Sentence = strMatchCollection.Distinct().ToList();






















                /*
                if (strMatchCollection.Count > 0)
                {
                    for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
                    {
                        listSentence.Add(new claSentence(strMatchCollection[int1].Value)); //Заполняем лист предложений.
                    }
                }
                Console.WriteLine($"Предложения {listSentence.Count}");
                */








                List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };







                var distinctAges = ages.Distinct().ToList();

                Console.WriteLine($"gggggggg {distinctAges.Count}");

                int l = 55;
                int numberUnvaccinated = ages.Count(x => x == l);

                Console.WriteLine($"ssssssssss {numberUnvaccinated}");



                /*
                var distinctAgesss = ages.Distinct().ToList();
                distinctAgesss[1] = 22;

                
                int numberUnvaccinated = listSentence.Count(p => p.strSentence == z);
                */






                /*
                List<claSentence> listSentence = new List<claSentence>(); //Лист предложений.
                List<claWord> listWord = new List<claWord>(); //Лист слов.
                List<claLetter> listLetter = new List<claLetter>(); //Лист букв.
                List<claPunctuationMark> listPunctuationMark = new List<claPunctuationMark>(); //Лист знаков препинания.
                */



                //-----------------------------------------------------------------------------------


                /*
                MatchCollection strMatchCollectionRest;

                for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
                {
                    strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])";
                    strMatchCollectionRest = Regex.Matches(strMatchCollection[int1].Value, strPattern); //Создаем коллекцию слов.

                    if (strMatchCollectionRest.Count > 0)
                    {
                        for (int int2 = 0; int2 <= strMatchCollectionRest.Count - 1; int2++)
                        {
                            listWord.Add(new claWord(strMatchCollectionRest[int2].Value)); //Заполняем лист слов.
                        }
                    }
                }
                Console.WriteLine($"Слова {listWord.Count}");
                */


                /*
                for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
                {
                    strPattern = @"[\w-[\d]]"; //Regex букв.
                    strMatchCollectionRest = Regex.Matches(strMatchCollection[int1].Value, strPattern); //Создаем коллекцию букв.

                    if (strMatchCollectionRest.Count > 0)
                    {
                        for (int int2 = 0; int2 <= strMatchCollectionRest.Count - 1; int2++)
                        {
                            listLetter.Add(new claLetter(strMatchCollection[int2].Value)); //Заполняем лист букв.
                        }
                    }
                }
                Console.WriteLine($"Буквы {listLetter.Count}");
                */

                /*
                for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
                {
                    strPattern = @"(\.\.\.)|[\?\!\.\""\'\,\:\;]"; //Regex знаков препинания.
                    strMatchCollectionRest = Regex.Matches(strMatchCollection[int1].Value, strPattern); //Создаем коллекцию знаков препинания.

                    if (strMatchCollectionRest.Count > 0)
                    {
                        for (int int2 = 0; int2 <= strMatchCollectionRest.Count - 1; int2++)
                        {
                            listPunctuationMark.Add(new claPunctuationMark(strMatchCollection[int1].Value)); //Заполняем лист знаков препинания.
                        }
                    }
                }
                Console.WriteLine($"Знаки препинания {listPunctuationMark.Count}");
                */




                /*
                //Подсчет количества предложений.
                if (listSentence.Count>0)
                {
                    listSentence = listSentence.OrderBy(x => x.strSentence).ToList();

                    for (int int1=0; int1<=listSentence.Count - 1; int1++)
                    {
                        listSentence[int1].intSentenceCount = 1;

                        while (int1 < listSentence.Count - 1 && listSentence[int1 + 1].strSentence == listSentence[int1].strSentence)
                        {
                            listSentence.RemoveAt(int1 + 1);
                            listSentence[int1].intSentenceCount++;
                        }
                    }
                }
                Console.WriteLine("1");


                //Подсчет количества слов.
                if (listWord.Count > 0)
                {
                    listWord = listWord.OrderBy(x => x.strWord).ToList();

                    for (int int1 = 0; int1 <= listWord.Count - 1; int1++)
                    {
                        listWord[int1].intWordCount = 1;

                        while (int1 < listWord.Count - 1 && listWord[int1 + 1].strWord == listWord[int1].strWord)
                        {
                            listWord.RemoveAt(int1 + 1);
                            listWord[int1].intWordCount++;
                        }
                    }
                }
                Console.WriteLine("1");


                //Подсчет количества букв.
                if (listLetter.Count > 0)
                {
                    listLetter = listLetter.OrderBy(x => x.strLetter).ToList();

                    for (int int1 = 0; int1 <= listLetter.Count - 1; int1++)
                    {
                        listLetter[int1].intLetterCount = 1;

                        while (int1 < listLetter.Count - 1 && listLetter[int1 + 1].strLetter == listLetter[int1].strLetter)
                        {
                            listLetter.RemoveAt(int1 + 1);
                            listLetter[int1].intLetterCount++;
                        }
                    }
                }
                Console.WriteLine("1");


                //Подсчет количества букв.
                if (listPunctuationMark.Count > 0)
                {
                    listPunctuationMark = listPunctuationMark.OrderBy(x => x.strPunctuationMark).ToList();

                    for (int int1 = 0; int1 <= listPunctuationMark.Count - 1; int1++)
                    {
                        listPunctuationMark[int1].intPunctuationMarkCount = 1;

                        while (int1 < listPunctuationMark.Count - 1 && listPunctuationMark[int1 + 1].strPunctuationMark == listPunctuationMark[int1].strPunctuationMark)
                        {
                            listPunctuationMark.RemoveAt(int1 + 1);
                            listPunctuationMark[int1].intPunctuationMarkCount++;
                        }
                    }
                }
                Console.WriteLine("1");

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
            MatchCollection strMatchCollectionSentence; //Коллекция слов.
            MatchCollection strMatchCollectionWord; //Коллекция предложений.

            string strSentence; //Предложение.
            int intSentenceCharactersCount; //Количество символов в предложениии.
            int intSentenceWordCount; //Количество слов в предложениии.

            strPattern = @"((\.\.\.)|[0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s]])((Sr.|Jr.|Mrs.|Mr.|Dr.|.exe|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\""|\!\""|\?\""|\.\.\.\'|\.\'|\!\'|\?\'|\.\.\.|[\.\!\?])"; //Regex предложений.
            strMatchCollectionSentence = Regex.Matches(f_strText, strPattern); //Создаем коллекцию предложений.

            List<claSentence> listSentence = new List<claSentence>(); //Создаем лист предложений.

            for (int int1 = 0; int1 <= strMatchCollectionSentence.Count - 1; int1++)
            {
                strSentence = strMatchCollectionSentence[int1].Value; //Предложение.
                intSentenceCharactersCount = strSentence.Length; //Количество символов в предложениии.
                strMatchCollectionWord = Regex.Matches(strSentence, strPattern); //Создаем коллекцию слов.
                intSentenceWordCount = strMatchCollectionWord.Count; //Количество слов в предложениии.
                
                listSentence.Add(new claSentence(strSentence, intSentenceCharactersCount, intSentenceWordCount));
            }
            
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Файлы
            
            
            Console.WriteLine("Предложения");
        }







    }
}