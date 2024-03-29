﻿using ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Constants;
using System.Runtime.Serialization;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version2.Files
{
    /// <summary>
    /// File hash algorithm
    /// </summary>
    [DataContract(Namespace = Version2Constants.Namespace)]
    public enum FileV2HashAlgorithm
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember]
        None = 0,

        /// <summary>
        /// SHA256
        /// </summary>
        [EnumMember]
        SHA256 = 4,

        /// <summary>
        /// SHA384
        /// </summary>
        [EnumMember]
        SHA384 = 5,

        /// <summary>
        /// SHA512
        /// </summary>
        [EnumMember]
        SHA512 = 6,
    }
}
