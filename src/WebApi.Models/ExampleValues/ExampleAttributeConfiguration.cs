
namespace ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Configuration
    /// </summary>
    public static class ExampleAttributeConfiguration
    {
        internal static bool Enabled { get; private set; }

        /// <summary>
        /// Enable example values
        /// </summary>
        public static void Enable()
        {
            Enabled = true;
        }
    }
}
