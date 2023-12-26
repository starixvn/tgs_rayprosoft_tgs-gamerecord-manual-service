using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record LEGamingViewModel
{
    /// <summary>
    /// The API record URL
    /// </summary>
    [Required]
    [DataType(DataType.Url)]
    public Uri ApiRecordUrl { get; init; } = default!;

    /// <summary>
    /// The deskey
    /// </summary>
    [Required]
    public string Deskey { get; init; } = default!;

    /// <summary>
    /// The md5key
    /// </summary>
    [Required]
    public string Md5key { get; init; } = default!;

    /// <summary>
    /// The agent identifier
    /// </summary>
    [Required]
    public string AgentId { get; init; } = default!;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTimeOffset StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 30)]
    public DateTimeOffset EndTime { get; init; }
}
