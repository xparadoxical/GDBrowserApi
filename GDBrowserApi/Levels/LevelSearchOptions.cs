using System.Collections.Specialized;
using System.Linq;
using System.Net;

namespace GDBrowserApi.Levels
{
	public record LevelSearchOptions(string? Query = null,
									 ushort Count = 10,
									 Difficulty? Difficulty = default,
									 DemonDifficulty? DemonFilter = default,
									 uint Page = 0,
									 uint? Gauntlet = default,
									 LevelLength? Length = default,
									 uint? SongID = default,
									 QuickSearch? SpecialSearch = default,
									 uint[]? Creators = default,
									 uint[]? LevelSourceList = default,
									 bool Featured = false,
									 bool Original = false,
									 bool TwoPlayer = false,
									 bool Coins = false,
									 bool Epic = false,
									 bool StarRated = false,
									 bool NoStar = false,
									 bool CustomSong = false,
									 bool IdIsUserId = false)
	{
		//TODO add logic to combine all these options into an html query string
	}

	/// <summary>
	/// Extensions methods for <see cref="NameValueCollection"/>.
	/// </summary>
	public static class NameValueCollectionExtensions
	{
		/// <summary>
		/// Builds a query string from a <see cref="NameValueCollection"/>, URL-encoding all values.
		/// </summary>
		/// <param name="nv">The source collection of key-values associations.</param>
		/// <returns>A query string containing all the key-values associations with all values URL-encoded.</returns>
		//god damnit why is this not built-in!?!?!??!?!?!?
		public static string ToQueryString(this NameValueCollection nv)
			=> string.Join(
				"&",
				nv.Cast<string>().Select(key => {
					var values = nv.GetValues(key)!.Select(WebUtility.UrlEncode);
					return $"{key}={string.Join(",", values)}";
				}));
	}
}
