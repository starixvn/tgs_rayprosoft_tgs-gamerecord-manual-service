namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.EvolutionTransfer;

public record EvolutionTransferQuery(
    Uri GameApiUrl,
    string CasinoId,
    string GameHistoryApiToken,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate);
