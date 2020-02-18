using System;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations on a <see cref="Patterns.Source"/>.
	/// </summary>
	/// <remarks>
	/// <para>In very simple terms, there are two main components. The first is a Boolean representing success of the operation. The second is the captured string during the operation. This type can be used as if it is either individual type.</para>
	/// <para>In more technicaly terms, this type only appears to be those, and may actually be implemented using complete different means.</para>
	/// </remarks>
	public ref struct Result {
		/// <summary>
		/// The position in the <see cref="Source"/> where this <see cref="Result"/> starts from.
		/// </summary>
		internal readonly Int32 Start;

		/// <summary>
		/// Whether any <see cref="Debugging.Error"/> occured during parsing; <see cref="Error.None"/> is successful.
		/// </summary>
		internal Error Error;

		/// <summary>
		/// The <see cref="Patterns.Source"/> this <see cref="Result"/> is from.
		/// </summary>
		private readonly Source Source;

		/// <summary>
		/// Initialize a new <see cref="Result"/> from the given <see cref="Patterns.Source"/>.
		/// </summary>
		/// <param name="source">The <see cref="Patterns.Source"/> this <see cref="Result"/> is coming from.</param>
		internal Result(ref Source source) {
			Error = Error.None;
			Source = source;
			Start = source.Position;
			Length = 0;
		}

		public ref readonly Char this[Int32 index] => ref Source[Start + index];

		/// <summary>
		/// The length of the captured text.
		/// </summary>
		public Int32 Length {
			get;
			internal set;
		}

		/// <summary>
		/// Whether the parsing was successful.
		/// </summary>
		/// <returns><see langword="true"/> if successful; otherwise <see langword="false"/>.</returns>
		public Boolean Success => Error == Error.None;

		public static implicit operator Boolean(Result result) => result.Success;

		public static implicit operator ReadOnlySpan<Char>(Result result) => result.AsSpan();

		public static implicit operator String(Result result) => result.ToString();

		public static Boolean operator !=(Result left, Result right) => !left.Equals(right);

		public static Boolean operator !=(Result left, String right) => !left.Equals(right);

		public static Boolean operator !=(String left, Result right) => !right.Equals(left);

		public static Boolean operator ==(Result left, Result right) => left.Equals(right);

		public static Boolean operator ==(Result left, String right) => left.Equals(right);

		public static Boolean operator ==(String left, Result right) => right.Equals(left);

		/// <summary>
		/// Returns a span that represents the current object.
		/// </summary>
		/// <returns>A span that represents the current object.</returns>
		public ReadOnlySpan<Char> AsSpan() => Source.Substring(Start, Length);

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this <see cref="Result"/> and the <paramref name="other"/> <see cref="Result"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="Result"/> to compare to</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Result other) => Source.Equals(other.Source) && Start.Equals(other.Start) && Length.Equals(other.Length) && ((Int32)Error == (Int32)other.Error);

		/// <summary>
		/// Determines whether this <see cref="Result"/> and the <paramref name="other"/> <see cref="String"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to compare to</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(String other) => !(other is null) && Source.Substring(Start, Length).Equals(other, StringComparison.CurrentCulture);

		/// <summary>
		/// Determines whether this <see cref="Result"/> and the <paramref name="other"/> <see cref="ReadOnlySpan{T}"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> to compare to</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(ReadOnlySpan<Char> other) => Source.Substring(Start, Length).Equals(other, StringComparison.CurrentCulture);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Source.GetHashCode() ^ Start.GetHashCode();

		/// <summary>
		/// Throw a <see cref="ParserException"/> based on the error that occured, if any.
		/// </summary>
		public void ThrowException() => Error.Throw();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Source.Substring(Start, Length).ToString();
	}
}
