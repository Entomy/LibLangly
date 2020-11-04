using System;

namespace Stringier.Linguistics {
	/// <summary>
	/// Represents a script, a system of writing used as part of an <see cref="UncasedOrthography"/>.
	/// </summary>
	public sealed class Script : IEquatable<Script> {
		/// <summary>
		/// Deseret script
		/// </summary>
		public static readonly Script Deseret = new Script(ISO15924.Dsrt, ScriptType.Alphabet, Directions.LeftToRight);

		/// <summary>
		/// Latin script
		/// </summary>
		public static readonly Script Latin = new Script(ISO15924.Latn, ScriptType.Alphabet, Directions.LeftToRight);

		/// <summary>
		/// Shavian script
		/// </summary>
		public static readonly Script Shavian = new Script(ISO15924.Shaw, ScriptType.Alphabet, Directions.LeftToRight);

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
		public Boolean Equals(Script other) => !(other is null) && Directions == other.Directions && ISO15924 == other.ISO15924 && Type == other.Type;
	}
}