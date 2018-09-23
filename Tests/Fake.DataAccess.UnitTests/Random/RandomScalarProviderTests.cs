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
        private readonly Func<long, long, long> RandomNumber = (min, max) => new System.Random().NextLong(min, max);

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

        [Fact]
        public void Number_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = long.MinValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Number(min: minValue, max: minValue + 1));

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Number_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Number(min: maxValue - 1, max: maxValue));

            // Assert
            Assert.Contains(maxValue, values);
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
            short count = (short)RandomNumber(short.MinValue, 0);

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

        [Fact]
        public void Numbers_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = long.MinValue;

            // Act
            IEnumerable<long> values = SUT.Numbers(TestingSetSize, min: minValue, max: minValue + 1);

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Numbers_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Numbers(TestingSetSize, min: maxValue - 1, max: maxValue);

            // Assert
            Assert.Contains(maxValue, values);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Numbers_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<long> values = SUT.Numbers(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
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

        [Fact]
        public void Digit_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const byte minValue = byte.MinValue;

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(min: minValue, max: minValue + 1));

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Digit_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const byte maxValue = 9;

            // Act
            IEnumerable<byte> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Digit(min: maxValue - 1, max: maxValue));

            // Assert
            Assert.Contains(maxValue, values);
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
            short count = (short)RandomNumber(short.MinValue, 0);

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

        [Fact]
        public void Digits_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const byte minValue = byte.MinValue;

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize, min: minValue, max: minValue + 1);

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Digits_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const byte maxValue = 9;

            // Act
            IEnumerable<byte> values = SUT.Digits(TestingSetSize, min: maxValue - 1, max: maxValue);

            // Assert
            Assert.Contains(maxValue, values);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Digits_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<byte> values = SUT.Digits(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
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

        [Fact]
        public void Even_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = long.MinValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(min: minValue, max: minValue + 1));

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Even_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue - 1;    // long.MaxValue is odd number so it cannot be picked

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Even(min: maxValue - 1, max: maxValue));

            // Assert
            Assert.Contains(maxValue, values);
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
            short count = (short)RandomNumber(short.MinValue, 0);

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
        [Fact]
        public void Evens_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = long.MinValue;

            // Act
            IEnumerable<long> values = SUT.Evens(TestingSetSize, min: minValue, max: minValue + 1);

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Evens_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue - 1;    // long.MaxValue is odd number so it cannot be picked

            // Act
            IEnumerable<long> values = SUT.Evens(TestingSetSize, min: maxValue - 1, max: maxValue);

            // Assert
            Assert.Contains(maxValue, values);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Evens_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<long> values = SUT.Evens(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
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

        [Fact]
        public void Odd_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = long.MinValue + 1;    // long.MinValue is even number so it cannot be picked

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Odd(min: minValue, max: minValue + 1));

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Odd_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Odd(min: maxValue - 1, max: maxValue));

            // Assert
            Assert.Contains(maxValue, values);
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
            short count = (short)RandomNumber(short.MinValue, 0);

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

        [Fact]
        public void Odds_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = long.MinValue + 1;    // long.MinValue is even number so it cannot be picked

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, min: minValue, max: minValue + 1);

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Odds_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Odds(TestingSetSize, min: maxValue - 1, max: maxValue);

            // Assert
            Assert.Contains(maxValue, values);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Odds_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<long> values = SUT.Odds(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
        }

        #endregion Odds

        #region Decimal

        [Fact]
        public void Decimal_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const double minValue = double.MinValue;
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal());

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Decimal_ShouldReturnlHigherThanMin()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal(min: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Decimal_ShouldReturnLowerThanMax()
        {
            // Arrange
            var rand = new System.Random();
            double maxValue = rand.NextDouble(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal(max: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Decimal_ShouldFailForInvertedMinMax()
        {
            // Arrange
            const double minValue = double.MaxValue;
            const double maxValue = double.MinValue;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Decimal(min: minValue, max: maxValue));
        }

        [Fact]
        public void Decimal_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const double minValue = double.MinValue;

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal(min: minValue, max: minValue + 1));

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Decimal_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Decimal(min: maxValue - 1, max: maxValue));

            // Assert
            Assert.Contains(maxValue, values);
        }

        #endregion Decimal

        #region Decimals

        [Fact]
        public void Decimals_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Decimals_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const double minValue = double.MinValue;
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Decimals_ShouldReturnHigherThanMin()
        {
            // Arrange
            var rand = new System.Random();
            double minValue = rand.NextDouble(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, min: minValue);

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Decimals_ShouldReturnLowerThanMax()
        {
            // Arrange
            var rand = new System.Random();
            double maxValue = rand.NextDouble(double.MinValue, double.MaxValue);

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, max: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Decimals_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<double> values = SUT.Decimals(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Decimals_ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const double minValue = double.MaxValue;
            const double maxValue = double.MinValue;

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Decimals_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const double minValue = double.MinValue;

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, min: minValue, max: minValue + 1);

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Decimals_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const double maxValue = double.MaxValue;

            // Act
            IEnumerable<double> values = SUT.Decimals(TestingSetSize, min: maxValue - 1, max: maxValue);

            // Assert
            Assert.Contains(maxValue, values);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Decimals_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<double> values = SUT.Decimals(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
        }

        #endregion Decimals

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

        [Fact]
        public void Char_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const char minValue = char.MinValue;

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(min: minValue, max: (char)(minValue + 1)));

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Char_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Char(min: (char)(maxValue - 1), max: maxValue));

            // Assert
            Assert.Contains(maxValue, values);
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
            short count = (short)RandomNumber(short.MinValue, 0);

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

        [Fact]
        public void Chars_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const char minValue = char.MinValue;

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, min: minValue, max: (char)(minValue + 1));

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Chars_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = SUT.Chars(TestingSetSize, min: (char)(maxValue - 1), max: maxValue);

            // Assert
            Assert.Contains(maxValue, values);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Chars_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<char> values = SUT.Chars(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
        }

        #endregion Chars

        #region String

        [Fact]
        public void String_ShouldReturnBetweenDefaultMinAndMaxLength()
        {
            // Arrange
            const short minValue = 0;
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
        public void String_ShouldReturnZeroLength()
        {
            // Arrange
            const short length = 0;

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(minLength: length, maxLength: length));

            // Assert
            Assert.All(values, Assert.Empty);
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

        [Fact]
        public void String_ShouldFailForNegativeLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(short.MinValue, -1);

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.String(minLength: minValue));
        }

        [Theory]
        [InlineData(0)]
        public void String_ShouldWorkForMinLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(minLength: boundaryValue, maxLength: (short)(boundaryValue + 1)));

            // Assert
            Assert.Contains(values, value => value.Length == boundaryValue);
        }

        [Theory]
        [InlineData(short.MaxValue)]
        public void String_ShouldWorkForMaxLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.String(minLength: (short)(boundaryValue - 1), maxLength: boundaryValue));

            // Assert
            Assert.Contains(values, value => value.Length == boundaryValue);
        }

        [Fact]
        public void String_ShouldWorkForMinCharBoundaryCondition()
        {
            // Arrange
            const char minValue = char.MinValue;

            // Act
            IEnumerable<char> values = SUT.String(TestingSetSize, TestingSetSize, minChar: minValue, maxChar: (char)(minValue + 1)).ToCharArray();

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void String_ShouldWorkForMaxCharBoundaryCondition()
        {
            // Arrange
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = SUT.String(TestingSetSize, TestingSetSize, minChar: (char)(maxValue - 1), maxChar: maxValue).ToCharArray();

            // Assert
            Assert.Contains(maxValue, values);
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
        public void Strings_ShouldReturnZeroLength()
        {
            // Arrange
            const short length = 0;

            // Act
            IEnumerable<string> values = SUT.Strings(1, minLength: length, maxLength: length);

            // Assert
            Assert.All(values, Assert.Empty);
        }

        [Fact]
        public void Strings_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

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

        [Fact]
        public void Strings_ShouldReturnEmptyEnumerationForNegativeMinLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(short.MinValue, -1);

            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, minLength: minValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Theory]
        [InlineData(0)]
        public void Strings_ShouldWorkForMinLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, minLength: boundaryValue, maxLength: (short)(boundaryValue + 1));

            // Assert
            Assert.Contains(values, value => value.Length == boundaryValue);
        }

        [Theory]
        [InlineData(short.MaxValue)]
        public void Strings_ShouldWorkForMaxLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.Strings(TestingSetSize, minLength: (short)(boundaryValue - 1), maxLength: boundaryValue);

            // Assert
            Assert.Contains(values, value => value.Length == boundaryValue);
        }

        [Fact]
        public void Strings_ShouldWorkForMinCharBoundaryCondition()
        {
            // Arrange
            const char minValue = char.MinValue;

            // Act
            IEnumerable<char> values = SUT.Strings(1, TestingSetSize, TestingSetSize, minChar: minValue, maxChar: (char)(minValue + 1)).First().ToCharArray();

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Strings_ShouldWorkForMaxCharBoundaryCondition()
        {
            // Arrange
            const char maxValue = char.MaxValue;

            // Act
            IEnumerable<char> values = SUT.Strings(1, TestingSetSize, TestingSetSize, minChar: (char)(maxValue - 1), maxChar: maxValue).First().ToCharArray();

            // Assert
            Assert.Contains(maxValue, values);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Strings_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.Strings(boundaryValue, 1, 1);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
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

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Hash_ShouldWorkForLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            string value = SUT.Hash(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, value.Length);
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
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Hashes(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Hashes_ShouldWorkForLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            string value = SUT.Hashes(1, boundaryValue).First();

            // Assert
            Assert.Equal(boundaryValue, value.Length);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Hashes_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.Hashes(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
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

        [Theory]
        [InlineData(0F, 0, TestingSetSize)]
        [InlineData(1F, TestingSetSize, 0)]
        public void Boolean_ShouldWorkForWeightBoundaryCondition(float boundaryValue, short numberOfTrues, short numberOfFalses)
        {
            // Act
            IEnumerable<bool> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Boolean(boundaryValue));

            // Assert
            Assert.Equal(numberOfTrues, values.Count(value => value));
            Assert.Equal(numberOfFalses, values.Count(value => !value));
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
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<bool> values = SUT.Booleans(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Theory]
        [InlineData(0F, 0, TestingSetSize)]
        [InlineData(1F, TestingSetSize, 0)]
        public void Booleans_ShouldWorkForWeightBoundaryCondition(float boundaryValue, short numberOfTrues, short numberOfFalses)
        {
            // Act
            IEnumerable<bool> values = SUT.Booleans(TestingSetSize, boundaryValue);

            // Assert
            Assert.Equal(numberOfTrues, values.Count(value => value));
            Assert.Equal(numberOfFalses, values.Count(value => !value));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Booleans_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<bool> values = SUT.Booleans(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
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

        [Fact]
        public void EnumerationElement_ShouldWorkForEnumerationLengthBoundaryCondition()
        {
            // Arrange
            IEnumerable<int> enumeration = new List<int>();

            // Act
            IEnumerable<int> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.EnumerationElement(enumeration));

            // Assert
            Assert.All(enumeration, value => Assert.Equal(default(int), value));
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

        [Fact]
        public void EnumerationElements_ShouldWorkForEnumerationLengthBoundaryCondition()
        {
            // Arrange
            IEnumerable<int> enumeration = new List<int>();

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(0, enumeration);

            // Assert
            Assert.Empty(enumeration);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void EnumerationElements_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, boundaryValue);

            // Act
            IEnumerable<int> values = SUT.EnumerationElements(boundaryValue, enumeration);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
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

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(short.MaxValue, false)]
        public void Shuffle_ShouldWorkForEnumerationLengthBoundaryCondition(short boundaryValue, bool expectedSameEnumeration)
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, boundaryValue);

            // Act
            IEnumerable<int> values = SUT.Shuffle(enumeration);

            // Assert
            if (expectedSameEnumeration)
            {
                Assert.True(enumeration.SequenceEqual(values));
            }
            else
            {
                Assert.False(enumeration.SequenceEqual(values));
            }
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
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Words(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Theory]
        [InlineData(short.MinValue, 0)]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(short.MaxValue, short.MaxValue)]
        public void Words_ShouldWorkForCountBoundaryCondition(short boundaryValue, short expectedCount)
        {
            // Act
            IEnumerable<string> values = SUT.Words(boundaryValue);

            // Assert
            Assert.Equal(expectedCount, values.Count());
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
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<Guid> values = SUT.Uuids(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Theory]
        [InlineData(short.MinValue, 0)]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(short.MaxValue, short.MaxValue)]
        public void Uuids_ShouldWorkForCountBoundaryCondition(short boundaryValue, short expectedCount)
        {
            // Act
            IEnumerable<Guid> values = SUT.Uuids(boundaryValue);

            // Assert
            Assert.Equal(expectedCount, values.Count());
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
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.Locales(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Theory]
        [InlineData(short.MinValue, 0)]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(short.MaxValue, short.MaxValue)]
        public void Locales_ShouldWorkForCountBoundaryCondition(short boundaryValue, short expectedCount)
        {
            // Act
            IEnumerable<string> values = SUT.Locales(boundaryValue);

            // Assert
            Assert.Equal(expectedCount, values.Count());
        }

        #endregion Locales

        #region Alphanumeric

        [Fact]
        public void Alphanumeric_ShouldReturnBetweenDefaultMinAndMaxLength()
        {
            // Arrange
            const short minValue = 0;
            const short maxValue = short.MaxValue;

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.AlphaNumeric());

            // Assert
            Assert.All(values, value => Assert.InRange(value.Length, minValue, maxValue));
        }

        [Fact]
        public void Alphanumeric_ShouldReturnHigherThanMinLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(0, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.AlphaNumeric(minLength: minValue));

            // Assert
            Assert.All(values, value => Assert.True(value.Length >= minValue));
        }

        [Fact]
        public void Alphanumeric_ShouldReturnLowerThanMaxLength()
        {
            // Arrange
            short maxValue = (short)RandomNumber(0, short.MaxValue);

            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.AlphaNumeric(maxLength: maxValue));

            // Assert
            Assert.All(values, value => Assert.True(value.Length <= maxValue));
        }

        [Fact]
        public void Alphanumeric_ShouldFailForInvertedMinMax()
        {
            // Arrange
            const short minValue = short.MaxValue;
            const short maxValue = 0;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.AlphaNumeric(minLength: minValue, maxLength: maxValue));
        }

        [Fact]
        public void Alphanumeric_ShouldFailForNegativeLength()
        {
            // Arrange
            short length = (short)RandomNumber(short.MinValue, -1);

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.AlphaNumeric(minLength: length));
        }

        [Theory]
        [InlineData(0)]
        public void AlphaNumeric_ShouldWorkForMinLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize)
                .Select(_ => SUT.AlphaNumeric(minLength: boundaryValue, maxLength: (short)(boundaryValue + 1)));

            // Assert
            Assert.Contains(values, value => value.Length == boundaryValue);
        }

        [Theory]
        [InlineData(short.MaxValue)]
        public void AlphaNumeric_ShouldWorkForMaxLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize)
                .Select(_ => SUT.AlphaNumeric(minLength: (short)(boundaryValue - 1), maxLength: boundaryValue));

            // Assert
            Assert.Contains(values, value => value.Length == boundaryValue);
        }

        #endregion AlphaNumeric

        #region Alphanumerics

        [Fact]
        public void Alphanumerics_ShouldReturnCorrectCount()
        {
            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize);

            // Assert
            Assert.Equal(TestingSetSize, values.Count());
        }

        [Fact]
        public void Alphanumerics_ShouldReturnBetweenDefaultMinAndMaxLength()
        {
            // Arrange
            const short minValue = 0;
            const short maxValue = short.MaxValue;

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.InRange(value.Length, minValue, maxValue));
        }

        [Fact]
        public void Alphanumerics_ShouldReturnHigherThanMinLength()
        {
            // Arrange
            short minValue = (short)RandomNumber(0, short.MaxValue);

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, minLength: minValue);

            // Assert
            Assert.All(values, value => Assert.True(value.Length >= minValue));
        }

        [Fact]
        public void Alphanumerics_ShouldReturnLowerThanMaxLength()
        {
            // Arrange
            short maxValue = (short)RandomNumber(0, short.MaxValue);

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, maxLength: maxValue);

            // Assert
            Assert.All(values, value => Assert.True(value.Length <= maxValue));
        }

        [Fact]
        public void Alphanumerics_ShouldReturnEmptyEnumerationForInvertedMinMax()
        {
            // Arrange
            const short minValue = short.MaxValue;
            const short maxValue = 0;

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, minLength: minValue, maxLength: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Alphanumerics_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 0);

            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Theory]
        [InlineData(0)]
        public void AlphaNumericc_ShouldWorkForMinLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, minLength: boundaryValue, maxLength: (short)(boundaryValue + 1));

            // Assert
            Assert.Contains(values, value => value.Length == boundaryValue);
        }

        [Theory]
        [InlineData(short.MaxValue)]
        public void AlphaNumerics_ShouldWorkForMaxLengthBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(TestingSetSize, minLength: (short)(boundaryValue - 1), maxLength: boundaryValue);

            // Assert
            Assert.Contains(values, value => value.Length == boundaryValue);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void AlphaNumerics_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.AlphaNumerics(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
        }

        #endregion AlphaNumeric

        #region Hexadecimal

        [Fact]
        public void Hexadecimal_ShouldReturnValidHexadecimal()
        {
            // Act
            IEnumerable<string> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Hexadecimal());

            // Assert
            Assert.All(values, value => Assert.True(long.TryParse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long number)));
        }

        [Fact]
        public void Hexadecimal_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize)
                .Select(_ => SUT.Hexadecimal())
                .Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Hexadecimal_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(0, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize)
                .Select(_ => SUT.Hexadecimal(min: minValue))
                .Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Hexadecimal_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(0, long.MaxValue);

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize)
                .Select(_ => SUT.Hexadecimal(max: maxValue))
                .Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Hexadecimal_ShouldFailForInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = 0;

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Hexadecimal(min: minValue, max: maxValue));
        }

        [Fact]
        public void Hexadecimal_ShouldFailForNegativeMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, -1);

            // Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => SUT.Hexadecimal(min: minValue));
        }

        [Fact]
        public void Hexadecimal_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = 0;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize)
                .Select(_ => SUT.Hexadecimal(min: minValue, max: minValue + 1))
                .Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Hexadecimal_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = Enumerable.Range(1, TestingSetSize)
                .Select(_ => SUT.Hexadecimal(min: maxValue - 1, max: maxValue))
                .Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.Contains(maxValue, values);
        }

        #endregion Hexadecimal

        #region Hexadecimals

        [Fact]
        public void Hexadecimals_ShouldReturnValidHexadecimal()
        {
            // Act
            IEnumerable<string> values = SUT.Hexadecimals(TestingSetSize);

            // Assert
            Assert.All(values, value => Assert.True(long.TryParse(value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out long number)));
        }

        [Fact]
        public void Hexadecimals_ShouldReturnBetweenDefaultMinAndMax()
        {
            // Arrange
            const long minValue = long.MinValue;
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize).Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.All(values, value => Assert.InRange(value, minValue, maxValue));
        }

        [Fact]
        public void Hexadecimals_ShouldReturnHigherThanMin()
        {
            // Arrange
            long minValue = RandomNumber(0, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize, min: minValue).Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.All(values, value => Assert.True(value >= minValue));
        }

        [Fact]
        public void Hexadecimals_ShouldReturnLowerThanMax()
        {
            // Arrange
            long maxValue = RandomNumber(0, long.MaxValue);

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize, max: maxValue).Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.All(values, value => Assert.True(value <= maxValue));
        }

        [Fact]
        public void Hexadecimals_ShouldReturnEmptyEnumerationForNegativeCount()
        {
            // Arrange
            short count = (short)RandomNumber(short.MinValue, 1);

            // Act
            IEnumerable<string> values = SUT.Hexadecimals(count);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Hexadecimals_ShouldReturnEmptyEnumerationInvertedMinMax()
        {
            // Arrange
            const long minValue = long.MaxValue;
            const long maxValue = 0;

            // Act
            IEnumerable<string> values = SUT.Hexadecimals(TestingSetSize, min: minValue, max: maxValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Hexadecimals_ShouldReturnEmptyEnumerationNegativeMin()
        {
            // Arrange
            long minValue = RandomNumber(long.MinValue, -1);

            // Act
            IEnumerable<string> values = SUT.Hexadecimals(TestingSetSize, min: minValue);

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }

        [Fact]
        public void Hexadecimals_ShouldWorkForMinBoundaryCondition()
        {
            // Arrange
            const long minValue = 0;

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize, min: minValue, max: minValue + 1)
                .Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.Contains(minValue, values);
        }

        [Fact]
        public void Hexadecimals_ShouldWorkForMaxBoundaryCondition()
        {
            // Arrange
            const long maxValue = long.MaxValue;

            // Act
            IEnumerable<long> values = SUT.Hexadecimals(TestingSetSize, min: maxValue - 1, max: maxValue)
                .Select(value => Convert.ToInt64(value, 16));

            // Assert
            Assert.Contains(maxValue, values);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(short.MaxValue)]
        public void Hexadecimals_ShouldWorkForCountBoundaryCondition(short boundaryValue)
        {
            // Act
            IEnumerable<string> values = SUT.Hexadecimals(boundaryValue);

            // Assert
            Assert.Equal(boundaryValue, values.Count());
        }

        #endregion Hexadecimals

        #region Weighted

        [Fact]
        public void Weighted_ShouldReturnItemFromEnumeration()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, 5);
            float[] weights = { 0.1F, 0.6F, 0.1F, 0.1F, 0.1F };

            // Act
            IEnumerable<int> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Weighted(enumeration, weights));

            // Assert
            Assert.All(values, value => Assert.Contains(value, enumeration));
        }

        [Fact]
        public void Weighted_ShouldReturnDefaultItemForNullEnumration()
        {
            // Arrange
            const IEnumerable<int> enumeration = null;
            const float[] weights = null;

            // Act
            IEnumerable<int> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Weighted(enumeration, weights));

            // Assert
            Assert.All(values, value => Assert.Equal(default(int), value));
        }

        [Fact]
        public void Weighted_ShouldFailForDifferentCounts()
        {
            // Arrange
            IEnumerable<int> enumeration = Enumerable.Range(1, 5);
            float[] weights = { 0.1F };

            // Act/Assert
            Assert.ThrowsAny<Exception>(() => SUT.Weighted(enumeration, weights));
        }

        [Fact]
        public void Weighted_ShouldWorkForEmptyEnumration()
        {
            // Arrange
            IEnumerable<int> enumeration = new List<int>();
            float[] weights = { };

            // Act
            IEnumerable<int> values = Enumerable.Range(1, TestingSetSize).Select(_ => SUT.Weighted(enumeration, weights));

            // Assert
            Assert.All(values, value => Assert.Equal(default(int), value));
        }

        #endregion Weighted
    }
}