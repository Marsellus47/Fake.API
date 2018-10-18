using System;
using System.Collections.Generic;

namespace Fake.DataAccess.Interfaces.Random
{
    public interface IRandomScalarProvider
    {
        long Integer(long min = long.MinValue, long max = long.MaxValue);
        IEnumerable<long> Integers(short count, long min = long.MinValue, long max = long.MaxValue);

        byte Digit(byte min = 0, byte max = 9);
        IEnumerable<byte> Digits(short count, byte min = 0, byte max = 9);

        long Even(long min = long.MinValue, long max = long.MaxValue);
        IEnumerable<long> Evens(short count, long min = long.MinValue, long max = long.MaxValue);

        long Odd(long min = long.MinValue, long max = long.MaxValue);
        IEnumerable<long> Odds(short count, long min = long.MinValue, long max = long.MaxValue);

        double Decimal(double min = double.MinValue, double max = double.MaxValue);
        IEnumerable<double> Decimals(short count, double min = double.MinValue, double max = double.MaxValue);

        char Char(char min = char.MinValue, char max = char.MaxValue);
        IEnumerable<char> Chars(short count, char min = char.MinValue, char max = char.MaxValue);

        string String(short minLength = 0, short maxLength = short.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue);
        IEnumerable<string> Strings(short count, short minLength = 0, short maxLength = short.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue);

        string Hash(short length = 40, bool upperCase = false);
        IEnumerable<string> Hashes(short count, short length = 40, bool upperCase = false);

        bool Boolean(float? weight = null);
        IEnumerable<bool> Booleans(short count, float? weight = null);

        T EnumerationElement<T>(IEnumerable<T> enumeration);
        IEnumerable<T> EnumerationElements<T>(short count, IEnumerable<T> enumeration);

        IEnumerable<T> Shuffle<T>(IEnumerable<T> enumeration);

        string Word();
        IEnumerable<string> Words(short count);

        Guid Uuid();
        IEnumerable<Guid> Uuids(short count);

        string Locale();
        IEnumerable<string> Locales(short count);

        string AlphaNumeric(short minLength = 0, short maxLength = short.MaxValue);
        IEnumerable<string> AlphaNumerics(short count, short minLength = 0, short maxLength = short.MaxValue);

        string Hexadecimal(long min = 0, long max = long.MaxValue);
        IEnumerable<string> Hexadecimals(short count, long min = 0, long max = long.MaxValue);

        T Weighted<T>(IEnumerable<T> items, float[] weights);
    }
}
