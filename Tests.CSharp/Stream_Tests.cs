using System;
using Streamy;
using Xunit;

namespace Langly {
	public class Stream_Tests {
		[Theory]
		[InlineData(new Byte[] { 1, 0, 1, 0 }, new Boolean[] { true, false, true, false }, Endian.Big)]
		[InlineData(new Byte[] { 1, 0, 1, 0 }, new Boolean[] { true, false, true, false }, Endian.Little)]
		public void RoundTrip_Boolean_Array(Byte[] expected, Boolean[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (Boolean @bool in values) {
				stream.Write(@bool);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (Boolean @bool in values) {
				stream.Read(out Boolean read);
				Assert.Equal(@bool, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Boolean @bool in values) {
				stream.Peek(out Boolean read);
				Assert.Equal(@bool, read);
				stream.Read(out read);
				Assert.Equal(@bool, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Boolean @bool in values) {
				stream.Peek(out Boolean read);
				Assert.Equal(@bool, read);
				stream.Peek(out read);
				Assert.Equal(@bool, read);
				stream.Read(out read);
				Assert.Equal(@bool, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 1, 2, 3, 4 }, new Byte[] { 1, 2, 3, 4 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 2, 3, 4 }, new Byte[] { 1, 2, 3, 4 }, Endian.Little)]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Little)]
		public void RoundTrip_Byte_Array(Byte[] expected, Byte[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (Byte @byte in values) {
				stream.Write(@byte);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (Byte @byte in values) {
				stream.Read(out Byte read);
				Assert.Equal(@byte, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Byte @byte in values) {
				stream.Peek(out Byte read);
				Assert.Equal(@byte, read);
				stream.Read(out read);
				Assert.Equal(@byte, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Byte @byte in values) {
				stream.Peek(out Byte read);
				Assert.Equal(@byte, read);
				stream.Peek(out read);
				Assert.Equal(@byte, read);
				stream.Read(out read);
				Assert.Equal(@byte, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 0, 1, 0, 2, 0, 3, 0, 4 }, new Int16[] { 1, 2, 3, 4 }, Endian.Big)]
		[InlineData(new Byte[] { 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7, 0, 8 }, new Int16[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 0, 2, 0, 3, 0, 4, 0 }, new Int16[] { 1, 2, 3, 4 }, Endian.Little)]
		[InlineData(new Byte[] { 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7, 0, 8, 0 }, new Int16[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Little)]
		public void RoundTrip_Int16_Array(Byte[] expected, Int16[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (Int16 @int in values) {
				stream.Write(@int);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (Int16 @int in values) {
				stream.Read(out Int16 read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Int16 @int in values) {
				stream.Peek(out Int16 read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Int16 @int in values) {
				stream.Peek(out Int16 read);
				Assert.Equal(@int, read);
				stream.Peek(out read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4 }, new Int32[] { 1, 2, 3, 4 }, Endian.Big)]
		[InlineData(new Byte[] { 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 6, 0, 0, 0, 7, 0, 0, 0, 8 }, new Int32[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0 }, new Int32[] { 1, 2, 3, 4 }, Endian.Little)]
		[InlineData(new Byte[] { 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 6, 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0 }, new Int32[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Little)]
		public void RoundTrip_Int32_Array(Byte[] expected, Int32[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (Int32 @int in values) {
				stream.Write(@int);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (Int32 @int in values) {
				stream.Read(out Int32 read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Int32 @int in values) {
				stream.Peek(out Int32 read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Int32 @int in values) {
				stream.Peek(out Int32 read);
				Assert.Equal(@int, read);
				stream.Peek(out read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4 }, new Int64[] { 1, 2, 3, 4 }, Endian.Big)]
		[InlineData(new Byte[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 8 }, new Int64[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0 }, new Int64[] { 1, 2, 3, 4 }, Endian.Little)]
		[InlineData(new Byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0 }, new Int64[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Little)]
		public void RoundTrip_Int64_Array(Byte[] expected, Int64[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (Int64 @int in values) {
				stream.Write(@int);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (Int64 @int in values) {
				stream.Read(out Int64 read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Int64 @int in values) {
				stream.Peek(out Int64 read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Int64 @int in values) {
				stream.Peek(out Int64 read);
				Assert.Equal(@int, read);
				stream.Peek(out read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 1, 2, 3, 4 }, new SByte[] { 1, 2, 3, 4 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new SByte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 2, 3, 4 }, new SByte[] { 1, 2, 3, 4 }, Endian.Little)]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new SByte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Little)]
		public void RoundTrip_SByte_Array(Byte[] expected, SByte[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (SByte @byte in values) {
				stream.Write(@byte);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (SByte @byte in values) {
				stream.Read(out SByte read);
				Assert.Equal(@byte, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (SByte @byte in values) {
				stream.Peek(out SByte read);
				Assert.Equal(@byte, read);
				stream.Read(out read);
				Assert.Equal(@byte, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (SByte @byte in values) {
				stream.Peek(out SByte read);
				Assert.Equal(@byte, read);
				stream.Peek(out read);
				Assert.Equal(@byte, read);
				stream.Read(out read);
				Assert.Equal(@byte, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 0, 1, 0, 2, 0, 3, 0, 4 }, new UInt16[] { 1, 2, 3, 4 }, Endian.Big)]
		[InlineData(new Byte[] { 0, 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7, 0, 8 }, new UInt16[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 0, 2, 0, 3, 0, 4, 0 }, new UInt16[] { 1, 2, 3, 4 }, Endian.Little)]
		[InlineData(new Byte[] { 1, 0, 2, 0, 3, 0, 4, 0, 5, 0, 6, 0, 7, 0, 8, 0 }, new UInt16[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Little)]
		public void RoundTrip_UInt16_Array(Byte[] expected, UInt16[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (UInt16 @int in values) {
				stream.Write(@int);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (UInt16 @int in values) {
				stream.Read(out UInt16 read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (UInt16 @int in values) {
				stream.Peek(out UInt16 read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (UInt16 @int in values) {
				stream.Peek(out UInt16 read);
				Assert.Equal(@int, read);
				stream.Peek(out read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4 }, new UInt32[] { 1, 2, 3, 4 }, Endian.Big)]
		[InlineData(new Byte[] { 0, 0, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 6, 0, 0, 0, 7, 0, 0, 0, 8 }, new UInt32[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0 }, new UInt32[] { 1, 2, 3, 4 }, Endian.Little)]
		[InlineData(new Byte[] { 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 6, 0, 0, 0, 7, 0, 0, 0, 8, 0, 0, 0 }, new UInt32[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Little)]
		public void RoundTrip_UInt32_Array(Byte[] expected, UInt32[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (UInt32 @int in values) {
				stream.Write(@int);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (UInt32 @int in values) {
				stream.Read(out UInt32 read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (UInt32 @int in values) {
				stream.Peek(out UInt32 read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (UInt32 @int in values) {
				stream.Peek(out UInt32 read);
				Assert.Equal(@int, read);
				stream.Peek(out read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4 }, new UInt64[] { 1, 2, 3, 4 }, Endian.Big)]
		[InlineData(new Byte[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 8 }, new UInt64[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Big)]
		[InlineData(new Byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0 }, new UInt64[] { 1, 2, 3, 4 }, Endian.Little)]
		[InlineData(new Byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0 }, new UInt64[] { 1, 2, 3, 4, 5, 6, 7, 8 }, Endian.Little)]
		public void RoundTrip_UInt64_Array(Byte[] expected, UInt64[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (UInt64 @int in values) {
				stream.Write(@int);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (UInt64 @int in values) {
				stream.Read(out UInt64 read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (UInt64 @int in values) {
				stream.Peek(out UInt64 read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (UInt64 @int in values) {
				stream.Peek(out UInt64 read);
				Assert.Equal(@int, read);
				stream.Peek(out read);
				Assert.Equal(@int, read);
				stream.Read(out read);
				Assert.Equal(@int, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 63, 128, 0, 0, 64, 0, 0, 0, 64, 64, 0, 0, 64, 128, 0, 0 }, new Single[] { 1.0f, 2.0f, 3.0f, 4.0f }, Endian.Big)]
		[InlineData(new Byte[] { 0, 0, 128, 63, 0, 0, 0, 64, 0, 0, 64, 64, 0, 0, 128, 64 }, new Single[] { 1.0f, 2.0f, 3.0f, 4.0f }, Endian.Little)]
		public void RoundTrip_Single_Array(Byte[] expected, Single[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (Single single in values) {
				stream.Write(single);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (Single single in values) {
				stream.Read(out Single read);
				Assert.Equal(single, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Single single in values) {
				stream.Peek(out Single read);
				Assert.Equal(single, read);
				stream.Read(out read);
				Assert.Equal(single, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Single single in values) {
				stream.Peek(out Single read);
				Assert.Equal(single, read);
				stream.Peek(out read);
				Assert.Equal(single, read);
				stream.Read(out read);
				Assert.Equal(single, read);
			}
		}

		[Theory]
		[InlineData(new Byte[] { 63, 240, 0, 0, 0, 0, 0, 0, 64, 0, 0, 0, 0, 0, 0, 0, 64, 8, 0, 0, 0, 0, 0, 0, 64, 16, 0, 0, 0, 0, 0, 0 }, new Double[] { 1.0, 2.0, 3.0, 4.0 }, Endian.Big)]
		[InlineData(new Byte[] { 0, 0, 0, 0, 0, 0, 240, 63, 0, 0, 0, 0, 0, 0, 0, 64, 0, 0, 0, 0, 0, 0, 8, 64, 0, 0, 0, 0, 0, 0, 16, 64 }, new Double[] { 1.0, 2.0, 3.0, 4.0 }, Endian.Little)]
		public void RoundTrip_Double_Array(Byte[] expected, Double[] values, Endian endianness) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = new(actual, endianness);
			// Write the values to the stream
			foreach (Double single in values) {
				stream.Write(single);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (Double single in values) {
				stream.Read(out Double read);
				Assert.Equal(single, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Double single in values) {
				stream.Peek(out Double read);
				Assert.Equal(single, read);
				stream.Read(out read);
				Assert.Equal(single, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Double single in values) {
				stream.Peek(out Double read);
				Assert.Equal(single, read);
				stream.Peek(out read);
				Assert.Equal(single, read);
				stream.Read(out read);
				Assert.Equal(single, read);
			}
		}
	}
}
