using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherEncryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "xyz";
            var result = CaesarCipherEncryptor(input, 2);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string CaesarCipherEncryptor(string str,int key)
        {
            char[] newLetters = new char[str.Length];
            int newKey = key % 26;

            for(int i=0;i<str.Length;i++)
            {
                newLetters[i] = GetNewLetter(str[i], newKey);
            }

            return new string(newLetters);
        }

        private static char GetNewLetter(char letter, int newKey)
        {
            int newLetterCode = letter + newKey;
            if (newLetterCode <= 122)
                return (char)newLetterCode;
            else
                return (char)(96 + newLetterCode % 122);
        }
    }
}
