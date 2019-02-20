using System;
using System.Collections;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example collection attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ExampleCollectionAttribute : ExampleAttribute
    {
        /// <summary>
        /// Kind
        /// </summary>
        public ExampleCollectionKind Kind { get; private set; }

        /// <summary>
        /// Element type
        /// </summary>
        public Type ElementType { get; private set; }

        /// <summary>
        /// Values
        /// </summary>
        public IEnumerable Values { get; private set; }


        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, byte[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, sbyte[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, short[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, ushort[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, float[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, double[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, int[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, uint[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, long[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, ulong[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, char[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, string[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, bool[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, Type[] values) { SetupCollection(kind, values); }
        ///// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        //internal ExampleCollectionAttribute(ExampleCollectionKind kind, object[] values) { SetupCollection(kind, values); }
        /// <summary>Initializes a new instance of the <see cref="ExampleCollectionAttribute"/> class.</summary>
        internal ExampleCollectionAttribute(ExampleCollectionKind kind, Type elementType, object[] values)
        {
            Kind = kind;

            ElementType = elementType;

            Values = values;
        }

        private void SetupCollection<T>(ExampleCollectionKind kind, T[] values)
        {
            Kind = kind;

            ElementType = typeof(T);

            Values = values;
        }
    }
}
