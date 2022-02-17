
namespace ConnectedDevelopment.InformSystem.WebApi.Client.Converters
{
    /// <summary>
    /// Generic interface for converting values to another type
    /// </summary>
    /// <typeparam name="TSource">Convert from type</typeparam>
    /// <typeparam name="TResult">Convert to type</typeparam>
    public interface IConverter<TSource, TResult>
    {
        /// <summary>
        /// Convert value
        /// </summary>
        /// <param name="source">The source value</param>
        /// <returns>The convert result</returns>
        ConvertResult<TResult> Convert(TSource source);
    }
}
