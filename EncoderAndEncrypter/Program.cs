using System;

namespace EncoderAndEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter your name: ");
            var fullName = Console.ReadLine();
            string binaryValue2 = Models.Converter.StringToBinary2(fullName);
            Console.WriteLine($"Text: {fullName}\nBinary: {binaryValue2}");
        }
    }
}
