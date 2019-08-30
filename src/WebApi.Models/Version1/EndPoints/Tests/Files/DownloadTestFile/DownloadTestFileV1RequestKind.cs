using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Files.DownloadTestFile
{
    /// <summary>
    /// File kind
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public enum DownloadTestFileV1RequestKind
    {
        /// <summary>
        /// Docx
        /// </summary>
        [EnumMember]
        Docx = 0,

        /// <summary>
        /// Pdf
        /// </summary>
        [EnumMember]
        Pdf = 1,

        /// <summary>
        /// Txt
        /// </summary>
        [EnumMember]
        Txt = 2,

        /// <summary>
        /// Xlsx
        /// </summary>
        [EnumMember]
        Xlsx = 3,
    }
}
