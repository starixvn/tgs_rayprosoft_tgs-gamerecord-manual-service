namespace Tgs.GameRecord.ManualService.ViewModels;

public record AwcQueryViewModel(
    Uri GameRecordApiUrl,
    string GameProviderCode,
    string GameProviderAgentId,
    string GameProviderCert,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
