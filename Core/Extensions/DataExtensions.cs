using System;
using System.Linq;

namespace Core.Extensions
{
    public static class DataExtensions
    {
        public static void Shuffle<T>(this T[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
        
        public static int[] ToIntArray<T>(this T[] enumArray) where T : Enum => 
            enumArray.Select(e => Convert.ToInt32(e)).ToArray();
    }
}