namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.JDBTransfer;

public record JDBTransferQuery(
    Uri ApiUrl,
    string Domain,
    string AesKey,
    string AesIV,
    string Agent,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
