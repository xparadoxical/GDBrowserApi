using System.Text.Json.Serialization;

namespace GDBrowserApi.Levels
{
	/// <summary>
	/// A level with its level data downloaded.
	/// </summary>
	public class DownloadedLevel : Level
	{
		/// <summary>
		/// Gets the upload date and time of the level, if available.
		/// </summary>
		[JsonConverter(typeof(SuffixedDateTimeConverter))]
		public DateTime? Uploaded { get; internal set; }

		/// <summary>
		/// Gets the date and time of the last update of the level, if available.
		/// </summary>
		[JsonConverter(typeof(SuffixedDateTimeConverter))]
		public DateTime? Updated { get; internal set; }

		/// <summary>
		/// Gets the amount of time spent in the editor.
		/// </summary>
		//TODO can this be != 0?
		[JsonConverter(typeof(SecondsTimeSpanConverter))]
		public TimeSpan EditorTime { get; internal set; }

		/// <summary>
		/// Gets the amount of time spent in the editor, including time spent on previous copies of the level.
		/// </summary>
		//TODO can this be != 0?
		[JsonConverter(typeof(SecondsTimeSpanConverter))]
		public TimeSpan TotalEditorTime { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the level can be copied.
		/// </summary>
		[JsonIgnore]
		public bool Copyable { get; private set; }

		/// <summary>
		/// Gets a value indicating whether a password is required to copy the level.
		/// </summary>
		[JsonIgnore]
		public bool HasPassword { get; private set; }

		/// <summary>
		/// Gets the password required to copy the level, if any.
		/// </summary>
		[JsonIgnore]
		public string? Password { get; private set; }

		/// <summary>
		/// Gets an unknown string associated with the level.
		/// </summary>
		public string ExtraString { get; internal set; } = null!;

		/// <summary>
		/// Gets the level data as a ZLIB-compressed and base64-encoded string.
		/// </summary>
		public string Data { get; internal set; } = null!;

		[JsonPropertyName("password")]
		internal string PasswordData { get; set; } = null!;

		public override void OnDeserialized()
		{
			base.OnDeserialized();

			Copyable = PasswordData != "0";
			HasPassword = PasswordData.Length > 1;
			if (HasPassword)
				Password = PasswordData;
		}
	}
}
