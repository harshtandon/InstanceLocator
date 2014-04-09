using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace InstanceLocator.FakesResolver.Extensions
{
    public static class TypeExtensions
    {
        private static readonly System.Type[] NumericTypes = new[] { typeof(byte), typeof(short), typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal) };

        /// <summary>
        /// Gets a value indicating whether the type is a supported numeric type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNumericType(this System.Type type)
        {
            return (NumericTypes.Contains(type));
        }

        public static bool IsString(this System.Type type)
        {
            return type == typeof (string);
        }

        public static bool IsDateTime(this System.Type type)
        {
            return type == typeof (DateTime);
        }

        public static bool IsBoolean(this System.Type type)
        {
            return type == typeof(bool);
        }

    }
}