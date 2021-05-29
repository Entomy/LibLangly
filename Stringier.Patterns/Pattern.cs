using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a textual pattern.
	/// </summary>
	public abstract partial class Pattern {
		/// <summary>
		/// Predefined <see cref="Exception"/> for when the end of the source was reached before finding a match.
		/// </summary>
		protected static readonly Exception AtEnd = new InvalidOperationException("The parser reached the end of the source before finding a match to this pattern.");

		/// <summary>
		/// Predefined <see cref="Exception"/> for when no match could be found.
		/// </summary>
		protected static readonly Exception NoMatch = new InvalidOperationException("The parser failed to find a match for the pattern in the source.");

		/// <summary>
		/// Initialize a new <see cref="Pattern"/>.
		/// </summary>
		protected Pattern() { }

		/// <summary>
		/// Check for the end of the line.
		/// </summary>
		/// <remarks>
		/// This checks for various OS line endings, properly handling Windows convention, not just single UNICODE line terminators.
		/// </remarks>
		[NotNull, DisallowNull]
		public static Pattern EndOfLine { get; } = new LineEndChecker();

		/// <summary>
		/// Check for the end of the source.
		/// </summary>
		[NotNull, DisallowNull]
		public static Pattern EndOfSource { get; } = new SourceEndChecker();

		#region Conversions
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
		public static implicit operator Pattern([AllowNull] String @string) => @string is not null ? new MemoryLiteral(@string) : null;

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="string"/>.
		/// </summary>
		/// <param name="string">A <see cref="ValueTuple{T1, T2}"/> of <see cref="String"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((String, Case) @string) => new MemoryLiteral(@string.Item1, @string.Item2);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="array"/>.
		/// </summary>
		/// <param name="array">The <see cref="Array"/> of <see cref="Char"/> to match.</param>
		[return: MaybeNull, NotNullIfNotNull("array")]
		public static implicit operator Pattern([AllowNull] Char[] array) => array is not null ? new MemoryLiteral(array) : null;

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="array"/>.
		/// </summary>
		/// <param name="array">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Array"/> of <see cref="Char"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((Char[], Case) array) => new MemoryLiteral(array.Item1, array.Item2);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="Memory{T}"/> of <see cref="Char"/> to match.</param>
		[return: NotNull]
		public static implicit operator Pattern(Memory<Char> memory) => new MemoryLiteral(memory);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">A <see cref="ValueTuple{T1, T2}"/> of <see cref="Memory{T}"/> of <see cref="Char"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((Memory<Char>, Case) memory) => new MemoryLiteral(memory.Item1, memory.Item2);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to match.</param>
		[return: NotNull]
		public static implicit operator Pattern(ReadOnlyMemory<Char> memory) => new MemoryLiteral(memory);

		/// <summary>
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="memory"/>.
		/// </summary>
		/// <param name="memory">A <see cref="ValueTuple{T1, T2}"/> of <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> to match and <see cref="Case"/> comparison.</param>
		[return: NotNull]
		public static implicit operator Pattern((ReadOnlyMemory<Char>, Case) memory) => new MemoryLiteral(memory.Item1, memory.Item2);

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
		/// Converts to a <see cref="Pattern"/> matching exactly the <paramref name="category"/>.
		/// </summary>
		/// <param name="category">The <see cref="Category"/> to match.</param>
		[return: MaybeNull, NotNullIfNotNull("category")]
		public static implicit operator Pattern([AllowNull] Category category) => category is not null ? new CategoryChecker(category) : null;
		#endregion

		#region Parse(Source, ref Int32)
		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse([AllowNull] String source, ref Int32 location) => Parse(source, ref location, trace: null);

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse([AllowNull] Char[] source, ref Int32 location) => Parse(source, ref location, trace: null);

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse(Memory<Char> source, ref Int32 location) => Parse(source, ref location, trace: null);

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse(ReadOnlyMemory<Char> source, ref Int32 location) => Parse(source, ref location, trace: null);

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <returns>The captured text.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public unsafe Capture Parse([AllowNull] Char* source, Int32 length, ref Int32 location) => Parse(source, length, ref location, trace: null);
		#endregion

		#region Parse(Source, ref Int32, Trace)
		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse([AllowNull] String source, ref Int32 location, [AllowNull] IAdd<Capture> trace) => Parse(source.AsMemory(), ref location, trace);

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse([AllowNull] Char[] source, ref Int32 location, [AllowNull] IAdd<Capture> trace) => Parse(source.AsMemory(), ref location, trace);

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse(Memory<Char> source, ref Int32 location, [AllowNull] IAdd<Capture> trace) => Parse((ReadOnlyMemory<Char>)source, ref location, trace);

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
		/// <returns>The captured text.</returns>
		[return: NotNull]
		public Capture Parse(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull] IAdd<Capture> trace) {
			Consume(source, ref location, out Exception? exception, trace);
			return exception is null ? new CaptureMemory(source.Slice(0, location)) : throw exception;
		}

		/// <summary>
		/// Parses the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
		/// <returns>The captured text.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public unsafe Capture Parse([AllowNull] Char* source, Int32 length, ref Int32 location, [AllowNull] IAdd<Capture> trace) {
			Consume(source, length, ref location, out Exception? exception, trace);
			return exception is null ? new CapturePointer(source, location) : throw exception;
		}
		#endregion

		/// <summary>
		/// Calls the consume parser for this <see cref="Pattern"/> on the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <param name="exception">The exception that occurred during parsing, if any.</param>
		/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
		/// <remarks>
		/// This looks in <paramref name="source"/> at the <paramref name="location"/> for this <see cref="Pattern"/>, advancing <paramref name="location"/> to the position just after the match, if found, and leaving it unchanged if not found. <paramref name="exception"/> is <see langword="null"/> if a match is found, and assigned with information on the failure that occurred. If <paramref name="trace"/> is a valid object, it is used to collection steps through the pattern graph for debugging purposes.
		/// </remarks>
		protected internal abstract void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace);

		/// <summary>
		/// Calls the consume parser for this <see cref="Pattern"/> on the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <param name="exception">The exception that occurred during parsing, if any.</param>
		/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
		/// <remarks>
		/// This looks in <paramref name="source"/> at the <paramref name="location"/> for this <see cref="Pattern"/>, advancing <paramref name="location"/> to the position just after the match, if found, and leaving it unchanged if not found. <paramref name="exception"/> is <see langword="null"/> if a match is found, and assigned with information on the failure that occurred. If <paramref name="trace"/> is a valid object, it is used to collection steps through the pattern graph for debugging purposes.
		/// </remarks>
		[CLSCompliant(false)]
		protected internal abstract unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace);

		/// <summary>
		/// Checks if the header for the consume parser is present. This is an efficient check to determine whether the consume parser should be called at all.
		/// </summary>
		/// <param name="source">The source to check.</param>
		/// <param name="location">The location within the <paramref name="source"/> to check.</param>
		/// <returns><see langword="true"/> if the pattern is potentially at this <paramref name="location"/>; otherwise, <see langword="false"/>.</returns>
		protected internal Boolean IsConsumeHeader(ReadOnlyMemory<Char> source, Int32 location) => IsConsumeHeader(source.Span, location);

		/// <summary>
		/// Checks if the header for the consume parser is present. This is an efficient check to determine whether the consume parser should be called at all.
		/// </summary>
		/// <param name="source">The source to check.</param>
		/// <param name="location">The location within the <paramref name="source"/> to check.</param>
		/// <returns><see langword="true"/> if the pattern is potentially at this <paramref name="location"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		protected internal unsafe Boolean IsConsumeHeader(Char* source, Int32 location) => IsConsumeHeader(new ReadOnlySpan<Char>(source, location + 1), location);

		/// <summary>
		/// Checks if the header for the consume parser is present. This is an efficient check to determine whether the consume parser should be called at all.
		/// </summary>
		/// <param name="source">The source to check.</param>
		/// <param name="location">The location within the <paramref name="source"/> to check.</param>
		/// <returns><see langword="true"/> if the pattern is potentially at this <paramref name="location"/>; otherwise, <see langword="false"/>.</returns>
		protected internal abstract Boolean IsConsumeHeader(ReadOnlySpan<Char> source, Int32 location);

		/// <summary>
		/// Checks if the header for the neglect parser is present. This is an efficient check to determine whether the neglect parser should be called at all.
		/// </summary>
		/// <param name="source">The source to check.</param>
		/// <param name="location">The location within the <paramref name="source"/> to check.</param>
		/// <returns><see langword="true"/> if the pattern is potentially at this <paramref name="location"/>; otherwise, <see langword="false"/>.</returns>
		protected internal Boolean IsNeglectHeader(ReadOnlyMemory<Char> source, Int32 location) => IsNeglectHeader(source.Span, location);

		/// <summary>
		/// Checks if the header for the neglect parser is present. This is an efficient check to determine whether the neglect parser should be called at all.
		/// </summary>
		/// <param name="source">The source to check.</param>
		/// <param name="location">The location within the <paramref name="source"/> to check.</param>
		/// <returns><see langword="true"/> if the pattern is potentially at this <paramref name="location"/>; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		protected internal unsafe Boolean IsNeglectHeader([DisallowNull] Char* source, Int32 location) => IsNeglectHeader(new ReadOnlySpan<Char>(source, location), location);

		/// <summary>
		/// Checks if the header for the neglect parser is present. This is an efficient check to determine whether the neglect parser should be called at all.
		/// </summary>
		/// <param name="source">The source to check.</param>
		/// <param name="location">The location within the <paramref name="source"/> to check.</param>
		/// <returns><see langword="true"/> if the pattern is potentially at this <paramref name="location"/>; otherwise, <see langword="false"/>.</returns>
		protected internal abstract Boolean IsNeglectHeader(ReadOnlySpan<Char> source, Int32 location);

		/// <summary>
		/// Calls the neglect parser for this <see cref="Pattern"/> on the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <param name="exception">The exception that occurred during parsing, if any.</param>
		/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
		/// <remarks>
		/// This behaves identically to <see cref="Consume(ReadOnlyMemory{Char}, ref Int32, out Exception, IAdd{Capture})"/>, except that a match is defined as anything the same length as this <see cref="Pattern"/>, but not equal to it. If the source is the same length and content as this <see cref="Pattern"/>, it is considered a failed match. This is used to implement <see cref="Not()"/>.
		/// </remarks>
		protected internal abstract void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace);

		/// <summary>
		/// Calls the neglect parser for this <see cref="Pattern"/> on the <paramref name="source"/>.
		/// </summary>
		/// <param name="source">The source to parse.</param>
		/// <param name="length">The length of the <paramref name="source"/>.</param>
		/// <param name="location">The location within the <paramref name="source"/> to begin parsing, updated to the end of the match.</param>
		/// <param name="exception">The exception that occurred during parsing, if any.</param>
		/// <param name="trace">The object to trace the steps through the pattern graph in.</param>
		/// <remarks>
		/// This behaves identically to <see cref="Consume(ReadOnlyMemory{Char}, ref Int32, out Exception, IAdd{Capture})"/>, except that a match is defined as anything the same length as this <see cref="Pattern"/>, but not equal to it. If the source is the same length and content as this <see cref="Pattern"/>, it is considered a failed match. This is used to implement <see cref="Not()"/>.
		/// </remarks>
		[CLSCompliant(false)]
		protected internal abstract unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace);
	}
}
