namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WMCasinoTransfer;

public record WMCasinoTransferQuery(
    Uri GameApiUrl,
    string GameProviderVendorId,
    string GameProviderSignature,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
