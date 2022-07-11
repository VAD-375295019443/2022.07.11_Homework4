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
                List<claSentence> listSentence = new List<claSentence>(); //Лист предложений.
                List<claWord> listWord = new List<claWord>(); //Лист слов.
                List<claLetter> listLetter = new List<claLetter>(); //Лист букв.
                List<claPunctuationMark> listPunctuationMark = new List<claPunctuationMark>(); //Лист знаков препинания.


                string strText =  File.ReadAllText(strTextPath); //Читаем данные из файла в переменную.

                strText = strText.Replace("\n", " "); //Удаляем все ентеры (в тексте вогон не нужных/случайных).



                string strPattern;
                MatchCollection strMatchCollection;


                //Парсинг текста на предложения.
                strPattern = @"((\.\.\.)|[0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s]])((Sr.|Jr.|Mrs.|Mr.|Dr.|.exe|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\""|\!\""|\?\""|\.\.\.\'|\.\'|\!\'|\?\'|\.\.\.|[\.\!\?])";
                strMatchCollection = Regex.Matches(strText, strPattern); //Создаем коллекцию предложений.
                
                if (strMatchCollection.Count > 0)
                {
                    for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
                    {
                        listSentence.Add(new claSentence(strMatchCollection[int1].Value)); //Заполняем лист предложений.
                    }
                }
                Console.WriteLine($"Предложения {listSentence.Count}");








                
                List<int> ages = new List<int> { 21, 46, 46, 55, 17, 21, 55, 55 };

                var distinctAges = ages.Distinct().ToList();

                Console.WriteLine($"gggggggg {distinctAges.Count}");
                
                
                int z = 55;
                int numberUnvaccinated = ages.Count(55);




                /*
                var distinctAgesss = ages.Distinct().ToList();
                distinctAgesss[1] = 22;

                
                int numberUnvaccinated = listSentence.Count(p => p.strSentence == z);
                */





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
                
                


                for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
                {
                    strPattern = @"[\w-[\d]]";
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



                for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
                {
                    strPattern = @"(\.\.\.)|[\?\!\.\""\'\,\:\;]";
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







































            }
            else
            {
                Console.WriteLine("Запрашиваемый файл отсутствует.");
            }
        }





    }
}