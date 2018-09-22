using Fake.Common.Extensions;
using Fake.DataAccess.Random;
using System;
using System.Linq;
using Xunit;

namespace Fake.DataAccess.UnitTests.Random
{
    public class RandomScalarProviderTests
    {
        private const short TestingSetSize = 1000;
        private readonly RandomScalarProvider SUT = new RandomScalarProvider();
        private readonly Func<long, bool> IsEven = number => number % 2 == 0;
        private readonly Func<long, long, long> RandomNumber = (min, max) => new System.Random().Next(min, max);

        #region Number

        [Fact]
        public void Number_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            long minValue = long.MinValue;
            long maxValue = long.MaxValue;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Number());

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Number_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Number(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Number_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Number(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Number_ShouldFailForInvertedMinMax()
        {
            // Arrange
            long minValue = long.MaxValue;
            long maxValue = long.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Number(min: minValue, max: maxValue));
        }

        #endregion

        #region Numbers

        [Fact]
        public void Numbers_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            long minValue = long.MinValue;
            long maxValue = long.MaxValue;

            // Act
            var values = SUT.Numbers(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Numbers_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            var values = SUT.Numbers(TestingSetSize, min: minValue);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Numbers_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(long.MinValue, long.MaxValue);

            // Act
            var values = SUT.Numbers(TestingSetSize, max: maxValue);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Numbers_ShouldFailForInvertedMinMax()
        {
            // Arrange
            long minValue = long.MaxValue;
            long maxValue = long.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Numbers(TestingSetSize, min: minValue, max: maxValue));
        }

        #endregion


        #region Digit

        [Fact]
        public void Digit_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            byte minValue = 0;
            byte maxValue = 9;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit());

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Digit_ShouldReturnHigherThanMin()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(0, 9);

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Digit_ShouldReturnLowerThanMax()
        {
            // Arrange
            byte maxValue = (byte)RandomNumber(0, 9);

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Digit_ShouldFailForMaxHigherThan9()
        {
            // Arrange
            byte maxValue = 10;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Digit(max: maxValue));
        }

