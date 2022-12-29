namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SM01;

public record SM01Query(
    Uri GameApiUrl,
    string GameMerchantId,
    string GameMerchantKey,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
