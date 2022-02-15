using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Form.Instructions.CompleteInstruction;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Form.Instructions.CreateInstruction;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Form.Instructions.ListInstruction;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Form.Instructions.RevokeInstruction;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.FormInstructions.GetFormInstruction;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Form.Instructions
{
    internal static class FormInstructionV1Constants
    {
        private const string Route = "api/v1/forms/instructions/";

        internal const string CompleteRoute = Route + "{" + nameof(CompleteFormInstructionV1Request.FormInstructionId) + "}/complete";
        internal const string CreateRoute = Route + "{" + nameof(CreateFormInstructionV1Request.FormId) + "}";
        internal const string ListRoute = Route + "{" + nameof(ListFormInstructionV1Request.FormId) + "}";
        internal const string RevokeRoute = Route + "{" + nameof(RevokeFormInstructionV1Request.FormInstructionId) + "}/revoke";
        internal const string GetRoute = Route + "/{" + nameof(GetFormInstructionV1Request.FormInstructionId) + "}";

        internal const int MaxEmailLength = 250;
        internal const int MaxRecipientLength = 50;

        // Max length on requests
        internal const int ResponseFormInstructionIdLength = 50;
        internal const int RequestInstructionIdLength = 50;
        internal const int RequestMessgeLength = 250;

        // Max length on results
        internal const int ResponseInstructionIdLength = 50 * 2;
        internal const int ResponseMessageLength = 250 * 2;
        internal const int ResponseEmailLength = 250;



        internal const int PageSizeMaxValue = 100;
    }
}
