using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System.Collections.Generic;
using System.Diagnostics;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction
{
    public partial class ListInformAppFormInstructionV1ResponseInstruction : IExampleMemberProvider
    {
        static ListInformAppFormInstructionV1ResponseInstruction()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
                _container.Add(nameof(Recipients), GetRecipientsExample());
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ExampleValuesContainer _container = new ExampleValuesContainer();

        object IExampleMemberProvider.GetExample(string name)
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

        private static void Assignable(ListInformAppFormInstructionV1ResponseInstruction request)
        {
            request.Recipients = GetRecipientsExample();
        }
    }
}
