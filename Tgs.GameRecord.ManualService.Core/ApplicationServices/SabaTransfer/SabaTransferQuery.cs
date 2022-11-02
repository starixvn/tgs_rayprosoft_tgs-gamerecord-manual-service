namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SabaTransfer;

public record SabaTransferQuery(
    Uri ApiUrl,
    string OperatorId,
    string VendorId,
    DateTime StartTime,
    DateTime EndTime);
