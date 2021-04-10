using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type is resizable.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	/// <remarks>
	/// This implementation technically leaks an implementation detail, in that the underlying data structure is of a fixed size, and uses array swapping to appear as a dynamic data structure.
	/// </remarks>
	public interface IResize<out TResult> : ICapacity where TResult : IResize<TResult> {
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		[SuppressMessage("Naming", "AV1706:Identifier contains an abbreviation or is too short", Justification = "Phi is a well known math constant.")]
		protected const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

		/// <summary>
		/// The current capacity of the collection before needing to be resized.
		/// </summary>
		new nint Capacity { get; set; }

		/// <inheritdoc/>
		nint ICapacity.Capacity => Capacity;

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		[return: MaybeNull]
		TResult Grow() => Capacity <= 8 ? Resize(13) : Resize((nint)(Capacity * φ));

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The new capacity of the collection.</param>
		[return: MaybeNull]
		TResult Resize(nint capacity);

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		[return: MaybeNull]
		TResult Shrink() => Resize((nint)(Capacity / φ));
	}
}
