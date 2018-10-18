using System;
using System.Collections.Generic;

namespace Fake.API.E2ETests.GraphQL.Random
{
    public class RandomDTO
    {
        public int Integer { get; set; }
        public IEnumerable<long> Integers { get; set; }

        public byte Digit { get; set; }
        public IEnumerable<byte> Digits { get; set; }

        public long Even { get; set; }
        public IEnumerable<long> Evens { get; set; }

        public long Odd { get; set; }
        public IEnumerable<long> Odds { get; set; }

        public double Decimal { get; set; }
        public IEnumerable<double> Decimals { get; set; }

        public char Char { get; set; }
        public IEnumerable<char> Chars { get; set; }

        public string String { get; set; }
        public IEnumerable<string> Strings { get; set; }

        public string Hash { get; set; }
        public IEnumerable<string> Hashes { get; set; }

        public bool? Boolean { get; set; }
        public IEnumerable<bool> Booleans { get; set; }

        public string EnumerationElement { get; set; }
        public IEnumerable<string> EnumerationElements { get; set; }

        public IEnumerable<string> Shuffle { get; set; }

        public string Word { get; set; }
        public IEnumerable<string> Words { get; set; }

        public Guid Uuid { get; set; }
        public IEnumerable<Guid> Uuids { get; set; }

        public string Locale { get; set; }
        public IEnumerable<string> Locales { get; set; }

        public string AlphaNumeric { get; set; }
        public IEnumerable<string> AlphaNumerics { get; set; }

        public string Hexadecimal { get; set; }
        public IEnumerable<string> Hexadecimals { get; set; }

        public string Weighted { get; set; }
    }
}
