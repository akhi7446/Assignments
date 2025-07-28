using System;

namespace Assignment11
{
    public static class NumericFunctions
    {
        //1
        public int Add1(params int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

    }
}
