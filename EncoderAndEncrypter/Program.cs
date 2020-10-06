using EncoderAndEncrypter.Models;
using System;
using System.Linq;
using System.Text;

namespace EncoderAndEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 1 - Encoding and Encryption");
            Console.WriteLine("--------------------------------------\n");
            //String to Binary Conversion
            Console.WriteLine("String to Binary Conversion");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter your name: ");
            var fullName = Console.ReadLine(); //Asks for the input
            string binaryValue = Models.Converter.StringToBinary(fullName);
            Console.WriteLine($"Entered text: {fullName}\nConverted Binary value: {binaryValue}\n");
            Console.WriteLine("----------------------------------------------------------------------------------\n");
            //Binary to String conversion
            Console.WriteLine("Binary to String Conversion");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter the Binary input: ");
            var ascii = Console.ReadLine();
            string textFromBinary = Models.Converter.BinaryToString(ascii);
            Console.WriteLine($"Entered Binary Value: {ascii}\nConverted Text: {textFromBinary}\n");
            Console.WriteLine("----------------------------------------------------------------------------------\n");
            //String to Hexadecimal
            Console.WriteLine("String to Hexadecimal Conversion");
            Console.WriteLine("--------------------------------");
            string hexaDecimalValue = Converter.StringToHex(fullName);
            Console.WriteLine($"Entered text: {fullName}\nConverted Hexadecimal value: {hexaDecimalValue}\n");
            Console.WriteLine("----------------------------------------------------------------------------------\n");
            //Hexadecimal to string
            Console.WriteLine("Hexadecimal to String Conversion");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Enter the Hexadecimal input: ");
            var hexa = Console.ReadLine();
            string hexaToAscii = Converter.HexToString(hexa);
            Console.WriteLine($"Entered HexaDecimal vaue: {hexa}\nConverted string is: {hexaToAscii}\n");
            Console.WriteLine("----------------------------------------------------------------------------------\n");
            //String to Base64
            Console.WriteLine("String to Base64 Conversion");
            Console.WriteLine("---------------------------");
            string base64Val = Converter.StringToBase64(fullName);
            Console.WriteLine($"Entered text: {fullName}\nConverted Base64 value: {base64Val}\n");
            Console.WriteLine("----------------------------------------------------------------------------------\n");
            //Base64 to String
            Console.WriteLine("Base64 to String Conversion");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter the Base64 input: ");
            var base64Input = Console.ReadLine();
            string stringFromBase64 = Converter.Base64ToString(base64Input);
            Console.WriteLine($"Entered Base64 input: {base64Input}\nConverted string is: {stringFromBase64}\n");
            Console.WriteLine("----------------------------------------------------------------------------------\n");

            int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //For displaying the cipher
            int encryptionDepth = 20; //Encryption Depth 20
            //Convert the text input to a byte array with name fullNameBytes
            byte[] fullNameBytes = Converter.ConvertToByteArray(fullName);
            //Deep Encrytion by passing the byte array fullNameBytes
            string nameDeepEncryptWithCipher = Converter.DeepEncryptWithCipher(fullNameBytes, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}}");
            Console.WriteLine($"Deep Encrypted output is: {nameDeepEncryptWithCipher}\n");
            Console.WriteLine("----------------------------------------------------------------------------------\n");
            //Using the encrypted string to deep decrypt
            //Convert the encrypted string to a byte array
            byte[] encryptedByteArray = Converter.ConvertToByteArray(nameDeepEncryptWithCipher);
            string nameDeepDecryptWithCipher = Converter.DeepDecryptWithCipher(encryptedByteArray, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}}");
            Console.WriteLine($"Deep Decrypted output is: {nameDeepDecryptWithCipher}\n");
            Console.WriteLine("----------------------------------------------------------------------------------\n");
        }
    }
}
