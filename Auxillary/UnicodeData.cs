// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the THIRD_PARTY_NOTICES file in the project root for more information.

using System;
using System.Globalization;
using System.Threading;
using System.Text;
using Stringier;

namespace Tests {
	public static class UnicodeData {
		private static readonly CodePoint[] _codePointData = new CodePoint[0x11_0000]; // an array for all code points
		private static readonly Lazy<ParsedUnicodeData> _lazyParsedData = new Lazy<ParsedUnicodeData>();
		internal static ParsedUnicodeData CurrentData { get; private set; }

		public static CodePoint GetData(int codePoint) {
			if ((uint)codePoint >= (uint)_codePointData.Length) {
				throw new ArgumentOutOfRangeException(
					message: FormattableString.Invariant($"Value U+{(uint)codePoint:X4} is not a valid code point."),
					paramName: nameof(codePoint));
			}

			CodePoint data = _codePointData[codePoint];

			// generate on-demand
			CurrentData = _lazyParsedData.Value;
			data = new CodePoint(codePoint);
			return data;
		}

		public static CodePoint GetData(uint codePoint) => GetData((int)codePoint);

		public static CodePoint GetData(Rune rune) => GetData(rune.Value);

		/*
         * Helper methods
         */

		public static UnicodeCategory GetUnicodeCategory(int codePoint) => GetData(codePoint).GetGeneralCategory();

		public static bool IsLetter(int codePoint) {
			switch (GetUnicodeCategory(codePoint)) {
			case UnicodeCategory.UppercaseLetter:
			case UnicodeCategory.LowercaseLetter:
			case UnicodeCategory.TitlecaseLetter:
			case UnicodeCategory.ModifierLetter:
			case UnicodeCategory.OtherLetter:
				return true;

			default:
				return false;
			}
		}

		public static bool IsWhiteSpace(int codePoint) => (GetData(codePoint).GetFlags() & CodePointFlags.White_Space) != 0;
	}
}
