namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;

public record PragmaticPlayTransferRequest(
    PragmaticPlayTransferDataType DataType,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
