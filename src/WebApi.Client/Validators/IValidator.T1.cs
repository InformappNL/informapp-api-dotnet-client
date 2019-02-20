
namespace Informapp.InformSystem.WebApi.Client.Validators
{
    /// <summary>
    /// Validator interface
    /// </summary>
    /// <typeparam name="T">The type of object to validate</typeparam>
    public interface IValidator<T>
        where T : class
    {
        /// <summary>
        /// Validate object
        /// </summary>
        /// <param name="instance">The instance to validate</param>
        void ValidateObject(T instance);
    }
}
