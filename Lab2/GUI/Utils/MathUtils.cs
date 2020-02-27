using System;

namespace GUI.Utils
{
    public static class MathUtils
    {
        public static double GradToRad(double grad)
        {
            return Math.PI * grad / 180;
        }
    }
}
