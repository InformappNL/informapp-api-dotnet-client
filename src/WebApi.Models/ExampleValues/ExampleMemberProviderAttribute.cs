using System;

namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example member provider attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ExampleMemberProviderAttribute : ExampleAttribute
    {
        /// <summary>
        /// Provider type
        /// </summary>
        public Type ProviderType { get; }

        /// <summary>
        /// Member name
        /// </summary>
        public string MemberName { get; }

        /// <summary>Initializes a new instance of the <see cref="ExampleMemberProviderAttribute"/> class.</summary>
        public ExampleMemberProviderAttribute(Type providerType, string memberName)
        {
            ProviderType = providerType;

            MemberName = memberName;
        }
    }
}
