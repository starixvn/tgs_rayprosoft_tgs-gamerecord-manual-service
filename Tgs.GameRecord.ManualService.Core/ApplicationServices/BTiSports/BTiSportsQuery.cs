namespace Tgs.GameRecord.ManualService.Core.ApplicationServices.BTiSports;

public record BTiSportsQuery(
    Uri TokenApiUrl,
    Uri OpenBetsApiUrl,
    Uri HistoryBetsPagingApiUrl,
    string AgentUserName,
    string AgentPassword,
    DateTime StartTime,
    DateTime EndTime);
