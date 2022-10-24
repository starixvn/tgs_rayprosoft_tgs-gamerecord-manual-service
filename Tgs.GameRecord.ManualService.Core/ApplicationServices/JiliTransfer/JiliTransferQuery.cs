namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.JiliTransfer;

public record JiliTransferQuery(
    Uri GameApiUrl,
    string GameProviderAgentId,
    string GameProviderAgentKey,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
