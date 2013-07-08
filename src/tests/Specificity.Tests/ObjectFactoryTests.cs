//-----------------------------------------------------------------------------
// <copyright file="ObjectFactoryTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectFactoryTests
    {
        [TestMethod]
        public void AnyDoubleShouldReturnRandomDouble()
        {
            this.TestFactory<double>(f => f.AnyDouble());
        }

        [TestMethod]
        public void AnyOfDoubleShouldReturnRandomDouble()
        {
            this.TestFactory<double>();
        }

        [TestMethod]
        public void AnyFloatShouldReturnRandomFloat()
        {
            this.TestFactory<float>(f => f.AnyFloat());
        }

        [TestMethod]
        public void AnyOfFloatShouldReturnRandomFloat()
        {
            this.TestFactory<float>();
        }

        [TestMethod]
        public void AnyLongShouldReturnRandomLong()
        {
            this.TestFactory<long>(f => f.AnyLong());
        }

        [TestMethod]
        public void AnyOfLongShouldReturnRandomLong()
        {
            this.TestFactory<long>();
        }

        [TestMethod]
        public void AnyULongShouldReturnRandomULong()
        {
            this.TestFactory<ulong>(f => f.AnyULong());
        }

        [TestMethod]
        public void AnyOfULongShouldReturnRandomULong()
        {
            this.TestFactory<ulong>();
        }

        [TestMethod]
        public void AnyIntShouldReturnRandomInt()
        {
            this.TestFactory<int>(f => f.AnyInt());
        }

        [TestMethod]
        public void AnyOfIntShouldReturnRandomInt()
        {
            this.TestFactory<int>();
        }

        [TestMethod]
        public void AnyUIntShouldReturnRandomUInt()
        {
            this.TestFactory<uint>(f => f.AnyUInt());
        }

        [TestMethod]
        public void AnyOfUIntShouldReturnRandomUInt()
        {
            this.TestFactory<uint>();
        }

        [TestMethod]
        public void AnyShortShouldReturnRandomShort()
        {
            this.TestFactory<short>(f => f.AnyShort());
        }

        [TestMethod]
        public void AnyOfShortShouldReturnRandomShort()
        {
            this.TestFactory<short>();
        }

        [TestMethod]
        public void AnyUShortShouldReturnRandomUShort()
        {
            this.TestFactory<ushort>(f => f.AnyUShort());
        }

        [TestMethod]
        public void AnyOfUShortShouldReturnRandomUShort()
        {
            this.TestFactory<ushort>();
        }

        [TestMethod]
        public void AnyByteShouldReturnRandomByte()
        {
            this.TestFactory<byte>(f => f.AnyByte());
        }

        [TestMethod]
        public void AnyOfByteShouldReturnRandomByte()
        {
            this.TestFactory<byte>();
        }

        [TestMethod]
        public void AnyCharShouldReturnRandomChar()
        {
            this.TestFactory<char>(f => f.AnyChar());
        }

        [TestMethod]
        public void AnyOfCharShouldReturnRandomChar()
        {
            this.TestFactory<char>();
        }

        [TestMethod]
        public void AnyOfBoolShouldReturnRandomBool()
        {
            this.TestFactory<bool>();
        }

        [TestMethod]
        public void AnyStringShouldReturnRandomString()
        {
            this.TestFactory<string>(f => f.AnyString());
        }

        [TestMethod]
        public void AnyOfStringShouldReturnRandomString()
        {
            this.TestFactory<string>();
        }

        [TestMethod]
        public void AnyDateTimeShouldReturnRandomDateTime()
        {
            this.TestFactory<DateTime>(f => f.AnyDateTime());
        }

        [TestMethod]
        public void AnyOfDateTimeShouldReturnRandomDateTime()
        {
            this.TestFactory<DateTime>();
        }

        [TestMethod]
        public void AnyDateTimeOffsetShouldReturnRandomDateTimeOffset()
        {
            this.TestFactory<DateTimeOffset>(f => f.AnyDateTimeOffset());
        }

        [TestMethod]
        public void AnyOfDateTimeOfsetShouldReturnRandomDateTimeOffset()
        {
            this.TestFactory<DateTimeOffset>();
        }

        [TestMethod]
        public void AnyTimeSpanShouldReturnRandomTimeSpan()
        {
            this.TestFactory<TimeSpan>(f => f.AnyTimeSpan());
        }

        [TestMethod]
        public void AnyOfTimeSpanShouldReturnRandomTimeSpan()
        {
            this.TestFactory<TimeSpan>();
        }

        [TestMethod]
        public void AnyOfGuidShouldReturnRandomGuid()
        {
            this.TestFactory<Guid>();
        }

        [TestMethod]
        public void AnyOfSimpleTypeShouldReturnRandomSimpleType()
        {
            this.TestFactory<SimpleType>();
        }

        private void TestFactory<T>()
        {
            this.TestFactory(f => f.Any<T>());
        }

        private void TestFactory<T>(Func<ObjectFactory, T> factoryMethod)
        {
            var factory = new ObjectFactory();
            var result = factoryMethod(factory);
            Specify.That(result).Should.BeInstanceOfType(typeof(T));
        }

        public class SimpleType
        {
            public SimpleType(string text)
            {
                this.Text = text;
            }

            public string Text { get; set; }
        }
    }
}
