﻿using Informapp.InformSystem.WebApi.Client.Clients;
using Informapp.InformSystem.WebApi.Client.Requests;
using Informapp.InformSystem.WebApi.Client.Responses;
using Informapp.InformSystem.WebApi.Client.Sample.Arguments;
using Informapp.InformSystem.WebApi.Client.Sample.Requires;
using Informapp.InformSystem.WebApi.Models.Version1.EndPoints.DataSources.UploadDataSource;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Informapp.InformSystem.WebApi.Client.Sample.Examples.DataSources
{
    internal class UploadDataSourceV1Example : IExample
    {
        // Set datasource id
        private const string DataSourceId = "eca97d10-fb59-4e04-8832-3892d46f6861";

        private readonly IApiClient<UploadDataSourceV1Request, UploadDataSourceV1Response> _client;

        public UploadDataSourceV1Example(
            IApiClient<UploadDataSourceV1Request, UploadDataSourceV1Response> client)
        {
            Argument.NotNull(client, nameof(client));

            _client = client;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            using (var model = GetRequest())
            {
                var request = ApiRequest.Create(model);

                var response = await _client.Execute(request, cancellationToken)
                    .ThrowIfFailed()
                    .ConfigureAwait(Await.Default);

                Require.NotNull(response, nameof(response));
            }
        }

        private static UploadDataSourceV1Request GetRequest()
        {
            var dataSourceId = Guid.Parse(DataSourceId);

            var file = GetFile();
            string fileName = FileName;

            var request = new UploadDataSourceV1Request
            {
                DataSourceId = dataSourceId,
                File = file,
                FileName = fileName,
                Size = file.Length,
            };

            return request;
        }

        private const string FileName = "projects.xlsx";
        private const string WorkSheetName = "Projects";

        private static Stream GetFile()
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage())
            using (var sheet = package.Workbook.Worksheets.Add(WorkSheetName))
            {
                package.Compatibility.IsWorksheets1Based = false;

                var projects = GetProjects();

                SetHeaderRow(sheet);

                SetRows(sheet);

                sheet.Cells.AutoFitColumns();

                package.SaveAs(stream);

                stream.Position = 0;
            }

            return stream;
        }

        private static void SetHeaderRow(ExcelWorksheet sheet)
        {
            var names = new[]
            {
                "Id",
                "ProjectId",
                "CustomerId",
                "Name",
            };

            for (int i = 0; i < names.Length; i++)
            {
                int column = i + 1;

                using (var cell = sheet.Cells[Row: 1, column])
                {
                    cell.Value = names[i];
                }
            }
        }

        private static void SetRows(ExcelWorksheet sheet)
        {
            var projects = GetProjects();

            for (int i = 0; i < projects.Count; i++)
            {
                var project = projects[i];

                int row = i + 2;
                int id = i + 1;

                sheet.Cells[row, IdColumn].Value = id;
                sheet.Cells[row, ProjectIdColumn].Value = project.ProjectId;
                sheet.Cells[row, CustomerIdColumn].Value = project.CustomerId;
                sheet.Cells[row, NameColumn].Value = project.Name;
            }
        }

        private const int IdColumn = 1;
        private const int ProjectIdColumn = 2;
        private const int CustomerIdColumn = 3;
        private const int NameColumn = 4;

        private static IReadOnlyList<ProjectModel> GetProjects()
        {
            var projects = new[]
            {
                new ProjectModel
                {
                    ProjectId = 38,
                    CustomerId = 8,
                    Name = "Building 21",
                },
                new ProjectModel
                {
                    ProjectId = 102,
                    CustomerId = 17,
                    Name = "Channel Tunnel",
                },
                new ProjectModel
                {
                    ProjectId = 57,
                    CustomerId = 42,
                    Name = "Euro Gate",
                },
                new ProjectModel
                {
                    ProjectId = 86,
                    CustomerId = 32,
                    Name = "The New Holland Bridge",
                },
            };

            return projects;
        }

        private class ProjectModel
        {
            public int ProjectId { get; set; }

            public int CustomerId { get; set; }

            public string Name { get; set; }
        }
    }
}