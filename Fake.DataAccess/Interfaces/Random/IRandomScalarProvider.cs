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

        double Double(double min = double.MinValue, double max = double.MaxValue);
        IEnumerable<double> Doubles(int count, double min = double.MinValue, double max = double.MaxValue);

        char Char(char min = char.MinValue, char max = char.MaxValue);
        IEnumerable<char> Chars(int count, char min = char.MinValue, char max = char.MaxValue);

        string String(int minLength = 1, int maxLength = int.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue);
        IEnumerable<string> Strings(int count, int minLength = 1, int maxLength = int.MaxValue, char minChar = char.MinValue, char maxChar = char.MaxValue);

        string Hash(int length = 40, bool upperCase = false);
        IEnumerable<string> Hashes(int count, int length = 40, bool upperCase = false);

        bool Boolean();
        bool Boolean(float weight = 0);
        IEnumerable<bool> Booleans(int count);
        IEnumerable<bool> Booleans(int count, float weight = 0);

        T EnumerationElement<T>(IEnumerable<T> enumeration);
        IEnumerable<T> EnumerationElements<T>(int count, IEnumerable<T> enumeration);

        IEnumerable<T> Shuffle<T>(IEnumerable<T> enumerable);

        string Word();
        IEnumerable<string> Words(int minCount = int.MinValue, int maxCount = int.MaxValue);

        Guid Uuid();
        IEnumerable<Guid> Uuids(int count);

        string Locale();
        IEnumerable<string> Locales(int count);

        string AlphaNumeric(short minLength = 1, short maxLength = short.MaxValue);
        IEnumerable<string> AlphaNumerics(int count, short minLength = 1, short maxLength = short.MaxValue);

        string Hexadecimal(int length = 1);
        IEnumerable<string> Hexadecimals(int count, short minLength = 1, short maxLength = short.MaxValue);

        T Weighted<T>(IEnumerable<T> items, float[] weights);
    }
}
