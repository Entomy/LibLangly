using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a textual pattern.
	/// </summary>
	public abstract partial class Pattern {
		/// <summary>
		/// Check for the end of the line.
		/// </summary>
		/// <remarks>
		/// This checks for various OS line endings, properly handling Windows convention, not just single UNICODE line terminators.
		/// </remarks>
		[NotNull, DisallowNull]
		public static readonly Pattern EndOfLine = new LineEndChecker();

		/// <summary>
		/// Check for the end of the source.
		/// </summary>
		[NotNull, DisallowNull]
		public static readonly Pattern EndOfSource = new SourceEndChecker();

		/// <summary>
		/// Initialize a new <see cref="Pattern"/>.
		/// </summary>
		protected Pattern() { }

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="Char"/> to match.</param>
		[return: NotNull]
		public static implicit operator Pattern(Char @char) => new CharLiteral(@char);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="char"/>.
		/// </summary>
		/// <param name="char">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Char"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((Char, Case) @char) => new CharLiteral(@char.Item1, @char.Item2);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune">The <see cref="Rune"/> to match.</param>
		[return: NotNull]
		public static implicit operator Pattern(Rune rune) => new RuneLiteral(rune);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Rune"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((Rune, Case) rune) => new RuneLiteral(rune.Item1, rune.Item2);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="string"/>.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to match.</param>
		[return: MaybeNull, NotNullIfNotNull("string")]
		public static implicit operator Pattern([AllowNull] String @string) => @string is not null ? new StringLiteral(@string) : null;

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="string"/>.
		/// </summary>
		/// <param name="string">A <see cref="ValueTuple{T1, T2}"/> of <see cref="String"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((String, Case) @string) => new StringLiteral(@string.Item1, @string.Item2);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="array"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Char"/> to match.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator Pattern([AllowNull] Char[] array) => array is not null ? new StringLiteral(array) : null;

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="array"/>.
		/// </summary>
		/// <param name="array">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Array"/> of <see cref="Char"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((Char[], Case) array) => new StringLiteral(array.Item1, array.Item2);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Char"/> to match.</param>
		[return: NotNull]
		public static implicit operator Pattern(Memory<Char> memory) => new StringLiteral(memory);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Memory{T}"/> of <see cref="Char"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((Memory<Char>, Case) memory) => new StringLiteral(memory.Item1, memory.Item2);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to match.</param>
		[return: NotNull]
		public static implicit operator Pattern(ReadOnlyMemory<Char> memory) => new StringLiteral(memory);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">A <see cref="ValueTuple{T1, T2}"/> of <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((ReadOnlyMemory<Char>, Case) memory) => new StringLiteral(memory.Item1, memory.Item2);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">The <see cref="Patterns.Capture"/> to match.</param>
		[return: MaybeNull, NotNullIfNotNull("capture")]
		public static implicit operator Pattern([AllowNull] Capture capture) => capture is not null ? new CaptureLiteral(capture) : null;

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Patterns.Capture"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((Capture, Case) capture) => new CaptureLiteral(capture.Item1, capture.Item2);

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse([AllowNull] String source) => Parse(source.AsMemory());

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse([AllowNull] Char[] source) => Parse(source.AsMemory());

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse(Memory<Char> source) => Parse((ReadOnlyMemory<Char>)source);

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse(ReadOnlyMemory<Char> source) {
			CaptureRegion result = new CaptureRegion(source);
			Consume(source, ref result.Length);
			return result;
		}

		/// <summary>
		/// Calls the consume parser for this <see cref="Pattern"/> on the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="length">The length of the captured text.</param>
		protected abstract void Consume(ReadOnlyMemory<Char> source, ref Int32 length);

		/// <summary>
		/// Calls the neglect parser for this <see cref="Pattern"/> on the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="length">The length of the captured text.</param>
		protected abstract void Neglect(ReadOnlyMemory<Char> source, ref Int32 length);
	}
}
