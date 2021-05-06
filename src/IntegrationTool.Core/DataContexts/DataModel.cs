using Informapp.InformSystem.IntegrationTool.Core.IO;
using System.Collections.Generic;

namespace Informapp.InformSystem.IntegrationTool.Core.DataContexts
{
    internal class DataModel
    {
        public IList<FileModel> Files { get; set; }
            = new List<FileModel>();
    }
}
