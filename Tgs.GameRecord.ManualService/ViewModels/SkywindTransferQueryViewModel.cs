using System.ComponentModel.DataAnnotations;
using Tgs.GameRecord.ManualService.Attributes;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record SkywindTransferQueryViewModel
{
    [Required]
    public Uri ApiUrl { get; init; } = default!;
    [Required]
    public string SecretKey { get; init; } = default!;
    [Required]
    public string Username { get; init; } = default!;
    [Required]
    public string Password { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; init; }
}
