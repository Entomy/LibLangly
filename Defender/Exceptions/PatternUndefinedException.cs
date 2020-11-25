using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when a pattern is attempted to be used when it hasn't been defined yet.
	/// </summary>
	[Serializable]
	public class PatternUndefinedException : PatternException {
		/// <summary>
		/// Initializes a new <see cref="PatternUndefinedException"/>.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		protected PatternUndefinedException(String message) : base(message) { }

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected PatternUndefinedException(SerializationInfo info, StreamingContext context) : base(info, context) { }

		/// <summary>
		/// Initializes a new <see cref="PatternUndefinedException"/> with the provided values.
		/// </summary>
		public static PatternUndefinedException With() => new PatternUndefinedException("An operation was called on an undefined pattern.");
	}
}
