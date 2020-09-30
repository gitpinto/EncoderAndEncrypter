using System;

namespace EncoderAndEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String to Binary Conversion");
            Console.WriteLine("Enter your name: ");
            var fullName = Console.ReadLine();
            string binaryValue2 = Models.Converter.StringToBinary2(fullName);
            Console.WriteLine($"Entered text: {fullName}\nConverted Binary value: {binaryValue2}");
            Console.WriteLine("\n\nBinary to String Conversion");
            Console.WriteLine("Enter the Binary input: ");
            var ascii = Console.ReadLine();
            string textFromBinary = Models.Converter.BinaryToString(ascii);
            Console.WriteLine($"Entered Binary Value: {ascii}\nConverted Text: {textFromBinary}");
        }
    }
}
