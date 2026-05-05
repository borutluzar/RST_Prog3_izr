using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3_izr
{
    public static class Extensions
    {
        public static int CountVowels(this string word)
        {
            List<char> lstVowels = new() { 'a', 'e', 'i', 'o', 'u' };

            int count = 0;
            foreach(var chr in word.ToLower())
            {
                if (lstVowels.Contains(chr))
                    count++;
            }
            return count;
        }

        public static int CountCharacters(this string word, char chr)
        {
            int count = 0;
            chr = Char.ToLower(chr);
            foreach (var c in word.ToLower())
            {
                if (chr == c)
                    count++;
            }
            return count;
        }
    }
}
