# Format Preserving Encryption (FPE) Demo for .NET

This is a sample application based on [an implementation of the FF1 algorithm written by Matthias Hunstock](https://github.com/a-tze/FPE.Net) and [forked to add support for .Net 5](https://github.com/travisnielsen/FPE.Net). It works by tokenizing a given string input into a list of continuous base62 characters (A-Z,a-z,0-9). Each base62 token is encrypted with FF1 and placed into its original position from the input string. Out-of-range characters, such as '-' and spaces, are left in place. Example:

```bash
❯ dotnet run
Enter text: (123) 456-789
Ciphertext: (sCO) Caj-Lbc
Plaintext: (123) 456-789
```

> NOTE: This code is *proof-of-concept only* and has not been optimized for performance. For convenience, a sample AES key is provided and it is *not to be used* for anything outside of demo purposes.
