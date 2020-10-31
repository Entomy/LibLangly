namespace Philosoft {
	/// <summary>
	/// Indicates the type is compilable to another form.
	/// </summary>
	/// <typeparam name="TResult">The result type.</typeparam>
	/// <remarks>
	/// This does not specify how the compiling occurs or what the compiled output is. It only specifies the type supports "compilation" in some form. This is most often associated with expression compilation, but doesn't imply that.
	/// </remarks>
	public interface ICompilable<out TResult> {
		/// <summary>
		/// Compiles this object.
		/// </summary>
		/// <returns>A type representing the result of the compilation.</returns>
		TResult Compile();
	}
}
