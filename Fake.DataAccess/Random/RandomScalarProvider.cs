using Bogus;
using Fake.DataAccess.Interfaces.Random;
using Fake.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fake.DataAccess.Random
{
    public class RandomScalarProvider : IRandomScalarProvider
    {
        private readonly Faker faker = new Faker();

        public string AlphaNumeric(short minLength = 1, short maxLength = short.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> AlphaNumerics(int count, short minLength = 1, short maxLength = short.MaxValue)
        {
            throw new NotImplementedException();
        }

        public bool Boolean()
        {
            throw new NotImplementedException();
        }

        public bool Boolean(float weight = 0)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<bool> Booleans(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<bool> Booleans(int count, float weight = 0)
        {
            throw new NotImplementedException();
        }

        public char Char(char min = char.MinValue, char max = char.MaxValue)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);

            return faker.Random.Char(min, max);
        }

        public IEnumerable<char> Chars(int count, char min = char.MinValue, char max = char.MaxValue)
        {
            return Enumerable.Range(1, count).Select(_ => Char(min, max)).ToList();
        }

        public double Double(double min = double.MinValue, double max = double.MaxValue)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            return rand.Next(min, max);
        }

        public IEnumerable<double> Doubles(int count, double min = double.MinValue, double max = double.MaxValue)
        {
            return Enumerable.Range(1, count).Select(_ => Double(min, max)).ToList();
        }

        public byte Digit(byte min = 0, byte max = 9)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);
            ThrowIfValueHigherThan(nameof(min), max, 9);

            return (byte)faker.Random.Digits(1, min, max).First();
        }

        public IEnumerable<byte> Digits(int count, byte min = 0, byte max = 9)
        {
            return Enumerable.Range(1, count).Select(_ => Digit(min, max)).ToList();
        }

        public T EnumerationElement<T>(IEnumerable<T> enumeration)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> EnumerationElements<T>(int count, IEnumerable<T> enumeration)
        {
            throw new NotImplementedException();
        }

        public long Even(long min = long.MinValue, long max = long.MaxValue)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            long randomNumber = rand.Next(min, max);

            if (randomNumber % 2 == 0) return randomNumber;
            if (randomNumber < long.MaxValue) return randomNumber + 1;
            return randomNumber - 1;
        }

        public IEnumerable<long> Evens(int count, long min = long.MinValue, long max = long.MaxValue)
        {
            return Enumerable.Range(1, count).Select(_ => Even(min, max)).ToList();
        }

        public string Hash(int length = 40, bool upperCase = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Hashes(int count, int length = 40, bool upperCase = false)
        {
            throw new NotImplementedException();
        }

        public string Hexadecimal(int length = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Hexadecimals(int count, short minLength = 1, short maxLength = short.MaxValue)
        {
            throw new NotImplementedException();
        }

        public string Locale()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Locales(int count)
        {
            throw new NotImplementedException();
        }

        public long Number(long min = long.MinValue, long max = long.MaxValue)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            return rand.Next(min, max);
        }

        public IEnumerable<long> Numbers(int count, long min = long.MinValue, long max = long.MaxValue)
        {
            return Enumerable.Range(1, count).Select(_ => Number(min, max)).ToList();
        }

        public long Odd(long min = long.MinValue, long max = long.MaxValue)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            long randomNumber = rand.Next(min, max);

            if (randomNumber % 2 != 0) return randomNumber;
            if (randomNumber < long.MaxValue) return randomNumber + 1;
            return randomNumber - 1;
        }

        public IEnumerable<long> Odds(int count, long min = long.MinValue, long max = long.MaxValue)
        {
            return Enumerable.Range(1, count).Select(_ => Odd(min, max)).ToList();
        }

        public IEnumerable<T> Shuffle<T>(IEnumerable<T> enumerable)
        {
            throw new NotImplementedException();
        }

        public string String(int minLength = 1, int maxLength = int.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Strings(int count, int minLength = 1, int maxLength = int.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue)
        {
            throw new NotImplementedException();
        }

        public Guid Uuid()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Guid> Uuids(int count)
        {
            throw new NotImplementedException();
        }

        public T Weighted<T>(IEnumerable<T> items, float[] weights)
        {
            throw new NotImplementedException();
        }

        public string Word()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Words(int minCount = int.MinValue, int maxCount = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        private static void ThrowIfValueLowerThan(string paramName, long value, long min = 1)
        {
            if (value < min) throw new ArgumentOutOfRangeException(paramName, value, $"Value {value} is lower than expected minimum value {min}");
        }

        private static void ThrowIfValueHigherThan(string paramName, long value, long max)
        {
            if (value > max) throw new ArgumentOutOfRangeException(paramName, value, $"Value {value} is higher than expected maximum value {max}");
        }

        private static void ThrowIfValueLowerThan(string paramName, double value, double min = 1)
        {
            if (value < min) throw new ArgumentOutOfRangeException(paramName, value, $"Value {value} is lower than expected minimum value {min}");
        }

        private static void ThrowIfValueHigherThan(string paramName, double value, double max)
        {
            if (value > max) throw new ArgumentOutOfRangeException(paramName, value, $"Value {value} is higher than expected maximum value {max}");
        }
    }
}
