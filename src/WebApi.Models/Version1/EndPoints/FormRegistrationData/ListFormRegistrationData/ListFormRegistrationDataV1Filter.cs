using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormRegistrationData.ListFormRegistrationData
{
    /// <summary>
    /// List form registration data request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListFormRegistrationDataV1Filter
    {
        /// <summary>
        /// Filter records by form registration id
        /// </summary>
        [DataMember]
        public IdV1Filter FormRegistrationId { get; set; }

        /// <summary>
        /// Filter records by form id
        /// </summary>
        [DataMember]
        public IdV1Filter FormId { get; set; }

        /// <summary>
        /// Filter records by serial number
        /// </summary>
        [DataMember]
        public Int32V1Filter SerialNumber { get; set; }

        /// <summary>
        /// Filter records by registration date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter RegistrationDate { get; set; }



        /// <summary>
        /// Filter records by depth
        /// </summary>
        [DataMember]
        public Int32V1Filter Depth { get; set; }

        /// <summary>
        /// Filter records by index
        /// </summary>
        [DataMember]
        public Int32V1Filter Index { get; set; }

        /// <summary>
        /// Filter records by order
        /// </summary>
        [DataMember]
        public Int32V1Filter Order { get; set; }

        /// <summary>
        /// Filter records by name
        /// </summary>
        [DataMember]
        public StringV1Filter Name { get; set; }

        /// <summary>
        /// Filter records by fullname
        /// </summary>
        [DataMember]
        public StringV1Filter FullName { get; set; }

        /// <summary>
        /// Filter records by path
        /// </summary>
        [DataMember]
        public StringV1Filter Path { get; set; }



        /// <summary>
        /// Filter records by text
        /// </summary>
        [DataMember]
        public StringV1Filter Text { get; set; }

        /// <summary>
        /// Filter records by integer
        /// </summary>
        [DataMember]
        public Int64V1Filter Integer { get; set; }

        /// <summary>
        /// Filter records by decimal
        /// </summary>
        [DataMember]
        public DecimalV1Filter Decimal { get; set; }

        /// <summary>
        /// Filter records by date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter Date { get; set; }

        /// <summary>
        /// Filter records by time
        /// </summary>
        [DataMember]
        public TimeSpanV1Filter Time { get; set; }

        /// <summary>
        /// Filter records by uuid
        /// </summary>
        [DataMember]
        public GuidV1Filter Uuid { get; set; }
    }
}
