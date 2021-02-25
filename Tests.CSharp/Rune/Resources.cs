// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;

namespace System.Text.Unicode {
	internal static class Resources {
		public const string CaseFolding = "CaseFolding.txt";
		public const string DerivedBidiClass = "DerivedBidiClass.txt";
		public const string DerivedName = "DerivedName.txt";
		public const string EmojiData = "emoji-data.txt";
		public const string GraphemeBreakProperty = "GraphemeBreakProperty.txt";
		public const string PropList = "PropList.txt";
		public const string UnicodeData =
#if NETCOREAPP2_1
			"UnicodeData-8.0.txt";
#elif NETCOREAPP3_0 || NETCOREAPP3_1
			"UnicodeData-11.0.txt";
#else
			"UnicodeData-12.0.txt";
#endif

		public static Stream OpenResource(string resourceName) => new FileStream(resourceName, FileMode.Open, FileAccess.Read);
	}
}
