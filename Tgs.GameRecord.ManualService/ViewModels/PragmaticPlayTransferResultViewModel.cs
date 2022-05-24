namespace Tgs.GameRecord.ManualService.ViewModels;

public record PragmaticPlayTransferResultViewModel
{
    public int Count { get; init; }

    public int FailureCount { get; set; }

    public DateTimeOffset? LastGameRecordTime { get; init; }

    public bool Success { get; init; }

    public int SuccessCount { get; set; }

    public DateTimeOffset? NextTime { get; init; }
}
