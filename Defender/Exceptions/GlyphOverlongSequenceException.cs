using System;
using System.Runtime.Serialization;

namespace Defender.Exceptions {
	/// <summary>
	/// Thrown when the sequence being parsed into a glyph is too overly long.
	/// </summary>
	[Serializable]
	public class GlyphOverlongSequenceException : GlyphException {
		/// <summary>
		/// Initializes a new <see cref="GlyphOverlongSequenceException"/>.
		/// </summary>
		/// <param name="sequence">The sequence that was parsed.</param>
		/// <param name="position">The position after parsing.</param>
		/// <param name="message">The message that describes the error.</param>
		protected GlyphOverlongSequenceException(String sequence, Int32 position, String message) : base(
			$"{message}\n" +
			$"Sequence: {sequence}\n" +
			$"Position: {"^".PadLeft(position)}") {
			Sequence = sequence;
			Position = position;
		}

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected GlyphOverlongSequenceException(SerializationInfo info, StreamingContext context) : base(info, context) {
			Sequence = info.GetString(nameof(Sequence));
			Position = info.GetInt32(nameof(Position));
		}

		/// <summary>
		/// The position after parsing.
		/// </summary>
		public Int32 Position { get; }

		/// <summary>
		/// The sequence that was parsed.
		/// </summary>
		public String Sequence { get; }

		/// <summary>
		/// Initializes a <see cref="GlyphOverlongSequenceException"/> with the provided values.
		/// </summary>
		/// <param name="sequence">The sequence that was parsed.</param>
		/// <param name="position">The position after parsing.</param>
		/// <returns>A <see cref="GlyphOverlongSequenceException"/> instance.</returns>
		public static GlyphOverlongSequenceException With(String sequence, Int32 position) => new GlyphOverlongSequenceException(sequence, position, $"The sequence was overly long; more than a single glyph was found.");

		/// <summary>
		/// Initializes a <see cref="GlyphOverlongSequenceException"/> with the provided values.
		/// </summary>
		/// <param name="sequence">The sequence that was parsed.</param>
		/// <param name="position">The position after parsing.</param>
		/// <returns>A <see cref="GlyphOverlongSequenceException"/> instance.</returns>
		public static GlyphOverlongSequenceException With(ReadOnlyMemory<Char> sequence, Int32 position) => new GlyphOverlongSequenceException(sequence.ToString(), position, $"The sequence was overly long; more than a single glyph was found.");
	}
}
