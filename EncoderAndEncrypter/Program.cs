using EncoderAndEncrypter.Models;
using System;

namespace EncoderAndEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            //String to Binary Conversion
            Console.WriteLine("String to Binary Conversion");
            Console.WriteLine("Enter your name: ");
            var fullName = Console.ReadLine(); //Asks for the input
            string binaryValue = Models.Converter.StringToBinary(fullName);
            Console.WriteLine($"Entered text: {fullName}\nConverted Binary value: {binaryValue}");
            
            //Binary to String conversion
            Console.WriteLine("\n\nBinary to String Conversion");
            Console.WriteLine("Enter the Binary input: ");
            var ascii = Console.ReadLine();
            string textFromBinary = Models.Converter.BinaryToString(ascii);
            Console.WriteLine($"Entered Binary Value: {ascii}\nConverted Text: {textFromBinary}\n\n");

            //String to Hexadecimal
            string hexadecimalValue = Converter.StringToHex(fullName);
            Console.WriteLine($"Entered text: {fullName}\nConverted Hexadecimal value: {hexadecimalValue}\n\n");

        }
    }
}
