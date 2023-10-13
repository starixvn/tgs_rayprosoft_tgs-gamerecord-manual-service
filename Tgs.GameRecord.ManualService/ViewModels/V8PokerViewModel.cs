using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record V8PokerViewModel
{
    /// <summary>
    /// The API record URL
    /// </summary>
    [Required]
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
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRangeMinutes("StartTime", 30)]
    public DateTime EndTime { get; init; }
}
