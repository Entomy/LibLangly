using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Linguistics {
	/// <summary>
	/// Represents a script, a system of writing used as part of an <see cref="Orthography"/>.
	/// </summary>
	public sealed class Script : IEquatable<Script> {
		/// <summary>
		/// Cyrillic script
		/// </summary>
		[DisallowNull, NotNull]
		public static Script Cyrillic { get; } = new(ISO15924.Cyrl, ScriptType.Alphabet, Directions.LeftToRight);

		/// <summary>
		/// Deseret script
		/// </summary>
		[DisallowNull, NotNull]
		public static Script Deseret { get; } = new(ISO15924.Dsrt, ScriptType.Alphabet, Directions.LeftToRight);

		/// <summary>
		/// Latin script
		/// </summary>
		[DisallowNull, NotNull]
		public static Script Latin { get; } = new(ISO15924.Latn, ScriptType.Alphabet, Directions.LeftToRight);

		/// <summary>
		/// Shavian script
		/// </summary>
		[DisallowNull, NotNull]
		public static Script Shavian { get; } = new(ISO15924.Shaw, ScriptType.Alphabet, Directions.LeftToRight);

		/// <summary>
		/// Initializes a new <see cref="Script"/>.
		/// </summary>
		/// <param name="iso15924">ISO-15924 script representation code.</param>
		/// <param name="type">The type of the script, the system of the writing.</param>
		/// <param name="directions">The directions a <see cref="Script"/> is written.</param>
		private Script(ISO15924 iso15924, ScriptType type, Directions directions) {
			Directions = directions;
			ISO15924 = iso15924;
			Type = type;
		}

		/// <summary>
		/// The directions a <see cref="Script"/> is written.
		/// </summary>
		public Directions Directions { get; }

		/// <summary>
		/// ISO-15924 script representation code.
		/// </summary>
		public ISO15924 ISO15924 { get; }

		/// <summary>
		/// The type of the script, the system of the writing.
		/// </summary>
		public ScriptType Type { get; }

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] Script other) => other is not null && Directions == other.Directions && ISO15924 == other.ISO15924 && Type == other.Type;
	}
}
