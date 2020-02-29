// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the THIRD_PARTY_NOTICES file in the project root for more information.

// This has been converted in a way that allows it to seamlessly work with Stringier's CodePoint struct.

using System;
using System.Globalization;
using Stringier;

namespace Tests {
	public static class CodePointExtensions {
		/// <summary>
		/// The bidi class of this code point. Note that even unassigned code points can
		/// have a non-default bidi class.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#Bidi_Class.
		/// </remarks>
		public static BidiClass GetBidiClass(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.DerivedBidiClassData.TryGetValue(codePoint.Value, out BidiClass bidiClass)) {
				return bidiClass;
			} else {
				return BidiClass.Left_To_Right; // default is "L" (strong left-to-right)
			}
		}

		/// <summary>
		/// The decimal digit value (0..9) of this code point, or -1 if this code point
		/// does not have a decimal digit value.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#Numeric_Value, field (6).
		/// </remarks>
		public static Int32 GetDecimalDigitValue(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.UnicodeDataData.TryGetValue(codePoint.Value, out UnicodeDataFileEntry entry)) {
				return entry.DecimalDigitValue;
			} else {
				return -1; // default is "not a decimal digit"
			}
		}

		/// <summary>
		/// The digit value (0..9) of this code point, or -1 if this code point
		/// does not have a digit value.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#Numeric_Value, field (7).
		/// </remarks>
		public static Int32 GetDigitValue(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.UnicodeDataData.TryGetValue(codePoint.Value, out UnicodeDataFileEntry entry)) {
				return entry.DigitValue;
			} else {
				return -1; // default is "not a digit"

			}
		}

		/// <summary>
		/// Any flags associated with this code point, such as "is white space?"
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#PropList.txt.
		/// </remarks>
		public static CodePointFlags GetFlags(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.PropListData.TryGetValue(codePoint.Value, out CodePointFlags flags)) {
				return flags;
			} else {
				return default; // default is "no flags"
			}
		}

		/// <summary>
		/// The general Unicode category of this code point.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#UnicodeData.txt.
		/// </remarks>
		public static UnicodeCategory GetGeneralCategory(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.UnicodeDataData.TryGetValue(codePoint.Value, out UnicodeDataFileEntry entry)) {
				return entry.GeneralCategory;
			} else {
				return UnicodeCategory.OtherNotAssigned; // default is "Unassigned"
			}
		}

		/// <summary>
		/// The grapheme cluster break property of this code point.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr29/#Grapheme_Cluster_Break_Property_Values.
		/// </remarks>
		public static GraphemeClusterBreakProperty GetGraphemeClusterBreakProperty(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.GraphemeBreakPropertyData.TryGetValue(codePoint.Value, out GraphemeClusterBreakProperty graphemeProperty)) {
				return graphemeProperty;
			} else {
				return GraphemeClusterBreakProperty.Other; // default is "Other"
			}
		}

		/// <summary>
		/// The name of this code point.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/Public/UCD/latest/ucd/extracted/DerivedName.txt.
		/// </remarks>
		public static String GetName(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.DerivedNameData.TryGetValue(codePoint.Value, out String preferredName)) {
				return preferredName;
			} else if (UnicodeData.CurrentData.UnicodeDataData.TryGetValue(codePoint.Value, out UnicodeDataFileEntry entry)) {
				return entry.Name;
			} else {
				return "<Unassigned>";
			}
		}

		/// <summary>
		/// The numeric value of this code point, or -1 if this code point
		/// does not have a numeric value.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#Numeric_Value, field (8).
		/// </remarks>
		public static Double GetNumericValue(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.UnicodeDataData.TryGetValue(codePoint.Value, out UnicodeDataFileEntry entry)) {
				return entry.NumericValue;
			} else {
				return -1; // default is "not a numeric value"
			}
		}

		/// <summary>
		/// The code point that results from performing a simple case fold mapping of this code point.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#CaseFolding.txt
		/// and https://www.unicode.org/Public/UCD/latest/ucd/CaseFolding.txt.
		/// </remarks>
		public static Int32 GetSimpleCaseFoldMapping(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.CaseFoldingData.TryGetValue(codePoint.Value, out Int32 caseFoldsTo)) {
				return caseFoldsTo;
			} else {
				return codePoint.Value;
			}
		}

		/// <summary>
		/// The code point that results from performing a simple lowercase mapping of this code point.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#Simple_Lowercase_Mapping.
		/// </remarks>
		public static Int32 GetSimpleLowercaseMapping(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.UnicodeDataData.TryGetValue(codePoint.Value, out UnicodeDataFileEntry entry)) {
				return entry.SimpleLowercaseMapping;
			} else {
				return codePoint.Value;
			}
		}

		/// <summary>
		/// The code point that results from performing a simple titlecase mapping of this code point.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#Simple_Titlecase_Mapping.
		/// </remarks>
		public static Int32 GetSimpleTitlecaseMapping(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.UnicodeDataData.TryGetValue(codePoint.Value, out UnicodeDataFileEntry entry)) {
				return entry.SimpleTitlecaseMapping;
			} else {
				return codePoint.Value;
			}
		}

		/// <summary>
		/// The code point that results from performing a simple uppercase mapping of this code point.
		/// </summary>
		/// <remarks>
		/// See https://www.unicode.org/reports/tr44/#Simple_Uppercase_Mapping.
		/// </remarks>
		public static Int32 GetSimpleUppercaseMapping(this CodePoint codePoint) {
			if (UnicodeData.CurrentData.UnicodeDataData.TryGetValue(codePoint.Value, out UnicodeDataFileEntry entry)) {
				return entry.SimpleUppercaseMapping;
			} else {
				return codePoint.Value;
			}
		}
	}
}
