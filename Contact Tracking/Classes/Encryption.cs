using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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
            if (PlainText != null)
            {
                PlainText = PlainText.ToString();
                //Getting the bytes of Input String.

                byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);



                MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();



                //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.

                byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(Properties.Settings.Default.SecurityKey));



                //De-allocatinng the memory after doing the Job.

                objMD5CryptoService.Clear();



                var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();



                //Assigning the Security key to the TripleDES Service Provider.

                objTripleDESCryptoService.Key = securityKeyArray;



                //Mode of the Crypto service is Electronic Code Book.

                objTripleDESCryptoService.Mode = CipherMode.ECB;



                //Padding Mode is PKCS7 if there is any extra byte is added.

                objTripleDESCryptoService.Padding = PaddingMode.PKCS7;



                var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();



                //Transform the bytes array to resultArray

                byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);



                //Releasing the Memory Occupied by TripleDES Service Provider for Encryption.

                objTripleDESCryptoService.Clear();



                //Convert and return the encrypted data/byte into string format.

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            else
                return PlainText;
        }


        public static string Decrypt(string CipherText)

        {
            if (CipherText != null && IsBase64String(CipherText))
            {
                byte[] toEncryptArray = Convert.FromBase64String(CipherText);



                MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();



                //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.

                byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(Properties.Settings.Default.SecurityKey));



                //De-allocatinng the memory after doing the Job.

                objMD5CryptoService.Clear();



                var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();



                //Assigning the Security key to the TripleDES Service Provider.

                objTripleDESCryptoService.Key = securityKeyArray;



                //Mode of the Crypto service is Electronic Code Book.

                objTripleDESCryptoService.Mode = CipherMode.ECB;



                //Padding Mode is PKCS7 if there is any extra byte is added.

                objTripleDESCryptoService.Padding = PaddingMode.PKCS7;



                var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();



                //Transform the bytes array to resultArray

                byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);



                //Releasing the Memory Occupied by TripleDES Service Provider for Decryption.          

                objTripleDESCryptoService.Clear();



                //Convert and return the decrypted data/byte into string format.

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            else
                Console.WriteLine("Not able to deciper:" );
                Console.WriteLine(CipherText);

            return CipherText;
        }
    }
}
