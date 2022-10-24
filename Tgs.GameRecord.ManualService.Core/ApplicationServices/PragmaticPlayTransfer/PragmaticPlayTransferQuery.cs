namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;

public record PragmaticPlayTransferQuery(
    PragmaticPlayTransferDataType GameDataType,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
