using ConnectedDevelopment.InformSystem.WebApi.Models.ExampleValues;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction
{
    public partial class ListInformAppFormInstructionV1ResponseInstruction : IExampleMemberProvider
    {
        static ListInformAppFormInstructionV1ResponseInstruction()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                _ = _container.Add(nameof(Recipients), GetRecipientsExample());
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

        private static IReadOnlyList<string> GetRecipientsExample()
        {
            var recipients = new[]
            {
                "58e213fcf1386c37ce86ba1a",
                "58e213fcf1563246534fe21b",
            };

            return recipients;
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static void Assignable(ListInformAppFormInstructionV1ResponseInstruction request)
#pragma warning restore IDE0051 // Remove unused private members
        {
            request.Recipients = GetRecipientsExample();
        }
    }
}
