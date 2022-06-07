using Tgs.GameRecord.ManualService.Core.ApplicationServices.PragmaticPlayTransfer;

namespace Tgs.GameRecord.ManualService.ViewModels;

public record PragmaticPlayTransferQueryViewModel
{
    public PragmaticPlayTransferDataType DataType { get; init; }
    public DateTimeOffset StartTime { get; init; }
}
