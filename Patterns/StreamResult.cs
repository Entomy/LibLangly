using System;
using System.IO;
using Stringier.Patterns.Debugging;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations on a <see cref="System.IO.Stream"/>.
	/// </summary>
	public ref struct StreamResult {
		/// <summary>
		/// The position in the <see cref="Stream"/> where this <see cref="StreamResult"/> starts from.
		/// </summary>
		internal readonly Int64 Start;

		/// <summary>
		/// Whether any <see cref="Debugging.Error"/> occured during parsing; <see cref="Error.None"/> is successful.
		/// </summary>
		internal Error Error;

		/// <summary>
		/// The <see cref="System.IO.Stream"/> this <see cref="StreamResult"/> is from.
		/// </summary>
		private readonly Stream Stream;

		/// <summary>
		/// The <see cref="StreamReader"/> this <see cref="StreamResult"/> uses.
		/// </summary>
		private readonly StreamReader Reader;

		/// <summary>
		/// Initialize a new <see cref="StreamResult"/> from the given <see cref="System.IO.Stream"/> and <see cref="StreamReader"/>.
		/// </summary>
		/// <param name="stream">The <see cref="System.IO.Stream"/> this <see cref="StreamResult"/> is coming from.</param>
		/// <param name="reader">The <see cref="StreamReader"/> this <see cref="StreamResult"/> uses.</param>
		internal StreamResult(Stream stream, StreamReader reader) {
			if (stream.CanRead && stream.CanSeek) {
				Error = Error.None;
				Stream = stream;
				Reader = reader;
				Start = stream.Position;
				Length = 0;
			} else {
				throw new ArgumentException("Stream must be readable and seekable", nameof(stream));
			}
		}

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

		public static implicit operator Boolean(StreamResult result) => result.Success;

		public static implicit operator ReadOnlySpan<Char>(StreamResult result) => result.AsSpan();

		public static implicit operator String(StreamResult result) => result.ToString();

		public static Boolean operator !=(StreamResult left, StreamResult right) => !left.Equals(right);

		public static Boolean operator ==(StreamResult left, StreamResult right) => left.Equals(right);

		/// <summary>
		/// Returns a span that represents the current object.
		/// </summary>
		/// <returns>A span that represents the current object.</returns>
		public ReadOnlySpan<Char> AsSpan() => ToString().AsSpan();

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this <see cref="StreamResult"/> and the <paramref name="other"/> <see cref="StreamResult"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="StreamResult"/> to compare to</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(StreamResult other) => Stream.Equals(other.Stream) && Start.Equals(other.Start) && Length.Equals(other.Length) && Error.Equals(other.Error);

		/// <summary>
		/// Determines whether this <see cref="StreamResult"/> and the <paramref name="other"/> <see cref="String"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to compare to</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(String other) => !(other is null) && String.Equals(ToString(), other, StringComparison.CurrentCulture);

		/// <summary>
		/// Determines whether this <see cref="StreamResult"/> and the <paramref name="other"/> <see cref="ReadOnlySpan{T}"/> are equal.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> to compare to</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(ReadOnlySpan<Char> other) => ToString().Equals(other, StringComparison.CurrentCulture);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Stream.GetHashCode() ^ Start.GetHashCode();

		/// <summary>
		/// Throw a <see cref="ParserException"/> based on the error that occured, if any.
		/// </summary>
		public void ThrowException() => Error.Throw();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() {
			Int64 pos = Stream.Position;
			Stream.Position = Start;
			String result = Reader.ReadToEnd();
			Stream.Position = pos;
			return result;
		}
	}
}
