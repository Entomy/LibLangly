using System;
using Xunit;
using Philosoft;

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

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		public void Read(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in buffer) {
				stream.Read(out Byte strby);
				Assert.Equal(buffer[i++], strby);
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		public void TryRead(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in buffer) {
				Assert.True(stream.TryRead(out Byte strby, out Errors error));
				Assert.Equal(buffer[i++], strby);
				Assert.Equal(Errors.None, error);
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		public void TryWrite(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in expected) {
				Assert.True(stream.TryWrite(item, out Errors error));
				Assert.Equal(expected[i], buffer[i++]);
				Assert.Equal(Errors.None, error);
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		public void Write(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in expected) {
				stream.Write(item);
				Assert.Equal(expected[i], buffer[i++]);
			}
		}
	}
}
