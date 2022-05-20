namespace Tgs.GameRecord.ManualService.Kaiyuan.Models
{
    public record KaiyuanRequest
    {
        public string BrandCode { get; init; } = default!;

        public string CurrencyCode { get; init; } = default!;

        public DateTimeOffset StartTime { get; init; } = default!;

        public DateTimeOffset EndTime { get; init; } = default!;
    }
}
