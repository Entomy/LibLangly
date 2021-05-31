using System;
using Streamy;
using Xunit;

namespace Langly {
	public class Stream_Tests {
		[Theory]
		[InlineData(new Byte[] { 1, 2, 3, 4 })]
		public void Read_Byte_Array(Byte[] array) {
			Byte[] arr = new Byte[array.Length];
			Stream stream = arr;
			foreach (Byte @byte in array) {
				stream.Write(@byte);
			}
			Assert.Equal(array, arr);
			foreach(Byte @byte in array) {
				stream.Peek(out Byte read);
				Assert.Equal(@byte, read);
				stream.Read(out read);
				Assert.Equal(@byte, read);
			}
		}
	}
}
