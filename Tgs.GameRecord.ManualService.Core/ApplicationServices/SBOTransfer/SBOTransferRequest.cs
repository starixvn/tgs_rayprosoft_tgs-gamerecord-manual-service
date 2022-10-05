namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.SBOTransfer;

public record SBOTransferRequest(
    Uri ApiUrl,
    string CompanyKey,
    string Agent,
    string Portfolio,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);
