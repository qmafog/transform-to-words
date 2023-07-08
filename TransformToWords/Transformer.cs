using System;
#pragma warning disable

namespace TransformToWords
{
    /// <summary>
    /// Provides transformer methods.
    /// </summary>
    public static class Transformer
    {
        /// <summary>
        /// Converts number's digital representation into words.
        /// </summary>
        /// <returns>Words representation.</returns>
        public static string ConvertDigit(char d)
        {
            switch (d)
            {
                case '-':
                    return "minus";
                case '0':
                    return "zero";
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
                case '.':
                    return "point";
                case 'E':
                    return "E";
                case '+':
                    return "plus";
                default:
                    return string.Empty;
            }
        }

        public static string TransformToWords(double number)
        {
            string strNum = number.ToString();
            string resultString = string.Empty;
            int i = 0;

            if (strNum[0] == '-')
            {
                resultString += ConvertDigit('-') + " ";
                i++;
            }

            if (strNum[0] == '+')
            {
                resultString += ConvertDigit('+') + " ";
                i++;
            }

            if (number == 0)
            {
                resultString += "zero";
                return char.ToUpper(resultString[0]) + resultString.Substring(1);
            }

            if (double.IsNaN(number))
            {
                return "NaN";
            }

            if (double.IsPositiveInfinity(number))
            {
                return "Positive Infinity";
            }

            if (double.IsNegativeInfinity(number))
            {
                return "Negative Infinity";
            }

            if (number == double.Epsilon)
            {
                return "Double Epsilon";
            }

            int len = strNum.Length - i;
            while (len > 0)
            {
                resultString += ConvertDigit(strNum[i]) + ' ';
                i++;
                len--;
            }

            resultString = resultString[..^1];
            return char.ToUpper(resultString[0]) + resultString.Substring(1);
        }
    }
}
