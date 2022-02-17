using System;
using System.Collections.Generic;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.DataContexts
{
    internal class DataModel
    {
        public IList<DataSource> DataSources { get; }
            = new List<DataSource>();

        public IDictionary<Guid?, IntegrationImport> IntegrationImports { get; }
            = new Dictionary<Guid?, IntegrationImport>();

        public IList<IntegrationImportQueueItem> IntegrationImportQueue { get; }
            = new List<IntegrationImportQueueItem>();
    }
}
