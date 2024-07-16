using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.ViewModels;

public class GTExpanseViewModel
{
	/// <summary>
	/// The data API URL
	/// </summary>
	/// <example>http://gm-stage-data.gmgiantgold.com/</example>
	[Required]
	[DataType(DataType.Url)]
	public Uri DataApiUrl { get; init; } = default!;
	/// <summary>
	/// The brand identifier
	/// </summary>
	/// <example>911</example>
	[Required]
	public int BrandId { get; init; } = default!;
	/// <summary>
	/// The secret key
	/// </summary>
	/// <example>pPRHm1NHFosSOUv4tVjv</example>
	[Required]
	public string SecretKey { get; init; } = default!;
	/// <summary>
	/// The start time
	/// </summary>
	/// <example>2024-07-08T15:00:00+08:00</example>
	[Required]
	[DataType(DataType.DateTime)]
	public DateTimeOffset StartTime { get; init; }
	/// <summary>
	/// The end time
	/// </summary>
	/// <example>2024-07-08T15:15:00+08:00</example>
	[Required]
	[DataType(DataType.DateTime)]
	public DateTimeOffset EndTime { get; init; }
}
