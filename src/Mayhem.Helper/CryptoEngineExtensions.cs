using System;
using System.Security.Cryptography;
using System.Text;

namespace Mayhem.Helper
{
    public static class CryptoEngineExtensions
    {
        public static string Encrypt(this string input, string key)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new()
            {
                Key = UTF8Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(this string input, string key)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new()
            {
                Key = UTF8Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static bool TryDecrypt(this string input, string key)
        {
            try
            {
                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new()
                {
                    Key = UTF8Encoding.UTF8.GetBytes(key),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                UTF8Encoding.UTF8.GetString(resultArray);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
