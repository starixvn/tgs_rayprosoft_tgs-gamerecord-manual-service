namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.JDBTransfer;

public record JDBTransferRequest(
    Uri ApiUrl,
    string Domain,
    string AesKey,
    string AesIV,
    string Agent,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
