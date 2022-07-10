using System;
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
                string strText =  File.ReadAllText(strTextPath); //Читаем данные из файла в переменную.

                strText = strText.Replace("\n", " "); //Удаляем все ентеры (в тексте вогон не нужных/случайных).





                string strPattern;
                MatchCollection strMatchCollection;

                strPattern = @"((\.\.\.)|[0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s]])((Sr.|Jr.|Mrs.|Mr.|Dr.|.exe|[0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.]])*(\.\.\.\""|\.\""|\!\""|\?\""|\.\.\.\'|\.\'|\!\'|\?\'|\.\.\.|[\.\!\?])";
                strMatchCollection = Regex.Matches(strText, strPattern); //Создаем коллекцию предложений.

                List<claSentence> strSentenceList = new List<claSentence>(); //Лист предложений.

                if (strMatchCollection.Count > 0)
                {
                    for (int int1 = 0; int1 <= strMatchCollection.Count - 1; int1++)
                    {
                        strSentenceList.Add(new claSentence(strMatchCollection[int1].Value)); //Создаем лист предложений.
                    }
                }
                

                if (strSentenceList.Count > 0)
                {
                    for (int int1 = 0; int1 <= strSentenceList.Count - 1; int1++)
                    {
                        strPattern = @"([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\(\{\[\,]])(([0-9]{1,}.[0-9]{1,})|[\w\W-[\?\!\.\s\""\(\)\{\}\[\]\,]])*([0-9]{1,}.[0-9]{1,}|[\w\W-[\?\!\.\s\""\)\}\]\,]])";
                        strMatchCollection = Regex.Matches(strSentenceList[int1].strSentence, strPattern); //Создаем коллекцию слов.

                        if (strMatchCollection.Count > 0)
                        {
                            for (int int2 = 0; int2 <= strMatchCollection.Count - 1; int2++)
                            {
                                strSentenceList[int2].strWordList.Add(strMatchCollection[int2].Value); //Создаем лист слов (на каждое предложение).
                            }
                        }

                        strPattern = @"(\.\.\.)|[\?\!\.\""\'\,\:\;]";
                        strMatchCollection = Regex.Matches(strSentenceList[int1].strSentence, strPattern); //Создаем коллекцию знаков препинания (на каждое предложение).

                        if (strMatchCollection.Count > 0)
                        {
                            for (int int2 = 0; int2 <= strMatchCollection.Count - 1; int2++)
                            {
                                strSentenceList[int2].strPunctuationMarkList.Add(strMatchCollection[int2].Value); //Создаем лист знаков препинания.
                            }
                        }


                    }
                }








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








                //


                //AppendAllLines;

                /*
                Process.Start(strPath);

                File.Open(strPath, FileMode.Open);
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
            else
            {
                Console.WriteLine("Запрашиваемый файл отсутствует.");
            }
        }
        
        


        
        



    }
}