namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WGFmGaming;

public record WGFmGamingRequest(
    Uri ApiUrl,
    string PartnerCode,
    string PartnerKey,
    string PartnerIV,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
