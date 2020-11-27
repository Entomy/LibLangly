using System;

namespace Langly {
	internal readonly struct Record {
		public readonly UInt32 Lowercase;

		public readonly String Sequence;

		public readonly UInt32 Titlecase;

		public readonly UInt32 Uppercase;

		public readonly Int32 Utf16SequenceLength;

		public readonly Int32 Utf8SequenceLength;

		public Record(String sequence, UInt32 lower, UInt32 title, UInt32 upper, Int32 utf8Length, Int32 utf16Length) {
			Sequence = sequence;
			Lowercase = lower;
			Titlecase = title;
			Uppercase = upper;
			Utf8SequenceLength = utf8Length;
			Utf16SequenceLength = utf16Length;
		}
	}
}
