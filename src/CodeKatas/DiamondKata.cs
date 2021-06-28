using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeKatas
{
    public static class DiamondKata
    {
        public static string CreateDiamond(char input)
        {
            var character = char.ToUpper(input);
            if (char.IsLetter(character))
            {
                return character switch
                {
                    'A' => "A",
                    _ => GetDiamond(character)
                };
            }
            else
            {
                throw new ArgumentOutOfRangeException("input", $"Received invalid input -'{input}'. Only letters are allowed!");
            }
        }

        private static string GetDiamond(char inputLetter)
        {
            char startingLetter = 'A';

            var halfLength = inputLetter - startingLetter;

            //2 times padding length plus character
            var maxLength = 2 * halfLength + 1;

            List<string> builder = new();
            builder.Add($"{GetPadding(halfLength)}{startingLetter}{GetPadding(halfLength)}");

            for (char letter = 'B'; letter <= inputLetter; letter++)
            {
                var paddingLength = inputLetter - letter;

                //maxlength - (leftpad + rightpad) - 2 letters
                var midPaddingLength = maxLength - (2 * paddingLength) - 2;

                builder.Add($"{GetPadding(paddingLength)}{letter}{GetPadding(midPaddingLength)}{letter}{GetPadding(paddingLength)}");
            }

            return
                $"{string.Join(Environment.NewLine, builder)}" +
                $"{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, builder.AsEnumerable().Reverse().Skip(1))}";
        }

        private static string GetPadding(int length) => new string(' ', length);
    }
}