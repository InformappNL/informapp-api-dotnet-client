using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System.Collections.Generic;
using System.Diagnostics;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.CreateInstruction
{
    public partial class CreateInformAppFormInstructionV1Request : IExampleMemberProvider
    {
        static CreateInformAppFormInstructionV1Request()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                _container.Add(nameof(FormData), GetFormDataExample());
                _container.Add(nameof(Recipients), GetRecipientsExample());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ExampleValuesContainer _container = new ExampleValuesContainer();

        object IExampleMemberProvider.GetExample(string name)
        {
            return _container.GetExample(name);
        }

        private static IReadOnlyDictionary<string, object> GetFormDataExample()
        {
#pragma warning disable IDE0028 // Simplify collection initialization
            var data = new Dictionary<string, object>();
#pragma warning restore IDE0028 // Simplify collection initialization

            data.Add("customerId", 4353);
            data.Add("customerName", "Customer ABC");
            data.Add("order", new[]
            {
                new Dictionary<string, object>
                {
                    { "productId", 6123 },
                    { "productName", "Product A" },
                    { "quantity", 2 },
                },
                new Dictionary<string, object>
                {
                    { "productId", 4619 },
                    { "productName", "Product B" },
                    { "quantity", 3 },
                }
            });

            return data;
        }

        private static IReadOnlyList<string> GetRecipientsExample()
        {
            var recipients = new[]
            {
                "58e213fcf1386c37ce86ba1a",
                "example@email",
            };

            return recipients;
        }

        private static void Assignable(CreateInformAppFormInstructionV1Request request)
        {
            request.FormData = GetFormDataExample();
            request.Recipients = GetRecipientsExample();
        }
    }
}
