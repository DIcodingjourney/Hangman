using System;
using System.IO;
using System.Text;

namespace Hangman
{
    class Hangman
    {
        public void SearchingTheWord(string wordTosearch)
        {
            int counter = 0;
            char[] word = new char[wordTosearch.Length];
            string wordTocheck = "";

            for (int i = 0; i < wordTosearch.Length; i++)
            {
                word[i] = '_';
            }

            Console.WriteLine(word); ;

            while (counter < wordTosearch.Length)
            {
                wordTocheck = "";
                Console.WriteLine("\n Введите букву");
                char inputLetter = char.Parse(Console.ReadLine());

                for (int i = 0; i < wordTosearch.Length; i++)
                {
                    if (wordTosearch[i] == inputLetter)
                    {
                        word[i] = inputLetter;
                    }

                }

                foreach (var i in word)
                {
                    wordTocheck += i;
                    Console.Write(i);

                    if (wordTocheck == wordTosearch)
                    {
                        Console.WriteLine("\nYou are winner");
                        counter = wordTosearch.Length;
                        break;
                    }

                }

                counter++;
            }
            if (wordTocheck != wordTosearch)
            {
                Console.WriteLine("\nYou lose.");
                Console.WriteLine($"Word to search = {wordTosearch}");
                Console.WriteLine($"Attempts = {counter}");
            }



        }
        class Program
        {
            static void Main(string[] args)
            {
                Hangman hangman = new Hangman();
                Random random = new Random();
                string[] str = File.ReadAllLines("WordsStockRus.txt", Encoding.Default);
                string s = str[random.Next(str.Length)];
                Console.WriteLine($"The word consists of {s.Length} letters");
                hangman.SearchingTheWord(s);


            }

        }
    }
}
