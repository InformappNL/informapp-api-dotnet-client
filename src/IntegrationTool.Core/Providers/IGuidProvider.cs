using System;

namespace Informapp.InformSystem.IntegrationTool.Core.Providers
{
    /// <summary>
    /// Interface for guid provider
    /// </summary>
    public interface IGuidProvider
    {
        /// <summary>
        /// Create new guid
        /// </summary>
        /// <returns>New Guid</returns>
        Guid NewGuid();
    }
}
