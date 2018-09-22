using Bogus;
using Fake.DataAccess.Interfaces.Random;
using Fake.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

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

        public bool Boolean(float? weight = null)
            => weight.HasValue
            ? faker.Random.Bool(weight.Value)
            : faker.Random.Bool();

        public IEnumerable<bool> Booleans(int count, float? weight = null)
            => count <= 0
            ? new List<bool>()
            : Enumerable.Range(1, count).Select(_ => Boolean(weight)).ToList();

        public char Char(char min = char.MinValue, char max = char.MaxValue)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);

            return faker.Random.Char(min, max);
        }

        public IEnumerable<char> Chars(int count, char min = char.MinValue, char max = char.MaxValue)
            => count <= 0 || min > max
            ? new List<char>()
            : Enumerable.Range(1, count).Select(_ => Char(min, max)).ToList();

        public double Double(double min = double.MinValue, double max = double.MaxValue)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            return rand.Next(min, max);
        }

        public IEnumerable<double> Doubles(int count, double min = double.MinValue, double max = double.MaxValue)
            => count <= 0 || min > max
            ? new List<double>()
            : Enumerable.Range(1, count).Select(_ => Double(min, max)).ToList();

        public byte Digit(byte min = 0, byte max = 9)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);
            ThrowIfValueHigherThan(nameof(min), max, 9);

            return (byte)faker.Random.Digits(1, min, max).First();
        }

        public IEnumerable<byte> Digits(int count, byte min = 0, byte max = 9)
            => count <= 0 || min > max
            ? new List<byte>()
            : Enumerable.Range(1, count).Select(_ => Digit(min, max)).ToList();

        public T EnumerationElement<T>(IEnumerable<T> enumeration)
            => enumeration == null
            ? default(T)
            : faker.Random.ArrayElement(enumeration.ToArray());

        public IEnumerable<T> EnumerationElements<T>(int count, IEnumerable<T> enumeration)
            => enumeration == null
            ? new T[0]
            : faker.Random.ArrayElements(enumeration.ToArray(), count);

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
            => count <= 0 || min > max
            ? new List<long>()
            : Enumerable.Range(1, count).Select(_ => Even(min, max)).ToList();

        public string Hash(short length = 40, bool upperCase = false)
        {
            ThrowIfValueLowerThan(nameof(length), length, 1);

            return faker.Random.Hash(length, upperCase);
        }

        public IEnumerable<string> Hashes(int count, short length = 40, bool upperCase = false)
            => count <= 0
            ? new List<string>()
            : Enumerable.Range(1, count).Select(_ => Hash(length, upperCase)).ToList();

        public string Hexadecimal(int length = 1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Hexadecimals(int count, short minLength = 1, short maxLength = short.MaxValue)
        {
            throw new NotImplementedException();
        }

        public string Locale() => AllLocales[faker.Random.Number(AllLocales.Length - 1)];

        private static string[] AllLocales
            => CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Select(culture => culture.IetfLanguageTag)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();

        public IEnumerable<string> Locales(int count)
            => count <= 0
            ? new List<string>()
            : Enumerable.Range(1, count).Select(_ => Locale()).ToList();

        public long Number(long min = long.MinValue, long max = long.MaxValue)
        {
            ThrowIfValueLowerThan(nameof(max), max, min);
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            return rand.Next(min, max);
        }

        public IEnumerable<long> Numbers(int count, long min = long.MinValue, long max = long.MaxValue)
            => count <= 0 || min > max
            ? new List<long>()
            : Enumerable.Range(1, count).Select(_ => Number(min, max)).ToList();

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
            => count <= 0 || min > max
            ? new List<long>()
            : Enumerable.Range(1, count).Select(_ => Odd(min, max)).ToList();

        public IEnumerable<T> Shuffle<T>(IEnumerable<T> enumeration)
            => enumeration == null
            ? new T[0]
            : faker.Random.Shuffle(enumeration.ToArray());

        public string String(short minLength = 1, short maxLength = short.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue)
        {
            ThrowIfValueLowerThan(nameof(maxLength), maxLength, minLength);
            ThrowIfValueHigherThan(nameof(minLength), minLength, maxLength);

            ThrowIfValueLowerThan(nameof(maxChar), maxChar, minChar);
            ThrowIfValueHigherThan(nameof(minChar), minChar, maxChar);

            return faker.Random.String(minLength, maxLength, minChar, maxChar);
        }

        public IEnumerable<string> Strings(int count, short minLength = 1, short maxLength = short.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue)
            => count <= 0 || minLength > maxLength || minChar > maxChar
            ? new List<string>()
            : Enumerable.Range(1, count).Select(_ => String(minLength, maxLength, minChar, maxChar)).ToList();

        public Guid Uuid() => faker.Random.Uuid();

        public IEnumerable<Guid> Uuids(int count)
            => count <= 0
            ? new List<Guid>()
            : Enumerable.Range(1, count).Select(_ => Uuid()).ToList();

        public T Weighted<T>(IEnumerable<T> items, float[] weights)
        {
            throw new NotImplementedException();
        }

        public string Word()
        {
            while (true)
            {
                string words = faker.Random.Word();

                foreach (var word in words.Split(' '))
                {
                    if (word.ToCharArray().All(@char => char.IsLetter(@char)))
                    {
                        return word;
                    }
                }
            }
        }

        public IEnumerable<string> Words(int count)
        {
            if (count <= 0) return new List<string>();

            var words = new List<string>();

            while (true)
            {
                string generatedWords = faker.Random.Words(count);
                IEnumerable<string> realWords = generatedWords.Split(' ')
                    .Where(word => word
                        .ToCharArray()
                        .All(@char => char.IsLetter(@char)));

                words.AddRange(realWords);

                if(words.Count >= count)
                {
                    return words.Take(count);
                }
            }
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
