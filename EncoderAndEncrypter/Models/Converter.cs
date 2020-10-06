using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EncoderAndEncrypter.Models
{
    class Converter
    {
        /// <summary>
        /// A more mathmatical approach to ASCII to Binary conversion
        /// https://forums.asp.net/t/1713174.aspx?How+to+convert+ASCII+value+to+binary+value+using+c+net
        /// </summary>
        /// <param name="data">String to convert</param>
        /// <returns>Binary encoded string</returns>
        public static string StringToBinary(string data)
        {
            string converted = string.Empty;
            // convert string to byte array
            byte[] bytes = Encoding.ASCII.GetBytes(data);
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    converted += (bytes[i] & 0x80) > 0 ? "1" : "0";
                    bytes[i] <<= 1;
                }
            }
            return converted;
        }

        /// <summary>
        /// Convert a Binary text string to a Text string
        /// </summary>
        /// <param name="text">Binary encoded string</param>
        /// <returns>Text string</returns>
        public static string BinaryToString(string text)
        {
            List<byte> bytes = new List<byte>();

            for (int i = 0; i < text.Length; i += 8)
            {
                bytes.Add(Convert.ToByte(text.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(bytes.ToArray());
        }

        /// <summary>
        /// An approach to ASCII to Hexadecimal conversion using ToString("X2")
        /// </summary>
        /// <param name="data">String to convert</param>
        /// <returns></returns>
        public static string StringToHex(string data)
        {
            StringBuilder sb = new StringBuilder();

            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            foreach (byte bytepart in bytearray)
            {
                sb.Append(bytepart.ToString("X2"));
            }

            return sb.ToString().ToUpper();
        }

        /// <summary>
        /// Converts a Hexadecimal string to ASCII string
        /// </summary>
        /// <param name="hexString">Hexadecimal string</param>
        /// <returns>ASCII string</returns>
        public static string HexToString(string hexString)
        {
            if (hexString == null || (hexString.Length & 1) == 1)
            {
                throw new ArgumentException();
            }
            var sb = new StringBuilder();
            for (var i = 0; i < hexString.Length; i += 2)
            {
                var hexChar = hexString.Substring(i, 2);
                sb.Append((char)Convert.ToByte(hexChar, 16));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Encodes a String to a Base64 String
        /// </summary>
        /// <param name="data">String data</param>
        /// <returns>Base64 Encoded String</returns>
        public static string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            string result = Convert.ToBase64String(bytearray);

            return result;
        }

        /// <summary>
        /// Converts a Base64 string to decoded String
        /// </summary>
        /// <param name="base64String">Base64 encoded string</param>
        /// <returns>Decoded String from Base64</returns>
        public static string Base64ToString(string base64String)
        {
            byte[] bytearray = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(bytearray))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
        }

        /// </summary>
        /// converts the string to byteArray
        /// <param name="text">String to convert</param>
        /// <returns>Byte Array of the string</returns>
        public static byte[] ConvertToByteArray(string text)
        {
            byte[] convertedByteArray = Encoding.Unicode.GetBytes(text);
            return convertedByteArray;
        }

        /// </summary>
        /// converts the byte array to string
        /// <param name="byteArray">String to convert</param>
        /// <returns>String converted from Byte array</returns>
        public static string ConvertToString(byte[] byteArray)
        {
            string convertedString = Encoding.Unicode.GetString(byteArray);
            return convertedString;
        }
        /// </summary>
        /// Encrypts the byte array with cipher specified times
        /// <param name="fullNameBytes">Byte array to encrypt</param>
        /// <param name="encryptionCipher">new[] { 1,2,3,4,5,6 }</param>
        /// <param name="encryptionDepth">Depth of the encryption</param>
        /// <returns>Encrypted String</returns>
        public static string DeepEncryptWithCipher(byte[] fullNameBytes, int[] encryptionCipher, int encryptionDepth)
        {
            //Encrypt fullNameBytes encryptionDepth times
            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                //Apply Encryption Cipher on current value of result
                fullNameBytes = EncryptWithCipher(fullNameBytes, encryptionCipher);
            }
            return ConvertToString(fullNameBytes);
        }

        /// <summary>
        /// Applies a Cipher to a string
        /// </summary>
        /// <param name="fullNameBytes">Byte array to encrypt</param>
        /// <param name="encryptionCipher">new[] { 1,2,3,4,5,6 }</param>
        /// <returns> encrypted byte array</returns>
        public static byte[] EncryptWithCipher(byte[] fullNameBytes, int[] encryptionCipher)
        {
            if (encryptionCipher == null || encryptionCipher.Length == 0)
            {
                return fullNameBytes;
            }
            //Build byte array from the original byte array that will receive the encrypted values
            byte[] byteArrayResult = fullNameBytes;
            //Apply Encryption Cipher
            for (int i = 0; i < fullNameBytes.Length; i++)
            {
                //Set the Cipher index
                int encryptionCipherIndex = i;
                //We reset the current encryption position to 0 to restart at the beginning of the encryptionCipher
                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    //Reset the cryper postion to zero and restart sequence
                    encryptionCipherIndex = 0;
                }

                //Change the value of the current character by the values received from the encryptionCipher array
                if (fullNameBytes[i] != 0)
                {
                    byteArrayResult[i] = (byte)(fullNameBytes[i] + encryptionCipher[encryptionCipherIndex]);
                }
            }
            return byteArrayResult;
        }

        /// <summary>
        /// Decrypts a deep cipher encrypted string
        /// </summary>
        /// <param name="encryptedByteArray">Cipher encrypted byte array</param>
        /// <param name="encryptionCipher">Sequence of whole numbers in an array</param>
        /// <param name="encryptionDepth">Depth of the encryption</param>
        /// <returns>Decrypted string</returns>
        public static string DeepDecryptWithCipher(byte[] encryptedByteArray, int[] encryptionCipher, int encryptionDepth)
        {
            //Encrypt result encryptionDepth times
            for (int depth = 0; depth < encryptionDepth; depth++)
            {
                //Apply Encryption Cipher on current value of result
                encryptedByteArray = DecryptWithCipher(encryptedByteArray, encryptionCipher);
            }
            return ConvertToString(encryptedByteArray);
        }

        /// <summary>
        /// Decrypts a cipher encrypted byte array
        /// </summary>
        /// <param name="encryptedByteArray">Encrypted Byte array</param>
        /// <param name="encryptionCipher">Sequence of whole numbers in an array</param>
        /// <returns> Decrypted byte array</returns>
        public static byte[] DecryptWithCipher(byte[] encryptedByteArray, int[] encryptionCipher)
        {
            //Build byte array from the original byte array that will receive the encrypted values
            byte[] byteArrayResult = encryptedByteArray;
            int encryptionCipherIndex = 0;
            for (int i = 0; i < encryptedByteArray.Length; i++)
            {
                //Set the Cipher index
                encryptionCipherIndex = i;
                //We reset the current encryption position to 0 to restart at the beginning of the encryptionCipher
                if (encryptionCipherIndex >= encryptionCipher.Length)
                {
                    //Reset the cryper postion to zero and restart sequence
                    encryptionCipherIndex = 0;
                }
                if (encryptedByteArray[i] != 0)
                {
                    byteArrayResult[i] = (byte)(encryptedByteArray[i] - encryptionCipher[encryptionCipherIndex]);
                }
            }
            return byteArrayResult;
        }
    }
}
