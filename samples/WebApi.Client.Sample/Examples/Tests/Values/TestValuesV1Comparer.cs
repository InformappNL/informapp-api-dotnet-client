using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Tests.Values.TestValues;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.Tests.Values
{
    internal class TestValuesV1Comparer
    {
        public bool Equals(TestValuesV1Request request, TestValuesV1Response response)
        {
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
                return false;
            }

            if ((Equals(request.Array, response.Array) &&
                Equals(request.Dictionary, response.Dictionary)) == false)
            {
                return false;
            }

            return true;
        }

        private bool Equals<T>(IEnumerable<T> x, IEnumerable<T> y)
            where T : struct, IEquatable<T>
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                if (x == null && y.Any() == false)
                {
                    return true;
                }

                if (y == null && x.Any() == false)
                {
                    return true;
                }

                return false;
            }

            var arrayX = x.ToArray();
            var arrayY = y.ToArray();

            if (arrayX.Length != arrayY.Length)
            {
                return false;
            }

            for (int i = 0; i < arrayX.Length; i++)
            {
                if (arrayX[i].Equals(arrayY[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool Equals<T>(IDictionary<T, T> x, IDictionary<T, T> y)
            where T : struct, IEquatable<T>
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                if (x == null && y.Count == 0)
                {
                    return true;
                }

                if (y == null && x.Count == 0)
                {
                    return true;
                }

                return false;
            }

            if (x.Count != y.Count)
            {
                return false;
            }

            foreach (var pair in x)
            {
                if (y.TryGetValue(pair.Key, out var value) == false)
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
