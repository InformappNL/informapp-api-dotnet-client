// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Build", "CA1031:Modify 'JsonDeserializeObject' to catch a more specific allowed exception type, or rethrow the exception", Justification = "<Pending>", Scope = "member", Target = "~M:Informapp.InformSystem.WebApi.Client.Clients.Decorators.ContentModelApiClientDecorator`2.JsonDeserializeObject(System.String,System.Type)~System.Object")]
[assembly: SuppressMessage("Build", "CA1044:Because the property getter for Token is less visible than its setter, either increase the accessibility of its getter or decrease the accessibility of its setter", Justification = "<Pending>", Scope = "member", Target = "~P:Informapp.InformSystem.WebApi.Client.Requests.ApiBearerToken.Token")]
[assembly: SuppressMessage("Build", "CA1721:The property name 'Token' is confusing given the existence of method 'GetToken'. Rename or remove one of these members.", Justification = "<Pending>", Scope = "member", Target = "~P:Informapp.InformSystem.WebApi.Client.Requests.ApiBearerToken.Token")]
[assembly: SuppressMessage("Build", "CA1044:Because the property getter for Password is less visible than its setter, either increase the accessibility of its getter or decrease the accessibility of its setter", Justification = "<Pending>", Scope = "member", Target = "~P:Informapp.InformSystem.WebApi.Client.Requests.ApiCredentials.Password")]
[assembly: SuppressMessage("Build", "CA1721:The property name 'Password' is confusing given the existence of method 'GetPassword'. Rename or remove one of these members.", Justification = "<Pending>", Scope = "member", Target = "~P:Informapp.InformSystem.WebApi.Client.Requests.ApiCredentials.Password")]
[assembly: SuppressMessage("Build", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:Informapp.InformSystem.WebApi.Client.Requests.ApiUploadFileRequest.Hash")]
[assembly: SuppressMessage("Build", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:Informapp.InformSystem.WebApi.Client.Responses.ApiUploadFileResponse.Hash")]
[assembly: SuppressMessage("Build", "CA1040:Avoid empty interfaces", Justification = "<Pending>", Scope = "type", Target = "~T:Informapp.InformSystem.WebApi.Client.Decorators.IDecorator")]
