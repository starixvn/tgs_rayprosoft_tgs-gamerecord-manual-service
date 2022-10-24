namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGFmGaming;

public record WGFmGamingQuery(
    Uri ApiUrl,
    string PartnerCode,
    string PartnerKey,
    string PartnerIV,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
