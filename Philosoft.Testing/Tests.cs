namespace System.Traits.Testing {
	/// <summary>
	/// Represents the base of all test classes.
	/// </summary>
	/// <remarks>
	/// Inheriting from this provides the Philosoft testing framework to unit tests contained in the derived class.
	/// </remarks>
	public abstract class Tests {
		/// <summary>
		/// Gets an object for beginning assertions on some other object.
		/// </summary>
		protected static Assert Assert => new();

		/// <summary>
		/// Gets an object for adjusting configuration of the testing framework.
		/// </summary>
		protected static Config Config => new();
	}
}
