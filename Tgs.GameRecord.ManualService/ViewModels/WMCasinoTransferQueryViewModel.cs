namespace Tgs.GameRecord.ManualService.ViewModels;

public record WMCasinoTransferQueryViewModel(
    Uri GameApiUrl,
    string GameProviderVendorId,
    string GameProviderSignature,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
