
namespace Informapp.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Configuration
    /// </summary>
    public static class ExampleAttributeConfiguration
    {
        internal static bool Enabled { get; private set; }

        /// <summary>
        /// Enabled example values
        /// </summary>
        public static void Enable()
        {
            Enabled = true;
        }
    }
}
