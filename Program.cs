using System;

namespace Algorytm8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            Console.WriteLine("Podaj zdanie: ");
            string sentence = Console.ReadLine();
            bool correct = false;

            if (service.IsBeginningCorrect(sentence))
            {
                int startWordIndex = 0;
                for (int i = 0; i < sentence.Length; i++)
                {
                    if (sentence[i] == ' ')
                    {
                        if (sentence[i + 1] != ' ' && service.IsWordCorrect(sentence.Substring(startWordIndex, i - startWordIndex), true))
                        {
                            startWordIndex = i + 1;
                            correct = true;
                        }
                        else
                        {
                            correct = false;
                            break;
                        }
                    }
                    else if(i == sentence.Length - 1)
                    {
                        if (!service.IsWordCorrect(sentence.Substring(startWordIndex, i - startWordIndex + 1), false))
                        {
                            correct = false;
                        }
                    }
                }

            }

            if (correct)
            {
                Console.WriteLine("To zdanie jest poprawne");
            }
            else
            {
                Console.WriteLine("To zdanie jest błędne");
            }
            
        }
    }
}
