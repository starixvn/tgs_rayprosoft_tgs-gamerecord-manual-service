namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;

public record PragmaticPlayTransferRequest(
    PragmaticPlayTransferDataType GameDataType,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
