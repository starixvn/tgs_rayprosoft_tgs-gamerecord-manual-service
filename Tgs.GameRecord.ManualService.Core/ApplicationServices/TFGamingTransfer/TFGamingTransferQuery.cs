namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.TFGamingTransfer;

public record TFGamingTransferQuery(
    Uri ApiUrl,
    string PrivateToken,
    DateTime StartTime,
    DateTime EndTime);
