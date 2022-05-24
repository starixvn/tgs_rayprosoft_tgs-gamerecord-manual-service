namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;

public record PragmaticPlayTransferResponse
{
    public int Count { get; init; }

    public int FailureCount { get; set; }

    public DateTimeOffset? LastGameRecordTime { get; init; }

    public DateTimeOffset? NextTime { get; init; }

    public bool Success { get; init; }

    public int SuccessCount { get; set; }
}
