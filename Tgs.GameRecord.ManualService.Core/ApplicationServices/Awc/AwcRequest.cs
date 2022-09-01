namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Awc;

public record AwcRequest(
Uri GameRecordApiUrl,
string GameProviderCode,
string GameProviderAgentId,
string GameProviderCert,
DateTimeOffset StartTime,
DateTimeOffset EndTime);
