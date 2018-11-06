using System;
using Moe.Rövarspråket.TranslatorConsole.Decoders;
using Moe.Rövarspråket.TranslatorConsole.Encoders;

namespace Moe.Rövarspråket.TranslatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Rövarspråket translation service.");

            while (true)
            {
                Console.WriteLine("Choose what you want to do:");
                Console.WriteLine("1. Translate to Rövarsrpåket (encode)");
                Console.WriteLine("2. Translate from Rövarsrpåket (decode)");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1": Encode();
                        break;

                    case "2": Decode();
                        break;

                    default: continue;
                }

                Console.WriteLine("Thank you for using the Rövarspråket translation service.");
                break;
            }

            Console.WriteLine("Press ENTER-key to exit.");
            Console.ReadLine();
        }

        private static void Encode()
        {
            var encoder = new RövarspråketRegexEncoder();

            while (true)
            {
                Console.WriteLine("Enter text to encode: ('exit' to quit)");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && input.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                    break;

                Console.WriteLine();
                Console.WriteLine("Result: " + encoder.Encode(input));
                Console.WriteLine();
            }
        }

        private static void Decode()
        {
            var decoder = new RövarspråketRegexDecoder();

            while (true)
            {
                Console.WriteLine("Enter text to decode: ('exit' to quit)");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && input.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                    break;

                Console.WriteLine();
                Console.WriteLine("Result: " + decoder.Decode(input));
                Console.WriteLine();
            }
        }
    }
}
