
namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Uploaders
{
    /// <summary>
    /// Interface for upload result
    /// </summary>
    public interface IUploadResult
    {
        /// <summary>
        /// If upload was successful this will be true
        /// </summary>
        bool Success { get; set; }
    }
}
