using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.CompleteInstruction;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.ListInstruction;
using ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions.RevokeInstruction;

namespace ConnectedDevelopment.InformSystem.WebApi.Models.Version1.EndPoints.InformApp.Instructions
{
    internal static class InformAppInstructionV1Constants
    {
        private const string Route = "api/v1/informapp/forms/";

        internal const string CompleteRoute = Route + "{" + nameof(CompleteInformAppFormInstructionV1Request.FormId) + "}/instructions/{" + nameof(CompleteInformAppFormInstructionV1Request.InstructionId) + "}/complete";
        internal const string CreateRoute = Route + "{" + nameof(CompleteInformAppFormInstructionV1Request.FormId) + "}/instructions";
        internal const string ListRoute = Route + "{" + nameof(ListInformAppFormInstructionV1Request.FormId) + "}/instructions";
        internal const string RevokeRoute = Route + "{" + nameof(RevokeInformAppFormInstructionV1Request.FormId) + "}/instructions/{" + nameof(RevokeInformAppFormInstructionV1Request.InstructionId) + "}/revoke";

        internal const int MaxEmailLength = 250;
        internal const int MaxRecipientLength = 50;

        // Max length on requests
        internal const int RequestInstructionIdLength = 50;
        internal const int RequestMessgeLength = 250;

        // Max length on results
        internal const int ResponseInstructionIdLength = 50 * 2;
        internal const int ResponseMessageLength = 250 * 2;



        internal const int PageSizeMaxValue = 100;
    }
}
