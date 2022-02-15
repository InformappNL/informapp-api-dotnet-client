using System;

namespace Informapp.InformSystem.IntegrationTool.Core.DataContexts
{
    public class IntegrationImportQueueItem
    {
        public Guid? IntegrationId { get; set; }

        public string File { get; set; }

        public long? FileSize { get; set; }

        public string Hash { get; set; }

        public Guid? VersionId { get; set; }
    }
}
