using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.Constants;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.IntegrationUsers.Heartbeats
{
    /// <summary>
    /// Drive
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class CreateIntegrationUserHeartbeatV1RequestDrive
    {
        internal const long MinSpace = 0;
        internal const long MaxSpace = long.MaxValue;
        internal const int PathLength = 260;

        /// <summary>
        /// Path
        /// </summary>
        [DataMember]
        [ExampleValue(@"C:\")]
        [MaxLength(PathLength)]
        [Required]
        public string Path { get; set; }

        /// <summary>
        /// The amount of available free space to the user on a drive, in bytes
        /// </summary>
        [DataMember]
        [ExampleValue(212199067648)]
        [Range(MinSpace, MaxSpace)]
        [Required]
        public long? AvailableFreeSpace { get; set; }

        /// <summary>
        /// The total amount of free space available on a drive, in bytes
        /// </summary>
        [DataMember]
        [ExampleValue(212199067648)]
        [Range(MinSpace, MaxSpace)]
        [Required]
        public long? TotalFreeSpace { get; set; }

        /// <summary>
        /// The total size of storage space on a drive, in bytes
        /// </summary>
        [DataMember]
        [ExampleValue(445561290752)]
        [Range(MinSpace, MaxSpace)]
        [Required]
        public long? TotalSize { get; set; }
    }
}
