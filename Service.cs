using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytm8
{
    public class Service
    {
        public List<char> SpecialAtMiddle { get; set; } = new List<char>() { ':', ',', ';' };
        public List<char> SpecialAtEnd { get; set; } = new List<char>() { '?', '!', '.' };
        public List<char> PolishSymbolsBig { get; set; } = new List<char>() { 'Ć', 'Ł', 'Ó', 'Ś', 'Ż', 'Ź' };
        public List<char> PolishSymbolsSmall { get; set; } = new List<char>() { 'ą', 'ę', 'ł', 'ć', 'ń', 'ó', 'ś', 'ż', 'ź' };
        public bool IsBeginningCorrect(string beginning)
        {
            if(65 <= (int)beginning[0] && (int)beginning[0] <= 90 || PolishSymbolsBig.Contains(beginning[0]))
            {
                if(97 <= (int)beginning[1] && (int)beginning[1] <= 122 || PolishSymbolsSmall.Contains(beginning[1]) || (int)beginning[1] == 32)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool IsWordCorrect(string word, bool atMiddle)
        {
            if (65 <= (int)word[0] && (int)word[0] <= 90 || 
                97 <= (int)word[0] && (int)word[0] <= 122 || PolishSymbolsBig.Contains(word[0])
                || PolishSymbolsSmall.Contains(word[0]))
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (i == word.Length - 1 && !atMiddle)
                    {
                        return IsSpecialCharInWordAtEndCorrect(word[i]);
                    }
                    if ((97 > (int)word[i] || (int)word[i] > 122) && !PolishSymbolsSmall.Contains(word[i]))
                    {
                        if(i == word.Length - 1)
                        {
                            return IsSpecialCharInWordAtMiddleCorrect(word[i]);
                        }
                        return false;
                    }
                    
                }
            }
            else return false;

            return true;
        }

        public bool IsSpecialCharInWordAtMiddleCorrect(char character)
        {
            if(SpecialAtMiddle.Contains(character)) return true;
            else return false;
        }

        public bool IsSpecialCharInWordAtEndCorrect(char character)
        {
            if(SpecialAtEnd.Contains(character)) return true;
            else return false;
        }
    }
}
