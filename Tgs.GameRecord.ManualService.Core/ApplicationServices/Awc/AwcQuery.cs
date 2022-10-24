namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Awc;

public record AwcQuery(
Uri GameRecordApiUrl,
string GameProviderCode,
string GameProviderAgentId,
string GameProviderCert,
DateTimeOffset StartTime,
DateTimeOffset EndTime);
