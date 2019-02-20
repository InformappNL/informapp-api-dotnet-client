﻿using Informapp.InformSystem.WebApi.Models.Version1.Constants;
using Informapp.InformSystem.WebApi.Models.Version1.Filters;
using System.Runtime.Serialization;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Customers.ListCustomer
{
    /// <summary>
    /// List customer request filter
    /// </summary>
    [DataContract(Namespace = Version1Constants.Namespace)]
    public class ListCustomerV1Filter
    {
        /// <summary>
        /// Filter records by name
        /// </summary>
        [DataMember]
        public StringV1Filter Name { get; set; }

        /// <summary>
        /// Filter records by description
        /// </summary>
        [DataMember]
        public StringV1Filter Description { get; set; }

        /// <summary>
        /// Filter records by number
        /// </summary>
        [DataMember]
        public StringV1Filter Number { get; set; }

        /// <summary>
        /// Filter records by create date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter CreateDate { get; set; }

        /// <summary>
        /// Filter records by last update date
        /// </summary>
        [DataMember]
        public DateTimeOffsetV1Filter LastUpdateDate { get; set; }
    }
}
