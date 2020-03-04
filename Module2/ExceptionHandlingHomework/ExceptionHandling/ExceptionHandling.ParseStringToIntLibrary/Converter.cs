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
            var number = 0;
            var charEnumerator = str.GetEnumerator();
            charEnumerator.MoveNext();

            while (char.IsWhiteSpace(charEnumerator.Current) && charEnumerator.MoveNext()) ;

            if (charEnumerator.Current == '-')
            {
                isNegative = true;
                charEnumerator.MoveNext();
            }

            while (charEnumerator.Current == '0')
                if (!charEnumerator.MoveNext())
                    return number;

            if (!char.IsWhiteSpace(charEnumerator.Current))
                number = CharToInt(charEnumerator.Current);

            while (charEnumerator.MoveNext() && !char.IsWhiteSpace(charEnumerator.Current))
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
            while (charEnumerator.MoveNext())
                if (!char.IsWhiteSpace(charEnumerator.Current))
                    throw new ArgumentException("Character is not a number");

            charEnumerator.Dispose();
            return isNegative ? -number : number;
        }

        public static int CharToInt(char character)
            => char.IsDigit(character)
                ? character - '0'
                : throw new ArgumentException("Character is not a number");
    }
}