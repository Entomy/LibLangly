using System;
using Xunit;
using Stringier.Encodings;
using Rune = System.Text.Rune;

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
		[InlineData(new Byte[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F }, Encoding.UTF8)]
		[InlineData(new Byte[] { 0xEF, 0xBB, 0xBF, 0x68, 0x65, 0x6C, 0x6C, 0x6F }, Encoding.UTF8)]
		[InlineData(new Byte[] { 0xFE, 0xFF, 0x00, 0x68, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F }, Encoding.UTF16BE)]
		[InlineData(new Byte[] { 0xFF, 0xFE, 0x68, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F, 0x00 }, Encoding.UTF16LE)]
		[InlineData(new Byte[] { 0x00, 0x00, 0xFE, 0xFF, 0x00, 0x00, 0x00, 0x68, 0x00, 0x00, 0x00, 0x65, 0x00, 0x00, 0x00, 0x6C, 0x00, 0x00, 0x00, 0x6C, 0x00, 0x00, 0x00, 0x6F }, Encoding.UTF32BE)]
		[InlineData(new Byte[] { 0xFF, 0xFE, 0x00, 0x00, 0x68, 0x00, 0x00, 0x00, 0x65, 0x00, 0x00, 0x00, 0x6C, 0x00, 0x00, 0x00, 0x6C, 0x00, 0x00, 0x00, 0x6F, 0x00, 0x00, 0x00 }, Encoding.UTF32LE)]
		public void EncodingDetection(Byte[] buffer, Encoding encoding) {
			using TextStream stream = new TextStream(buffer, encoding);
			Assert.Equal(encoding, stream.Encoding);
			// It is not enough to ensure the encoding was detected and reported. We need to also test that the BOM was read as appropriate, and we are left in the correct position. By reading actual text after, we ensure the entire process was done right.
			Rune rune;
			stream.Read(out rune);
			Assert.Equal(new Rune(0x68), rune);
			stream.Read(out rune);
			Assert.Equal(new Rune(0x65), rune);
			stream.Read(out rune);
			Assert.Equal(new Rune(0x6C), rune);
			stream.Read(out rune);
			Assert.Equal(new Rune(0x6C), rune);
			stream.Read(out rune);
			Assert.Equal(new Rune(0x6F), rune);
		}

		[Theory]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Peek_Byte(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in buffer) {
				stream.Peek(out Byte peek);
				Assert.Equal(buffer[i], peek);
				stream.Read(out Byte read);
				Assert.Equal(buffer[i++], read);
				Assert.Equal(peek, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Peek_Int16(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Peek(out Int16 peek);
				Assert.Equal(BitConverter.ToInt16(buffer.AsSpan().Slice(i, 2)), peek);
				stream.Read(out Int16 read);
				Assert.Equal(BitConverter.ToInt16(buffer.AsSpan().Slice(i, 2)), read);
				Assert.Equal(peek, read);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Read_Byte(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in buffer) {
				stream.Read(out Byte strby);
				Assert.Equal(buffer[i++], strby);
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Read_Int16(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Read(out Int16 strin);
				Assert.Equal(BitConverter.ToInt16(buffer.AsSpan().Slice(i, 2)), strin);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F }, Encoding.UTF8)]
		[InlineData(new Byte[] { 0x00, 0x68, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F }, Encoding.UTF16BE)]
		[InlineData(new Byte[] { 0x68, 0x00, 0x65, 0x00, 0x6C, 0x00, 0x6C, 0x00, 0x6F, 0x00 }, Encoding.UTF16LE)]
		[InlineData(new Byte[] { 0x00, 0x00, 0x00, 0x68, 0x00, 0x00, 0x00, 0x65, 0x00, 0x00, 0x00, 0x6C, 0x00, 0x00, 0x00, 0x6C, 0x00, 0x00, 0x00, 0x6F }, Encoding.UTF32BE)]
		[InlineData(new Byte[] { 0x68, 0x00, 0x00, 0x00, 0x65, 0x00, 0x00, 0x00, 0x6C, 0x00, 0x00, 0x00, 0x6C, 0x00, 0x00, 0x00, 0x6F, 0x00, 0x00, 0x00 }, Encoding.UTF32LE)]
		public void Read_Rune(Byte[] buffer, Encoding encoding) {
			using TextStream stream = new TextStream(buffer, encoding);
			Rune rune;
			stream.Read(out rune);
			Assert.Equal(new Rune(0x68), rune);
			stream.Read(out rune);
			Assert.Equal(new Rune(0x65), rune);
			stream.Read(out rune);
			Assert.Equal(new Rune(0x6C), rune);
			stream.Read(out rune);
			Assert.Equal(new Rune(0x6C), rune);
			stream.Read(out rune);
			Assert.Equal(new Rune(0x6F), rune);
		}

		[Theory]
		[InlineData(new Byte[] { } )]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryPeek_Byte(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			foreach (Byte item in buffer) {
				Assert.True(stream.TryPeek(out Byte peek, out error));
				Assert.Equal(buffer[i], peek);
				Assert.Equal(Errors.None, error);
				Assert.True(stream.TryRead(out Byte read, out error));
				Assert.Equal(buffer[i++], read);
				Assert.Equal(Errors.None, error);
				Assert.Equal(peek, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryPeek_Int16(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryPeek(out Int16 peek, out error));
				Assert.Equal(BitConverter.ToInt16(buffer.AsSpan().Slice(i, 2)), peek);
				Assert.Equal(Errors.None, error);
				Assert.True(stream.TryRead(out Int16 read, out error));
				Assert.Equal(BitConverter.ToInt16(buffer.AsSpan().Slice(i, 2)), read);
				Assert.Equal(Errors.None, error);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryRead_Byte(Byte[] buffer) {
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
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryRead_Int16(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				Assert.True(stream.TryRead(out Int16 strin, out Errors error));
				Assert.Equal(BitConverter.ToInt16(buffer.AsSpan().Slice(i, 2)), strin);
				Assert.Equal(Errors.None, error);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryWrite_Byte(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in expected) {
				Assert.True(stream.TryWrite(item, out Errors error));
				Assert.Equal(expected[i], buffer[i++]);
				Assert.Equal(Errors.None, error);
			}
			Assert.Equal(expected, buffer);
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryWrite_Int16(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			while (i < expected.Length) {
				Assert.True(stream.TryWrite(BitConverter.ToInt16(expected.AsSpan().Slice(i, 2)), out Errors error));
				Assert.Equal(BitConverter.ToInt16(expected.AsSpan().Slice(i, 2)), BitConverter.ToInt16(buffer.AsSpan().Slice(i, 2)));
				Assert.Equal(Errors.None, error);
				i += 2;
			}
			Assert.Equal(expected, buffer);
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Write_Byte(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in expected) {
				stream.Write(item);
				Assert.Equal(expected[i], buffer[i++]);
			}
			Assert.Equal(expected, buffer);
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Write_Int16(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			while (i < expected.Length) {
				stream.Write(BitConverter.ToInt16(expected.AsSpan().Slice(i, 2)));
				Assert.Equal(BitConverter.ToInt16(expected.AsSpan().Slice(i, 2)), BitConverter.ToInt16(expected.AsSpan().Slice(i, 2)));
				i += 2;
			}
			Assert.Equal(expected, buffer);
		}
	}
}
