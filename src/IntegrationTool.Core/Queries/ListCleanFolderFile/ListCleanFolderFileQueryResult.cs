using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.Queries.ListCleanFolderFile
{
    /// <summary>
    /// Result after making a list of files that will be cleaned up
    /// </summary>
    public class ListCleanFolderFileQueryResult
    {
        /// <summary>
        /// The list of files
        /// </summary>
        public IEnumerable<IFileInfo> Files { get; set; }
            = Enumerable.Empty<IFileInfo>();
    }
}
