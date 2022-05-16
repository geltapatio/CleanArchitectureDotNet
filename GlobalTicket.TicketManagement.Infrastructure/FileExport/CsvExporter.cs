using CsvHelper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;

namespace GloboTicket.TicketManagement.Infrastructure
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
