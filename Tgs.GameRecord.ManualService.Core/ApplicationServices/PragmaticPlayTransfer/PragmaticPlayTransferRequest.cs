namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;

public record PragmaticPlayTransferRequest
{
    public PragmaticPlayTransferDataType DataType { get; init; }

    public DateTimeOffset StartTime { get; init; }
}
