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



                F_voiSentence(ref strText);

                
                
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
            string strPattern = @"((\.\.\.)|[0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s]])((Sr.|Jr.|Mrs.|Mr.|Dr.|.exe|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\""|\!\""|\?\""|\.\.\.\'|\.\'|\!\'|\?\'|\.\.\.|[\.\!\?])"; //Regex предложений.
            MatchCollection matchSentence = Regex.Matches(f_strText, strPattern); //Коллекция предложений.

            if (matchSentence.Count > 0)
            {
                var matchSentenceSort = matchSentence.OrderBy(x => x.Value).ToList(); //Сортируем коллекцию предложений.

                string strSentence = ""; //Предложение.
                int intCountSentenceInText = 0; //Количество таких предложений в тексте.
                int intCountWordInSentence = 0; //Количество слов в предложениии.
                int intCountCharactersInSentence = 0; //Количество символов в предложениии.
                List<claSentence> listSentence = new List<claSentence>(matchSentenceSort.Select(x => x.Value).Distinct().ToList().Count); //Лист предложений.

                for (int int1 = 0; int1 <= matchSentenceSort.Count - 1; int1++)
                {
                    if (matchSentenceSort[int1].Value != strSentence)
                    {
                        if (int1 != 0)
                        {
                            listSentence.Add(new claSentence(strSentence, intCountSentenceInText, intCountWordInSentence, intCountCharactersInSentence));  //Заполняем лист предложений.
                        }

                        strSentence = matchSentenceSort[int1].Value; //Предложение.
                        intCountSentenceInText = 1; //Количество таких предложений в тексте.

                        strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])"; //Regex слов.
                        MatchCollection matchWord = Regex.Matches(strSentence, strPattern); //Коллекция слов.
                        intCountWordInSentence = matchWord.Count; //Количество слов в предложениии.

                        intCountCharactersInSentence = strSentence.Length; //Количество символов в предложениии.
                    }
                    else
                    {
                        intCountSentenceInText++;
                    }
                }
                listSentence.Add(new claSentence(strSentence, intCountSentenceInText, intCountWordInSentence, intCountCharactersInSentence));  //Заполняем лист предложений.

                f_strText = string.Join(" ", matchSentence); //После парсинга возвращаем все предложения в strText (чистый текст без оставшейся абры-кадабры после парсинга).




                for (int int1 = 0; int1 <= listSentence.Count - 1; int1++)
                {
                    Console.WriteLine($"В тексте предложений {listSentence[int1].intCountSentenceInText} - В предложении слов {listSentence[int1].intCountWordInSentence} - В предложении символов {listSentence[int1].intCountCharactersInSentence} - {listSentence[int1].strSentence}");

                }
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Файлы
            }
        }







        //Парсинг текста на слова.
        public static void F_voiWord(string f_strText)
        {
            string strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])"; //Regex слов.
            MatchCollection matchWord = Regex.Matches(f_strText, strPattern); //Коллекция слов.

            if(matchWord.Count>0)
            {
                var matchWordSort = matchWord.OrderBy(x => x.Value).ToList(); //Сортируем коллекцию слов.
            
                string strWord = ""; //Слово.
                int intCountWordInText = 0; //Количество таких слов в тексте.
                List<claWord> listWord = new List<claWord>(matchWordSort.Select(x => x.Value).Distinct().ToList().Count); //Лист слов.
                
                for (int int1 = 0; int1 <= matchWordSort.Count - 1; int1++)
                {
                    if (matchWordSort[int1].Value != strWord)
                    {
                        if (int1 != 0)
                        {
                            listWord.Add(new claWord(strWord, intCountWordInText));  //Заполняем лист слов.
                        }
                    
                        strWord = matchWordSort[int1].Value;
                        intCountWordInText = 1;
                    }
                    else
                    {
                        intCountWordInText++;
                    }
                }
                listWord.Add(new claWord(strWord, intCountWordInText));  //Заполняем лист слов.




                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Файлы
            }
        }





        //Парсинг текста на буквы.
        public static void F_voiLetter(string f_strText)
        {
            string strPattern = @"[\w-[\d]]"; //Regex букв.
            MatchCollection matchLetter = Regex.Matches(f_strText, strPattern); //Коллекция букв.

            if (matchLetter.Count > 0)
            {
                var matchLetterSort = matchLetter.OrderBy(x => x.Value).ToList(); //Сортируем коллекцию букв.

                string strLetter = ""; //Буква.
                int intCountLetterInText = 0; //Количество таких букв в тексте.
                List<claLetter> listLetter = new List<claLetter>(matchLetterSort.Select(x => x.Value).Distinct().ToList().Count); //Лист букв.
                
                for (int int1 = 0; int1 <= matchLetterSort.Count - 1; int1++)
                {
                    if (matchLetterSort[int1].Value != strLetter)
                    {
                        if (int1 != 0)
                        {
                            listLetter.Add(new claLetter(strLetter, intCountLetterInText));  //Заполняем лист букв.
                        }

                        strLetter = matchLetterSort[int1].Value;
                        intCountLetterInText = 1;
                    }
                    else
                    {
                        intCountLetterInText++;
                    }
                }
                listLetter.Add(new claLetter(strLetter, intCountLetterInText));  //Заполняем лист букв.




                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Файлы
            }
        }





        //Парсинг текста на знаки препинания.
        public static void F_voiPunctuationMark(ref string f_strText)
        {
            string strPattern = @"(\.\.\.)|[\?\!\.\""\'\,\:\;]"; //Regex знаков препинания.
            MatchCollection matchPunctuationMark = Regex.Matches(f_strText, strPattern); //Коллекция знаков препинания.

            if (matchPunctuationMark.Count > 0)
            {
                var matchPunctuationMarkSort = matchPunctuationMark.OrderBy(x => x.Value).ToList(); //Сортируем коллекцию знаков препинания.

                string strPunctuationMark = ""; //Знак препинания.
                int intCountPunctuationMarkInText = 0; //Количество таких знаков препинания в тексте.
                List<claPunctuationMark> listPunctuationMark = new List<claPunctuationMark>(matchPunctuationMarkSort.Select(x => x.Value).Distinct().ToList().Count); //Лист знаков препинания.

                for (int int1 = 0; int1 <= matchPunctuationMarkSort.Count - 1; int1++)
                {
                    if (matchPunctuationMarkSort[int1].Value != strPunctuationMark)
                    {
                        if (int1 != 0)
                        {
                            listPunctuationMark.Add(new claPunctuationMark(strPunctuationMark, intCountPunctuationMarkInText));  //Заполняем лист знаков препинания.
                        }

                        strPunctuationMark = matchPunctuationMarkSort[int1].Value;
                        intCountPunctuationMarkInText = 1;
                    }
                    else
                    {
                        intCountPunctuationMarkInText++;
                    }
                }
                listPunctuationMark.Add(new claPunctuationMark(strPunctuationMark, intCountPunctuationMarkInText));  //Заполняем лист знаков препинания.




                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Файлы
            }
        }







    }
}