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

        public string AlphaNumeric(short minLength = 0, short maxLength = short.MaxValue)
        {
            ThrowIfValueHigherThan(nameof(minLength), minLength, maxLength);
            ThrowIfValueLowerThan(nameof(minLength), minLength, 0);

            var rand = new System.Random();
            var length = (short)rand.NextLong(minLength, maxLength);

            return faker.Random.AlphaNumeric(length);
        }

        public IEnumerable<string> AlphaNumerics(short count, short minLength = 0, short maxLength = short.MaxValue)
            => count < 0 || minLength > maxLength
            ? new List<string>()
            : Enumerable.Range(1, count).Select(_ => AlphaNumeric(minLength, maxLength)).ToList();

        public bool Boolean(float? weight = null)
            => weight.HasValue
            ? faker.Random.Bool(weight.Value)
            : faker.Random.Bool();

        public IEnumerable<bool> Booleans(short count, float? weight = null)
            => count <= 0
            ? new List<bool>()
            : Enumerable.Range(1, count).Select(_ => Boolean(weight)).ToList();

        public char Char(char min = char.MinValue, char max = char.MaxValue)
        {
            ThrowIfValueHigherThan(nameof(min), min, max);

            return faker.Random.Char(min, max);
        }

        public IEnumerable<char> Chars(short count, char min = char.MinValue, char max = char.MaxValue)
            => count <= 0 || min > max
            ? new List<char>()
            : Enumerable.Range(1, count).Select(_ => Char(min, max)).ToList();

        public double Decimal(double min = double.MinValue, double max = double.MaxValue)
        {
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            return rand.NextDouble(min, max);
        }

        public IEnumerable<double> Decimals(short count, double min = double.MinValue, double max = double.MaxValue)
            => count <= 0 || min > max
            ? new List<double>()
            : Enumerable.Range(1, count).Select(_ => Decimal(min, max)).ToList();

        public byte Digit(byte min = 0, byte max = 9)
        {
            ThrowIfValueHigherThan(nameof(min), min, max);
            ThrowIfValueHigherThan(nameof(min), max, 9);

            return (byte)faker.Random.Digits(1, min, max).First();
        }

        public IEnumerable<byte> Digits(short count, byte min = 0, byte max = 9)
            => count <= 0 || min > max
            ? new List<byte>()
            : Enumerable.Range(1, count).Select(_ => Digit(min, max)).ToList();

        public T EnumerationElement<T>(IEnumerable<T> enumeration)
            => enumeration?.Any() != true
            ? default(T)
            : faker.Random.ArrayElement(enumeration.ToArray());

        public IEnumerable<T> EnumerationElements<T>(short count, IEnumerable<T> enumeration)
            => enumeration == null
            ? new T[0]
            : faker.Random.ArrayElements(enumeration.ToArray(), count);

        public long Even(long min = long.MinValue, long max = long.MaxValue)
        {
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            long randomNumber = rand.NextLong(min, max);

            if (randomNumber % 2 == 0) return randomNumber;
            if (randomNumber < long.MaxValue) return randomNumber + 1;
            return randomNumber - 1;
        }

        public IEnumerable<long> Evens(short count, long min = long.MinValue, long max = long.MaxValue)
            => count <= 0 || min > max
            ? new List<long>()
            : Enumerable.Range(1, count).Select(_ => Even(min, max)).ToList();

        public string Hash(short length = 40, bool upperCase = false)
        {
            ThrowIfValueLowerThan(nameof(length), length, 1);

            return faker.Random.Hash(length, upperCase);
        }

        public IEnumerable<string> Hashes(short count, short length = 40, bool upperCase = false)
            => count <= 0
            ? new List<string>()
            : Enumerable.Range(1, count).Select(_ => Hash(length, upperCase)).ToList();

        public string Hexadecimal(long min = 0, long max = long.MaxValue)
        {
            ThrowIfValueHigherThan(nameof(min), min, max);
            ThrowIfValueLowerThan(nameof(min), min, 0);

            var rand = new System.Random();
            var randomValue = rand.NextLong(min, max);

            return randomValue.ToString("X2");
        }

        public IEnumerable<string> Hexadecimals(short count, long min = 0, long max = long.MaxValue)
            => count <= 0 || min > max || min < 0
            ? new List<string>()
            : Enumerable.Range(1, count).Select(_ => Hexadecimal(min, max)).ToList();

        public string Locale() => AllLocales()[faker.Random.Number(AllLocales().Length - 1)];

        private static string[] AllLocales()
            => CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Select(culture => culture.IetfLanguageTag)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();

        public IEnumerable<string> Locales(short count)
            => count <= 0
            ? new List<string>()
            : Enumerable.Range(1, count).Select(_ => Locale()).ToList();

        public long Integer(long min = long.MinValue, long max = long.MaxValue)
        {
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            return rand.NextLong(min, max);
        }

        public IEnumerable<long> Integers(short count, long min = long.MinValue, long max = long.MaxValue)
            => count <= 0 || min > max
            ? new List<long>()
            : Enumerable.Range(1, count).Select(_ => Integer(min, max)).ToList();

        public long Odd(long min = long.MinValue, long max = long.MaxValue)
        {
            ThrowIfValueHigherThan(nameof(min), min, max);

            var rand = new System.Random();
            long randomNumber = rand.NextLong(min, max);

            if (randomNumber % 2 != 0) return randomNumber;
            if (randomNumber < long.MaxValue) return randomNumber + 1;
            return randomNumber - 1;
        }

        public IEnumerable<long> Odds(short count, long min = long.MinValue, long max = long.MaxValue)
            => count <= 0 || min > max
            ? new List<long>()
            : Enumerable.Range(1, count).Select(_ => Odd(min, max)).ToList();

        public IEnumerable<T> Shuffle<T>(IEnumerable<T> enumeration)
            => enumeration == null
            ? new T[0]
            : faker.Random.Shuffle(enumeration.ToArray());

        public string String(short minLength = 0, short maxLength = short.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue)
        {
            ThrowIfValueHigherThan(nameof(minLength), minLength, maxLength);
            ThrowIfValueHigherThan(nameof(minChar), minChar, maxChar);
            ThrowIfValueLowerThan(nameof(minLength), minLength, 0);

            return faker.Random.String(minLength, maxLength, minChar, maxChar);
        }

        public IEnumerable<string> Strings(short count, short minLength = 0, short maxLength = short.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue)
            => count <= 0 || minLength > maxLength || minChar > maxChar || minLength < 0
            ? new List<string>()
            : Enumerable.Range(1, count).Select(_ => String(minLength, maxLength, minChar, maxChar)).ToList();

        public Guid Uuid() => faker.Random.Uuid();

        public IEnumerable<Guid> Uuids(short count)
            => count <= 0
            ? new List<Guid>()
            : Enumerable.Range(1, count).Select(_ => Uuid()).ToList();

        public T Weighted<T>(IEnumerable<T> items, float[] weights)
            => items == null
            ? default(T)
            : faker.Random.WeightedRandom<T>(items.ToArray(), weights);

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

        public IEnumerable<string> Words(short count)
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

        private static void ThrowIfValueHigherThan(string paramName, double value, double max)
        {
            if (value > max) throw new ArgumentOutOfRangeException(paramName, value, $"Value {value} is higher than expected maximum value {max}");
        }
    }
}
