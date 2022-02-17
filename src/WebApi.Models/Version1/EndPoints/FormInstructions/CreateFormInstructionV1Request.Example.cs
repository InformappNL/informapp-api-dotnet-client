using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions
{
    public partial class CreateFormInstructionV1Request : IExampleMemberProvider
    {
        static CreateFormInstructionV1Request()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                _ = _container.Add(nameof(FormData), GetFormDataExample());
                _ = _container.Add(nameof(AppUserIds), GetRecipientsExample());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ExampleValuesContainer _container = new ExampleValuesContainer();

#pragma warning disable CA1033 // Interface methods should be callable by child types
        object IExampleMemberProvider.GetExample(string name)
#pragma warning restore CA1033 // Interface methods should be callable by child types
        {
            return _container.GetExample(name);
        }

        private static string GetFormDataExample()
        {
#pragma warning disable IDE0028 // Simplify collection initialization
            var data = "Test Data";//new Dictionary<string, object>();
#pragma warning restore IDE0028 // Simplify collection initialization

            //data.Add("customerId", 4353);
            //data.Add("customerName", "Customer ABC");
            //data.Add("order", new[]
            //{
            //    new Dictionary<string, object>
            //    {
            //        { "productId", 6123 },
            //        { "productName", "Product A" },
            //        { "quantity", 2 },
            //    },
            //    new Dictionary<string, object>
            //    {
            //        { "productId", 4619 },
            //        { "productName", "Product B" },
            //        { "quantity", 3 },
            //    }
            //});

            return data;
        }

        private static IReadOnlyList<Guid?> GetRecipientsExample()
        {
            var recipients = new Guid?[]
            {
                Guid.Parse("4B663902-8B23-47FE-BEDC-4A5D4A669401"),
                Guid.Parse("4B663902-8B23-47FE-BEDC-4A5D4A669502"),
            };

            return recipients;
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static void Assignable(CreateFormInstructionV1Request request)
#pragma warning restore IDE0051 // Remove unused private members
        {
            request.FormData = GetFormDataExample();
            request.AppUserIds = GetRecipientsExample();
        }
    }
}
