using System;
using System.Collections.Generic;

namespace Fake.DataAccess.Interfaces.Random
{
    public interface IRandomScalarProvider
    {
        long Number(long min = long.MinValue, long max = long.MaxValue);
        IEnumerable<long> Numbers(int count, long min = long.MinValue, long max = long.MaxValue);

        byte Digit(byte min = 0, byte max = 9);
        IEnumerable<byte> Digits(int count, byte min = 0, byte max = 9);

        long Even(long min = long.MinValue, long max = long.MaxValue);
        IEnumerable<long> Evens(int count, long min = long.MinValue, long max = long.MaxValue);

        long Odd(long min = long.MinValue, long max = long.MaxValue);
        IEnumerable<long> Odds(int count, long min = long.MinValue, long max = long.MaxValue);

        double Decimal(double min = double.MinValue, double max = double.MaxValue);
        IEnumerable<double> Decimals(int count, double min = double.MinValue, double max = double.MaxValue);

        char Char(char min = char.MinValue, char max = char.MaxValue);
        IEnumerable<char> Chars(int count, char min = char.MinValue, char max = char.MaxValue);

        string String(short minLength = 1, short maxLength = short.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue);
        IEnumerable<string> Strings(int count, short minLength = 1, short maxLength = short.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue);

        string Hash(short length = 40, bool upperCase = false);
        IEnumerable<string> Hashes(int count, short length = 40, bool upperCase = false);

        bool Boolean(float? weight = null);
        IEnumerable<bool> Booleans(int count, float? weight = null);

        T EnumerationElement<T>(IEnumerable<T> enumeration);
        IEnumerable<T> EnumerationElements<T>(int count, IEnumerable<T> enumeration);

        IEnumerable<T> Shuffle<T>(IEnumerable<T> enumeration);

        string Word();
        IEnumerable<string> Words(int count);

        Guid Uuid();
        IEnumerable<Guid> Uuids(int count);

        string Locale();
        IEnumerable<string> Locales(int count);

        string AlphaNumeric(short minLength = 1, short maxLength = short.MaxValue);
        IEnumerable<string> AlphaNumerics(int count, short minLength = 1, short maxLength = short.MaxValue);

        string Hexadecimal(long min = 0, long max = long.MaxValue);
        IEnumerable<string> Hexadecimals(int count, long min = 0, long max = long.MaxValue);

        T Weighted<T>(IEnumerable<T> items, float[] weights);
    }
}
