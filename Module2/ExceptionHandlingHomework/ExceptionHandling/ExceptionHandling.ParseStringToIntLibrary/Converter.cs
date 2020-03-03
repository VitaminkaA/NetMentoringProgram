using System;

namespace ExceptionHandling.ParseStringToIntLibrary
{
    public static class Converter
    {
        public static int StringToInt(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentException("The entered string cannot be null, empty or white space.");

            var isNegative = false;
            var length = str.Length;
            var charEnumerator = str.GetEnumerator();
            charEnumerator.MoveNext();

            if (charEnumerator.Current == '-')
            {
                isNegative = true;
                charEnumerator.MoveNext();
            }
            if (charEnumerator.Current == '0' && length > 1)
                throw new ArgumentException("Number cannot start from zero.");

            var number = CharToInt(charEnumerator.Current);
            while (charEnumerator.MoveNext())
            {
                try
                {
                    number = checked(number * 10 + CharToInt(charEnumerator.Current));
                }
                catch (OverflowException)
                {
                    throw new ArgumentException("Value was either too large or too small for an Int32.");
                }
            }
            charEnumerator.Dispose();
            return isNegative ? -number : number;
        }

        public static int CharToInt(char character)
            => char.IsDigit(character)
                ? character - '0'
                : throw new ArgumentException("Character is not a number");
    }
}