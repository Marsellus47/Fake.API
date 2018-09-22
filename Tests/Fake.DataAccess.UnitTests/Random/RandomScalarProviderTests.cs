using Fake.Common.Extensions;
using Fake.DataAccess.Random;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random
{
    // TODO Use FLuent assertions https://fluentassertions.com/
    public class RandomScalarProviderTests
    {
        private const short TestingSetSize = 1000;
        private readonly RandomScalarProvider SUT = new RandomScalarProvider();
        private readonly Func<long, bool> IsEven = number => number % 2 == 0;
        private readonly Func<long, long, long> RandomNumber = (min, max) => new System.Random().Next(min, max);

        #region Number

        [Fact]
        public void Number_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Number());

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Number_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Number(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Number_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Number(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Number_ShouldFailForInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = long.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Number(min: minValue, max: maxValue));
        }

        #endregion Number

        #region Numbers

        [Fact]
        public void Numbers_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<long> values = SUT.Numbers(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Numbers_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Numbers(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Numbers_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Numbers(TestingSetSize, min: minValue);

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Numbers_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Numbers(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Numbers_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<long> values = SUT.Numbers(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Numbers_ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = long.MinValue;

            // Act
            IEnumerable<long> values = SUT.Numbers(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Numbers

        #region Digit

        [Fact]
        public void Digit_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const byte minValue = 0;
            const byte maxValue = 9;

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit());

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Digit_ShouldReturnHigherThanMin()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(0, 9);

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Digit_ShouldReturnLowerThanMax()
        {
            // Arrange
            byte maxValue = (byte)RandomNumber(0, 9);

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Digit_ShouldFailForMaxHigherThan9()
        {
            // Arrange
            const byte maxValue = 10;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Digit(max: maxValue));
        }

        [Fact]
        public void Digit_ShouldFailForInvertedMinMax()
        {
            // Arrange
            const byte minValue = 9;
            const byte maxValue = 0;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Digit(min: minValue, max: maxValue));
        }

        #endregion Digit

        #region Digits

        [Fact]
        public void Digits_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Digits_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const byte minValue = 0;
            const byte maxValue = 9;

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Digits_ShouldReturnHigherThanMin()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(0, 9);

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize, min: minValue);

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Digits_ShouldReturnLowerThanMax()
        {
            // Arrange
            byte maxValue = (byte)RandomNumber(0, 9);

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Digits_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<byte> values = SUT.Digits(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Digits_ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const byte minValue = 9;
            const byte maxValue = 0;

            // Act
            IEnumerable<long> values = SUT.Numbers(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Digits

        #region Even

        [Fact]
        public void Even_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even());

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Even_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Even_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Even_ShouldFailForInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = long.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Even(min: minValue, max: maxValue));
        }

        #endregion Even

        #region Evens

        [Fact]
        public void Evens_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<long> values = SUT.Evens(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Evens_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Evens(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Evens_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Evens(TestingSetSize, min: minValue);

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Evens_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Evens(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Evens_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<long> values = SUT.Evens(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Evens_ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = long.MinValue;

            // Act
            IEnumerable<long> values = SUT.Evens(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Evens

        #region Odd

        [Fact]
        public void Odd_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Odd());

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Odd_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Odd(min: minValue));

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Odd_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Odd(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Odd_ShouldFailForInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = long.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Odd(min: minValue, max: maxValue));
        }

        #endregion Odd

        #region Odds

        [Fact]
        public void Odds_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Odds_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Odds_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, min: minValue);

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Odds_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Odds_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<long> values = SUT.Odds(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Odds_ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = long.MinValue;

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Odds

        #region Double

        [Fact]
        public void Double_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const double minValue = double.MinValue;
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Double());

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Double_ShouldReturnlHigherThanMin()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.Next(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Double(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Double_ShouldReturnLowerThanMax()
        {
            // Arrange
            var rand = new System.Random();
            double maxValue = rand.Next(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Double(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Double_ShouldFailForInvertedMinMax()
        {
            // Arrange
            const double minValue = double.MaxValue;
            const double maxValue = double.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Double(min: minValue, max: maxValue));
        }

        #endregion Double

        #region Doubles

        [Fact]
        public void Doubles_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<double> values = SUT.Doubles(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Doubles_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const double minValue = double.MinValue;
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = SUT.Doubles(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Doubles_ShouldReturnHigherThanMin()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.Next(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = SUT.Doubles(TestingSetSize, min: minValue);

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Doubles_ShouldReturnLowerThanMax()
        {
            // Arrange
            var rand = new System.Random();
            double maxValue = rand.Next(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = SUT.Doubles(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Doubles_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<double> values = SUT.Doubles(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Doubles_ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const double minValue = double.MaxValue;
            const double maxValue = double.MinValue;

            // Act
            IEnumerable<double> values = SUT.Doubles(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Doubles

        #region Char

        [Fact]
        public void Char_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const char minValue = char.MinValue;
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char());

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Char_ShouldReturnHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Char_ShouldReturnLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Char_ShouldFailForInvertedMinMax()
        {
            // Arrange
            const char minValue = char.MaxValue;
            const char maxValue = char.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Char(min: minValue, max: maxValue));
        }

        #endregion Char

        #region Chars

        [Fact]
        public void Chars_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Chars_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const char minValue = char.MinValue;
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Chars_ShouldReturnHigherThanMin()
        {
            // Arrange
            char minValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, min: minValue);

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Chars_ShouldReturnLowerThanMax()
        {
            // Arrange
            char maxValue = (char)RandomNumber(char.MinValue, char.MaxValue);

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Chars_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<char> values = SUT.Chars(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Chars_ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const char minValue = char.MaxValue;
            const char maxValue = char.MinValue;

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Chars

        #region String

        [Fact]
        public void String_ShouldReturnBetweenDefaultMinAndMaxLength()
        {
            // Arrange
            const short minValue = 1;
            const short maxValue = short.MaxValue;

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String());

            // Assert
            Assert.All(values, value => Assert.InRange(value.Length, minValue, maxValue));
        }

        [Fact]
        public void String_ShouldReturnBetweenDefaultMinAndMaxChar()
        {
            // Arrange
            const char minValue = char.MinValue;
            const char maxValue = char.MaxValue;

            // Act
            string value = SUT.String(minLength: TestingSetSize, maxLength: TestingSetSize);

            // Assert
            Assert.All(value.ToCharArray(), @char => Assert.InRange(@char, minValue, maxValue));
        }

        [Fact]
        public void String_ShouldReturnHigherThanMinLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(minLength: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value.Length >= minValue));
        }

        [Fact]
        public void String_ShouldReturnLowerThanMaxLength()
        {
            // Arrange
            short maxValue = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(maxLength: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value.Length <= maxValue));
        }

        [Fact]
        public void String_ShouldReturnHigherThanMinChar()
        {
            // Arrange
            char minValue = (char)RandomNumber(1, char.MaxValue);

            // Act
            string value = SUT.String(minLength: TestingSetSize, maxLength: TestingSetSize, minChar: minValue);

            // Assert
            Assert.All(value.ToCharArray(), @char => Assert.True(@char >= minValue));
        }

        [Fact]
        public void String_ShouldReturnLowerThanMaxChar()
        {
            // Arrange
            char maxValue = (char)RandomNumber(1, char.MaxValue);

            // Act
            string value = SUT.String(minLength: TestingSetSize, maxLength: TestingSetSize, maxChar: maxValue);

            // Assert
            Assert.All(value.ToCharArray(), @char => Assert.True(@char <= maxValue));
        }

        [Fact]
        public void String_ShouldFailForInvertedMinMaxLength()
        {
            // Arrange
            const short minValue = short.MaxValue;
            const short maxValue = 1;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.String(minLength: minValue, maxLength: maxValue));
        }

        [Fact]
        public void String_ShouldFailForInvertedMinMaxChar()
        {
            // Arrange
            const char minValue = char.MaxValue;
            const char maxValue = char.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.String(minChar: minValue, maxChar: maxValue));
        }

        #endregion String

        #region Strings

        [Fact]
        public void Strings_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Strings_ShouldReturnBetweenDefaultMinAndMaxLength()
        {
            // Arrange
            const short minValue = 1;
            const short maxValue = short.MaxValue;

            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.InRange(value.Length, minValue, maxValue));
        }

        [Fact]
        public void Strings_ShouldReturnBetweenDefaultMinAndMaxChar()
        {
            // Arrange
            const char minValue = char.MinValue;
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, minLength: TestingSetSize, maxLength: TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.All(value.ToCharArray(), @char => Assert.InRange(@char, minValue, maxValue)));
        }

        [Fact]
        public void Strings_ShouldReturnHigherThanMinLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, minLength: minValue);

            // Assert
            Assert.All(values, value => Assert.True(value.Length >= minValue));
        }

        [Fact]
        public void Strings_ShouldReturnLowerThanMaxLength()
        {
            // Arrange
            short maxValue = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, maxLength: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(value.Length <= maxValue));
        }

        [Fact]
        public void Strings_ShouldReturnHigherThanMinChar()
        {
            // Arrange
            char minValue = (char)RandomNumber(1, char.MaxValue);

            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, minLength: TestingSetSize, maxLength: TestingSetSize, minChar: minValue);

            // Assert
            Assert.All(values, value => Assert.All(value.ToCharArray(), @char => Assert.True(@char >= minValue)));
        }

        [Fact]
        public void Strings_ShouldReturnLowerThanMaxChar()
        {
            // Arrange
            char maxValue = (char)RandomNumber(1, char.MaxValue);

            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, minLength: TestingSetSize, maxLength: TestingSetSize, maxChar: maxValue);

            // Assert
            Assert.All(values, value => Assert.All(value.ToCharArray(), @char => Assert.True(@char <= maxValue)));
        }

        [Fact]
        public void Strings_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Strings(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Strings_ShouldReturnEmptyEnumerationForInvertedMinMaxLength()
        {
            // Arrange
            const short minValue = short.MaxValue;
            const short maxValue = 1;

            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, minLength: minValue, maxLength: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Strings_ShouldReturnEmptyEnumerationForInvertedMinMaxChar()
        {
            // Arrange
            const char minValue = char.MaxValue;
            const char maxValue = char.MinValue;

            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, minChar: minValue, maxChar: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Strings

        #region Hash

        [Fact]
        public void Hash_ShouldReturnDefaultLength()
        {
            // Arrange
            const short length = 40;

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Hash());

            // Assert
            Assert.All(values, value => Assert.True(value.Length == length));
        }

        [Fact]
        public void Hash_ShouldReturnDigitOrDefaultLowercase()
        {
            // Act
            string value = SUT.Hash(TestingSetSize);

            // Assert
            Assert.All(value.ToCharArray(), @char => Assert.True(char.IsDigit(@char) || char.IsLower(@char)));
        }

        [Fact]
        public void Hash_ShouldReturnDigitOrLowercase()
        {
            // Arrange
            const bool uppercase = false;

            // Act
            string value = SUT.Hash(TestingSetSize, uppercase);

            // Assert
            Assert.All(value.ToCharArray(), @char => Assert.True(char.IsDigit(@char) || char.IsLower(@char)));
        }

        [Fact]
        public void Hash_ShouldReturnDigitOrUppercase()
        {
            // Arrange
            const bool uppercase = true;

            // Act
            string value = SUT.Hash(TestingSetSize, uppercase);

            // Assert
            Assert.All(value.ToCharArray(), @char => Assert.True(char.IsDigit(@char) || char.IsUpper(@char)));
        }

        [Fact]
        public void Hash_ShouldReturnCorrectLength()
        {
            // Arrange
            short length = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Hash(length));

            // Assert
            Assert.All(values, value => Assert.True(value.Length >= length));
        }

        [Fact]
        public void Hash_ShouldFailForNegativeLength()
        {
            // Arrange
            short length = (short)RandomNumber(short.MinValue, 0);

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Hash(length));
        }

        #endregion Hash

        #region Hashes

        [Fact]
        public void Hashes_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<string> values = SUT.Hashes(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Hashes_ShouldReturnDefaultLength()
        {
            // Arrange
            const short length = 40;

            // Act
            IEnumerable<string> values = SUT.Hashes(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.True(value.Length == length));
        }

        [Fact]
        public void Hashes_ShouldReturnDigitOrDefaultLowercase()
        {
            // Act
            IEnumerable<string> values = SUT.Hashes(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.All(value.ToCharArray(), @char => Assert.True(char.IsDigit(@char) || char.IsLower(@char))));
        }

        [Fact]
        public void Hashes_ShouldReturnDigitOrLowercase()
        {
            // Arrange
            const bool uppercase = false;

            // Act
            IEnumerable<string> values = SUT.Hashes(TestingSetSize, upperCase: uppercase);

            // Assert
            Assert.All(values, value => Assert.All(value.ToCharArray(), @char => Assert.True(char.IsDigit(@char) || char.IsLower(@char))));
        }

        [Fact]
        public void Hashes_ShouldReturnDigitOrUppercase()
        {
            // Arrange
            const bool uppercase = true;

            // Act
            IEnumerable<string> values = SUT.Hashes(TestingSetSize, upperCase: uppercase);

            // Assert
            Assert.All(values, value => Assert.All(value.ToCharArray(), @char => Assert.True(char.IsDigit(@char) || char.IsUpper(@char))));
        }

        [Fact]
        public void Hashes_ShouldReturnCorrectLength()
        {
            // Arrange
            short length = (short)RandomNumber(1, short.MaxValue);

            // Act
            IEnumerable<string> values = SUT.Hashes(TestingSetSize, length);

            // Assert
            Assert.All(values, value => Assert.True(value.Length >= length));
        }

        [Fact]
        public void Hashes_ShouldReturnEmptyEnumerationForNegativeLength()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Hashes(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Hashes

        #region Boolean

        [Fact]
        public void Boolean_ShouldReturnRandomValues()
        {
            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean());

            // Assert
            Assert.Contains(values, value => value);
            Assert.Contains(values, value => !value);
        }

        [Fact]
        public void Boolean_ShouldReturnMoreTruesForHigherWeight()
        {
            // Arrange
            const float weight = 0.8F;

            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(weight));

            // Assert
            Assert.True(values.Count(value => value) > values.Count() / 2);
        }

        [Fact]
        public void Boolean_ShouldReturnAllTruesForWeight1()
        {
            // Arrange
            const float weight = 1F;

            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(weight));

            // Assert
            Assert.All(values, Assert.True);
        }

        [Fact]
        public void Boolean_ShouldReturnMoreFalsesForLowerWeight()
        {
            // Arrange
            const float weight = 0.2F;

            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(weight));

            // Assert
            Assert.True(values.Count(value => !value) > values.Count() / 2);
        }

        [Fact]
        public void Boolean_ShouldReturnAllFalsesForWeight0()
        {
            // Arrange
            const float weight = 0F;

            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(weight));

            // Assert
            Assert.All(values, Assert.False);
        }

        #endregion Boolean

        #region Booleans

        [Fact]
        public void Booleans_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Booleans_ShouldReturnRandomValues()
        {
            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize);

            // Assert
            Assert.Contains(values, value => value);
            Assert.Contains(values, value => !value);
        }

        [Fact]
        public void Booleans_ShouldReturnMoreTruesForHigherWeight()
        {
            // Arrange
            const float weight = 0.8F;

            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, weight);

            // Assert
            Assert.True(values.Count(value => value) > values.Count() / 2);
        }

        [Fact]
        public void Booleans_ShouldReturnAllTruesForWeight1()
        {
            // Arrange
            const float weight = 1F;

            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, weight);

            // Assert
            Assert.All(values, Assert.True);
        }

        [Fact]
        public void Booleans_ShouldReturnMoreFalsesForLowerWeight()
        {
            // Arrange
            const float weight = 0.2F;

            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, weight);

            // Assert
            Assert.True(values.Count(value => !value) > values.Count() / 2);
        }

        [Fact]
        public void Booleans_ShouldReturnAllFalsesForWeight0()
        {
            // Arrange
            const float weight = 0F;

            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, weight);

            // Assert
            Assert.All(values, Assert.False);
        }

        [Fact]
        public void Booleans_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<bool> values = SUT.Booleans(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Booleans

        #region EnumerationElement

        [Fact]
        public void EnumerationElement_ShouldReturnItemFromEnumeration()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            int value = SUT.EnumerationElement(enumeration);

            // Assert
            Assert.Contains(value, enumeration);
        }

        [Fact]
        public void EnumerationElement_ShouldReturnDefaultItemForNullEnumration()
        {
            // Arrange
            const IEnumerable<int> enumeration = null;

            // Act
            int value = SUT.EnumerationElement(enumeration);

            // Assert
            Assert.Equal(default(int), value);
        }

        #endregion EnumerationElement

        #region EnumerationElements

        [Fact]
        public void EnumerationElements_ShouldReturnCorrectCount()
        {
            // Arrange
            const short count = TestingSetSize / 10;
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(count, enumeration);

            // Assert
            Assert.Equal(count, values.Count());
        }

        [Fact]
        public void EnumerationElements_ShouldReturnItemFromEnumeration()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(TestingSetSize / 10, enumeration);

            // Assert
            Assert.All(enumeration, item => Assert.Contains(item, enumeration));
        }

        [Fact]
        public void EnumerationElements_ShouldReturnEmptyEnumerationForNullEnumration()
        {
            // Arrange
            const IEnumerable<int> enumeration = null;

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(TestingSetSize / 10, enumeration);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion EnumerationElements

        #region Shuffle

        [Fact]
        public void Shuffle_ShouldReturnSameNumberOfItems()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            IEnumerable<int> values = SUT.Shuffle(enumeration);

            // Assert
            Assert.Equal(enumeration.Count(), values.Count());
        }

        [Fact]
        public void Shuffle_ShouldReturnShuffledEnumeration()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, TestingSetSize);

            // Act
            IEnumerable<int> values = SUT.Shuffle(enumeration);

            // Assert
            Assert.False(enumeration.SequenceEqual(values));
        }

        [Fact]
        public void Shuffle_ShouldReturnEmptyEnumerationForNullEnumration()
        {
            // Arrange
            const IEnumerable<int> enumeration = null;

            // Act
            IEnumerable<int> values = SUT.Shuffle(enumeration);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion

        #region Word

        [Fact]
        public void Word_ShouldReturnNotEmptyString()
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Word());

            // Assert
            Assert.All(values, Assert.NotEmpty);
        }

        [Fact]
        public void Word_ShouldReturnOnlyLetters()
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Word());

            // Assert
            Assert.All(values, value => Assert.All(value.ToCharArray(), @char => char.IsLetter(@char)));
        }

        #endregion Word

        #region Words

        [Fact]
        public void Words_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<string> values = SUT.Words(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Words_ShouldReturnNotEmptyString()
        {
            // Act
            IEnumerable<string> values = SUT.Words(TestingSetSize);

            // Assert
            Assert.All(values, Assert.NotEmpty);
        }

        [Fact]
        public void Words_ShouldReturnOnlyLetters()
        {
            // Act
            IEnumerable<string> values = SUT.Words(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.All(value.ToCharArray(), @char => char.IsLetter(@char)));
        }

        [Fact]
        public void Words_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Words(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Words

        #region Uuids

        [Fact]
        public void Uuids_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<Guid> values = SUT.Uuids(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Uuids_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<Guid> values = SUT.Uuids(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Uuids

        #region Locale

        [Fact]
        public void Locale_ShouldReturnNotEmptyString()
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Locale());

            // Assert
            Assert.All(values, Assert.NotEmpty);
        }

        #endregion Locale

        #region Locales

        [Fact]
        public void Locales_ShouldReturnNotEmptyString()
        {
            // Act
            IEnumerable<string> values = SUT.Locales(TestingSetSize);

            // Assert
            Assert.All(values, Assert.NotEmpty);
        }

        [Fact]
        public void Locales_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            int count = (int)RandomNumber(int.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Locales(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        #endregion Locales
    }
}