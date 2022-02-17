using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Constants;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Filters
{
    /// <summary>
    /// SByte filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class SByteV2Filter : NumericV2Filter<sbyte>
    {
        static SByteV2Filter()
        {
            var example = new SByteV2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class ByteV2Filter : NumericV2Filter<byte>
    {
        static ByteV2Filter()
        {
            var example = new ByteV2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class Int16V2Filter : NumericV2Filter<short>
    {
        static Int16V2Filter()
        {
            var example = new Int16V2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class UInt16V2Filter : NumericV2Filter<ushort>
    {
        static UInt16V2Filter()
        {
            var example = new UInt16V2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class Int32V2Filter : NumericV2Filter<int>
    {
        static Int32V2Filter()
        {
            var example = new Int32V2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class UInt32V2Filter : NumericV2Filter<uint>
    {
        static UInt32V2Filter()
        {
            var example = new UInt32V2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class Int64V2Filter : NumericV2Filter<long>
    {
        static Int64V2Filter()
        {
            var example = new Int64V2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class UInt64V2Filter : NumericV2Filter<ulong>
    {
        static UInt64V2Filter()
        {
            var example = new UInt64V2Filter
            {
                GreaterThanOrEqual = 1LU,
                LessThanOrEqual = 64UL,
            };

            Add(nameof(example.GreaterThanOrEqual), example.GreaterThanOrEqual);
            Add(nameof(example.LessThanOrEqual), example.LessThanOrEqual);
        }
    }

    /// <summary>
    /// Char filter
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class CharV2Filter : NumericV2Filter<char>
    {
        static CharV2Filter()
        {
            var example = new CharV2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class SingleV2Filter : NumericV2Filter<float>
    {
        static SingleV2Filter()
        {
            var example = new SingleV2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class DoubleV2Filter : NumericV2Filter<double>
    {
        static DoubleV2Filter()
        {
            var example = new DoubleV2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public class DecimalV2Filter : NumericV2Filter<decimal>
    {
        static DecimalV2Filter()
        {
            var example = new DecimalV2Filter
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
    [DataContract(Namespace = Version2Constants.Namespace)]
    public abstract class NumericV2Filter<T> : IExampleMemberProvider
        where T : struct
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected NumericV2Filter() { }

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
                _ = _container.Add(name, value);
            }
        }

#pragma warning disable CA1033 // Interface methods should be callable by child types
        object IExampleMemberProvider.GetExample(string name)
#pragma warning restore CA1033 // Interface methods should be callable by child types
        {
            return _container.GetExample(name);
        }
    }
}
