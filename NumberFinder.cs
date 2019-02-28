using System;

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

            int size = 15;
            int[] digitOfNumbers = new int[size];
            int[] temp = new int[size];

            for(int i = 0; i < temp.Length; i++)
            {
                digitOfNumbers[i] = 0;
                temp[i] = 0; 
            }

            DigitsOfNumber(digitOfNumbers, number); 

            if(IncreaseOfArray(digitOfNumbers))
            {
                return null; 
            }

            int count = number + 1;

            while (number != int.MaxValue)
            {
                DigitsOfNumber(temp, count); 
                if(Equals(temp, digitOfNumbers))
                {
                    return count; 
                }

                count++; 
            }

            return null; 
        }

        public static bool IncreaseOfArray(int[] source)
        {
            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] > source[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static void DigitsOfNumber(int[] source, int number)
        {
            int digit = 0;
            int i = 0;

            while (number > 0)
            {
                digit = number % 10;
                source[i] = digit;
                number /= 10;
                i++;
            }
        }

        public static void BubleSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static bool Equals(int[] source, int[] array)
        {
            if (source.Length != array.Length)
            {
                return false;
            }

            BubleSort(source);
            BubleSort(array);

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
