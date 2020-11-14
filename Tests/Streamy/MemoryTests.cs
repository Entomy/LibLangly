using System;
using Xunit;

namespace Streamy {
	public class MemoryTests {
		[Theory]
		[InlineData(null, false, false, false)]
		[InlineData(new Byte[] { }, false, false, false)]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 }, true, true, true)]
		public void Constructor(Byte[] buffer, Boolean readable, Boolean seekable, Boolean writable) {
			Stream stream = buffer;
			Assert.Equal(0, stream.Position);
			Assert.Equal(readable, stream.Readable);
			Assert.Equal(seekable, stream.Seekable);
			Assert.Equal(writable, stream.Writable);
		}
	}
}
