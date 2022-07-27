namespace Tgs.GameRecord.ManualService.ViewModels;

public record PragmaticPlayTransferResultViewModel(
    bool Success = false,
    string Message = "",
    DateTimeOffset? NextTime = null,
    DateTimeOffset? LastGameRecordTime = null);
