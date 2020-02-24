using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Core {
	public class UnicodeInfoTestData {
		// named such so that it appears at the beginning of the console output for any failing unit test
		public String __DebugDisplay => $"U+{ScalarValue.Value:X4}";

		public Rune ScalarValue;
		public UnicodeCategory UnicodeCategory;
		public Double NumericValue;
		public Boolean IsControl;
		public Boolean IsDigit;
		public Boolean IsLetter;
		public Boolean IsLetterOrDigit;
		public Boolean IsLower;
		public Boolean IsNumber;
		public Boolean IsPunctuation;
		public Boolean IsSeparator;
		public Boolean IsSymbol;
		public Boolean IsUpper;
		public Boolean IsWhiteSpace;

		public UnicodeInfoTestData(Rune scalarValue, UnicodeCategory unicodeCategory, Double numericValue, Boolean isControl, Boolean isDigit, Boolean isLetter, Boolean isLetterOrDigit, Boolean isLower, Boolean isNumber, Boolean isPunctuation, Boolean isSeparator, Boolean isSymbol, Boolean isUpper, Boolean isWhiteSpace) {
			ScalarValue = scalarValue;
			UnicodeCategory = unicodeCategory;
			NumericValue = numericValue;
			IsControl = isControl;
			IsDigit = isDigit;
			IsLetter = isLetter;
			IsLetterOrDigit = isLetterOrDigit;
			IsLower = isLower;
			IsNumber = isNumber;
			IsPunctuation = isPunctuation;
			IsSeparator = isSeparator;
			IsSymbol = isSymbol;
			IsUpper = isUpper;
			IsWhiteSpace = isWhiteSpace;
		}
	}
}
