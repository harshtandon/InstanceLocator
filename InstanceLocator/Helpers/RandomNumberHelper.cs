using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace InstanceLocator.Helpers
{
    /// <summary>
    /// A thread safe implementation of random number generator.
    /// </summary>
    static class RandomNumberHelper
    {
        private static int seedCounter;
        private static readonly object seedLock = new object();

        [ThreadStatic]      // One instance for each thread
        private static Random randomGen;

        public static Random Randomizer
        {
            get
            {
                if (randomGen == null)
                {
                    lock (seedLock)
                    {
                        seedCounter = Guid.NewGuid().GetHashCode();
                    }

                    randomGen = new Random(seedCounter);
                }
                return randomGen;
            }
        }
    }
}