//-----------------------------------------------------------------------------
// <copyright file="ObjectFactory.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

namespace Testing.Specificity
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Provides a factory object that can be used to create "random" objects
    /// and values for use in unit tests.
    /// </summary>
    /// <remarks>
    /// <para>Unit tests need to be repeatable. For this reason <see cref="ObjectFactory"/>
    /// creates pseudo-random objects and values by using a <see cref="Random"/> instance
    /// that is by default constructed with a fixed seed. If you construct an
    /// <see cref="ObjectFactory"/> with a seed you should ensure the seed is a
    /// compile-time constant.</para>
    /// <para><see cref="ObjectFactory"/> is intended to be used to create objects
    /// and values necessary for the code under test but that is not really relevant
    /// to what is being tested. This can greatly reduce the amount of setup code
    /// necessary in a test as well as reduce coupling, making tests less fragile.</para>
    /// </remarks>
    public sealed class ObjectFactory : IObjectFactory, IObjectFactoryRegistry
    {
        /// <summary>
        /// Cached MethodInfo for the <see cref="m:ObjectFactory.Any{T}"/> method.
        /// </summary>
        private static readonly MethodInfo AnyMethod = typeof(IObjectFactory).GetMethod("Any");

        /// <summary>
        /// Static object factory methods.
        /// </summary>
        private static readonly DefaultObjectFactoryRegistry DefaultFactories;

        /// <summary>
        /// The pseudo-random number generator used when creating objects.
        /// </summary>
        private readonly Random random;

        /// <summary>
        /// The registered object factory methods.
        /// </summary>
        private readonly Dictionary<Type, Func<IObjectFactory, object>> factories = new Dictionary<Type, Func<IObjectFactory, object>>();

        /// <summary>
        /// Initializes static members of the <see cref="ObjectFactory"/> class.
        /// </summary>
        static ObjectFactory()
        {
            var registry = new DefaultObjectFactoryRegistry();
            registry.Register(typeof(double), f => f.AnyDouble());
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
            ObjectFactory.DefaultFactories = registry;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFactory"/> class.
        /// </summary>
        public ObjectFactory()
            : this(0x73577357)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFactory"/> class
        /// with a seed for the pseudo-random number generator.
        /// </summary>
        /// <param name="seed">The pseudo-random number generator seed value.</param>
        /// <remarks>The <paramref name="seed"/> should be a compile time constant to
        /// ensure that unit tests are repeatable.</remarks>
        public ObjectFactory(int seed)
        {
            this.random = new Random(seed);
            foreach (var kv in ObjectFactory.DefaultFactories)
            {
                this.factories[kv.Key] = kv.Value;
            }
        }

        /// <summary>
        /// Registers default factory methods using the specified <see cref="IObjectFactoryRegistrar"/> type.
        /// </summary>
        /// <typeparam name="TRegistrar">The registrar type.</typeparam>
        public static void Register<TRegistrar>()
            where TRegistrar : IObjectFactoryRegistrar, new()
        {
            ObjectFactory.DefaultFactories.Register<TRegistrar>();
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="Double"/> value.
        /// </summary>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="Double"/> value.</returns>
        public double AnyDouble(double minimum = double.MinValue, double maximum = double.MaxValue, Distribution distribution = null)
        {
            if (minimum >= maximum)
            {
                throw new ArgumentOutOfRangeException();
            }

            distribution = distribution ?? Distribution.Uniform;
            return (distribution.NextDouble(this.random) * (maximum - minimum)) + minimum;
        }

        /// <summary>
        /// Generate a pseudo-random object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to generate.</typeparam>
        /// <returns>A pseudo-random instance of the specified type.</returns>
        public T Any<T>()
        {
            Func<IObjectFactory, object> factory;
            if (this.factories.TryGetValue(typeof(T), out factory))
            {
                return (T)factory(this);
            }

            if (default(T) is IEnumerable)
            {
                return this.CreateCollection<T>();
            }

            return this.CreateObject<T>();
        }

        /// <summary>
        /// Registers a factory method that can be used to create instances of the specified type.
        /// </summary>
        /// <param name="type">The type of object created by the factory.</param>
        /// <param name="factory">The factory method.</param>
        public void Register(Type type, Func<IObjectFactory, object> factory)
        {
            this.factories[type] = factory;
        }

        /// <summary>
        /// Determines if the specified method is a registrar method.
        /// </summary>
        /// <param name="method">The method to check.</param>
        /// <returns><see langword="true"/> if the method is a registrar method;
        /// otherwise <see langword="false"/>.</returns>
        private static bool IsRegisrar(MethodInfo method)
        {
            if (method.GetCustomAttribute(typeof(ObjectFactoryRegistrarAttribute)) == null)
            {
                return false;
            }

            if (method.GetParameters().SingleOrDefault(t => t.ParameterType == typeof(IObjectFactoryRegistry)) == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates an instance of the specified collection type, caching the dynamically
        /// created factory used.
        /// </summary>
        /// <typeparam name="T">The collection type to create.</typeparam>
        /// <returns>An instance of the specified collection type.</returns>
        private T CreateCollection<T>()
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates an instance of the specified type, caching the dynamically created
        /// factory used.
        /// </summary>
        /// <typeparam name="T">The type of the object to create.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        private T CreateObject<T>()
        {
            var type = typeof(T);
            if (type.IsInterface || type.IsAbstract)
            {
                throw new InvalidOperationException("Cannot create interface or abstract class " + type + ".");
            }

            var ctor = type
                .GetConstructors()
                .OrderBy(c => c.GetParameters().Length)
                .FirstOrDefault();
            if (ctor == null)
            {
                throw new InvalidOperationException("No public constructor found for type " + type + ".");
            }

            var factory = this.CreateFactory(ctor);
            ObjectFactory.DefaultFactories[type] = factory;
            this.factories[type] = factory;
            return (T)factory(this);
        }

        /// <summary>
        /// Creates a factory using the specified constructor.
        /// </summary>
        /// <param name="ctor">The constructor to use when creating an object with the factory.</param>
        /// <returns>A factory used to create objects using the specified constructor.</returns>
        private Func<IObjectFactory, object> CreateFactory(ConstructorInfo ctor)
        {
            var factoryExpression = Expression.Parameter(typeof(IObjectFactory), "factory");
            var parameterExpressions = ctor.GetParameters()
                .Select(p => this.GetParameterExpression(p, factoryExpression));
            var newExpression = Expression.New(ctor, parameterExpressions);
            var lambda = Expression.Lambda<Func<IObjectFactory, object>>(newExpression, factoryExpression);
            return lambda.Compile();
        }

        /// <summary>
        /// Gets a parameter expression that calls <see cref="m:IObjectFactory.Any{T}"/>.
        /// </summary>
        /// <param name="parameter">The parameter to create an expression for.</param>
        /// <param name="factory">The factory parameter expression.</param>
        /// <returns>A parameter expression for the specified parameter.</returns>
        private MethodCallExpression GetParameterExpression(ParameterInfo parameter, ParameterExpression factory)
        {
            var anyMethod = ObjectFactory.AnyMethod.MakeGenericMethod(new[] { parameter.ParameterType });
            return Expression.Call(factory, anyMethod);
        }
    }
}