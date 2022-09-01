namespace Tgs.GameRecord.ManualService.ViewModels;

public record VRGamingQueryViewModel
{
    public string BrandCode { get; init; } = default!;

    public DateTimeOffset StartTime { get; init; } = default!;

    public DateTimeOffset EndTime { get; init; } = default!;
}
