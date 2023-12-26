using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record SkywindTransferQueryViewModel
{
    [Required]
    [DataType(DataType.Url)]
    public Uri ApiUrl { get; init; } = default!;
    [Required]
    public string SecretKey { get; init; } = default!;
    [Required]
    public string Username { get; init; } = default!;
    [Required]
    public string Password { get; init; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTimeOffset StartTime { get; init; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTimeOffset EndTime { get; init; }
}
