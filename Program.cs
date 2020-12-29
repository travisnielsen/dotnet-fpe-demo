using System;
using System.Text.RegularExpressions;

namespace FPEDemo
{
    class Program
    {
        enum Action { Encrypt, Decrypt };
        static void Main(string[] args)
        {
            byte[] key = { (byte) 0x2B, (byte) 0x7E, (byte) 0x15, (byte) 0x16, (byte) 0x28, (byte) 0xAE, (byte) 0xD2,
                (byte) 0xA6, (byte) 0xAB, (byte) 0xF7, (byte) 0x15, (byte) 0x88, (byte) 0x09, (byte) 0xCF, (byte) 0x4F,
                (byte) 0x3C };
            
            byte[] tweak = new byte[0];

            Encryption encryption = new Encryption(key, tweak);

            Console.Write("Enter text: ");
            string inputText = Console.ReadLine();

            string encryptedText = ProcessText(inputText, encryption, Action.Encrypt);
            Console.WriteLine("Ciphertext: " + encryptedText);

            string decryptedText = ProcessText(encryptedText, encryption, Action.Decrypt);
            Console.WriteLine("Plaintext: " + decryptedText);
        }

        static string ProcessText(string s, Encryption encryption, Action a)
        {
            string newText = s;
            Regex rx = new Regex(@"[a-zA-Z0-9]+", RegexOptions.Compiled);

            MatchCollection matches = rx.Matches(s);

            foreach (Match match in matches)
            {
                string modText;

                if (a == Action.Encrypt)
                    modText = encryption.Encrypt(match.Value);
                else
                    modText = encryption.Decrypt(match.Value);
                
                newText = newText.Replace(match.Value, modText);
            }

            return newText;

        }

    }
}
