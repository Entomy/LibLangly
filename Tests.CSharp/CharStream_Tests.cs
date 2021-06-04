using System;
using Streamy;
using Xunit;

namespace Langly {
	public class CharStream_Tests {
		[Theory]
		[InlineData(new Byte[] { 0, 0x61, 0, 0x62, 0, 0x63, 0, 0x64 }, new Char[] { 'a', 'b', 'c', 'd' }, Encoding.UTF16BE)]
		[InlineData(new Byte[] { 0x61, 0, 0x62, 0, 0x63, 0, 0x64, 0 }, new Char[] { 'a', 'b', 'c', 'd' }, Encoding.UTF16LE)]
		public void RoundTrip_Char_Array(Byte[] expected, Char[] values, Encoding encoding) {
			Byte[] actual = new Byte[expected.Length];
			using CharStream stream = new(actual, encoding);
			// Write the values to the stream
			foreach (Char @char in values) {
				stream.Write(@char);
			}
			// Ensure what was written matches
			Assert.Equal(expected, actual);
			// Reset the position
			stream.Position = 0;
			// Read through the stream without any buffering
			// When Read() is called nothing is in the buffer, so the read occurs directly
			foreach (Char @char in values) {
				stream.Read(out Char read);
				Assert.Equal(@char, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Char @char in values) {
				stream.Peek(out Char read);
				Assert.Equal(@char, read);
				stream.Read(out read);
				Assert.Equal(@char, read);
			}
			// Reset the position
			stream.Position = 0;
			// Read through the stream with buffering
			// When Peek() is first called nothing is in the buffer, so the read occurs directly, storing the read in the buffer
			// When Peek() is called again there is a value in the buffer, so the peek returns that buffered value
			// When Read() is called there is a value in the buffer, so the read removes the buffered value
			foreach (Char @char in values) {
				stream.Peek(out Char read);
				Assert.Equal(@char, read);
				stream.Peek(out read);
				Assert.Equal(@char, read);
				stream.Read(out read);
				Assert.Equal(@char, read);
			}
		}
	}
}
