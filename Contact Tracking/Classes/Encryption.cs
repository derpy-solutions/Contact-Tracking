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


        public static string Encrypt_OG(string PlainText)

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

            // ConsoleEx.WriteLine("Not able to encrypt:");
            // ConsoleEx.WriteLine(PlainText);
            return PlainText;
        }


        public static string Decrypt_OG(string CipherText)

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

            //ConsoleEx.WriteLine("Not able to deciper:");
            //ConsoleEx.WriteLine(CipherText);
            return CipherText;
        }

        public static string Encrypt(string plainText)
        {
            var Key = Convert.FromBase64String(Properties.Settings.Default.SecurityKey);
            var IV = Convert.FromBase64String(Properties.Settings.Default.SecurityIV);

            if (plainText != null && plainText.Length > 0)
            {
                byte[] encrypted;

                // Create an AesCryptoServiceProvider object
                // with the specified key and IV.
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    // Create an encryptor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }

                // Return the encrypted bytes from the memory stream.
                return Convert.ToBase64String(encrypted);
            }
            else
                return plainText;
        }

        public static string Decrypt(string encrypted)
        {

            if (encrypted != null && IsBase64String(encrypted))
            {
                byte[] cipherText = Convert.FromBase64String(encrypted);

                if (cipherText != null && cipherText.Length > 0)
                {
                    var Key = Convert.FromBase64String(Properties.Settings.Default.SecurityKey);
                    var IV = Convert.FromBase64String(Properties.Settings.Default.SecurityIV);

                    // Declare the string used to hold
                    // the decrypted text.
                    string plaintext = null;

                    // Create an AesCryptoServiceProvider object
                    // with the specified key and IV.
                    using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                    {
                        aesAlg.Key = Key;
                        aesAlg.IV = IV;

                        // Create a decryptor to perform the stream transform.
                        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                        // Create the streams used for decryption.
                        using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                                {

                                    // Read the decrypted bytes from the decrypting stream
                                    // and place them in a string.
                                    plaintext = srDecrypt.ReadToEnd();
                                }
                            }
                        }
                    }

                    return plaintext;
                }
                else
                return encrypted;
            }
            else
                return encrypted;
        }
    }
}
