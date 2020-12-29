using System;
using System.Collections.Generic;
using System.Text;

namespace FPEDemo
{
    static class Utility
    {
        const string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static int[] toBase62(string s)
        {
            List<int> intList = new List<int>();
            foreach (char c in s)
            {
                int x = alphabet.IndexOf(c);
                intList.Add(x);
            }

            return intList.ToArray();
        }

        public static string fromBase62(int[] arr)
        {
            var builder = new StringBuilder();

            foreach(int i in arr)
            {
                char c = alphabet[i];
                builder.Append(c);
            }

            return builder.ToString();
        }

    }
}
