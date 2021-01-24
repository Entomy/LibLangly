using System;
using Xunit;
using Langly.Internals;
using static System.Environment;

namespace Langly {
	public class ConsoleTests {
		TestConsole tester = new TestConsole();

		public ConsoleTests() {
			ConsoleComponents.Reader = tester;
			ConsoleComponents.Writer = tester;
			ConsoleComponents.ErrorWriter = tester;
			ConsoleComponents.StateManager = new StubStateManager();
		}

		[Theory]
		[InlineData(null)]
		[InlineData("Hello")]
		public void Write_String(String text) {
			Console.Write(text);
			Assert.Equal(text ?? String.Empty, tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("Hello")]
		public void Write_String_Color(String text) {
			Console.Write(text, Color.Blue, Color.White);
			Assert.Equal(text ?? String.Empty, tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void Write_Array(Char[] text) {
			Console.Write(text);
			Assert.Equal(text ?? Array.Empty<Char>(), tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void Write_Array_Color(Char[] text) {
			Console.Write(text, Color.Blue, Color.White);
			Assert.Equal(text ?? Array.Empty<Char>(), tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void Write_Memory(Char[] text) {
			Console.Write(text.AsMemory());
			Assert.Equal(text ?? Array.Empty<Char>(), tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void Write_Memory_Color(Char[] text) {
			Console.Write(text.AsMemory(), Color.Blue, Color.White);
			Assert.Equal(text ?? Array.Empty<Char>(), tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public void Write_ReadOnlyMemory(String text) {
			Console.Write(text.AsMemory());
			Assert.Equal(text, tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public void Write_ReadOnlyMemory_Color(String text) {
			Console.Write(text.AsMemory(), Color.Blue, Color.White);
			Assert.Equal(text, tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void Write_Span(Char[] text) {
			Console.Write(text.AsSpan());
			Assert.Equal(text ?? Array.Empty<Char>(), tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void Write_Span_Color(Char[] text) {
			Console.Write(text.AsSpan(), Color.Blue, Color.White);
			Assert.Equal(text ?? Array.Empty<Char>(), tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public void Write_ReadOnlySpan(String text) {
			Console.Write(text.AsSpan());
			Assert.Equal(text, tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public void Write_ReadOnlySpan_Color(String text) {
			Console.Write(text.AsSpan(), Color.Blue, Color.White);
			Assert.Equal(text, tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public unsafe void Write_Pointer(String text) {
			fixed (Char* txt = text) {
				Console.Write(txt, text.Length);
			}
			Assert.Equal(text, tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public unsafe void Write_Pointer_Color(String text) {
			fixed (Char* txt = text) {
				Console.Write(txt, text.Length, Color.Blue, Color.White);
			}
			Assert.Equal(text, tester.Written);
		}

		[Theory]
		[InlineData(1)]
		public void Write_Int32(Int32 value) {
			Console.Write(value);
			Assert.Equal(value.ToString(), tester.Written);
		}

		[Theory]
		[InlineData(1)]
		public void Write_Int32_Color(Int32 value) {
			Console.Write(value, Color.Blue, Color.White);
			Assert.Equal(value.ToString(), tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("Hello")]
		public void WriteLine_String(String text) {
			Console.WriteLine(text);
			Assert.Equal($"{text ?? String.Empty}{NewLine}", tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("Hello")]
		public void WriteLine_String_Color(String text) {
			Console.WriteLine(text, Color.Blue, Color.White);
			Assert.Equal($"{text ?? String.Empty}{NewLine}", tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void WriteLine_Array(Char[] text) {
			Console.WriteLine(text);
			Char[] expected = new Char[(text?.Length ?? 0) + NewLine.Length];
			text?.CopyTo(expected, 0);
			NewLine.CopyTo(0, expected, text?.Length ?? 0, NewLine.Length);
			Assert.Equal(expected, tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void WriteLine_Array_Color(Char[] text) {
			Console.WriteLine(text, Color.Blue, Color.White);
			Char[] expected = new Char[(text?.Length ?? 0) + NewLine.Length];
			text?.CopyTo(expected, 0);
			NewLine.CopyTo(0, expected, text?.Length ?? 0, NewLine.Length);
			Assert.Equal(expected, tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void WriteLine_Memory(Char[] text) {
			Console.WriteLine(text.AsMemory());
			Char[] expected = new Char[(text?.Length ?? 0) + NewLine.Length];
			text?.CopyTo(expected, 0);
			NewLine.CopyTo(0, expected, text?.Length ?? 0, NewLine.Length);
			Assert.Equal(expected, tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void WriteLine_Memory_Color(Char[] text) {
			Console.WriteLine(text.AsMemory(), Color.Blue, Color.White);
			Char[] expected = new Char[(text?.Length ?? 0) + NewLine.Length];
			text?.CopyTo(expected, 0);
			NewLine.CopyTo(0, expected, text?.Length ?? 0, NewLine.Length);
			Assert.Equal(expected, tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public void WriteLine_ReadOnlyMemory(String text) {
			Console.WriteLine(text.AsMemory());
			Char[] expected = new Char[(text?.Length ?? 0) + NewLine.Length];
			text?.CopyTo(0, expected, 0, text.Length);
			NewLine.CopyTo(0, expected, text?.Length ?? 0, NewLine.Length);
			Assert.Equal(expected, tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public void WriteLine_ReadOnlyMemory_Color(String text) {
			Console.WriteLine(text.AsMemory(), Color.Blue, Color.White);
			Char[] expected = new Char[(text?.Length ?? 0) + NewLine.Length];
			text?.CopyTo(0, expected, 0, text.Length);
			NewLine.CopyTo(0, expected, text?.Length ?? 0, NewLine.Length);
			Assert.Equal(expected, tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void WriteLine_Span(Char[] text) {
			Console.WriteLine(text.AsSpan());
			Char[] expected = new Char[(text?.Length ?? 0) + NewLine.Length];
			text?.CopyTo(expected, 0);
			NewLine.CopyTo(0, expected, text?.Length ?? 0, NewLine.Length);
			Assert.Equal(expected, tester.Written);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(new Char[] { 'H', 'e', 'l', 'l', 'o' })]
		public void WriteLine_Span_Color(Char[] text) {
			Console.WriteLine(text.AsSpan(), Color.Blue, Color.White);
			Char[] expected = new Char[(text?.Length ?? 0) + NewLine.Length];
			text?.CopyTo(expected, 0);
			NewLine.CopyTo(0, expected, text?.Length ?? 0, NewLine.Length);
			Assert.Equal(expected, tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public void WriteLine_ReadOnlySpan(String text) {
			Console.WriteLine(text.AsSpan());
			Assert.Equal($"{text}{NewLine}", tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public void WriteLine_ReadOnlySpan_Color(String text) {
			Console.WriteLine(text.AsSpan(), Color.Blue, Color.White);
			Assert.Equal($"{text}{NewLine}", tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public unsafe void WriteLine_Pointer(String text) {
			fixed (Char* txt = text) {
				Console.WriteLine(txt, text.Length);
			}
			Assert.Equal($"{text}{NewLine}", tester.Written);
		}

		[Theory]
		[InlineData("Hello")]
		public unsafe void WriteLine_Pointer_Color(String text) {
			fixed (Char* txt = text) {
				Console.WriteLine(txt, text.Length, Color.Blue, Color.White);
			}
			Assert.Equal($"{text}{NewLine}", tester.Written);
		}

		[Theory]
		[InlineData(1)]
		public void WriteLine_Int32(Int32 value) {
			Console.WriteLine(value);
			Assert.Equal($"{value}{NewLine}", tester.Written);
		}

		[Theory]
		[InlineData(1)]
		public void WriteLine_Int32_Color(Int32 value) {
			Console.WriteLine(value, Color.Blue, Color.White);
			Assert.Equal($"{value}{NewLine}", tester.Written);
		}
	}
}
