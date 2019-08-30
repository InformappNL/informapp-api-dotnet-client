using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestValues;
using System;
using System.Collections.Generic;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Values
{
    internal class TestValuesV1Comparer
    {
        public bool Equals(TestValuesV1Request request, TestValuesV1Response response)
        {
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

            else if ((Equals(request.Array, response.Array) &&
                Equals(request.Bytes, response.Bytes) &&
                Equals(request.Dictionary, response.Dictionary)) == false)
            {
                equals = false;
            }

            return equals;
        }

        private bool Equals<T>(IReadOnlyList<T> left, IReadOnlyList<T> right)
            where T : struct, IEquatable<T>
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (left.Count != right.Count)
            {
                return false;
            }

            for (int i = 0; i < left.Count; i++)
            {
                if (left[i].Equals(right[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool Equals<T>(IReadOnlyDictionary<T, T> left, IReadOnlyDictionary<T, T> right)
            where T : struct, IEquatable<T>
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (left.Count != right.Count)
            {
                return false;
            }

            foreach (var pair in left)
            {
                if (right.TryGetValue(pair.Key, out var value) == false)
                {
                    return false;
                }

                if (pair.Value.Equals(value) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
