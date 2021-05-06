using System;

namespace Informapp.InformSystem.IntegrationTool.Core.Providers
{
    /// <summary>
    /// Provides a new guid
    /// </summary>
    public class GuidProvider : IGuidProvider
    {
        /// <summary>
        /// Creates new guid
        /// </summary>
        /// <returns>New Guid</returns>
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
