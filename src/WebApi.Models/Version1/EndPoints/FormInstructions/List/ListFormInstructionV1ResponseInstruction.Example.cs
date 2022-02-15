﻿using Informapp.InformSystem.WebApi.Models.ExampleValues;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Informapp.InformSystem.WebApi.Models.Version1.EndPoints.Form.Instructions.ListInstruction
{
    public partial class ListFormInstructionV1ResponseInstruction : IExampleMemberProvider
    {
        static ListFormInstructionV1ResponseInstruction()
        {
            if (ExampleAttributeConfiguration.Enabled == true)
            {
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
        private static void Assignable(ListFormInstructionV1ResponseInstruction request)
#pragma warning restore IDE0051 // Remove unused private members
        {
            request.AppUserIds = GetRecipientsExample();
        }
    }
}
