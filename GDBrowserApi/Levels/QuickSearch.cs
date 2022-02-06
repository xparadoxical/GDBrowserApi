namespace GDBrowserApi.Levels
{
	/// <summary>
	/// An <see langword="enum"/>-like class containing possible kinds of quick search.
	/// </summary>
	public sealed class QuickSearch
	{
		internal readonly string _type;
		internal readonly bool _ignoreFilters;

		private QuickSearch(string type, bool ignoreFilters)
			=> (_type, _ignoreFilters) = (type, ignoreFilters);

		/// <summary>
		/// Gets the <see cref="QuickSearch"/> that returns the levels with the most downloads in descending order.
		/// </summary>
		public QuickSearch MostDownloaded { get; } = new("mostdownloaded", false);

		/// <summary>
		/// Gets the <see cref="QuickSearch"/> that returns the levels with the most likes in descending order.
		/// <para>This is the default for all normal level searches.</para>
		/// </summary>
		public QuickSearch MostLiked { get; } = new("mostliked", false);

		/// <summary>
		/// Gets the <see cref="QuickSearch"/> that returns the most recent levels with a high download rate.
		/// </summary>
		public QuickSearch Trending { get; } = new("trending", false);

		/// <summary>
		/// Gets the <see cref="QuickSearch"/> that returns the most recent levels in descending order.
		/// </summary>
		public QuickSearch Recent { get; } = new("recent", false);

		/// <summary>
		/// Gets the <see cref="QuickSearch"/> that returns the recently star-rated levels in descending order.
		/// </summary>
		public QuickSearch Awarded { get; } = new("awarded", false);

		/// <summary>
		/// Gets the <see cref="QuickSearch"/> that returns only featured levels.
		/// <para>Ignores other filters.</para>
		/// </summary>
		public QuickSearch Featured { get; } = new("featured", true);

		/// <summary>
		/// Gets the <see cref="QuickSearch"/> that returns the most recently uploaded levels with over 10,000 objects in descending order.
		/// <para>Ignores other filters.</para>
		/// </summary>
		public QuickSearch Magic { get; } = new("magic", true);

		/// <summary>
		/// Gets the <see cref="QuickSearch"/> that returns only epic levels.
		/// <para>Ignores other filters.</para>
		/// </summary>
		public QuickSearch HallOfFame { get; } = new("halloffame", true);
	}
}
