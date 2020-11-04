using Informapp;
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("", "CA0000:Description", Justification = "TODO", Scope = "namespaceanddescendants", Target = GlobalSuppressions.ResourceNameSpace)]

namespace Informapp
{
    internal static class GlobalSuppressions
    {
        public const string ResourceNameSpace =
            nameof(Informapp) + "." +
            nameof(InformSystem) + "." +
            nameof(InformSystem.WebApi) + "." +
            nameof(InformSystem.WebApi.Client) + "." +
            nameof(InformSystem.WebApi.Client.Sample);
    }
}
