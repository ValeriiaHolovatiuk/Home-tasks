using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace ZesarCode
{
    class EncryptCezar
    {
        int key, helping_key, helper, saver, UnicDecipher;
        char[] EnglishAlphabetBig = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        char[] EnglishAlphabetSmall = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        char[] RussianAlphabetBig = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
        char[] RussianAlphabetSmall = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        char[] Symbols = { ' ', '.', ',', '(', ')', '-', '!', '?', '/', ';', ':', '"' };
        static char[] Phrase;
        char[] EncryptedPhrase;
        char[] DecipherPhrase;

        public EncryptCezar(int k, string Phr)
        {
            key = k;
            Phrase = Phr.ToCharArray();
            EncryptedPhrase = new char[Phrase.Length];
            DecipherPhrase = new char[Phrase.Length];
        }

        public EncryptCezar(int k, string Phr, int smth)
        {
            key = k;
            Phrase = Phr.ToCharArray();
            DecipherPhrase = new char[Phrase.Length];
            UnicDecipher = smth;
        }

        private void Encrypt(char[] Alphabet)
        {
            for (int i = 0; i < Phrase.Length; i++)
            {
                for (int j = 0; j < Alphabet.Length; j++)
                {
                    if (Phrase[i] == Alphabet[j])
                    {
                        if ((j + key) > Alphabet.Length)
                        {
                            helper = Alphabet.Length - j;
                            saver = j;
                            helping_key = key - helper;
                            j = 0;
                            j = helping_key;
                            EncryptedPhrase[i] = Alphabet[j];
                            j = saver;
                        }
                        else if ((j + key) == Alphabet.Length)
                        {
                            j = 0;
                            EncryptedPhrase[i] = Alphabet[j];
                        }
                        else
                        {
                            EncryptedPhrase[i] = Alphabet[j + key];
                        }
                        break;
                    }
                }
            }
        }

        public void EncryptEnglish()
        {
            for (int i = 0; i < Phrase.Length; i++)
            {
                for (int it = 0; it < Symbols.Length; it++)
                {
                    if (Phrase[i] != Symbols[it])
                    {
                        if (char.IsUpper(Phrase[i]) == true)
                        {
                            Encrypt(EnglishAlphabetBig);
                        }
                        else
                        {
                            Encrypt(EnglishAlphabetSmall);
                        }
                    }
                    else
                    {
                        EncryptedPhrase[i] = Symbols[it];
                    }
                }
            }

            for (int it = 0; it < EncryptedPhrase.Length; it++)
            {
                Console.Write(EncryptedPhrase[it]);
            }
            Console.WriteLine();
        }

        public void EncryptRussian()
        {
            for (int i = 0; i < Phrase.Length; i++)
            {
                for (int it = 0; it < Symbols.Length; it++)
                {
                    if (Phrase[i] != Symbols[it])
                    {
                        if (char.IsUpper(Phrase[i]) == true)
                        {
                            Encrypt(RussianAlphabetBig);
                        }
                        else
                        {
                            Encrypt(RussianAlphabetSmall);
                        }
                    }
                    else
                    {
                        EncryptedPhrase[i] = Symbols[it];
                    }
                }
            }

            for (int it = 0; it < EncryptedPhrase.Length; it++)
            {
                Console.Write(EncryptedPhrase[it]);
            }
            Console.WriteLine();
        }

        private void Decipher(char[] Alphabet)
        {
            if (UnicDecipher == 0)
            {
                for (int i = 0; i < EncryptedPhrase.Length; i++)
                {
                    for (int j = 0; j < Alphabet.Length; j++)
                    {
                        if (EncryptedPhrase[i] == Alphabet[j])
                        {
                            if ((j - key) <= 0)
                            {
                                helping_key = Abs(j - key);
                                helper = Alphabet.Length - helping_key;
                                DecipherPhrase[i] = Alphabet[helper];
                            }
                            else
                            {
                                DecipherPhrase[i] = Alphabet[j - key];
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Phrase.Length; i++)
                {
                    for (int j = 0; j < Alphabet.Length; j++)
                    {

                        if (Phrase[i] == Alphabet[j])
                        {
                            if ((j - key) <= 0)
                            {
                                helping_key = Abs(j - key);
                                helper = Alphabet.Length - helping_key;
                                DecipherPhrase[i] = Alphabet[helper];
                            }
                            else
                            {
                                DecipherPhrase[i] = Alphabet[j - key];
                            }
                            break;
                        }
                    }
                }
            }
        }

        public void DecipherEnglish()
        {
            if (UnicDecipher == 0)
            {
                for (int i = 0; i < EncryptedPhrase.Length; i++)
                {
                    for (int it = 0; it < Symbols.Length; it++)
                    {
                        if (EncryptedPhrase[i] != Symbols[it])
                        {
                            if (char.IsUpper(Phrase[i]) == true)
                            {
                                Decipher(EnglishAlphabetBig);
                            }
                            else
                            {
                                Decipher(EnglishAlphabetSmall);
                            }
                        }
                        else
                        {
                            DecipherPhrase[i] = Symbols[it];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Phrase.Length; i++)
                {
                    for (int it = 0; it < Symbols.Length; it++)
                    {
                        if (Phrase[i] != Symbols[it])
                        {
                            if (char.IsUpper(Phrase[i]) == true)
                            {
                                Decipher(EnglishAlphabetBig);
                            }
                            else
                            {
                                Decipher(EnglishAlphabetSmall);
                            }
                        }
                        else
                        {
                            DecipherPhrase[i] = Symbols[it];
                        }
                    }
                }
            }
            for (int it = 0; it < DecipherPhrase.Length; it++)
            {
                Console.Write(DecipherPhrase[it]);
            }
            Console.WriteLine();
        }

        public void DecipherRussian()
        {
            if (UnicDecipher == 0)
            {
                for (int i = 0; i < EncryptedPhrase.Length; i++)
                {
                    for (int it = 0; it < Symbols.Length; it++)
                    {
                        if (EncryptedPhrase[i] != Symbols[it])
                        {
                            if (char.IsUpper(Phrase[i]) == true)
                            {
                                Decipher(RussianAlphabetBig);
                            }
                            else
                            {
                                Decipher(RussianAlphabetSmall);
                            }
                        }
                        else
                        {
                            DecipherPhrase[i] = Symbols[it];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Phrase.Length; i++)
                {
                    for (int it = 0; it < Symbols.Length; it++)
                    {
                        if (Phrase[i] != Symbols[it])
                        {
                            if (char.IsUpper(Phrase[i]) == true)
                            {
                                Decipher(RussianAlphabetBig);
                            }
                            else
                            {
                                Decipher(RussianAlphabetSmall);
                            }
                        }
                        else
                        {
                            DecipherPhrase[i] = Symbols[it];
                        }
                    }
                }
            }
            for (int it = 0; it < DecipherPhrase.Length; it++)
            {
                Console.Write(DecipherPhrase[it]);
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int key, trigger;
            String Phrase;
            char language, decision;

            Console.WriteLine("Введите ключ шифрования: ");
            Console.WriteLine("Ключ шифрования - это число на которое будут сдвинуты все буквы в алфавите.");
            key = Convert.ToInt32(Console.ReadLine());

            while(key <= 0)
            {
                Console.WriteLine("Вы ввели неверное значение. Повторите попытку: ");
                key = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Если хотите зашифровать фразу, введите 1.\nЕсли хотите расшифровать введите что - то еще: ");
            trigger = Convert.ToInt32(Console.ReadLine());

            if(trigger == 1)
            {
                Console.WriteLine("Если хотите зашифровать фразу на английском нажмите e.\nЕсли на русском что - то еще: ");
                language = Convert.ToChar(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Введите фразу, которую хотите зашифровать с помощью шифра Цезаря: ");
                Phrase = Convert.ToString(Console.ReadLine());

                EncryptCezar encrypt = new EncryptCezar(key, Phrase);

                Console.WriteLine();
                Console.WriteLine("Зашифрованная фраза: ");
                Console.WriteLine();

                if (language == 'e')
                {
                    encrypt.EncryptEnglish();
                }
                else
                {
                    encrypt.EncryptRussian();
                }

                Console.WriteLine("Хотите расшифровать только что зашифрованную фразу? Введите y, если да.");
                decision = Convert.ToChar(Console.ReadLine());

                if (decision == 'y')
                {
                    if (language == 'e')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Расшифрованная фраза: ");
                        Console.WriteLine();

                        encrypt.DecipherEnglish();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Расшифрованная фраза: ");
                        Console.WriteLine();

                        encrypt.DecipherRussian();
                    }
                }
            }
            else
            {
                Console.WriteLine("Если хотите расшифровать фразу на английском нажмите e.\nЕсли на русском что - то еще: ");
                language = Convert.ToChar(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Введите фразу, которую хотите расшифровать с помощью шифра Цезаря: ");
                Phrase = Convert.ToString(Console.ReadLine());

                EncryptCezar encrypt = new EncryptCezar(key, Phrase, 2);

                Console.WriteLine();
                Console.WriteLine("Расшифрованная фраза: ");
                Console.WriteLine();

                if (language == 'e')
                {
                    encrypt.DecipherEnglish();
                }
                else
                {
                    encrypt.DecipherRussian();
                }
            }
        }
    }
}
