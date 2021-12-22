namespace GDBrowserApi.Levels
{
	/// <summary>
	/// The difficulty of a level.
	/// </summary>
	public enum Difficulty
	{
		/// <summary>
		/// Difficulty is not available (N/A).
		/// </summary>
		NotAvailable = -1,

		/// <summary>
		/// The Auto difficulty.
		/// </summary>
		Auto = -3,

		/// <summary>
		/// The Easy difficulty.
		/// </summary>
		Easy = 1,

		/// <summary>
		/// The Normal difficulty.
		/// </summary>
		Normal = 2,

		/// <summary>
		/// The Hard difficulty.
		/// </summary>
		Hard = 3,

		/// <summary>
		/// The Harder difficulty.
		/// </summary>
		Harder = 4,

		/// <summary>
		/// The Insane difficulty.
		/// </summary>
		Insane = 5,

		/// <summary>
		/// The Demon difficulty.
		/// </summary>
		Demon = -2
	}
}
