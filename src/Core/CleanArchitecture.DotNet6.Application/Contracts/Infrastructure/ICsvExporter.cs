using CleanArchitecture.DotNet6.Application.Features.Events.Queries.GetEventsExport;

namespace CleanArchitecture.DotNet6.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
