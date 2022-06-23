namespace Tgs.GameRecord.ManualService.ViewModels
{
    public record JiliTransferQueryViewModel(
        Uri GameApiUrl,
        string GameProviderAgentId,
        string GameProviderAgentKey,
        DateTimeOffset StartTime,
        DateTimeOffset EndTime);
}
