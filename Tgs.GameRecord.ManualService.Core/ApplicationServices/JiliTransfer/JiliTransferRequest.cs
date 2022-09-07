namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.JiliTransfer;

public record JiliTransferRequest(
    Uri GameApiUrl,
    string GameProviderAgentId,
    string GameProviderAgentKey,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
