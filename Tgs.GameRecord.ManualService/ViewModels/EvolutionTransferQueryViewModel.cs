namespace Tgs.GameRecord.ManualService.ViewModels
{
    public record EvolutionTransferQueryViewModel(
        Uri GameApiUrl,
        string CasinoId,
        string GameHistoryApiToken,
        DateTimeOffset StartTime,
        DateTimeOffset EndTime);
}
