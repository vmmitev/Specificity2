//-----------------------------------------------------------------------------
// <copyright file="ObjectAssertionsTests.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.SpecificityTests
{
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Testing.Specificity;

    /// <summary>
    /// Provides tests for the <see cref="ObjectAssertions"/> extension methods.
    /// </summary>
    [TestClass]
    public class ObjectAssertionsTests
    {
        /// <summary>
        /// Verifies that <see cref="ObjectAssertions.ShouldBeNull{T}(ConstrainedValue{T})"/> should pass when given a <see langword="null"/>
        /// reference.
        /// </summary>
        [TestMethod]
        public void ShouldBeNull_GivenNull_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That((object)null).ShouldBeNull();
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies that <see cref="ObjectAssertions.ShouldBeNull{T}(ConstrainedValue{T})"/> fails when given an object reference.
        /// </summary>
        [TestMethod]
        public void ShouldBeNull_GivenObject_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new object()).ShouldBeNull();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldNotBeNull{T}(ConstrainedValue{T})"/> fails when given a
        /// <see langword="null"/> reference.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeNull_GivenNull_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That((object)null).ShouldNotBeNull();
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldNotBeNull{T}(ConstrainedValue{T})"/> does not fail when given an object instance.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeNull_GivenObject_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new object()).ShouldNotBeNull();
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldBeEqualTo{TExpected, TActual}(ConstrainedValue{TActual}, TExpected)"/> fails
        /// when given objects of different types.
        /// </summary>
        [TestMethod]
        public void ShouldBeEqualTo_GivenObjectsOfDifferentTypes_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldBeEqualTo(new object());
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldBeEqualTo{TExpected, TActual}(ConstrainedValue{TActual}, TExpected)"/> fails
        /// when given different object instances.
        /// </summary>
        [TestMethod]
        public void ShouldBeEqualTo_GivenDifferentObjects_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldBeEqualTo(new ArrayList());
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldBeEqualTo{TExpected, TActual}(ConstrainedValue{TActual}, TExpected)"/> does
        /// not fail when given objects that are equal.
        /// </summary>
        [TestMethod]
        public void ShouldBeEqualTo_GivenEqualObjects_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That((object)10).ShouldBeEqualTo((object)10);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldNotBeEqualTo{TExpected, TActual}(ConstrainedValue{TActual}, TExpected)"/> does
        /// not fail when given objects of different types.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenObjectsOfDifferentTypes_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldNotBeEqualTo(new object());
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldNotBeEqualTo{TExpected, TActual}(ConstrainedValue{TActual}, TExpected)"/> does
        /// not fail when given different object instances.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenDifferentObjects_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new ArrayList()).ShouldNotBeEqualTo(new ArrayList());
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldNotBeEqualTo{TExpected, TActual}(ConstrainedValue{TActual}, TExpected)"/> fails
        /// when given objects that are equal.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeEqualTo_GivenEqualObjects_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That((object)10).ShouldNotBeEqualTo((object)10);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldBeSameAs{T}(ConstrainedValue{T}, T)"/> fails when given different object
        /// instances.
        /// </summary>
        [TestMethod]
        public void ShouldBeSameAs_GivenDifferentInstances_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new object()).ShouldBeSameAs(new object());
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldBeSameAs{T}(ConstrainedValue{T}, T)"/> does not fail when given same
        /// instances.
        /// </summary>
        [TestMethod]
        public void ShouldBeSameAs_GivenSameInstances_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                object instance = new object();
                Specify.That(instance).ShouldBeSameAs(instance);
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldNotBeSameAs{T}(ConstrainedValue{T}, T)"/> does not fail when given different
        /// object instances.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeSameAs_GivenDifferentInstances_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That(new object()).ShouldNotBeSameAs(new object());
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldNotBeSameAs{T}(ConstrainedValue{T}, T)"/> fails when given the same object
        /// instances.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeSameAs_GivenSameInstances_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                object instance = new object();
                Specify.That(instance).ShouldNotBeSameAs(instance);
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldBeInstanceOfType{T}(ConstrainedValue{T}, System.Type)"/> fails when given
        /// objects of different types.
        /// </summary>
        [TestMethod]
        public void ShouldBeInstanceOfType_GivenObjectOfDifferentType_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldBeInstanceOfType(typeof(int));
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldBeInstanceOfType{T}(ConstrainedValue{T}, System.Type)"/> does not fail when
        /// given an object intance of the specified type.
        /// </summary>
        [TestMethod]
        public void ShouldBeInstanceOfType_GivenObjectOfType_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldBeInstanceOfType(typeof(string));
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldNotBeInstanceOfType{T}(ConstrainedValue{T}, System.Type)"/> does not fail when
        /// given objects of different types.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeInstanceOfType_GivenObjectOfDifferentType_ShouldNotFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotBeInstanceOfType(typeof(int));
            }).ShouldNotHaveThrown();
        }

        /// <summary>
        /// Verifies <see cref="ObjectAssertions.ShouldNotBeInstanceOfType{T}(ConstrainedValue{T}, System.Type)"/> fails when given an
        /// object instance of the specified type.
        /// </summary>
        [TestMethod]
        public void ShouldNotBeInstanceOfType_GivenObjectOfType_ShouldFail()
        {
            Specify.ThatAction(delegate
            {
                Specify.That("foo").ShouldNotBeInstanceOfType(typeof(string));
            }).ShouldHaveThrown(typeof(ConstraintFailedException));
        }
    }
}
