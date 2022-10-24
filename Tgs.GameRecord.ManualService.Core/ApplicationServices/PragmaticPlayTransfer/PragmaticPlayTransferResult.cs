namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;

public record PragmaticPlayTransferResult(
    bool Success = false,
    string Message = "",
    DateTimeOffset? NextTime = null,
    DateTimeOffset? LastGameRecordTime = null);
