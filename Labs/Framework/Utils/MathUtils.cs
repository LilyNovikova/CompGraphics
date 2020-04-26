using System;

namespace Framework.Utils
{
    public static class MathUtils
    {
        public static double GradToRad(double grad)
        {
            return Math.PI * grad / 180;
        }

        public static long Factorial(long number)
        {
            if (number == 0)
            {
                return 1;
            }
            else if (number < 3)
            {
                return number;
            }
            long result = 2;
            for (long i = 3; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
