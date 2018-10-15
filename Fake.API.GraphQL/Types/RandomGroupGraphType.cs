using Fake.DataAccess.Random;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Fake.API.GraphQL.Types
{
    public class RandomGroupGraphType : ObjectGraphType
    {
        private const short MIN_COUNT = 1;
        private const short MAX_COUNT = 1000;

        public RandomGroupGraphType()
        {
            var randomScalarProvider = new RandomScalarProvider();  // TODO Dependency injection

            Name = "Random";
            Description = "Random value generator";

            #region Integer

            Field<IntGraphType>(
                name: "Integer",
                description: "Random integer number",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Integer(min: min, max: max);
                });

            Field<ListGraphType<IntGraphType>>(
                name: "Integers",
                description: "List of random integer numbers",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Integers(count: count, min: min, max: max);
                });

            #endregion Integer

            #region Digit

            Field<IntGraphType>(
                name: "Digit",
                description: "Random digit",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = (int)byte.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = 9 }
                    ),
                resolve: ctx =>
                {
                    var min = CoerceToByte(ctx.GetArgument<int>("min"), max: 9);
                    var max = CoerceToByte(ctx.GetArgument<int>("max"), max: 9);
                    SwitchValuesWhenInverted(ref min, ref max);
                    return (int)randomScalarProvider.Digit(min: min, max: max);
                });

            Field<ListGraphType<IntGraphType>>(
                name: "Digits",
                description: "List of random digits",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = (int)byte.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = 9 }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var min = CoerceToByte(ctx.GetArgument<int>("min"), max: 9);
                    var max = CoerceToByte(ctx.GetArgument<int>("max"), max: 9);
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Digits(count: count, min: min, max: max).Select(value => (int)value);
                });

            #endregion Digit

            #region Even

            Field<IntGraphType>(
                name: "Even",
                description: "Random 32-bit even number",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    SwitchValuesWhenInverted(ref min, ref max);

                    if (min == max && min % 2 != 0)
                        return null;

                    return randomScalarProvider.Even(min: min, max: max);
                });

            Field<ListGraphType<IntGraphType>>(
                name: "Evens",
                description: "List of random 32-bit even numbers",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Evens(count: count, min: min, max: max);
                });

            #endregion Even

            #region Odd

            Field<IntGraphType>(
                name: "Odd",
                description: "Random 32-bit odd number",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Odd(min: min, max: max);
                });

            Field<ListGraphType<IntGraphType>>(
                name: "Odds",
                description: "List of random 32-bit odd numbers",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Odds(count: count, min: min, max: max);
                });

            #endregion Odd

            #region Decimal

            Field<FloatGraphType>(
                name: "Decimal",
                description: "Random decimal number",
                arguments: new QueryArguments(
                    new QueryArgument<FloatGraphType> { Name = "min", Description = "Minimum decimal value", DefaultValue = double.MinValue },
                    new QueryArgument<FloatGraphType> { Name = "max", Description = "Maximum decimal value", DefaultValue = double.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var min = ctx.GetArgument<double>("min");
                    var max = ctx.GetArgument<double>("max");
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Decimal(min: min, max: max);
                });

            Field<ListGraphType<FloatGraphType>>(
                name: "Decimals",
                description: "List of random decimal numbers",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<FloatGraphType> { Name = "min", Description = "Minimum decimal value", DefaultValue = double.MinValue },
                    new QueryArgument<FloatGraphType> { Name = "max", Description = "Maximum decimal value", DefaultValue = double.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var min = ctx.GetArgument<double>("min");
                    var max = ctx.GetArgument<double>("max");
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Decimals(count: count, min: min, max: max);
                });

            #endregion Number

            #region Char

            Field<StringGraphType>(
                name: "Char",
                description: "Random character",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "min", Description = "Minimum character value", DefaultValue = new string(new[] { (char)9 }) },
                    new QueryArgument<StringGraphType> { Name = "max", Description = "Maximum character value", DefaultValue = new string(new[] { char.MaxValue }) }
                    ),
                resolve: ctx =>
                {
                    var min = ctx.GetArgument<string>("min")?.FirstOrDefault() ?? char.MinValue;
                    var max = ctx.GetArgument<string>("max")?.FirstOrDefault() ?? char.MaxValue;
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Char(min: min, max: max);
                });

            Field<ListGraphType<StringGraphType>>(
                name: "Chars",
                description: "List of random characters",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<StringGraphType> { Name = "min", Description = "Minimum character value", DefaultValue = new string(new[] { (char)9 }) },
                    new QueryArgument<StringGraphType> { Name = "max", Description = "Maximum character value", DefaultValue = new string(new[] { char.MaxValue }) }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var min = ctx.GetArgument<string>("min")?.FirstOrDefault() ?? char.MinValue;
                    var max = ctx.GetArgument<string>("max")?.FirstOrDefault() ?? char.MaxValue;
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Chars(count: count, min: min, max: max);
                });

            #endregion Char

            #region String

            Field<StringGraphType>(
                name: "String",
                description: "Random string",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "minLength", Description = "Lower-bound string length", DefaultValue = 0 },
                    new QueryArgument<IntGraphType> { Name = "maxLength", Description = "Upper-bound string length", DefaultValue = (int)short.MaxValue },
                    new QueryArgument<StringGraphType> { Name = "minChar", Description = "Minimum character value", DefaultValue = new string(new[] { (char)9 }) },
                    new QueryArgument<StringGraphType> { Name = "maxChar", Description = "Maximum character value", DefaultValue = new string(new[] { char.MaxValue }) }
                    ),
                resolve: ctx =>
                {
                    var minLength = CoerceToShort(ctx.GetArgument<int>("minLength"), min: 0);
                    var maxLength = CoerceToShort(ctx.GetArgument<int>("maxLength"), min: 0);
                    SwitchValuesWhenInverted(ref minLength, ref maxLength);
                    var minChar = ctx.GetArgument<string>("minChar")?.FirstOrDefault() ?? char.MinValue;
                    var maxChar = ctx.GetArgument<string>("maxChar")?.FirstOrDefault() ?? char.MaxValue;
                    SwitchValuesWhenInverted(ref minChar, ref maxChar);
                    return randomScalarProvider.String(minLength: minLength, maxLength: maxLength, minChar: minChar, maxChar: maxChar);
                });

            Field<ListGraphType<StringGraphType>>(
                name: "Strings",
                description: "List of random strings",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<IntGraphType> { Name = "minLength", Description = "Lower-bound string length", DefaultValue = 0 },
                    new QueryArgument<IntGraphType> { Name = "maxLength", Description = "Upper-bound string length", DefaultValue = (int)short.MaxValue },
                    new QueryArgument<StringGraphType> { Name = "minChar", Description = "Minimum character value", DefaultValue = new string(new[] { (char)9 }) },
                    new QueryArgument<StringGraphType> { Name = "maxChar", Description = "Maximum character value", DefaultValue = new string(new[] { char.MaxValue }) }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var minLength = CoerceToShort(ctx.GetArgument<int>("minLength"), min: 0);
                    var maxLength = CoerceToShort(ctx.GetArgument<int>("maxLength"), min: 0);
                    SwitchValuesWhenInverted(ref minLength, ref maxLength);
                    var minChar = ctx.GetArgument<string>("minChar")?.FirstOrDefault() ?? char.MinValue;
                    var maxChar = ctx.GetArgument<string>("maxChar")?.FirstOrDefault() ?? char.MaxValue;
                    SwitchValuesWhenInverted(ref minChar, ref maxChar);
                    return randomScalarProvider.Strings(count: count, minLength: minLength, maxLength: maxLength, minChar: minChar, maxChar: maxChar);
                });

            #endregion String

            #region Hash

            Field<StringGraphType>(
                name: "Hash",
                description: "Random hash",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "length", Description = "The length of the hash string", DefaultValue = 40 },
                    new QueryArgument<BooleanGraphType> { Name = "upperCase", Description = "Returns the hash string with uppercase characters", DefaultValue = false }
                    ),
                resolve: ctx =>
                {
                    var length = CoerceToShort(ctx.GetArgument<int>("length"), min: 0);
                    var upperCase = ctx.GetArgument<bool>("upperCase");
                    return randomScalarProvider.Hash(length: length, upperCase: upperCase);
                });

            Field<ListGraphType<StringGraphType>>(
                name: "Hashes",
                description: "List of random hashes",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<IntGraphType> { Name = "length", Description = "The length of the hash string", DefaultValue = 40 },
                    new QueryArgument<BooleanGraphType> { Name = "upperCase", Description = "Returns the hash string with uppercase characters", DefaultValue = false }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var length = CoerceToShort(ctx.GetArgument<int>("length"), min: 0);
                    var upperCase = ctx.GetArgument<bool>("upperCase");
                    return randomScalarProvider.Hashes(count: count, length: length, upperCase: upperCase);
                });

            #endregion Hash

            #region Boolean

            Field<BooleanGraphType>(
                name: "Boolean",
                description: "Random boolean",
                arguments: new QueryArguments(
                    new QueryArgument<FloatGraphType> { Name = "weight", Description = "The probability of true" }
                    ),
                resolve: ctx =>
                {
                    var weight = ctx.GetArgument<double?>("weight");
                    return randomScalarProvider.Boolean(weight: (float?)weight);
                });

            Field<ListGraphType<BooleanGraphType>>(
                name: "Booleans",
                description: "List of random booleans",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<FloatGraphType> { Name = "weight", Description = "The probability of true" }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var weight = ctx.GetArgument<double?>("weight");
                    return randomScalarProvider.Booleans(count: count, weight: (float?)weight);
                });

            #endregion Hash

            #region EnumerationElement

            Field<StringGraphType>(
                name: "EnumerationElement",
                description: "Select random item from the list of items",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<StringGraphType>>> { Name = "items", Description = "List of items to choose from" }
                    ),
                resolve: ctx =>
                {
                    var items = ctx.GetArgument<IEnumerable<string>>("items");
                    return randomScalarProvider.EnumerationElement(enumeration: items);
                });

            Field<ListGraphType<StringGraphType>>(
                name: "EnumerationElements",
                description: "Select random sub-list from the list of items",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<StringGraphType>>>> { Name = "items", Description = "List of items to choose from" }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: 0, max: MAX_COUNT);
                    var items = ctx.GetArgument<IEnumerable<string>>("items");
                    return randomScalarProvider.EnumerationElements(count: count, enumeration: items);
                });

            #endregion EnumerationElement

            #region Shuffle

            Field<ListGraphType<StringGraphType>>(
                name: "Shuffle",
                description: "Shuffle the list of items",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<StringGraphType>>>> { Name = "items", Description = "List of items to choose from" }
                    ),
                resolve: ctx =>
                {
                    var items = ctx.GetArgument<IEnumerable<string>>("items");
                    return randomScalarProvider.Shuffle(enumeration: items);
                });

            #endregion Shuffle

            #region Word

            Field<StringGraphType>(
                name: "Word",
                description: "Random word",
                resolve: ctx => randomScalarProvider.Word());

            Field<ListGraphType<StringGraphType>>(
                name: "Words",
                description: "List of random words",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = "Number of values to generate" }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    return randomScalarProvider.Words(count: count);
                });

            #endregion Word

            #region Uuid

            Field<StringGraphType>(
                name: "Uuid",
                description: "Random UUID",
                resolve: ctx => randomScalarProvider.Uuid());

            Field<ListGraphType<StringGraphType>>(
                name: "Uuids",
                description: "List of random UUIDs",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = "Number of values to generate" }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    return randomScalarProvider.Uuids(count: count);
                });

            #endregion Word

            #region Locale

            Field<StringGraphType>(
                name: "Locale",
                description: "Random locale",
                resolve: ctx => randomScalarProvider.Locale());

            Field<ListGraphType<StringGraphType>>(
                name: "Locales",
                description: "List of random locales",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = "Number of values to generate" }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    return randomScalarProvider.Locales(count: count);
                });

            #endregion Locale

            #region AlphaNumeric

            Field<StringGraphType>(
                name: "AlphaNumeric",
                description: "Random alphanumeric string",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "minLength", Description = "Lower-bound string length", DefaultValue = 0 },
                    new QueryArgument<IntGraphType> { Name = "maxLength", Description = "Upper-bound string length", DefaultValue = 1000 }
                    ),
                resolve: ctx =>
                {
                    var minLength = CoerceToShort(ctx.GetArgument<int>("minLength"), min: 0);
                    var maxLength = CoerceToShort(ctx.GetArgument<int>("maxLength"), min: 0, max: 1000);
                    SwitchValuesWhenInverted(ref minLength, ref maxLength);
                    return randomScalarProvider.AlphaNumeric(minLength: minLength, maxLength: maxLength);
                });

            Field<ListGraphType<StringGraphType>>(
                name: "AlphaNumerics",
                description: "List of random alphanumeric strings",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<IntGraphType> { Name = "minLength", Description = "Minimum length to generate", DefaultValue = 0 },
                    new QueryArgument<IntGraphType> { Name = "maxLength", Description = "Maximum length to generate", DefaultValue = 1000 }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var minLength = CoerceToShort(ctx.GetArgument<int>("minLength"), min: 0);
                    var maxLength = CoerceToShort(ctx.GetArgument<int>("maxLength"), min: 0, max: 1000);
                    SwitchValuesWhenInverted(ref minLength, ref maxLength);
                    return randomScalarProvider.AlphaNumerics(count: count, minLength: minLength, maxLength: maxLength);
                });

            #endregion AlphaNumeric

            #region Hexadecimal

            Field<StringGraphType>(
                name: "Hexadecimal",
                description: "Random hexadecimal number",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Hexadecimal(min: min, max: max);
                });

            Field<ListGraphType<StringGraphType>>(
                name: "Hexadecimals",
                description: "List of random hexadecimal numbers",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count", Description = $"Number of values to generate, from {MIN_COUNT} to {MAX_COUNT}" },
                    new QueryArgument<IntGraphType> { Name = "min", Description = "Minimum value", DefaultValue = int.MinValue },
                    new QueryArgument<IntGraphType> { Name = "max", Description = "Maximum value", DefaultValue = int.MaxValue }
                    ),
                resolve: ctx =>
                {
                    var count = CoerceToShort(ctx.GetArgument<int>("count"), min: MIN_COUNT, max: MAX_COUNT);
                    var min = ctx.GetArgument<int>("min");
                    var max = ctx.GetArgument<int>("max");
                    SwitchValuesWhenInverted(ref min, ref max);
                    return randomScalarProvider.Hexadecimals(count: count, min: min, max: max);
                });

            #endregion Hexadecimal

            #region Weighted

            Field<StringGraphType>(
                name: "Weighted",
                description: "Select random item from the list of items based on weights",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<StringGraphType>>> { Name = "items", Description = "List of items to choose from" },
                    new QueryArgument<NonNullGraphType<ListGraphType<FloatGraphType>>> { Name = "weights", Description = "List of probabilities that corresponding item will be chosen" }
                    ),
                resolve: ctx =>
                {
                    var items = ctx.GetArgument<IEnumerable<string>>("items");
                    var weights = ctx.GetArgument<IEnumerable<double>>("weights");
                    return randomScalarProvider.Weighted(items: items, weights: weights.Select(value => (float)value).ToArray());
                });

            #endregion EnumerationElement
        }

        private static short CoerceToShort(int number, short min = short.MinValue, short max = short.MaxValue)
        {
            if (number <= min)
                return min;

            if (number >= max)
                return max;

            return (short)number;
        }

        private static byte CoerceToByte(int number, byte min = byte.MinValue, byte max = byte.MaxValue)
        {
            if (number <= min)
                return min;

            if (number >= max)
                return max;

            return (byte)number;
        }

        private static void SwitchValuesWhenInverted<T>(ref T shouldBeLower, ref T shouldBeHigher)
            where T : IComparable
        {
            if (shouldBeLower.CompareTo(shouldBeHigher) > 0)
            {
                var temp = shouldBeLower;
                shouldBeLower = shouldBeHigher;
                shouldBeHigher = temp;
            }
        }
    }
}
