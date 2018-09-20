using Fake.DataAccess.Interfaces.Random;
using System;
using System.Collections.Generic;

namespace Fake.DataAccess.Random
{
    public class RandomProvider : IRandomProvider
    {
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

        public char Char(char min = '\0', char max = '\uffff')
        {
            throw new NotImplementedException();
        }

        public IEnumerable<char> Chars(int count, char min = '\0', char max = '\uffff')
        {
            throw new NotImplementedException();
        }

        public double Decimal(double min = double.MinValue, double max = double.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<double> Decimals(int count, double min = double.MinValue, double max = double.MaxValue)
        {
            throw new NotImplementedException();
        }

        public byte Digit(byte min = 0, byte max = 255)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<byte> Digits(int count, byte min = 0, byte max = 255)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<long> Even(int count, long min = long.MinValue, long max = long.MaxValue)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<long> Numbers(int count, long min = long.MinValue, long max = long.MaxValue)
        {
            throw new NotImplementedException();
        }

        public long Odd(long min = long.MinValue, long max = long.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> Odd(int count, long min = long.MinValue, long max = long.MaxValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Shuffle<T>(IEnumerable<T> enumerable)
        {
            throw new NotImplementedException();
        }

        public string String(int minLength = 1, int maxLength = int.MaxValue, char minChar = '\0', char maxChar = '\uffff')
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Strings(int count, int minLength = 1, int maxLength = int.MaxValue, char minChar = '\0', char maxChar = '\uffff')
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
    }
}
