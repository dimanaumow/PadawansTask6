using System;
using System.Collections.Generic;

namespace PadawansTask6
{
    public static class NumberFinder
    {
        public static int? NextBiggerThan(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException();
            }

            int count = 0;
            while (number > 0)
            {
                number /= 10;
                count++;
            }

            int[] digits = new int[count];

            int m = count - 1;
            while (number > 0)
            {
                digits[m] = number % 10;
                number /= 10;
                m--;
            }

            int term = 0;
            for (int i = digits.Length - 1; i >= 1; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    int minInd = i - 1; 
                    for(int j = i - 1; j < digits.Length; j++)
                    {
                        if(digits[j] > digits[i - 1])
                        {
                            minInd = j; 
                        }
                    }
                    int temp = digits[minInd];
                    digits[minInd] = digits[i - 1];
                    digits[i - 1] = temp;
                    term = i - 1; 
                    break; 
                }
            }

            Array.Sort(digits, term + 1, digits.Length - term);
            //for (int i = term + 1; i < digits.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < digits.Length; j++)
            //    {
            //        if (digits[i] > digits[j])
            //        {
            //            int temp = digits[i];
            //            digits[i] = digits[j];
            //            digits[j] = temp;
            //        }
            //    }
            //}

            int result = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                result += digits[i] * (int)Math.Pow(10, digits.Length - i - 1); 
            }

            if(result == number)
            {
                return null; 
            }
            return result; 
        }
    }
}
