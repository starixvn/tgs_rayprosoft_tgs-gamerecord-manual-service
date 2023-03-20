namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.Endorphina
{
    public record EndorphinaQuery(
        Uri ApiUrl,
        string MerchantId,
        string SecretKey,
        string Token);
}
