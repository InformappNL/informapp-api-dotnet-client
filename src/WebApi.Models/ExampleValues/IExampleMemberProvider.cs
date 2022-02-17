
namespace ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues
{
    /// <summary>
    /// Example value member provider interface
    /// </summary>
    public interface IExampleMemberProvider
    {
        /// <summary>
        /// Get example
        /// </summary>
        /// <param name="name">name of member to get example for</param>
        /// <returns>the example object, null if no example was found</returns>
        object GetExample(string name);
    }
}
