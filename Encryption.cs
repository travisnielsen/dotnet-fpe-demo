using System;
using FPE.Net;

namespace FPEDemo
{
    public class Encryption
    {
        private FF1 crypto;
        private byte[] key;
        private byte[] tweak;

        public Encryption(byte[] k, byte[] t)
        {
            // Initialize FF1 with a base62 alphabet (a-zA-Z0-9)
            crypto = new FF1(62, 8);
            this.key = k;
            this.tweak = t;
        }

        public string Encrypt(string s)
        {
            int[] plainText = Utility.toBase62(s);
            int[] cipherText = crypto.encrypt(key, tweak, plainText);
            return Utility.fromBase62(cipherText);
        }

        public string Decrypt(string s)
        {
            int[] cipherText = Utility.toBase62(s);
            int[] plainText = crypto.decrypt(key, tweak, cipherText);
            return Utility.fromBase62(plainText);
        }

    }

}