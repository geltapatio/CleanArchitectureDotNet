using CleanArchitecture.DotNet6.Application.Contracts.Infrastructure;
using CleanArchitecture.DotNet6.Application.Features.Events.Queries.GetEventsExport;
using CsvHelper;


namespace CleanArchitecture.DotNet6.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using MemoryStream? memoryStream = new MemoryStream();
            using (StreamWriter? streamWriter = new StreamWriter(memoryStream))
            {
                using CsvWriter? csvWriter = new CsvWriter(streamWriter, null, false);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
