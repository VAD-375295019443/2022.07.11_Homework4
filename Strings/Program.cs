using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Strings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Пожалуйста, поместите файл с названием \"sample.txt\" по указанному пути \"d:\\sample.txt\"");
                Console.WriteLine("");
                Console.WriteLine("Для выхода из программы и удаления рабочих дирректорий наберите Exit.");
                Console.WriteLine("Для продолжения нажмите Enter.");
                string? strMenu = Console.ReadLine();

                if (strMenu == "Exit" || strMenu == "exit")
                {
                    string strPath = @"d:\VAD_Homework4";
                    if (Directory.Exists(strPath) == true) //Если директория существует.
                    {
                        Directory.Delete(strPath, true); //Удаляем.
                    }

                    Console.Clear();
                    Console.WriteLine("Goodbye.");
                    break;
                }
                else
                {
                    string strText = "";

                    Console.WriteLine("Создание рабочих дирректорий и чтение данных из файла \"d:\\sample.txt\"");
                    if (F_booReadFromFile(ref strText) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Запрашиваемый файл \"d:\\sample.txt\" отсутствует.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        strMenu = Console.ReadLine();
                        continue;
                    }
                    

                    Console.WriteLine("Парсинг текста на предложения.");
                    if (F_booSentence(ref strText) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Недостаточно данных для парсинга текста на предложения.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        strMenu = Console.ReadLine();
                        continue;
                    }


                    Console.WriteLine("Парсинг текста на слова.");
                    if (F_booWord(strText) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Недостаточно данных для парсинга текста на слова.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        strMenu = Console.ReadLine();
                        continue;
                    }


                    Console.WriteLine("Парсинг текста на буквы.");
                    if (F_booLetter(strText) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Недостаточно данных для парсинга текста на буквы.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        strMenu = Console.ReadLine();
                        continue;
                    }


                    Console.WriteLine("Парсинг текста на знаки препинания.");
                    if (F_booPunctuationMark(strText) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Недостаточно данных для парсинга текста на знаки препинания.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        strMenu = Console.ReadLine();
                        continue;
                    }


                    Console.WriteLine("");
                    Console.WriteLine("Анализ текста завершен.");
                    Console.WriteLine("Адрес рабочих дирректрий: \"d:\\VAD_Homework4\\\"");
                    Console.WriteLine("");
                    Console.WriteLine("ВНИМАНИЕ!");
                    Console.WriteLine("При выходе из программы через Exit все рабочие дирректории будут удалены.");
                    Console.WriteLine("");
                    Console.WriteLine("Для продолжения нажмите Enter.");
                    strMenu = Console.ReadLine();
                }
            }
        }


        //Создание рабочих дирректорий и чтение данных из файла
        public static bool F_booReadFromFile(ref string strText)
        {
            string strPath = @"d:\sample.txt";

            if (File.Exists(strPath) == true) //Если файл существует.
            {
                strPath = @"d:\sample.txt";
                strText = File.ReadAllText(strPath); //Читаем данные из файла в переменную.


                strPath = @"d:\VAD_Homework4\Parsing";
                if (Directory.Exists(strPath) == true) //Если директория существует.
                {
                    Directory.Delete(strPath, true); //Удаляем.
                }
                Directory.CreateDirectory(strPath); //Создаем заново чистую.

                strPath = @"d:\VAD_Homework4\Sorted";
                if (Directory.Exists(strPath) == true) //Если директория существует.
                {
                    Directory.Delete(strPath, true); //Удаляем.
                }
                Directory.CreateDirectory(strPath); //Создаем заново чистую.

                strPath = @"d:\VAD_Homework4\Request";
                if (Directory.Exists(strPath) == true) //Если директория существует.
                {
                    Directory.Delete(strPath, true); //Удаляем.
                }
                Directory.CreateDirectory(strPath); //Создаем заново чистую.

                return (true);
            }
            else
            {
                return (false);
            }
        }
        
        
        //Парсинг текста на предложения.
        public static bool F_booSentence(ref string f_strText)
        {
            f_strText = f_strText.Replace("\n", " "); //Удаляем все ентеры (в тексте вогон не нужных/случайных).

            string strPattern = @"((\.\.\.)|([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s]])((Sr.|Jr.|Mrs.|Mr.|Dr.|.exe|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\""|\!\""|\?\""|\.\.\.\'|\.\'|\!\'|\?\'|\.\.\.|[\.\!\?])?"; //Regex предложений.
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

                        strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])?"; //Regex слов.
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


                //Вывод результата парсинга текста на предложения.
                f_strText = string.Join("\n", matchSentence);
                string strPath = $@"d:\VAD_Homework4\Parsing\Sentence.txt";
                File.WriteAllText(strPath, f_strText);


                //Вывод сортированного результата парсинга текста на предложения.
                List<string> listSentenceSorted = new List<string>(listSentence.Select(x => x).Distinct().ToList().Count);
                for(int int1=0; int1<=listSentence.Count-1; int1++)
                {
                    listSentenceSorted.Add($"Предложений в тексте = {Convert.ToString(listSentence[int1].intCountSentenceInText)}: {listSentence[int1].strSentence}");
                }
                f_strText = string.Join("\n", listSentenceSorted);
                strPath = $@"d:\VAD_Homework4\Sorted\SentenceSorted.txt";
                File.WriteAllText(strPath, f_strText);


                //Вывод запроса на максимальное количество символов в предложении.
                int intMaxCountCharactersInSentence = listSentence.Max(x => x.intCountCharactersInSentence);
                var MaxCountCharactersInSentence = listSentence.Where(x => x.intCountCharactersInSentence == intMaxCountCharactersInSentence).ToList();
                List<string> listMaxCountCharactersInSentence = new List<string>(MaxCountCharactersInSentence.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= MaxCountCharactersInSentence.Count - 1; int1++)
                {
                    listMaxCountCharactersInSentence.Add($"Количество символов = {Convert.ToString(MaxCountCharactersInSentence[int1].intCountCharactersInSentence)}: {MaxCountCharactersInSentence[int1].strSentence}");
                }
                f_strText = string.Join("\n", listMaxCountCharactersInSentence);
                strPath = $@"d:\VAD_Homework4\Request\Request.txt";
                File.WriteAllText(strPath, "                ПРЕДЛОЖЕНИЯ С МАКСИМАЛЬНЫМ КОЛИЧЕСТВОМ СИМВОЛОВ\n\n");
                File.AppendAllText(strPath, f_strText);


                //Вывод запроса на минимальное количество слов в предложении.
                int intMinCountWordInSentence = listSentence.Min(x => x.intCountWordInSentence);
                var MinCountWordInSentence = listSentence.Where(x => x.intCountWordInSentence == intMinCountWordInSentence).ToList();
                List<string> listMinCountWordInSentence = new List<string>(MinCountWordInSentence.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= MinCountWordInSentence.Count - 1; int1++)
                {
                    listMinCountWordInSentence.Add($"Количество слов = {Convert.ToString(MinCountWordInSentence[int1].intCountWordInSentence)}: {MinCountWordInSentence[int1].strSentence}");
                }
                f_strText = string.Join("\n", listMinCountWordInSentence);
                strPath = $@"d:\VAD_Homework4\Request\Request.txt";
                File.AppendAllText(strPath, "\n\n                ПРЕДЛОЖЕНИЯ С МИНИМАЛЬНЫМ КОЛИЧЕСТВОМ СЛОВ\n\n");
                File.AppendAllText(strPath, f_strText);


                f_strText = string.Join(" ", matchSentence); //После парсинга возвращаем все предложения в strText (чистый текст без оставшейся абры-кадабры после парсинга).

                return (true);
            }
            else
            {
                return (false);
            }
        }


        //Парсинг текста на слова.
        public static bool F_booWord(string f_strText)
        {
            string strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])?"; //Regex слов.
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


                //Вывод результата парсинга текста на слова.
                f_strText = string.Join("\n", matchWord);
                string strPath = $@"d:\VAD_Homework4\Parsing\Word.txt";
                File.WriteAllText(strPath, f_strText);


                //Вывод сортированного результата парсинга текста на слова.
                List<string> listWordSorted = new List<string>(listWord.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= listWord.Count - 1; int1++)
                {
                    listWordSorted.Add($"Слов в тексте = {Convert.ToString(listWord[int1].intCountWordInText)}: {listWord[int1].strWord}");
                }
                f_strText = string.Join("\n", listWordSorted);
                strPath = $@"d:\VAD_Homework4\Sorted\WordSorted.txt";
                File.WriteAllText(strPath, f_strText);

                return (true);
            }
            else
            {
                return (false);
            }
        }


        //Парсинг текста на буквы.
        public static bool F_booLetter(string f_strText)
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


                //Вывод результата парсинга текста на буквы.
                f_strText = string.Join("\n", matchLetter);
                string strPath = $@"d:\VAD_Homework4\Parsing\Letter.txt";
                File.WriteAllText(strPath, f_strText);


                //Вывод сортированного результата парсинга текста на буквы.
                List<string> listLetterSorted = new List<string>(listLetter.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= listLetter.Count - 1; int1++)
                {
                    listLetterSorted.Add($"Букв в тексте = {Convert.ToString(listLetter[int1].intCountLetterInText)}: {listLetter[int1].strLetter}");
                }
                f_strText = string.Join("\n", listLetterSorted);
                strPath = $@"d:\VAD_Homework4\Sorted\LetterSorted.txt";
                File.WriteAllText(strPath, f_strText);


                //Вывод запроса на максимальное количество букв в тексте.
                int intMaxCountLetterInText = listLetter.Max(x => x.intCountLetterInText);
                var MaxCountLetterInText = listLetter.Where(x => x.intCountLetterInText == intMaxCountLetterInText).ToList();
                List<string> listMaxCountLetterInText = new List<string>(MaxCountLetterInText.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= MaxCountLetterInText.Count - 1; int1++)
                {
                    listMaxCountLetterInText.Add($"Количество букв = {Convert.ToString(MaxCountLetterInText[int1].intCountLetterInText)}: {MaxCountLetterInText[int1].strLetter}");
                }
                f_strText = string.Join("\n", listMaxCountLetterInText);
                strPath = $@"d:\VAD_Homework4\Request\Request.txt";
                File.AppendAllText(strPath, "\n\n                БУКВЫ С МАКСИМАЛЬНЫМ КОЛИЧЕСТВОМ ПОВТОРЕНИЙ\n\n");
                File.AppendAllText(strPath, f_strText);

                return (true);
            }
            else
            {
                return (false);
            }
        }


        //Парсинг текста на знаки препинания.
        public static bool F_booPunctuationMark(string f_strText)
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


                //Вывод результата парсинга текста на знаки препинания.
                f_strText = string.Join("\n", matchPunctuationMark);
                string strPath = $@"d:\VAD_Homework4\Parsing\PunctuationMark.txt";
                File.WriteAllText(strPath, f_strText);


                //Вывод сортированного результата парсинга текста на знаки препинания.
                List<string> listPunctuationMarkSorted = new List<string>(listPunctuationMark.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= listPunctuationMark.Count - 1; int1++)
                {
                    listPunctuationMarkSorted.Add($"Знаков препинания в тексте = {Convert.ToString(listPunctuationMark[int1].intCountPunctuationMarkInText)}: {listPunctuationMark[int1].strPunctuationMark}");
                }
                f_strText = string.Join("\n", listPunctuationMarkSorted);
                strPath = $@"d:\VAD_Homework4\Sorted\PunctuationMarkSorted.txt";
                File.WriteAllText(strPath, f_strText);

                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}