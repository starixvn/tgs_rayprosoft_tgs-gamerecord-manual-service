namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.YeeBet;

public record YeeBetQuery(
    Uri ApiUrl,
    string AppId,
    string SecretKey,
    DateTimeOffset BeginTime,
    DateTimeOffset EndTime);
