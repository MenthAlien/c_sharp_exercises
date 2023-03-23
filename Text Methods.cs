using System;

namespace TextMethods
{
    class TextMethods
    {
        private static char[] separators = {' ', '.', ','};
        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("1.Find min word\n2.Find max word\n3.Delete extra letters");
            do
            {
                bool success = int.TryParse(Console.ReadLine(), out choice);
                if (!success)
                {
                    Console.WriteLine("Try again!");
                }
                else break;
            }
            while (true);

            Console.WriteLine("Enter some text:");
            switch (choice)
            {
                case 1:
                    MinWord(Console.ReadLine());
                    break;
                case 2:
                    MaxWord(Console.ReadLine());
                    break;
                case 3:
                    DeleteExtraLetters(Console.ReadLine());
                    break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Prints the shortest words from the text
        /// </summary>
        /// <param name="text"></param>
        private static void MinWord(string text)
        {
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));
            var minLength = words[0].Length;
            foreach (string word in words)
            {
                if (word.Length == minLength)
                {
                    Console.WriteLine(word);
                }
                else return;
            }
        }

        /// <summary>
        /// Prints the longest words from the text
        /// </summary>
        /// <param name="text"></param>
        private static void MaxWord(string text)
        {
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));
            Array.Reverse(words);
            var maxLength = words[0].Length;
            foreach (string word in words)
            {
                if (word.Length == maxLength)
                {
                    Console.WriteLine(word);
                }
                else return;
            }
        }

        /// <summary>
        /// Prints the text without repeating letters
        /// </summary>
        /// <param name="text"></param>
        private static void DeleteExtraLetters(string text)
        {
            string newText = default;
            newText += text[0];
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == text[i - 1]) continue;
                newText += text[i];
            }
            Console.WriteLine(newText);
        }
    }

}
