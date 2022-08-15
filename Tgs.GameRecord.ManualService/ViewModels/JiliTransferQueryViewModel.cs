using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels
{
    public record JiliTransferQueryViewModel
    {
        [Required]
        public Uri GameApiUrl { get; init; } = default!;
        [Required]
        public string GameProviderAgentId { get; init; } = default!;
        [Required]
        public string GameProviderAgentKey { get; init; } = default!;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; init; }
        [Required]
        [DataType(DataType.DateTime)]
        [DateTimeRange("StartTime", 600)]
        public DateTime EndTime { get; init; }
    }
}
