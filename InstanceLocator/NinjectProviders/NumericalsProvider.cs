using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Activation;
using InstanceLocator.Helpers;

namespace InstanceLocator.NinjectProviders
{
    //TODO : Verify randomness logic
    /// <summary>
    /// Provider for supported numeric types.
    /// </summary>
    class NumericalsProvider : Provider<object>
    {

        public NumericalsProvider()
        {
            

        }

        protected override object CreateInstance(IContext context)
        {
            var type = context.Request.Service;

            if (type == typeof(byte))
                return GetRandomByte();
            if (type == typeof(short))
                return GetRandomShort();
            if (type == typeof(int))
                return GetRandomInt();
            if (type == typeof(long))
                return GetRandomLong();
            if (type == typeof(float))
                return GetRandomFloat();
            if (type == typeof(double))
                return GetRandomDouble();
            if (type == typeof(decimal))
                return GetRandomDecimal();
            else
                throw new Exception("Type does not have an implementation for getting Random Instance.");
        }

        #region GetRandom methods

        // Byte
        public static byte GetRandomByte(int min = 1, int max = 256)
        {
            if (min < byte.MinValue || max > byte.MaxValue)
                throw new InvalidOperationException("Type range violation");

            return (byte)RandomNumberHelper.Randomizer.Next(min, max);
        }

        // Short
        public static short GetRandomShort(int min = 1, int max = 501)
        {
            if (min < short.MinValue || max > short.MaxValue)
                throw new InvalidOperationException("Type range violation");

            return (short)RandomNumberHelper.Randomizer.Next(min, max);
        }

        // Int
        public static int GetRandomInt(int min = 1, int max = 501)
        {
            return RandomNumberHelper.Randomizer.Next(min, max);
        }

        // Long
        public static long GetRandomLong(int min = 1, int max = 501)
        {
            return RandomNumberHelper.Randomizer.Next(min, max);
        }

        // Float, Inclusive Ranges
        public static float GetRandomFloat(float minimum = 1.0f, float maximum = 500.0f)
        {
            if (minimum < float.MinValue || maximum > float.MaxValue)
                throw new InvalidOperationException("Type range violation");

            return (float)((RandomNumberHelper.Randomizer.NextDouble() * (maximum - minimum)) + minimum);
        }

        // Double, Inclusive Ranges
        public static double GetRandomDouble(double minimum = 1.0, double maximum = 500.0)
        {
            if (minimum < double.MinValue || maximum > double.MaxValue)
                throw new InvalidOperationException("Type range violation");

            return ((RandomNumberHelper.Randomizer.NextDouble() * (maximum - minimum)) + minimum);
        }

        // Decimal, Inclusive Ranges
        public static decimal GetRandomDecimal(decimal minimum = 1.0m, decimal maximum = 500.0m)
        {
            if (minimum < decimal.MinValue || maximum > decimal.MaxValue)
                throw new InvalidOperationException("Type range violation");

            return ((Convert.ToDecimal(RandomNumberHelper.Randomizer.NextDouble()) * (maximum - minimum)) + minimum);
        }

        #endregion
    }
}