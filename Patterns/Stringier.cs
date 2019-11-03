using System;

namespace Stringier.Patterns {
	/// <summary>
	/// Contains internal utilities for use in implementing the pattern engine
	/// </summary>
	/// <remarks>
	/// In previous versions, this was internal. It has been made public because of the code-point equality nature of it, not being available elsewhere.
	/// Furthermore, this provides a centralized way for quickly and easily changing the implementation of a core operation.
	/// </remarks>
	public static class Stringier {
		/// <summary>
		/// Compare the specified code points for equality; comparison is case insensitive.
		/// </summary>
		/// <param name="a">Code point as a <see cref="Char"/>.</param>
		/// <param name="b">Code point as a <see cref="Char"/></param>
		/// <returns><c>true</c> if code points are equal; otherwise, <c>false</c>.</returns>
		public static Boolean Equals(Char a, Char b) => a.Equals(b);

		/// <summary>
		/// Compare the specified code points for equality.
		/// </summary>
		/// <param name="a">Code point as a <see cref="Char"/>.</param>
		/// <param name="b">Code point as a <see cref="Char"/></param>
		/// <param name="CaseSensitive">Whether the comparison should be case sensitive.</param>
		/// <returns><c>true</c> if code points are equal; otherwise, <c>false</c>.</returns>
		public static Boolean Equals(Char a, Char b, Boolean CaseSensitive) => CaseSensitive ? a.Equals(b) : a.ToUpperInvariant().Equals(b.ToUpperInvariant());

		/// <summary>
		/// Compare the specified code points for equality; comparison is case insensitive.
		/// </summary>
		/// <param name="a">Code point as a <see cref="UInt16"/>.</param>
		/// <param name="b">Code point as a <see cref="Char"/></param>
		/// <returns><c>true</c> if code points are equal; otherwise, <c>false</c>.</returns>
		public static Boolean Equals(UInt16 a, Char b) => a.Equals(b);

		/// <summary>
		/// Compare the specified code points for equality.
		/// </summary>
		/// <param name="a">Code point as a <see cref="UInt16"/>.</param>
		/// <param name="b">Code point as a <see cref="Char"/></param>
		/// <param name="CaseSensitive">Whether the comparison should be case sensitive.</param>
		/// <returns><c>true</c> if code points are equal; otherwise, <c>false</c>.</returns>
		public static Boolean Equals(UInt16 a, Char b, Boolean CaseSensitive) => CaseSensitive ? a.Equals(b) : a.ToUpperInvariant().Equals(b.ToUpperInvariant());

		/// <summary>
		/// Compare the specified code points for equality; comparison is case insensitive.
		/// </summary>
		/// <param name="a">Code point as a <see cref="Char"/>.</param>
		/// <param name="b">Code point as a <see cref="UInt16"/></param>
		/// <returns><c>true</c> if code points are equal; otherwise, <c>false</c>.</returns>
		public static Boolean Equals(Char a, UInt16 b) => b.Equals(a);

		/// <summary>
		/// Compare the specified code points for equality.
		/// </summary>
		/// <param name="a">Code point as a <see cref="Char"/>.</param>
		/// <param name="b">Code point as a <see cref="UInt16"/></param>
		/// <param name="CaseSensitive">Whether the comparison should be case sensitive.</param>
		/// <returns><c>true</c> if code points are equal; otherwise, <c>false</c>.</returns>
		public static Boolean Equals(Char a, UInt16 b, Boolean CaseSensitive) => CaseSensitive ?  b.Equals(a) : b.ToUpperInvariant().Equals(a.ToUpperInvariant());

		/// <summary>
		/// Compare the specified code points for equality; comparison is case insensitive.
		/// </summary>
		/// <param name="a">Code point as a <see cref="UInt16"/>.</param>
		/// <param name="b">Code point as a <see cref="UInt16"/></param>
		/// <returns><c>true</c> if code points are equal; otherwise, <c>false</c>.</returns>
		public static Boolean Equals(UInt16 a, UInt16 b) => a.Equals(b);

		/// <summary>
		/// Compare the specified code points for equality.
		/// </summary>
		/// <param name="a">Code point as a <see cref="UInt16"/>.</param>
		/// <param name="b">Code point as a <see cref="UInt16"/></param>
		/// <param name="CaseSensitive">Whether the comparison should be case sensitive.</param>
		/// <returns><c>true</c> if code points are equal; otherwise, <c>false</c>.</returns>
		public static Boolean Equals(UInt16 a, UInt16 b, Boolean CaseSensitive) => CaseSensitive ? a.Equals(b) : a.ToUpperInvariant().Equals(b.ToUpperInvariant());

		public static Boolean Equals(String a, String b) => String.Equals(a, b);

		public static Boolean Equals(String a, String b, Boolean CaseSensitive) => CaseSensitive ? String.Equals(a, b, StringComparison.Ordinal) : String.Equals(a, b, StringComparison.OrdinalIgnoreCase);

		public static Boolean Equals(String a, UInt16[] b) => Equals(a, b, true);

		public static Boolean Equals(String a, UInt16[] b, Boolean CaseSensitive) {
			if (a.Length != b.Length) { return false; }
			for (Int32 i = 0; i < a.Length; i++) {
				if (!Equals(a[i], b[i], CaseSensitive)) { return false; }
			}
			return true;
		}

		public static Boolean Equals(UInt16[] a, String b) => Equals(a, b, true);

		public static Boolean Equals(UInt16[] a, String b, Boolean CaseSensitive) {
			if (a.Length != b.Length) { return false; }
			for (Int32 i = 0; i < a.Length; i++) {
				if (!Equals(a[i], b[i], CaseSensitive)) { return false; }
			}
			return true;
		}

		public static Boolean Equals(UInt16[] a, UInt16[] b) => Equals(a, b, true);

		public static Boolean Equals(UInt16[] a, UInt16[] b, Boolean CaseSensitive) {
			if (a.Length != b.Length) { return false; }
			for (Int32 i = 0; i < a.Length; i++) {
				if (!Equals(a[i], b[i], CaseSensitive)) { return false; }
			}
			return true;
		}

		/// <summary>
		/// Converts the code point to its uppercase form, invariant of culture.
		/// </summary>
		/// <param name="CodePoint"></param>
		/// <returns>The uppercase of this code point.</returns>
		internal static UInt16 ToUpperInvariant(this UInt16 CodePoint) => ((Char)CodePoint).ToUpperInvariant();
	}
}
