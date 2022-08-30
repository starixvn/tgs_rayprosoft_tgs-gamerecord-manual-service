namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SkywindTransfer
{
    public record SkywindTransferRequest(
        Uri GameApiUrl,
        string SecretKey,
        string Username,
        string Password,
        DateTimeOffset StartDate,
        DateTimeOffset EndDate);
}
