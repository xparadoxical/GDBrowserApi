using System.Text.Json.Serialization;

namespace GDBrowserApi.Levels
{
	/// <summary>
	/// A daily or a weekly level.
	/// </summary>
	public sealed class PeriodicLevel : DownloadedLevel
	{
		/// <summary>
		/// Gets a value indicating whether the level is a weekly level instead of daily level.
		/// </summary>
		[JsonPropertyName("weekly")]
		public bool IsWeekly { get; internal set; }

		/// <summary>
		/// Gets the ordinal number of the level.
		/// </summary>
		[JsonPropertyName("dailyNumber")]
		public ushort Number { get; internal set; }

		/// <summary>
		/// Gets the amount of time until the level expires.
		/// </summary>
		[JsonPropertyName("nextDaily")]
		[JsonConverter(typeof(SecondsTimeSpanConverter))]
		public TimeSpan Next { get; internal set; }

		/// <summary>
		/// Gets the date and time of expiration of the level.
		/// </summary>
		[JsonPropertyName("nextDailyTimestamp")]
		[JsonConverter(typeof(UnixTimestampDateTimeConverter))]
		public DateTime NextDate { get; internal set; }
	}
}
