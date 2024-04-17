#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tgs.GameRecord.ManualService.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DateTimeRangeDayAttribute(string columnName, int maxDay) : ValidationAttribute
{
	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		var endTime = (DateTimeOffset)value;

		var startTime = (DateTimeOffset)validationContext.ObjectType.GetProperty(columnName).GetValue(validationContext.ObjectInstance, null);

		TimeSpan diffTimeSpan = endTime.Subtract(startTime);

		return DateTimeOffset.Compare(startTime, endTime) is -1 && diffTimeSpan.TotalDays <= maxDay ?
			ValidationResult.Success :
			new ValidationResult($"The start time cannot be greater than the end time, and the time range is limited({maxDay} day).");
	}
}
