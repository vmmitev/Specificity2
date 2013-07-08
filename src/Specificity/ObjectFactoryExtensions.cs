//-----------------------------------------------------------------------------
// <copyright file="ObjectFactoryExtensions.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.ComponentModel;
    using System.Linq;
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
        private static readonly char[] Digits =
            Enumerable.Range(char.MinValue, char.MaxValue - char.MinValue)
            .Select(c => (char)c)
            .Where(c => char.IsDigit(c))
            .ToArray();

        /// <summary>
        /// Letter characters.
        /// </summary>
        private static readonly char[] Letters =
            Enumerable.Range(char.MinValue, char.MaxValue - char.MinValue)
            .Select(c => (char)c)
            .Where(c => char.IsLetter(c))
            .ToArray();

        /// <summary>
        /// Generate a pseudo-random <see cref="Single"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="Single"/> value.</returns>
        public static float AnyFloat(this IObjectFactory factory, float minimum = float.MinValue, float maximum = float.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (float)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="Int64"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="Int64"/> value.</returns>
        public static long AnyLong(this IObjectFactory factory, long minimum = long.MinValue, long maximum = long.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (long)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="UInt64"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="UInt64"/> value.</returns>
        public static ulong AnyULong(this IObjectFactory factory, ulong minimum = ulong.MinValue, ulong maximum = ulong.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (ulong)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="Int32"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="Int32"/> value.</returns>
        public static int AnyInt(this IObjectFactory factory, int minimum = int.MinValue, int maximum = int.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (int)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="UInt32"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="UInt32"/> value.</returns>
        public static uint AnyUInt(this IObjectFactory factory, uint minimum = uint.MinValue, uint maximum = uint.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (uint)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="Int16"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="Int16"/> value.</returns>
        public static short AnyShort(this IObjectFactory factory, short minimum = short.MinValue, short maximum = short.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (short)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="UInt16"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="UInt16"/> value.</returns>
        public static ushort AnyUShort(this IObjectFactory factory, ushort minimum = ushort.MinValue, ushort maximum = ushort.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (ushort)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="SByte"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="SByte"/> value.</returns>
        public static byte AnyByte(this IObjectFactory factory, byte minimum = byte.MinValue, byte maximum = byte.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (byte)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="Char"/> value.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="Char"/> value.</returns>
        public static char AnyChar(this IObjectFactory factory, char minimum = char.MinValue, char maximum = char.MaxValue, Distribution distribution = null)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            return (char)factory.AnyDouble(minimum, maximum, distribution);
        }

        /// <summary>
        /// Generate a pseudo-random digit character.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="Char"/> value.</returns>
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
        /// Generate a pseudo-random letter character.
        /// </summary>
        /// <param name="factory">The object factory.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="Char"/> value.</returns>
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
        /// <returns>A pseudo-random <see cref="Char"/> value.</returns>
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
        /// Register the standard factories with the <see cref="IObjectFactoryRegistry"/>.
        /// </summary>
        /// <param name="registry">The registry to register factory methods with.</param>
        [ObjectFactoryRegistrar]
        public static void RegisterFactories(IObjectFactoryRegistry registry)
        {
            registry.Register(typeof(float), f => f.AnyFloat());
            registry.Register(typeof(long), f => f.AnyLong());
            registry.Register(typeof(ulong), f => f.AnyULong());
            registry.Register(typeof(int), f => f.AnyInt());
            registry.Register(typeof(uint), f => f.AnyUInt());
            registry.Register(typeof(short), f => f.AnyShort());
            registry.Register(typeof(ushort), f => f.AnyUShort());
            registry.Register(typeof(byte), f => f.AnyByte());
            registry.Register(typeof(char), f => f.AnyChar());
            registry.Register(typeof(bool), f => f.AnyInt() % 2 == 0);
            registry.Register(typeof(string), f => f.AnyString());
            registry.Register(typeof(DateTime), f => f.AnyDateTime());
            registry.Register(typeof(DateTimeOffset), f => f.AnyDateTimeOffset());
            registry.Register(typeof(TimeSpan), f => f.AnyTimeSpan());
            registry.Register(typeof(Guid), f => Guid.NewGuid());
        }
    }
}
