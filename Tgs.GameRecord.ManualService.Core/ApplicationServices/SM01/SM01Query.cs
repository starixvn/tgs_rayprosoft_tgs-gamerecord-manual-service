namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SM01;

public record SM01Query(
    Uri ApiUrl,
    string MerchantId,
    string MerchantKey,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
