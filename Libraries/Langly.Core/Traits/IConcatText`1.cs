using System;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can have other elements concatenated onto it, with additional textual operations.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IConcatText<out TResult> : IConcat<Char, TResult>, IPostpendText<TResult>, IPrependText<TResult> where TResult : IConcatText<TResult> { }
}
