using System;
using Xunit;
using Rune = System.Text.Rune;

namespace Langly.Streams {
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
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Peek_SByte(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in buffer) {
				stream.Peek(out SByte peek);
				Assert.Equal((SByte)buffer[i], peek);
				stream.Read(out SByte read);
				Assert.Equal((SByte)buffer[i++], read);
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
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Peek_UInt16(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Peek(out UInt16 peek);
				Assert.Equal(BitConverter.ToUInt16(buffer.AsSpan().Slice(i, 2)), peek);
				stream.Read(out UInt16 read);
				Assert.Equal(BitConverter.ToUInt16(buffer.AsSpan().Slice(i, 2)), read);
				Assert.Equal(peek, read);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Peek_Int32(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Peek(out Int32 peek);
				Assert.Equal(BitConverter.ToInt32(buffer.AsSpan().Slice(i, 4)), peek);
				stream.Read(out Int32 read);
				Assert.Equal(BitConverter.ToInt32(buffer.AsSpan().Slice(i, 4)), read);
				Assert.Equal(peek, read);
				i += 4;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Peek_UInt32(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Peek(out UInt32 peek);
				Assert.Equal(BitConverter.ToUInt32(buffer.AsSpan().Slice(i, 4)), peek);
				stream.Read(out UInt32 read);
				Assert.Equal(BitConverter.ToUInt32(buffer.AsSpan().Slice(i, 4)), read);
				Assert.Equal(peek, read);
				i += 4;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void Peek_Int64(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Peek(out Int64 peek);
				Assert.Equal(BitConverter.ToInt64(buffer.AsSpan().Slice(i, 8)), peek);
				stream.Read(out Int64 read);
				Assert.Equal(BitConverter.ToInt64(buffer.AsSpan().Slice(i, 8)), read);
				Assert.Equal(peek, read);
				i += 8;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void Peek_UInt64(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Peek(out UInt64 peek);
				Assert.Equal(BitConverter.ToUInt64(buffer.AsSpan().Slice(i, 8)), peek);
				stream.Read(out UInt64 read);
				Assert.Equal(BitConverter.ToUInt64(buffer.AsSpan().Slice(i, 8)), read);
				Assert.Equal(peek, read);
				i += 8;
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
				stream.Read(out Byte read);
				Assert.Equal(buffer[i++], read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Read_SByte(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in buffer) {
				stream.Read(out SByte read);
				Assert.Equal((SByte)buffer[i++], read);
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
				stream.Read(out Int16 read);
				Assert.Equal(BitConverter.ToInt16(buffer.AsSpan().Slice(i, 2)), read);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Read_UInt16(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Read(out UInt16 read);
				Assert.Equal(BitConverter.ToUInt16(buffer.AsSpan().Slice(i, 2)), read);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Read_Int32(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Read(out Int32 read);
				Assert.Equal(BitConverter.ToInt32(buffer.AsSpan().Slice(i, 4)), read);
				i += 4;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Read_UInt32(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Read(out UInt32 read);
				Assert.Equal(BitConverter.ToUInt32(buffer.AsSpan().Slice(i, 4)), read);
				i += 4;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void Read_Int64(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Read(out Int64 read);
				Assert.Equal(BitConverter.ToInt64(buffer.AsSpan().Slice(i, 8)), read);
				i += 8;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void Read_UInt64(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				stream.Read(out UInt64 read);
				Assert.Equal(BitConverter.ToUInt64(buffer.AsSpan().Slice(i, 8)), read);
				i += 8;
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
		[InlineData(new Byte[] { })]
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
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryPeek_SByte(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			foreach (Byte item in buffer) {
				Assert.True(stream.TryPeek(out SByte peek, out error));
				Assert.Equal((SByte)buffer[i], peek);
				Assert.Equal(Errors.None, error);
				Assert.True(stream.TryRead(out SByte read, out error));
				Assert.Equal((SByte)buffer[i++], read);
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
				Assert.Equal(peek, read);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryPeek_UInt16(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryPeek(out UInt16 peek, out error));
				Assert.Equal(BitConverter.ToUInt16(buffer.AsSpan().Slice(i, 2)), peek);
				Assert.Equal(Errors.None, error);
				Assert.True(stream.TryRead(out UInt16 read, out error));
				Assert.Equal(BitConverter.ToUInt16(buffer.AsSpan().Slice(i, 2)), read);
				Assert.Equal(Errors.None, error);
				Assert.Equal(peek, read);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryPeek_Int32(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryPeek(out Int32 peek, out error));
				Assert.Equal(BitConverter.ToInt32(buffer.AsSpan().Slice(i, 4)), peek);
				Assert.Equal(Errors.None, error);
				Assert.True(stream.TryRead(out Int32 read, out error));
				Assert.Equal(BitConverter.ToInt32(buffer.AsSpan().Slice(i, 4)), read);
				Assert.Equal(Errors.None, error);
				Assert.Equal(peek, read);
				i += 4;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryPeek_UInt32(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryPeek(out UInt32 peek, out error));
				Assert.Equal(BitConverter.ToUInt32(buffer.AsSpan().Slice(i, 4)), peek);
				Assert.Equal(Errors.None, error);
				Assert.True(stream.TryRead(out UInt32 read, out error));
				Assert.Equal(BitConverter.ToUInt32(buffer.AsSpan().Slice(i, 4)), read);
				Assert.Equal(Errors.None, error);
				Assert.Equal(peek, read);
				i += 4;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void TryPeek_Int64(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryPeek(out Int64 peek, out error));
				Assert.Equal(BitConverter.ToInt64(buffer.AsSpan().Slice(i, 8)), peek);
				Assert.Equal(Errors.None, error);
				Assert.True(stream.TryRead(out Int64 read, out error));
				Assert.Equal(BitConverter.ToInt64(buffer.AsSpan().Slice(i, 8)), read);
				Assert.Equal(Errors.None, error);
				Assert.Equal(peek, read);
				i += 8;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void TryPeek_UInt64(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryPeek(out UInt64 peek, out error));
				Assert.Equal(BitConverter.ToUInt64(buffer.AsSpan().Slice(i, 8)), peek);
				Assert.Equal(Errors.None, error);
				Assert.True(stream.TryRead(out UInt64 read, out error));
				Assert.Equal(BitConverter.ToUInt64(buffer.AsSpan().Slice(i, 8)), read);
				Assert.Equal(Errors.None, error);
				Assert.Equal(peek, read);
				i += 8;
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
				Assert.True(stream.TryRead(out Byte read, out Errors error));
				Assert.Equal(buffer[i++], read);
				Assert.Equal(Errors.None, error);
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryRead_SByte(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			foreach (Byte item in buffer) {
				Assert.True(stream.TryRead(out SByte read, out Errors error));
				Assert.Equal((SByte)buffer[i++], read);
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
				Assert.True(stream.TryRead(out Int16 read, out Errors error));
				Assert.Equal(BitConverter.ToInt16(buffer.AsSpan().Slice(i, 2)), read);
				Assert.Equal(Errors.None, error);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryRead_UInt16(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			while (i < buffer.Length) {
				Assert.True(stream.TryRead(out UInt16 read, out Errors error));
				Assert.Equal(BitConverter.ToUInt16(buffer.AsSpan().Slice(i, 2)), read);
				Assert.Equal(Errors.None, error);
				i += 2;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryRead_Int32(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryRead(out Int32 read, out error));
				Assert.Equal(BitConverter.ToInt32(buffer.AsSpan().Slice(i, 4)), read);
				Assert.Equal(Errors.None, error);
				i += 4;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryRead_UInt32(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryRead(out UInt32 read, out error));
				Assert.Equal(BitConverter.ToUInt32(buffer.AsSpan().Slice(i, 4)), read);
				Assert.Equal(Errors.None, error);
				i += 4;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void TryRead_Int64(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryRead(out Int64 read, out error));
				Assert.Equal(BitConverter.ToInt64(buffer.AsSpan().Slice(i, 8)), read);
				Assert.Equal(Errors.None, error);
				i += 8;
			}
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void TryRead_UInt64(Byte[] buffer) {
			Stream stream = buffer;
			Int32 i = 0;
			Errors error;
			while (i < buffer.Length) {
				Assert.True(stream.TryRead(out UInt64 read, out error));
				Assert.Equal(BitConverter.ToUInt64(buffer.AsSpan().Slice(i, 8)), read);
				Assert.Equal(Errors.None, error);
				i += 8;
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
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void TryWrite_Int32(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			while (i < expected.Length) {
				Assert.True(stream.TryWrite(BitConverter.ToInt32(expected.AsSpan().Slice(i, 4)), out Errors error));
				Assert.Equal(BitConverter.ToInt32(expected.AsSpan().Slice(i, 4)), BitConverter.ToInt32(buffer.AsSpan().Slice(i, 4)));
				Assert.Equal(Errors.None, error);
				i += 4;
			}
			Assert.Equal(expected, buffer);
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void TryWrite_Int64(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			while (i < expected.Length) {
				Assert.True(stream.TryWrite(BitConverter.ToInt64(expected.AsSpan().Slice(i, 8)), out Errors error));
				Assert.Equal(BitConverter.ToInt64(expected.AsSpan().Slice(i, 8)), BitConverter.ToInt64(buffer.AsSpan().Slice(i, 8)));
				Assert.Equal(Errors.None, error);
				i += 8;
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

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 255, 254, 253, 252 })]
		public void Write_Int32(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			while (i < expected.Length) {
				stream.Write(BitConverter.ToInt32(expected.AsSpan().Slice(i, 4)));
				Assert.Equal(BitConverter.ToInt32(expected.AsSpan().Slice(i, 4)), BitConverter.ToInt32(expected.AsSpan().Slice(i, 4)));
				i += 4;
			}
			Assert.Equal(expected, buffer);
		}

		[Theory]
		[InlineData(new Byte[] { })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		[InlineData(new Byte[] { 255, 254, 253, 252, 251, 250, 249, 248 })]
		public void Write_Int64(Byte[] expected) {
			Byte[] buffer = new Byte[expected.Length];
			Stream stream = buffer;
			Int32 i = 0;
			while (i < expected.Length) {
				stream.Write(BitConverter.ToInt64(expected.AsSpan().Slice(i, 8)));
				Assert.Equal(BitConverter.ToInt64(expected.AsSpan().Slice(i, 8)), BitConverter.ToInt64(expected.AsSpan().Slice(i, 8)));
				i += 8;
			}
			Assert.Equal(expected, buffer);
		}
	}
}
