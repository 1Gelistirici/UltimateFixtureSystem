using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Functions
{
    public class Hashing
    {

        public static string SHA_256_Encrypting(string password)
        {
            password += "StrongPassword";
            SHA256 sha = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] shaBytes = sha.ComputeHash(passwordBytes);
            return HashToByte(shaBytes);
        }

        public static string SHA_512_Encrypting(string password)
        {
            password += "StrongPassword";
            SHA512 sha = SHA512.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] sha256byte = sha.ComputeHash(passwordBytes);
            return HashToByte(sha256byte);
        }

        private static string HashToByte(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            foreach (byte item in hash)
            {
                result.Append(item.ToString("x2"));
            }

            string hashPassword = result.ToString();
            hashPassword = hashPassword.Substring(1, hashPassword.Length - 1).Substring(0, hashPassword.Length - 2);
            return hashPassword;
        }



    }
}
