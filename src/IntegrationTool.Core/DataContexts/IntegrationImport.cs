using System;

namespace Informapp.InformSystem.IntegrationTool.Core.DataContexts
{
    /// <summary>
    /// Integration import class
    /// </summary>
    public class IntegrationImport
    {
        /// <summary>
        /// Integration id
        /// </summary>
        public Guid? IntegrationId { get; set; }

        /// <summary>
        /// Size of the file
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// Hash of the file
        /// </summary>
        public string Hash { get; set; }
    }
}
