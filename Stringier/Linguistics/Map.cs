using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Stringier.Linguistics {
	[StructLayout(LayoutKind.Auto)]
	internal readonly struct Map : IEquatable<Map>, IEquatable<Char>, IEquatable<Rune>, IEquatable<Glyph> {
		public readonly Glyph Lower;
		public readonly Glyph Upper;

		public Map(Char lower, Char upper) {
			Lower = new Glyph(lower);
			Upper = new Glyph(upper);
		}

		public Map(UInt32 lower, UInt32 upper) {
			Lower = new Glyph(lower);
			Upper = new Glyph(upper);
		}

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Map map:
				return Equals(map);
			case Char @char:
				return Equals(@char);
			case Rune rune:
				return Equals(rune);
			case Glyph glyph:
				return Equals(glyph);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Map other) => Lower == other.Lower && Upper == other.Upper;

		/// <inheritdoc/>
		public Boolean Equals(Char other) => Lower == other || Upper == other;

		/// <inheritdoc/>
		public Boolean Equals(Rune other) => Lower == other || Upper == other;

		/// <inheritdoc/>
		public Boolean Equals(Glyph other) => Lower == other || Upper == other;

		/// <inheritdoc/>
		public override Int32 GetHashCode() => Lower.GetHashCode() ^ Upper.GetHashCode();
	}
}