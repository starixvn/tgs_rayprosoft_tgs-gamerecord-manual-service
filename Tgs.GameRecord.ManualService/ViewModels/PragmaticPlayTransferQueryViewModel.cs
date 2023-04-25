using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record PragmaticPlayTransferQueryViewModel
{
    /// <summary>
    /// The API URL
    /// </summary>
    [Required]
    public Uri ApiUrl { get; init; } = default!;
    /// <summary>
    /// The secure login
    /// </summary>
    [Required]
    public string SecureLogin { get; init; } = default!;
    /// <summary>
    /// The secret key
    /// </summary>
    [Required]
    public string SecretKey { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    [DateTimeRange("StartTime", 3600)]
    public DateTime EndTime { get; init; }
}
