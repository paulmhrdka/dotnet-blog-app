using System.Globalization;
using dotnet_clean_arch.Application.Common.Interfaces;
using dotnet_clean_arch.Application.TodoLists.Queries.ExportTodos;
using dotnet_clean_arch.Infrastructure.Files.Maps;
using CsvHelper;

namespace dotnet_clean_arch.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
