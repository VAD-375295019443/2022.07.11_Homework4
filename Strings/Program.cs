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
                string? Menu = Console.ReadLine();

                if (Menu == "Exit" || Menu == "exit")
                {
                    string Path = @"d:\VAD_Homework4";
                    if (Directory.Exists(Path) == true) //Если директория существует.
                    {
                        Directory.Delete(Path, true); //Удаляем.
                    }

                    Console.Clear();
                    Console.WriteLine("Goodbye.");
                    break;
                }
                else
                {
                    string Text = "";

                    Console.WriteLine("Создание рабочих дирректорий и чтение данных из файла \"d:\\sample.txt\"");
                    if (ReadFromFile(ref Text) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Запрашиваемый файл \"d:\\sample.txt\" отсутствует.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        Menu = Console.ReadLine();
                        continue;
                    }
                    

                    Console.WriteLine("Парсинг текста на предложения.");
                    if (Sentence(ref Text) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Недостаточно данных для парсинга текста на предложения.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        Menu = Console.ReadLine();
                        continue;
                    }


                    Console.WriteLine("Парсинг текста на слова.");
                    if (Word(Text) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Недостаточно данных для парсинга текста на слова.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        Menu = Console.ReadLine();
                        continue;
                    }


                    Console.WriteLine("Парсинг текста на буквы.");
                    if (Letter(Text) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Недостаточно данных для парсинга текста на буквы.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        Menu = Console.ReadLine();
                        continue;
                    }


                    Console.WriteLine("Парсинг текста на знаки препинания.");
                    if (PunctuationMark(Text) == true)
                    {
                        Console.WriteLine("          выполнено успешно.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Недостаточно данных для парсинга текста на знаки препинания.");
                        Console.WriteLine("");
                        Console.WriteLine("Для продолжения нажмите Enter.");
                        Menu = Console.ReadLine();
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
                    Menu = Console.ReadLine();
                }
            }
        }


        //Создание рабочих дирректорий и чтение данных из файла
        public static bool ReadFromFile(ref string Text)
        {
            string Path = @"d:\sample.txt";

            if (File.Exists(Path) == true) //Если файл существует.
            {
                Path = @"d:\sample.txt";
                Text = File.ReadAllText(Path); //Читаем данные из файла в переменную.


                Path = @"d:\VAD_Homework4\Parsing";
                if (Directory.Exists(Path) == true) //Если директория существует.
                {
                    Directory.Delete(Path, true); //Удаляем.
                }
                Directory.CreateDirectory(Path); //Создаем заново чистую.

                Path = @"d:\VAD_Homework4\Sorted";
                if (Directory.Exists(Path) == true) //Если директория существует.
                {
                    Directory.Delete(Path, true); //Удаляем.
                }
                Directory.CreateDirectory(Path); //Создаем заново чистую.

                Path = @"d:\VAD_Homework4\Request";
                if (Directory.Exists(Path) == true) //Если директория существует.
                {
                    Directory.Delete(Path, true); //Удаляем.
                }
                Directory.CreateDirectory(Path); //Создаем заново чистую.

                return (true);
            }
            else
            {
                return (false);
            }
        }
        
        
        //Парсинг текста на предложения.
        public static bool Sentence(ref string Text)
        {
            Text = Text.Replace("\n", " "); //Удаляем все ентеры (в тексте вогон не нужных/случайных).

            string Pattern = @"((\.\.\.)|([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s]])((Sr.|Jr.|Mrs.|Mr.|Dr.|.exe|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\""|\!\""|\?\""|\.\.\.\'|\.\'|\!\'|\?\'|\.\.\.|[\.\!\?])?"; //Regex предложений.
            MatchCollection CollectionSentence = Regex.Matches(Text, Pattern); //Коллекция предложений.

            if (CollectionSentence.Count > 0)
            {
                var SentenceSort = CollectionSentence.OrderBy(x => x.Value).ToList(); //Сортируем коллекцию предложений.

                string Sentence = ""; //Предложение.
                int CountSentenceInText = 0; //Количество таких предложений в тексте.
                int CountWordInSentence = 0; //Количество слов в предложениии.
                int CountCharactersInSentence = 0; //Количество символов в предложениии.
                List<Sentence> listSentence = new List<Sentence>(SentenceSort.Select(x => x.Value).Distinct().ToList().Count); //Лист предложений.

                for (int int1 = 0; int1 <= SentenceSort.Count - 1; int1++)
                {
                    if (SentenceSort[int1].Value != Sentence)
                    {
                        if (int1 != 0)
                        {
                            listSentence.Add(new Sentence(Sentence, CountSentenceInText, CountWordInSentence, CountCharactersInSentence));  //Заполняем лист предложений.
                        }

                        Sentence = SentenceSort[int1].Value; //Предложение.
                        CountSentenceInText = 1; //Количество таких предложений в тексте.

                        Pattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])?"; //Regex слов.
                        MatchCollection CollectionWord = Regex.Matches(Sentence, Pattern); //Коллекция слов.
                        CountWordInSentence = CollectionWord.Count; //Количество слов в предложениии.

                        CountCharactersInSentence = Sentence.Length; //Количество символов в предложениии.
                    }
                    else
                    {
                        CountSentenceInText++;
                    }
                }
                listSentence.Add(new Sentence(Sentence, CountSentenceInText, CountWordInSentence, CountCharactersInSentence));  //Заполняем лист предложений.


                //Вывод результата парсинга текста на предложения.
                Text = string.Join("\n", CollectionSentence);
                string Path = $@"d:\VAD_Homework4\Parsing\Sentence.txt";
                File.WriteAllText(Path, Text);


                //Вывод сортированного результата парсинга текста на предложения.
                List<string> listSentenceSorted = new List<string>(listSentence.Select(x => x).Distinct().ToList().Count);
                for(int int1=0; int1<=listSentence.Count-1; int1++)
                {
                    listSentenceSorted.Add($"Предложений в тексте = {Convert.ToString(listSentence[int1].CountSentenceInText)}: {listSentence[int1].Sentence}");
                }
                Text = string.Join("\n", listSentenceSorted);
                Path = $@"d:\VAD_Homework4\Sorted\SentenceSorted.txt";
                File.WriteAllText(Path, Text);


                //Вывод запроса на максимальное количество символов в предложении.
                int intMaxCountCharactersInSentence = listSentence.Max(x => x.CountCharactersInSentence);
                var MaxCountCharactersInSentence = listSentence.Where(x => x.CountCharactersInSentence == intMaxCountCharactersInSentence).ToList();
                List<string> listMaxCountCharactersInSentence = new List<string>(MaxCountCharactersInSentence.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= MaxCountCharactersInSentence.Count - 1; int1++)
                {
                    listMaxCountCharactersInSentence.Add($"Количество символов = {Convert.ToString(MaxCountCharactersInSentence[int1].CountCharactersInSentence)}: {MaxCountCharactersInSentence[int1].Sentence}");
                }
                Text = string.Join("\n", listMaxCountCharactersInSentence);
                Path = $@"d:\VAD_Homework4\Request\Request.txt";
                File.WriteAllText(Path, "                ПРЕДЛОЖЕНИЯ С МАКСИМАЛЬНЫМ КОЛИЧЕСТВОМ СИМВОЛОВ\n\n");
                File.AppendAllText(Path, Text);


                //Вывод запроса на минимальное количество слов в предложении.
                int intMinCountWordInSentence = listSentence.Min(x => x.CountWordInSentence);
                var MinCountWordInSentence = listSentence.Where(x => x.CountWordInSentence == intMinCountWordInSentence).ToList();
                List<string> listMinCountWordInSentence = new List<string>(MinCountWordInSentence.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= MinCountWordInSentence.Count - 1; int1++)
                {
                    listMinCountWordInSentence.Add($"Количество слов = {Convert.ToString(MinCountWordInSentence[int1].CountWordInSentence)}: {MinCountWordInSentence[int1].Sentence}");
                }
                Text = string.Join("\n", listMinCountWordInSentence);
                Path = $@"d:\VAD_Homework4\Request\Request.txt";
                File.AppendAllText(Path, "\n\n                ПРЕДЛОЖЕНИЯ С МИНИМАЛЬНЫМ КОЛИЧЕСТВОМ СЛОВ\n\n");
                File.AppendAllText(Path, Text);


                Text = string.Join(" ", CollectionSentence); //После парсинга возвращаем все предложения в Text (чистый текст без оставшейся абры-кадабры после парсинга).

                return (true);
            }
            else
            {
                return (false);
            }
        }


        //Парсинг текста на слова.
        public static bool Word(string Text)
        {
            string Pattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])?"; //Regex слов.
            MatchCollection CollectionWord = Regex.Matches(Text, Pattern); //Коллекция слов.

            if(CollectionWord.Count>0)
            {
                var matchWordSort = CollectionWord.OrderBy(x => x.Value).ToList(); //Сортируем коллекцию слов.
            
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
                Text = string.Join("\n", CollectionWord);
                string Path = $@"d:\VAD_Homework4\Parsing\Word.txt";
                File.WriteAllText(Path, Text);


                //Вывод сортированного результата парсинга текста на слова.
                List<string> listWordSorted = new List<string>(listWord.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= listWord.Count - 1; int1++)
                {
                    listWordSorted.Add($"Слов в тексте = {Convert.ToString(listWord[int1].intCountWordInText)}: {listWord[int1].strWord}");
                }
                Text = string.Join("\n", listWordSorted);
                Path = $@"d:\VAD_Homework4\Sorted\WordSorted.txt";
                File.WriteAllText(Path, Text);

                return (true);
            }
            else
            {
                return (false);
            }
        }


        //Парсинг текста на буквы.
        public static bool Letter(string Text)
        {
            string Pattern = @"[\w-[\d]]"; //Regex букв.
            MatchCollection matchLetter = Regex.Matches(Text, Pattern); //Коллекция букв.

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
                Text = string.Join("\n", matchLetter);
                string Path = $@"d:\VAD_Homework4\Parsing\Letter.txt";
                File.WriteAllText(Path, Text);


                //Вывод сортированного результата парсинга текста на буквы.
                List<string> listLetterSorted = new List<string>(listLetter.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= listLetter.Count - 1; int1++)
                {
                    listLetterSorted.Add($"Букв в тексте = {Convert.ToString(listLetter[int1].intCountLetterInText)}: {listLetter[int1].strLetter}");
                }
                Text = string.Join("\n", listLetterSorted);
                Path = $@"d:\VAD_Homework4\Sorted\LetterSorted.txt";
                File.WriteAllText(Path, Text);


                //Вывод запроса на максимальное количество букв в тексте.
                int intMaxCountLetterInText = listLetter.Max(x => x.intCountLetterInText);
                var MaxCountLetterInText = listLetter.Where(x => x.intCountLetterInText == intMaxCountLetterInText).ToList();
                List<string> listMaxCountLetterInText = new List<string>(MaxCountLetterInText.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= MaxCountLetterInText.Count - 1; int1++)
                {
                    listMaxCountLetterInText.Add($"Количество букв = {Convert.ToString(MaxCountLetterInText[int1].intCountLetterInText)}: {MaxCountLetterInText[int1].strLetter}");
                }
                Text = string.Join("\n", listMaxCountLetterInText);
                Path = $@"d:\VAD_Homework4\Request\Request.txt";
                File.AppendAllText(Path, "\n\n                БУКВЫ С МАКСИМАЛЬНЫМ КОЛИЧЕСТВОМ ПОВТОРЕНИЙ\n\n");
                File.AppendAllText(Path, Text);

                return (true);
            }
            else
            {
                return (false);
            }
        }


        //Парсинг текста на знаки препинания.
        public static bool PunctuationMark(string Text)
        {
            string Pattern = @"(\.\.\.)|[\?\!\.\""\'\,\:\;]"; //Regex знаков препинания.
            MatchCollection matchPunctuationMark = Regex.Matches(Text, Pattern); //Коллекция знаков препинания.

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
                Text = string.Join("\n", matchPunctuationMark);
                string Path = $@"d:\VAD_Homework4\Parsing\PunctuationMark.txt";
                File.WriteAllText(Path, Text);


                //Вывод сортированного результата парсинга текста на знаки препинания.
                List<string> listPunctuationMarkSorted = new List<string>(listPunctuationMark.Select(x => x).Distinct().ToList().Count);
                for (int int1 = 0; int1 <= listPunctuationMark.Count - 1; int1++)
                {
                    listPunctuationMarkSorted.Add($"Знаков препинания в тексте = {Convert.ToString(listPunctuationMark[int1].intCountPunctuationMarkInText)}: {listPunctuationMark[int1].strPunctuationMark}");
                }
                Text = string.Join("\n", listPunctuationMarkSorted);
                Path = $@"d:\VAD_Homework4\Sorted\PunctuationMarkSorted.txt";
                File.WriteAllText(Path, Text);

                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}