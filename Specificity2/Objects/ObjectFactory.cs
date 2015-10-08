// <copyright file="ObjectFactory.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

namespace Testing.Specificity2.Objects
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
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
        /// The pseudo-random number generator used when creating objects.
        /// </summary>
        private readonly Random random;

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
            foreach (var kv in DefaultRegistryInstance)
            {
                this.Factories[kv.Key] = kv.Value;
            }

            foreach (var customization in DefaultRegistryInstance.Customizations)
            {
                this.Customizations.Push(customization);
            }
        }

        /// <summary>
        /// Gets the default registry used to register factories and customizations used by all <see cref="ObjectFactory"/>
        /// instances.
        /// </summary>
        public static IObjectFactoryRegistry DefaultRegistry
        {
            get { return DefaultRegistryInstance; }
        }

        /// <summary>
        /// Static object factory methods.
        /// </summary>
        private static DefaultObjectFactoryRegistry DefaultRegistryInstance { get; } = GetDefaultRegistry();

        /// <summary>
        /// Cached MethodInfo for the <see cref="m:ObjectFactory.Any{T}"/> method.
        /// </summary>
        private static MethodInfo AnyMethod { get; } = typeof(IObjectFactory).GetMethod("Any");

        /// <summary>
        /// The registered customizations.
        /// </summary>
        private Stack<ObjectFactoryCustomization> Customizations { get; } = new Stack<ObjectFactoryCustomization>();

        /// <summary>
        /// The registered object factory methods.
        /// </summary>
        private Dictionary<Type, Func<IObjectFactory, object>> Factories { get; } = new Dictionary<Type, Func<IObjectFactory, object>>();

        /// <summary>
        /// Generate a pseudo-random object of the specified type.
        /// </summary>
        /// <param name="type">The type of object to create.</param>
        /// <returns>A pseudo-random instance of the specified type.</returns>
        public object Any(Type type)
        {
            Func<IObjectFactory, object> factory;
            if (this.Factories.TryGetValue(type, out factory))
            {
                return factory(this);
            }

            object result;
            var context = new CustomizationContext(this.Customizations);
            if (context.TryNextCustomization(this, out result))
            {
                return result;
            }

            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                return this.CreateCollection(type);
            }

            return this.CreateObject(type);
        }

        /// <summary>
        /// Generate a pseudo-random <see cref="double"/> value.
        /// </summary>
        /// <param name="minimum">The minimum value to generate.</param>
        /// <param name="maximum">The maximum value to generate.</param>
        /// <param name="distribution">The distribution to use.</param>
        /// <returns>A pseudo-random <see cref="double"/> value.</returns>
        public double AnyDouble(double minimum = double.MinValue, double maximum = double.MaxValue, Distribution distribution = null)
        {
            if (minimum >= maximum)
            {
                throw new ArgumentOutOfRangeException("minimum");
            }

            distribution = distribution ?? Distribution.Uniform;
            return (distribution.NextDouble(this.random) * (maximum - minimum)) + minimum;
        }

        /// <summary>
        /// Registers a customization object that can change how objects are created.
        /// </summary>
        /// <param name="customization">The customization to apply.</param>
        public void Customize(ObjectFactoryCustomization customization)
        {
            this.Customizations.Push(customization);
        }

        /// <summary>
        /// Registers a factory method that can be used to create instances of the specified type.
        /// </summary>
        /// <param name="type">The type of object created by the factory.</param>
        /// <param name="factoryMethod">The factory method.</param>
        public void Register(Type type, Func<IObjectFactory, object> factoryMethod)
        {
            this.Factories[type] = factoryMethod;
        }

        /// <summary>
        /// Returns the default registry instance.
        /// </summary>
        /// <returns>The default registry instance.</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Any other method of mapping would result in the same readability experience.")]
        private static DefaultObjectFactoryRegistry GetDefaultRegistry()
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

            return registry;
        }

        /// <summary>
        /// Gets the type of the items in the enumerable.
        /// </summary>
        /// <param name="type">The enumerable type.</param>
        /// <returns>The type of the items in the enumerable.</returns>
        private static Type GetEnumerableItemType(Type type)
        {
            if (type == typeof(IEnumerable))
            {
                return typeof(object);
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return type.GetGenericArguments().Single();
            }

            return null;
        }

        /// <summary>
        /// Gets a parameter expression that calls <see cref="m:IObjectFactory.Any{T}"/>.
        /// </summary>
        /// <param name="parameter">The parameter to create an expression for.</param>
        /// <param name="factory">The factory parameter expression.</param>
        /// <returns>A parameter expression for the specified parameter.</returns>
        private static Expression GetParameterExpression(ParameterInfo parameter, ParameterExpression factory)
        {
            var anyMethod = AnyMethod;
            var call = Expression.Call(factory, anyMethod, Expression.Constant(parameter.ParameterType));

            return Expression.Convert(call, parameter.ParameterType);
        }

        /// <summary>
        /// Creates a factory using the specified constructor.
        /// </summary>
        /// <param name="ctor">The constructor to use when creating an object with the factory.</param>
        /// <returns>A factory used to create objects using the specified constructor.</returns>
        private static Func<IObjectFactory, object> CreateFactory(ConstructorInfo ctor)
        {
            var factoryExpression = Expression.Parameter(typeof(IObjectFactory), "factory");
            var parameterExpressions = ctor.GetParameters()
                .Select(p => GetParameterExpression(p, factoryExpression));
            var newExpression = Expression.New(ctor, parameterExpressions);
            var lambda = Expression.Lambda<Func<IObjectFactory, object>>(newExpression, factoryExpression);

            return lambda.Compile();
        }

        /// <summary>
        /// Creates an instance of the specified collection type, caching the dynamically
        /// created factory used.
        /// </summary>
        /// <param name="type">The type of the items to create.</param>
        /// <returns>An instance of the specified collection type.</returns>
        private object CreateCollection(Type type)
        {
            var itemType = GetEnumerableItemType(type);
            if (itemType != null)
            {
                return this.AnyEnumerable(itemType);
            }

            if (type.IsAbstract || type.IsInterface)
            {
                throw new InvalidOperationException();
            }

            var ctors = from c in type.GetConstructors()
                        let args = c.GetParameters()
                        where args.Length == 1
                        let argItemType = GetEnumerableItemType(args[0].ParameterType)
                        where argItemType != null
                        select new { Ctor = c, ItemType = argItemType };

            var ctor = ctors.SingleOrDefault();
            if (ctor != null)
            {
                return ctor.Ctor.Invoke(new[] { this.AnyEnumerable(ctor.ItemType) });
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Creates an instance of the specified type, caching the dynamically created
        /// factory used.
        /// </summary>
        /// <param name="type">The type of the object to create.</param>
        /// <returns>An instance of the specified type.</returns>
        private object CreateObject(Type type)
        {
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

            var factory = CreateFactory(ctor);
            DefaultRegistryInstance[type] = factory;
            this.Factories[type] = factory;

            return factory(this);
        }
    }
}