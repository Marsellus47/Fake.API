using System;

namespace Fake.Common.Extensions
{
    public static class RandomExtensions
    {
        public static long NextLong(this Random random, long minimum, long maximum)
        {
            if (minimum == maximum) return minimum;

            //Working with ulong so that modulo works correctly with values > long.MaxValue
            ulong uRange = (ulong)(maximum - minimum);

            //Prevent a modulo bias; see https://stackoverflow.com/a/10984975/238419
            //for more information.
            //In the worst case, the expected number of calls is 2 (though usually it's
            //much closer to 1) so this loop doesn't really hurt performance at all.
            ulong ulongRand;
            do
            {
                byte[] buf = new byte[8];
                random.NextBytes(buf);
                ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
            } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

            var randomValue = (long)(ulongRand % uRange) + minimum;

            // Above code never returns maximum so here is random generation of long.MaxValue
            return randomValue == maximum - 1 && random.Next() % 2 == 0
                ? maximum
                : randomValue;
        }

        public static double NextDouble(this Random random, double minimum, double maximum)
        {
            var average = (minimum / 2.0) + (maximum / 2.0);
            var factor = maximum - average;
            return (((2.0 * random.NextDouble()) - 1.0) * factor) + average;
        }
    }
}