        [Fact]
        public void Digit_ShouldFailForInvertedMinMax()
        {
            // Arrange
            byte minValue = 9;
            byte maxValue = 0;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Digit(min: minValue, max: maxValue));
        }

        #endregion

        #region Digits

        [Fact]
        public void Digits_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            byte minValue = 0;
            byte maxValue = 9;

            // Act
            var values = SUT.Digits(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Digits_ShouldReturnHigherThanMin()
        {
            // Arrange
            byte minValue = (byte)RandomNumber(0, 9);

            // Act
            var values = SUT.Digits(TestingSetSize, min: minValue);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Digits_ShouldReturnLowerThanMax()
        {
            // Arrange
            byte maxValue = (byte)RandomNumber(0, 9);

            // Act
            var values = SUT.Digits(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Digits_ShouldFailForInvertedMinMax()
        {
            // Arrange
            byte minValue = 9;
            byte maxValue = 0;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Digits(TestingSetSize, min: minValue, max: maxValue));
        }

        #endregion


        #region Even

        [Fact]
        public void Even_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            long minValue = long.MinValue;
            long maxValue = long.MaxValue;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even());

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Even_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = long.MinValue + 20;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Even_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = long.MaxValue - 20;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Even_ShouldFailForInvertedMinMax()
        {
            // Arrange
            long minValue = long.MaxValue;
            long maxValue = long.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Even(min: minValue, max: maxValue));
        }

        #endregion

        #region Evens

        [Fact]
        public void Evens_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            long minValue = long.MinValue;
            long maxValue = long.MaxValue;

            // Act
            var values = SUT.Evens(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Evens_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = long.MinValue + 20;

            // Act
            var values = SUT.Evens(TestingSetSize, min: minValue);

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Evens_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = long.MaxValue - 20;

            // Act
            var values = SUT.Evens(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(IsEven(value)));
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Evens_ShouldFailForInvertedMinMax()
        {
            // Arrange
            long minValue = long.MaxValue;
            long maxValue = long.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Evens(TestingSetSize, min: minValue, max: maxValue));
        }

        #endregion


        #region Odd

        [Fact]
        public void Odd_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            long minValue = long.MinValue;
            long maxValue = long.MaxValue;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Odd());

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Odd_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = long.MinValue + 20;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Odd(min: minValue));

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Odd_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = long.MaxValue - 20;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Odd(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Odd_ShouldFailForInvertedMinMax()
        {
            // Arrange
            long minValue = long.MaxValue;
            long maxValue = long.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Odd(min: minValue, max: maxValue));
        }

        #endregion

        #region Odds

        [Fact]
        public void Odds_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            long minValue = long.MinValue;
            long maxValue = long.MaxValue;

            // Act
            var values = SUT.Odds(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Odds_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = long.MinValue + 20;

            // Act
            var values = SUT.Odds(TestingSetSize, min: minValue);

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Odds_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = long.MaxValue - 20;

            // Act
            var values = SUT.Odds(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.False(IsEven(value)));
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Odds_ShouldFailForInvertedMinMax()
        {
            // Arrange
            long minValue = long.MaxValue;
            long maxValue = long.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Odds(TestingSetSize, min: minValue, max: maxValue));
        }

        #endregion


        #region Double

        [Fact]
        public void Double_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            double minValue = double.MinValue;
            double maxValue = double.MaxValue;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Double());

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Double_ShouldReturnlHigherThanMin()
        {
            // Arrange
            double minValue = double.MinValue + 20;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Double(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Double_ShouldReturnLowerThanMax()
        {
            // Arrange
            double maxValue = double.MaxValue - 20;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Double(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Double_ShouldFailForInvertedMinMax()
        {
            // Arrange
            double minValue = double.MaxValue;
            double maxValue = double.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Double(min: minValue, max: maxValue));
        }

        #endregion

        #region Doubles

        [Fact]
        public void Doubles_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            double minValue = double.MinValue;
            double maxValue = double.MaxValue;

            // Act
            var values = SUT.Doubles(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Doubles_ShouldReturnHigherThanMin()
        {
            // Arrange
            double minValue = double.MinValue + 20;

            // Act
            var values = SUT.Doubles(TestingSetSize, min: minValue);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Doubles_ShouldReturnLowerThanMax()
        {
            // Arrange
            double maxValue = double.MaxValue - 20;

            // Act
            var values = SUT.Doubles(TestingSetSize, max: maxValue);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Doubles_ShouldFailForInvertedMinMax()
        {
            // Arrange
            double minValue = double.MaxValue;
            double maxValue = double.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Doubles(TestingSetSize, min: minValue, max: maxValue));
        }

        #endregion


        #region Char

        [Fact]
        public void Char_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            char minValue = char.MinValue;
            char maxValue = char.MaxValue;

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char());

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Char_ShouldReturnHigherThanMin()
        {
            // Arrange
            char minValue = (char)(char.MinValue + 20);

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Char_ShouldReturnLowerThanMax()
        {
            // Arrange
            char maxValue = (char)(char.MaxValue - 20);

            // Act
            var values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Char_ShouldFailForInvertedMinMax()
        {
            // Arrange
            char minValue = char.MaxValue;
            char maxValue = char.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Char(min: minValue, max: maxValue));
        }

        #endregion

        #region Chars

        [Fact]
        public void Chars_ShouldReturnBetweenMinAndMax()
        {
            // Arrange
            char minValue = char.MinValue;
            char maxValue = char.MaxValue;

            // Act
            var values = SUT.Chars(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value >= minValue && value <= maxValue));
        }

        [Fact]
        public void Chars_ShouldReturnHigherThanMin()
        {
            // Arrange
            char minValue = (char)(char.MinValue + 20);

            // Act
            var values = SUT.Chars(TestingSetSize, min: minValue);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Chars_ShouldReturnLowerThanMax()
        {
            // Arrange
            char maxValue = (char)(char.MaxValue - 20);

            // Act
            var values = SUT.Chars(TestingSetSize, max: maxValue);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Chars_ShouldFailForInvertedMinMax()
        {
            // Arrange
            char minValue = char.MaxValue;
            char maxValue = char.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Chars(TestingSetSize, min: minValue, max: maxValue));
        }

        #endregion
    }
}
