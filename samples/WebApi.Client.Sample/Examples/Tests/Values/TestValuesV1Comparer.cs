﻿using Informapp.InformSystem.WebApi.Client.Sample.Comparers;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestValues;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Values
{
    internal class TestValuesV1Comparer
    {
        public bool Equals(TestValuesV1Request request, TestValuesV1Response response)
        {
            var collectionEqualityComparer = new CollectionEqualityComparer();
            var dictionaryEqualityComparer = new DictionaryEqualityComparer();

            bool equals = true;

            if ((request.Boolean == response.Boolean &&
                request.Byte == response.Byte &&
                request.Char == response.Char &&
                request.DateTime == response.DateTime &&
                request.DateTimeOffset == response.DateTimeOffset &&
                request.Decimal == response.Decimal &&
                request.Double == response.Double &&
                request.Enum == response.Enum &&
                request.Int16 == response.Int16 &&
                request.Int32 == response.Int32 &&
                request.Int64 == response.Int64 &&
                request.SignedByte == response.SignedByte &&
                request.Single == response.Single &&
                request.String == response.String &&
                request.TimeSpan == response.TimeSpan &&
                request.UnsignedInt16 == response.UnsignedInt16 &&
                request.UnsignedInt32 == response.UnsignedInt32 &&
                request.UnsignedInt64 == response.UnsignedInt64 &&
                request.Uri == response.Uri &&
                request.Uuid == response.Uuid) == false)
            {
                equals = false;
            }

            else if ((collectionEqualityComparer.CollectionEquals(request.Array, response.Array) &&
                collectionEqualityComparer.CollectionEquals(request.Bytes, response.Bytes) &&
                dictionaryEqualityComparer.DictionaryEquals(request.Dictionary, response.Dictionary)) == false)
            {
                equals = false;
            }

            return equals;
        }
    }
}
