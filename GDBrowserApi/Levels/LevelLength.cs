namespace GDBrowserApi.Levels
{
	/// <summary>
	/// The length category of a level.
	/// </summary>
	// HACK consider renaming to Length
	public enum LevelLength
	{
		/// <summary>
		/// 1-9 seconds.
		/// </summary>
		Tiny,

		/// <summary>
		/// 10-29 seconds.
		/// </summary>
		Short,

		/// <summary>
		/// 30-59 seconds.
		/// </summary>
		Medium,

		/// <summary>
		/// 60-119 seconds.
		/// </summary>
		Long,

		/// <summary>
		/// 120+ seconds.
		/// </summary>
		XL
	}
}
