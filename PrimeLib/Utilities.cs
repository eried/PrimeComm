using System;

namespace PrimeLib
{
    /// <summary>
    /// Generic utilities
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Returns a subarray of an array
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="data">Source</param>
        /// <param name="index">Start from</param>
        /// <param name="length">Lenght</param>
        /// <returns>Subarray</returns>
        /// <seealso cref="http://stackoverflow.com/questions/943635/c-sharp-arrays-getting-a-sub-array-from-an-existing-array"/>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
