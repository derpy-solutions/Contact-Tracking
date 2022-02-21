using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Contact_Tracking
{
    public class Encryption
    {
        
        public static bool IsBase64String(string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }


        public static string Encrypt(string PlainText)

        {
            var key = Properties.Settings.Default.SecurityKey;

            if (PlainText != null)
            {
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(PlainText);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }
                return Convert.ToBase64String(array);
            }

           // Console.WriteLine("Not able to encrypt:");
            // Console.WriteLine(PlainText);
            return PlainText;
        }


        public static string Decrypt(string CipherText)

        {
            var key = Properties.Settings.Default.SecurityKey;

            if (CipherText != null && IsBase64String(CipherText))
            {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(CipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }

            //Console.WriteLine("Not able to deciper:");
            //Console.WriteLine(CipherText);
            return CipherText;
        }
    }
}
