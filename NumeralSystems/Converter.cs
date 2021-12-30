using System;
using System.Globalization;
using System.Text;

namespace NumeralSystems
{
    public static class Converter
    {
        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveOctal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number is less than zero", nameof(number));
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = number; i > 0; i /= 8)
            {
                stringBuilder.Append(i % 8);
            }

            char[] arr = stringBuilder.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string GetPositiveOctall(this long number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number is less than zero", nameof(number));
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (long i = number + 1; i > 0; i /= 8)
            {
                stringBuilder.Append(i % 8);
            }

            char[] arr = stringBuilder.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the decimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveDecimal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number is less than zero", nameof(number));
            }

            return number.ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveHex(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number is less than zero", nameof(number));
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = number; i > 0; i /= 16)
            {
                if (i % 16 == 10)
                {
                    stringBuilder.Append("A");
                }
                else if (i % 16 == 11)
                {
                    stringBuilder.Append("B");
                }
                else if (i % 16 == 12)
                {
                    stringBuilder.Append("C");
                }
                else if (i % 16 == 13)
                {
                    stringBuilder.Append("D");
                }
                else if (i % 16 == 14)
                {
                    stringBuilder.Append("E");
                }
                else if (i % 16 == 15)
                {
                    stringBuilder.Append("F");
                }
                else
                {
                    stringBuilder.Append(i % 16);
                }
            }

            char[] arr = stringBuilder.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string GetPositiveHexl(this long number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number is less than zero", nameof(number));
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (long i = number + 1; i > 0; i /= 16)
            {
                if (i % 16 == 10)
                {
                    stringBuilder.Append("A");
                }
                else if (i % 16 == 11)
                {
                    stringBuilder.Append("B");
                }
                else if (i % 16 == 12)
                {
                    stringBuilder.Append("C");
                }
                else if (i % 16 == 13)
                {
                    stringBuilder.Append("D");
                }
                else if (i % 16 == 14)
                {
                    stringBuilder.Append("E");
                }
                else if (i % 16 == 15)
                {
                    stringBuilder.Append("F");
                }
                else
                {
                    stringBuilder.Append(i % 16);
                }
            }

            char[] arr = stringBuilder.ToString().ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveRadix(this int number, int radix)
        {
            if (number < 0)
            {
                throw new ArgumentException("number is less than zero", nameof(number));
            }

            if (radix == 8)
            {
                return GetPositiveOctal(number);
            }
            else if (radix == 10)
            {
                return GetPositiveDecimal(number);
            }
            else if (radix == 16)
            {
                return GetPositiveHex(number);
            }
            else
            {
                throw new ArgumentException("radix is not equal 8, 10 or 16", nameof(number));
            }
        }
        
        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        public static string GetRadix(this int number, int radix)
        {
            // бред с добавлением цифр в начало это из-за того что не выходило правильное число, а с int.MinValue приколы из-за того что int.MaxValue + 1 не помещается в int принимаемый методами, для этого добавил методы GetPositiveOctall & GetPositiveHexl
            if (radix == 8)
            {
                if (number == int.MinValue)
                {
                    return new string(GetPositiveOctall(int.MaxValue));
                }

                char[] finish = GetPositiveOctal(number ^ int.MinValue).ToCharArray();
                finish[0] = '3';
                return new string(finish);
            }
            else if (radix == 10)
            {
                return GetPositiveDecimal(number);
            }
            else if (radix == 16)
            {
                if (number == int.MinValue)
                {
                    return new string(GetPositiveHexl(int.MaxValue));
                }

                char[] finish = GetPositiveHex(number ^ int.MinValue).ToCharArray();
                finish[0] = 'F';
                return new string(finish);
            }
            else
            {
                throw new ArgumentException("not equal 8, 10 or 16", nameof(number));
            }
        }
    }
}
