using Informapp.InformSystem.WebApi.Models.ExampleValues;
using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.Filters
{
    /// <summary>
    /// SByte filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class SByteV1Filter : NumericV1Filter<sbyte>
    {
        static SByteV1Filter()
        {
            var example = new SByteV1Filter
            {
                GreaterThanOrEqual = 1,
                LessThanOrEqual = 8,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Byte filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ByteV1Filter : NumericV1Filter<byte>
    {
        static ByteV1Filter()
        {
            var example = new ByteV1Filter
            {
                GreaterThanOrEqual = 1,
                LessThanOrEqual = 8,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Int16 filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class Int16V1Filter : NumericV1Filter<short>
    {
        static Int16V1Filter()
        {
            var example = new Int16V1Filter
            {
                GreaterThanOrEqual = 1,
                LessThanOrEqual = 16,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// UInt16 filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class UInt16V1Filter : NumericV1Filter<ushort>
    {
        static UInt16V1Filter()
        {
            var example = new UInt16V1Filter
            {
                GreaterThanOrEqual = 1,
                LessThanOrEqual = 16,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Int32 filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class Int32V1Filter : NumericV1Filter<int>
    {
        static Int32V1Filter()
        {
            var example = new Int32V1Filter
            {
                GreaterThanOrEqual = 1,
                LessThanOrEqual = 32,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// UInt32 filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class UInt32V1Filter : NumericV1Filter<uint>
    {
        static UInt32V1Filter()
        {
            var example = new UInt32V1Filter
            {
                GreaterThanOrEqual = 1U,
                LessThanOrEqual = 32U,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Int64 filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class Int64V1Filter : NumericV1Filter<long>
    {
        static Int64V1Filter()
        {
            var example = new Int64V1Filter
            {
                GreaterThanOrEqual = 1L,
                LessThanOrEqual = 64L,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// UInt64 filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class UInt64V1Filter : NumericV1Filter<ulong>
    {
        static UInt64V1Filter()
        {
            var example = new UInt64V1Filter
            {
                GreaterThanOrEqual = 1UL,
                LessThanOrEqual = 64UL,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Char filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CharV1Filter : NumericV1Filter<char>
    {
        static CharV1Filter()
        {
            var example = new CharV1Filter
            {
                GreaterThanOrEqual = 'A',
                LessThanOrEqual = 'F',
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Single filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class SingleV1Filter : NumericV1Filter<float>
    {
        static SingleV1Filter()
        {
            var example = new SingleV1Filter
            {
                GreaterThanOrEqual = 123.45F,
                LessThanOrEqual = 456.67F,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Double filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class DoubleV1Filter : NumericV1Filter<double>
    {
        static DoubleV1Filter()
        {
            var example = new DoubleV1Filter
            {
                GreaterThanOrEqual = 123.45D,
                LessThanOrEqual = 456.67D,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Decimal filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class DecimalV1Filter : NumericV1Filter<decimal>
    {
        static DecimalV1Filter()
        {
            var example = new DecimalV1Filter
            {
                GreaterThanOrEqual = 123.45M,
                LessThanOrEqual = 456.67M,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Numeric filter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public abstract class NumericV1Filter<T> : IExampleMemberProvider
        where T : struct
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected NumericV1Filter() { }

        /// <summary>
        /// Greater than or equal
        /// </summary>
        [DataMember]
        [ExampleMember]
        public T? GreaterThanOrEqual { get; set; }

        /// <summary>
        /// Less than or equal
        /// </summary>
        [DataMember]
        [ExampleMember]
        public T? LessThanOrEqual { get; set; }

        /// <summary>
        /// Has value
        /// </summary>
        [DataMember]
        [ExampleValue(true)]
        public bool? HasValue { get; set; }



        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ExampleValuesContainer _container = new ExampleValuesContainer();

        /// <summary>
        /// Add example
        /// </summary>
        /// <param name="name">name of member to get example for</param>
        /// <param name="value">the example value</param>
        protected static void Add(string name, object value)
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                _container.Add(name, value);
            }
        }

        object IExampleMemberProvider.GetExample(string name)
        {
            return _container.GetExample(name);
        }
    }
}
