namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SkywindTransfer;

public record SkywindTransferQuery(
    Uri GameApiUrl,
    string SecretKey,
    string Username,
    string Password,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate);
