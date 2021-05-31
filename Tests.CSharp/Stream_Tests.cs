using System;
using Streamy;
using Xunit;

namespace Langly {
	public class Stream_Tests {
		[Theory]
		[InlineData(new Byte[] { 1, 2, 3, 4 }, new Byte[] { 1, 2, 3, 4 })]
		[InlineData(new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new Byte[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
		public void RoundTrip_Byte_Array(Byte[] expected, Byte[] values) {
			Byte[] actual = new Byte[expected.Length];
			using Stream stream = actual;
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
			foreach (Byte @byte in expected) {
				stream.Read(out Byte read);
				Assert.Equal(@byte, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach(Byte @byte in expected) {
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
			foreach (Byte @byte in expected) {
				stream.Peek(out Byte read);
				Assert.Equal(@byte, read);
				stream.Peek(out read);
				Assert.Equal(@byte, read);
				stream.Read(out read);
				Assert.Equal(@byte, read);
			}
		}
	}
}
