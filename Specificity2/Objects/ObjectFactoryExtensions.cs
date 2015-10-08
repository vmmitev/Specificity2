// <copyright file="ObjectFactoryExtensions.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Provides standard factory methods.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ObjectFactoryExtensions
    {
        /// <summary>
        /// Digit characters.
        /// </summary>
        private static char[] Digits { get; } =
            Enumerable.Range(char.MinValue, char.MaxValue - char.MinValue)
            .Select(c => (char)c)
            .Where(c => char.IsDigit(c))
            .ToArray();

        /// <summary>
        /// Letter characters.
        /// </summary>
        private static char[] Letters { get; } =
            Enumerable.Range(0x00, 0xFF)
            .Select(c => (char)c)
            .Where(c => char.IsLetter(c))
            .ToArray();

        /// <summary>
        /// Generate a pseudo-random object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <param name="factory">The object factory.</param>
        /// <returns>A pseudo-random instance of the specified type.</returns>
        public static T Any<T>(this IObjectFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            var result = factory.Any(typeof(T));
            return (T)result;
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="sbyte"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="sbyte"/> value.</returns>
        public static byte AnyByte(this IObjectFactory factory, byte minimum = byte.MinValue, byte maximum = byte.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (byte)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="char"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="char"/> value.</returns>
        public static char AnyChar(this IObjectFactory factory, char minimum = char.MinValue, char maximum = char.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (char)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="DateTime"/> value.</returns>
        public static DateTime AnyDateTime(this IObjectFactory factory, DateTime? minimum = null, DateTime? maximum = null, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            minimum = minimum ?? DateTime.MinValue;
            maximum = maximum ?? DateTime.MaxValue;
            long ticks = factory.AnyLong(minimum.Value.Ticks, maximum.Value.Ticks, distribution);
            return new DateTime(ticks);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="DateTimeOffset"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="DateTimeOffset"/> value.</returns>
        public static DateTimeOffset AnyDateTimeOffset(this IObjectFactory factory, DateTimeOffset? minimum = null, DateTimeOffset? maximum = null, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            minimum = minimum ?? DateTimeOffset.MinValue;
            maximum = maximum ?? DateTimeOffset.MaxValue;
            long ticks = factory.AnyLong(minimum.Value.Ticks, maximum.Value.Ticks, distribution);
            return new DateTimeOffset(new DateTime(ticks));
        }

        /// <summary>
        /// Generate a pseudo-random digit character.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="char"/> value.</returns>
        public static char AnyDigit(this IObjectFactory factory, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            int index = factory.AnyInt(0, ObjectFactoryExtensions.Digits.Length, distribution);
            return ObjectFactoryExtensions.Digits[index];
        }

        /// <summary>
        /// Generates an <see cref="IEnumerable"/> of pseudo-random objects of the specified type.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="type">The type of items to create.</param>
        /// <param name="minimumLength">The minimum length of the collection.</param>
        /// <param name="maximumLength">The maximum length of the collection.</param>
        /// <param name="itemFactory">The factory method used to create the items.</param>
        /// <returns>A collection of pseudo-random object of the specified type.</returns>
        public static IEnumerable AnyEnumerable(this IObjectFactory factory, Type type, int minimumLength = 0, int maximumLength = 20, Func<IObjectFactory, object> itemFactory = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            itemFactory = itemFactory ?? (f => f.Any(type));
            int length = factory.AnyInt(minimumLength, maximumLength);
            var method = typeof(ObjectFactoryExtensions).GetMethod("AnyEnumerableInternal", BindingFlags.NonPublic | BindingFlags.Static);
            method = method.MakeGenericMethod(type);
            return (IEnumerable)method.Invoke(null, new object[] { factory, length, itemFactory });
        }

        /// <summary>
        /// Generates an <see cref="IEnumerable{T}"/> of pseudo-random objects of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of items to create.</typeparam>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimumLength">The minimum length of the collection.</param>
        /// <param name="maximumLength">The maximum length of the collection.</param>
        /// <param name="itemFactory">The factory method used to create the items.</param>
        /// <returns>A collection of pseudo-random object of the specified type.</returns>
        public static IEnumerable<T> AnyEnumerable<T>(this IObjectFactory factory, int minimumLength = 0, int maximumLength = 20, Func<IObjectFactory, T> itemFactory = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            itemFactory = itemFactory ?? (f => f.Any<T>());
            int length = factory.AnyInt(minimumLength, maximumLength);
            return AnyEnumerableInternal<T>(factory, length, f => itemFactory(f));
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="float"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="float"/> value.</returns>
        public static float AnyFloat(this IObjectFactory factory, float minimum = float.MinValue, float maximum = float.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (float)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="int"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="int"/> value.</returns>
        public static int AnyInt(this IObjectFactory factory, int minimum = int.MinValue, int maximum = int.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (int)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random letter character.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="char"/> value.</returns>
        public static char AnyLetter(this IObjectFactory factory, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            int index = factory.AnyInt(0, ObjectFactoryExtensions.Letters.Length, distribution);
            return ObjectFactoryExtensions.Letters[index];
        }

        /// <summary>
        /// Generate a pseudo-random letter or digit character.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="char"/> value.</returns>
        public static char AnyLetterOrDigit(this IObjectFactory factory, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            int index = factory.AnyInt(0, ObjectFactoryExtensions.Letters.Length + ObjectFactoryExtensions.Digits.Length, distribution);
            if (index < ObjectFactoryExtensions.Letters.Length)
            {
                return ObjectFactoryExtensions.Letters[index];
            }

            return ObjectFactoryExtensions.Digits[index - ObjectFactoryExtensions.Letters.Length];
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="long"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="long"/> value.</returns>
        public static long AnyLong(this IObjectFactory factory, long minimum = long.MinValue, long maximum = long.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (long)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="short"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="short"/> value.</returns>
        public static short AnyShort(this IObjectFactory factory, short minimum = short.MinValue, short maximum = short.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (short)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generates a pseudo-random string.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimumLength">The minimum string length.</param>
        /// <param name="maximumLength">The maximum string length.</param>
        /// <param name="characterFactory">The character factory to use.</param>
        /// <returns>A pseudo-random string.</returns>
        public static string AnyString(this IObjectFactory factory, int minimumLength = 0, int maximumLength = 20, Func<char> characterFactory = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            characterFactory = characterFactory ?? (() => factory.AnyLetterOrDigit());
            int length = factory.AnyInt(minimumLength, maximumLength);
            var text = new StringBuilder();
            while (text.Length < length)
            {
                text.Append(characterFactory());
            }

            return text.ToString();
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="TimeSpan"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="TimeSpan"/> value.</returns>
        public static TimeSpan AnyTimeSpan(this IObjectFactory factory, TimeSpan? minimum = null, TimeSpan? maximum = null, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            minimum = minimum ?? TimeSpan.MinValue;
            maximum = maximum ?? TimeSpan.MaxValue;
            long ticks = factory.AnyLong(minimum.Value.Ticks, maximum.Value.Ticks, distribution);
            return new TimeSpan(ticks);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="uint"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="uint"/> value.</returns>
        [CLSCompliant(false)]
        public static uint AnyUInt(this IObjectFactory factory, uint minimum = uint.MinValue, uint maximum = uint.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (uint)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="ulong"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="ulong"/> value.</returns>
        [CLSCompliant(false)]
        public static ulong AnyULong(this IObjectFactory factory, ulong minimum = ulong.MinValue, ulong maximum = ulong.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (ulong)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="ushort"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="ushort"/> value.</returns>
        [CLSCompliant(false)]
        public static ushort AnyUShort(this IObjectFactory factory, ushort minimum = ushort.MinValue, ushort maximum = ushort.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (ushort)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Freezes the specified instance as the result for any further calls to obtain an object of the specified type.
        /// </summary>
        /// <param name="registry">The registry.</param>
        /// <param name="type">The type to freeze.</param>
        /// <param name="instance">The instance to return for any further calls to obtain an object of the specified type.</param>
        public static void Freeze(this IObjectFactoryRegistry registry, Type type, object instance)
        {
            ValidateRegistryArgument(registry);

            registry.Register(type, f => instance);
        }

        /// <summary>
        /// Freezes the specified instance as the result for any further calls to obtain an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to freeze.</typeparam>
        /// <param name="registry">The registry.</param>
        /// <param name="instance">The instance to return for any further calls to obtain an object of the specified type.</param>
        public static void Freeze<T>(this IObjectFactoryRegistry registry, T instance)
        {
            ValidateRegistryArgument(registry);

            registry.Register(typeof(T), f => instance);
        }

        /// <summary>
        /// Registers factory methods using the specified <see cref="IObjectFactoryRegistrar"/> type.
        /// </summary>
        /// <typeparam name="TRegistrar">The registrar type.</typeparam>
        /// <param name="registry">The registry.</param>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The generic type is the only parameter that needs to be supplied.")]
        public static void Register<TRegistrar>(this IObjectFactoryRegistry registry)
            where TRegistrar : IObjectFactoryRegistrar, new()
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }

            var registrar = new TRegistrar();
            registrar.Register(registry);
        }

        /// <summary>
        /// Creates an pseudo-random <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items to create.</typeparam>
        /// <param name="factory">The object factory.</param>
        /// <param name="length">The length of the collection to create.</param>
        /// <param name="itemFactory">The factory method used to create the items.</param>
        /// <returns>A pseudo-random collection.</returns>
        private static IEnumerable<T> AnyEnumerableInternal<T>(IObjectFactory factory, int length, Func<IObjectFactory, object> itemFactory)
        {
            for (int i = 0; i < length; ++i)
            {
                yield return (T)itemFactory(factory);
            }
        }

        private static void ValidateRegistryArgument(IObjectFactoryRegistry registry)
        {
            if (registry == null)
            {
                throw new ArgumentNullException("registry");
            }
        }
    }
}