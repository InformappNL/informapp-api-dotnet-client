﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ConnectedDevelopment.InformSystem.IntegrationTool.Core.IntegrationImports
{
    /// <summary>
    /// Queue integration import command
    /// </summary>
    public class QueueIntegrationImportCommand
    {
        /// <summary>
        /// Integration id
        /// </summary>
        [Required]
        public Guid? IntegrationId { get; set; }

        /// <summary>
        /// File
        /// </summary>
        [Required]
        public string File { get; set; }

        /// <summary>
        /// Move file
        /// </summary>
        [Required]
        public bool? MoveFile { get; set; }
    }
}
