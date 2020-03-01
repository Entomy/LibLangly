// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the THIRD_PARTY_NOTICES file in the project root for more information.

using System;
using System.IO;

namespace Tests {
	internal static class Resources {
		public const string CaseFolding = "CaseFolding-12.1.0.txt";
		public const string DerivedBidiClass = "DerivedBidiClass-12.1.0.txt";
		public const string DerivedName = "DerivedName-12.1.0.txt";
		public const string EmojiData = "emoji-data-12.0.txt";
		public const string GraphemeBreakProperty = "GraphemeBreakProperty-12.1.0.txt";
		public const string PropList = "PropList-12.1.0.txt";
		public const string UnicodeData =
#if NETCOREAPP2_1
			"UnicodeData-8.0.txt";
#elif NETCOREAPP3_1
			"UnicodeData-11.0.txt";
#else
			"UnicodeData-12.0.txt";
#endif

		public static Stream OpenResource(string resourceName) => new FileStream(resourceName, FileMode.Open);
	}
}
