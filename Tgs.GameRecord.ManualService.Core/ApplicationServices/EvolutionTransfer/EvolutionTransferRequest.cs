namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.EvolutionTransfer
{
    public record EvolutionTransferRequest(
        Uri GameApiUrl,
        string CasinoId,
        string GameHistoryApiToken,
        DateTimeOffset StartDate,
        DateTimeOffset EndDate);
}
