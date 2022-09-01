namespace Tgs.GameRecord.ManualService.ViewModels;

public record AVIAGamingQueryViewModel
{
    public string BrandCode { get; init; } = default!;

    public DateTimeOffset StartTime { get; init; } = default!;

    public DateTimeOffset EndTime { get; init; } = default!;
}
