using System.Text.Json.Serialization;

namespace GDBrowserApi.Levels
{
	/// <summary>
	/// A user level.
	/// </summary>
	public class Level
	{
		private bool? _hasDescription;
		private bool? _hasCustomSong;

		internal Level() { }

		/// <summary>
		/// Gets the name of the level.
		/// </summary>
		public string Name { get; internal set; } = null!;

		/// <summary>
		/// Gets the ID of the level.
		/// </summary>
		public uint ID { get; internal set; }

		/// <summary>
		/// Gets the description of the level.
		/// </summary>
		public string Description { get; internal set; } = null!;

		/// <summary>
		/// Gets a value indicating whether the level has a non-default description.
		/// </summary>
		public bool HasDescription => _hasDescription ??= Description != "(No description provided)";

		/// <summary>
		/// Gets the unique player ID of the level's author.
		/// </summary>
		public uint PlayerID { get; internal set; }

		/// <summary>
		/// Gets the account ID of the level's author. When <see langword="null"/>, the author is an unregistered (green) user.
		/// </summary>
		[JsonConverter(typeof(ZeroToNullConverter<uint>))]
		public uint? AccountID { get; internal set; }

		/// <summary>
		/// Gets the difficulty of the level.
		/// </summary>
		[JsonConverter(typeof(DifficultyConverter))]
		public Difficulty Difficulty { get; internal set; }
		//TODO maybe convert "difficulty": "Easy Demon" into { Difficulty = Demon, DemonDifficulty = Easy } or use json.net to be free from shitjsonapi issues

		/// <summary>
		/// Gets the demon difficulty of the level
		/// or <see langword="null"/> if <see cref="Difficulty"/> is not <see cref="Difficulty.Demon"/>.
		/// </summary>
		[JsonIgnore]
		public DemonDifficulty? DemonDifficulty { get; internal set; }

		/// <summary>
		/// Gets the filename part of the URL of the difficulty face image for this level.
		/// Can be used with <see cref=""/> to get the image.
		/// </summary>
		//UNDONE figure out the structure of API fetchers and add difficulty face fetcher to this xmldoc
		public string DifficultyFace { get; internal set; } = null!;

		/// <summary>
		/// Gets the number of downloads of the level.
		/// </summary>
		public uint Downloads { get; internal set; }

		/// <summary>
		/// Gets the number of likes of the level.
		/// </summary>
		public uint Likes { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the level has a negative number of likes.
		/// </summary>
		[JsonPropertyName("disliked")]
		public bool IsDisliked { get; internal set; }

		/// <summary>
		/// Gets the length of the level.
		/// </summary>
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public LevelLength Length { get; internal set; }

		/// <summary>
		/// Gets the number of stars the author requested the level to be rated
		/// or <see langword="null"/> if no request was given.
		/// </summary>
		[JsonConverter(typeof(ZeroToNullConverter<byte>))]
		public byte? StarsRequested { get; internal set; }

		/// <summary>
		/// Gets the amount of stars received for beating the level (0-10).
		/// </summary>
		public byte Stars { get; internal set; }

		/// <summary>
		/// Gets the number of user coins placed in the level.
		/// </summary>
		public byte Coins { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the user coins in the level are verified.
		/// </summary>
		[JsonPropertyName("verifiedCoins")]
		public bool HasVerifiedCoins { get; internal set; }

		/// <summary>
		/// Gets the amount of mana orbs received for beating the level.
		/// </summary>
		public ushort Orbs { get; internal set; }

		/// <summary>
		/// Gets the amount of diamonds received for beating the level or 0 if the level is not star rated.
		/// </summary>
		public byte Diamonds { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the level is featured.
		/// </summary>
		[JsonPropertyName("featured")]
		public bool IsFeatured { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the level has an "epic" rating.
		/// </summary>
		[JsonPropertyName("epic")]
		public bool IsEpic { get; internal set; }

		/// <summary>
		/// Gets the version of Geometry Dash the level was released on.
		/// </summary>
		[JsonConverter(typeof(GameVersionConverter))]
		public GameVersion GameVersion { get; internal set; }

		/// <summary>
		/// Gets the number of times the level was updated, including the first upload.
		/// </summary>
		public ushort Version { get; internal set; }

		/// <summary>
		/// Gets the number of objects in the level or <see langword="null"/> if it is an older level.
		/// </summary>
		//TODO determine what "an older level" means
		//TODO this can be 0 for not empty recent levels
		[JsonConverter(typeof(ZeroToNullConverter<uint>))]
		public ushort? Objects { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the level is considered "large",
		/// which means it has more than 40,000 objects.
		/// </summary>
		[JsonPropertyName("large")]
		public bool IsLarge { get; internal set; }

		/// <summary>
		/// Gets the number of creator points the level is worth
		/// (1 for star rating, 1 for feature and 1 for epic rating).
		/// </summary>
		public byte CreatorPoints { get; internal set; }

		/// <summary>
		/// Gets the original level ID, if the level was copied, or <see langword="null"/> if it was not.
		/// </summary>
		[JsonPropertyName("copiedID")]
		[JsonConverter(typeof(ZeroToNullConverter<uint>))]
		public uint? OriginalLevelID { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the level has two player mode enabled.
		/// </summary>
		[JsonPropertyName("twoPlayer")]
		public bool IsTwoPlayer { get; internal set; }

		/// <summary>
		/// Gets the official song ID or <see langword="null"/> if a custom song was used.
		/// </summary>
		[JsonPropertyName("officialSong")]
		[JsonConverter(typeof(ZeroToNullConverter<ushort>))]
		public ushort? OfficialSongID { get; internal set; }

		/// <summary>
		/// Gets the custom song ID or <see langword="null"/> if an official song was used.
		/// </summary>
		[JsonPropertyName("customSong")]
		[JsonConverter(typeof(ZeroToNullConverter<uint>))]
		public int? CustomSongID { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the level uses a custom song.
		/// </summary>
		public bool HasCustomSong => _hasCustomSong ??= CustomSongID is not null;

		/// <summary>
		/// Gets the ID of the song used.
		/// </summary>
		/// <value>Either <see cref="OfficialSongID"/> or <see cref="CustomSongID"/>.</value>
		public int SongID => (int)(OfficialSongID ?? CustomSongID!);

		/// <summary>
		/// Gets the name of the song used.
		/// </summary>
		public string SongName { get; internal set; } = null!;

		/// <summary>
		/// Gets the author of the song used.
		/// </summary>
		public string SongAuthor { get; internal set; } = null!;

		/// <summary>
		/// Gets the size of the song in MiB.
		/// </summary>
		[JsonConverter(typeof(SuffixedDecimalConverter<float>))]
		public float SongSize { get; internal set; }

		/// <summary>
		/// Gets the link to the raw MP3 of the song, if available.
		/// </summary>
		public Uri? SongLink { get; internal set; }

		/// <summary>
		/// Gets the position of the level on the extreme demon list (<see href="https://pointercrate.com"/>)
		/// or <see langword="null"/> if <see cref="DemonDifficulty"/> is not <see cref="DemonDifficulty.Extreme"/>.
		/// </summary>
		[JsonPropertyName("demonList")]
		public ushort? DemonListPosition { get; internal set; }

		//UNDONE uploaded ...

		//TODO xmldoc
		internal int? Results { get; set; }
		//TODO xmldoc
		internal int? Pages { get; set; }
	}
}
