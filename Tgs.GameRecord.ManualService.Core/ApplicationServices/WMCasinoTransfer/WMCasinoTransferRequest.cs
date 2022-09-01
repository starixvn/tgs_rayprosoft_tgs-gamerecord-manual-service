namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.WMCasinoTransfer;

public record WMCasinoTransferRequest(
    Uri GameApiUrl,
    string GameProviderVendorId,
    string GameProviderSignature,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
