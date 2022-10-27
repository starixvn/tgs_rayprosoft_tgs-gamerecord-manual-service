namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.HabaneroTransfer;

public record HabaneroTransferQuery(
    Uri ApiUrl,
    string BrandId,
    string ApiKey,
    DateTime StartTime,
    DateTime EndTime);
