using System;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Enums
{
    /// <summary>
    /// Unexpected enum value exception class
    /// </summary>
    [Serializable]
    public class UnexpectedEnumValueException : Exception
    {
        /// <summary>
        /// Base unexpected enum value exception
        /// </summary>
        public UnexpectedEnumValueException() : base()
        {

        }

        /// <summary>
        /// Base unexpected enum value exception with message string
        /// </summary>
        /// <param name="message">The message string</param>
        public UnexpectedEnumValueException(string message) : base(message)
        {

        }

        /// <summary>
        /// Base unexpected enum value exception with message string and inner exception
        /// </summary>
        /// <param name="message">The message string</param>
        /// <param name="innerException">The inner exception</param>
        public UnexpectedEnumValueException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// Base unexpected enum value exception with serialization info and streaming context
        /// </summary>
        /// <param name="info">The serialization info</param>
        /// <param name="context">The streaming context</param>
        protected UnexpectedEnumValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        /// <summary>
        /// Type of enum
        /// </summary>
        public Type EnumType { get; }

        /// <summary>
        /// Value of the enum
        /// </summary>
        public object Value { get; }

        private UnexpectedEnumValueException(Type enumType, object value)
            : base("Value " + value ?? "(null)" + " of enum " + enumType.Name + " is not supported")
        {
            EnumType = enumType;

            Value = value;
        }

        /// <summary>
        /// Sets serialization info with information about exception and adds enum type and value
        /// </summary>
        /// <param name="info">The serialization info</param>
        /// <param name="context">The streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(EnumType), EnumType);
            info.AddValue(nameof(Value), Value);
        }

        /// <summary>
        /// Create new unexpected enum value exception for type T
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="value">The value</param>
        /// <returns>New unexpected enum value exception</returns>
        public static UnexpectedEnumValueException Create<T>(T value)
            where T : struct, Enum, IComparable, IFormattable, IConvertible
        {
            return new UnexpectedEnumValueException(typeof(T), value);
        }

        /// <summary>
        /// Create new unexpected enum value exception for type T, where T is nullable
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="value">The value</param>
        /// <returns>New unexpected enum value exception</returns>
        public static UnexpectedEnumValueException Create<T>(T? value)
            where T : struct, Enum, IComparable, IFormattable, IConvertible
        {
            return new UnexpectedEnumValueException(typeof(T), value);
        }

        /// <summary>
        /// Throws new unexpected enum value exception for type T
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="value">The value</param>
        public static void Throw<T>(T value)
            where T : struct, Enum, IComparable, IFormattable, IConvertible
        {
            throw Create(value);
        }

        /// <summary>
        /// Throws new unexpected enum value exception for type nullable T
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="value">The value</param>
        public static void Throw<T>(T? value)
            where T : struct, Enum, IComparable, IFormattable, IConvertible
        {
            throw Create(value);
        }
    }
}
