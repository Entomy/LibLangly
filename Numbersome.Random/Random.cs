using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
#if NETCOREAPP3_0_OR_GREATER
using System.Text;
#endif
using System.Traits;
using Troschuetz.Random;
using Troschuetz.Random.Generators;

namespace Numbersome {
	/// <summary>
	/// Represents a pseudo-random number generator, which is an algorithm that produces a sequence of numbers that meet certain statistical requirements for randomness.
	/// </summary>
	/// <remarks>
	/// This is essentially a <see cref="System.Random"/> but with additional features. Not only is the standard type coverage considerably better, but generators are provided, and the whole thing is itself a read-only stream, and can be used anywhere <see cref="IRead{TElement}"/> can be used.
	/// </remarks>
	public sealed class Random :
		IRead<Byte>,
		IRead<SByte>,
		IRead<Int16>,
		IRead<UInt16>,
		IRead<Int32>,
		IRead<UInt32>,
		IRead<Int64>,
		IRead<UInt64>,
		IRead<Single>,
		IRead<Double>,
		IRead<Decimal>,
		IRead<Boolean>,
		IRead<Char>
#if NETCOREAPP3_0_OR_GREATER
		, IRead<Rune>
#endif
		{
		/// <summary>
		/// The <see cref="IGenerator"/> instance powering this <see cref="Random"/>.
		/// </summary>
		private readonly IGenerator Base;

		/// <summary>
		/// Initializes a new instance of the <see cref="Random"/> class using a default seed value.
		/// </summary>
		public Random() : this(new NR3Q1Generator()) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Random"/> class, using the specified <paramref name="seed"/> value.
		/// </summary>
		/// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. If a negative number is specified, the absolute value of the number is used.</param>
		public Random(Int32 seed) : this(new NR3Q1Generator(seed)) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Random"/> class, using the specified <paramref name="base"/>.
		/// </summary>
		/// <param name="base">The <see cref="IGenerator"/> providing the raw random generator capabilities.</param>
		[CLSCompliant(false)]
		public Random([DisallowNull] IGenerator @base) => Base = @base;

		#region Boolean
		/// <inheritdoc/>
		public void Read(out Boolean element) {
			Read(out Byte elmt);
			element = elmt > 0;
		}

		/// <summary>
		/// Generates a <see cref="Boolean"/> value.
		/// </summary>
		/// <returns>A random <see cref="Boolean"/> value.</returns>
		public Boolean NextBoolean() {
			Read(out Byte elmt);
			return elmt > 0;
		}

		/// <summary>
		/// Generates a sequence of <see cref="Boolean"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Boolean"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Boolean> NextBooleans(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextBoolean();
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Boolean"/> with random  values.
		/// </summary>
		/// <param name="buffer">The array to be filled with random <see cref="Boolean"/> values.</param>
		public void NextBooleans([AllowNull] Boolean[] buffer) => NextBooleans(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Boolean"/> with random values.
		/// </summary>
		/// <param name="buffer">The array to be filled with random <see cref="Boolean"/> values.</param>
		public void NextBooleans(Memory<Boolean> buffer) => NextBooleans(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Boolean"/> with random values.
		/// </summary>
		/// <param name="buffer">The array to be filled with random <see cref="Boolean"/> values.</param>
		public void NextBooleans(Span<Boolean> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region Byte
		/// <inheritdoc/>
		public unsafe void Read(out Byte element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Byte)];
			Base.NextBytes(buffer);
			element = buffer[0];
		}

		/// <summary>
		/// Generates a <see cref="Byte"/> value.
		/// </summary>
		/// <returns>A random <see cref="Byte"/> value.</returns>
		public Byte NextByte() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Byte)];
			Base.NextBytes(buffer);
			return buffer[0];
		}

		/// <summary>
		/// Generates a <see cref="Byte"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Byte"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Byte NextByte(Byte min, Byte max) {
		TryAgain:
			Byte @byte = NextByte();
			if (min <= @byte && @byte <= max) {
				return @byte;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Byte"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Byte"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Byte> NextBytes(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextByte();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Byte"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="Byte"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<Byte> NextBytes(nint amount, Byte min, Byte max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextByte(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Byte"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextBytes([AllowNull] Byte[] buffer) => NextBytes(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Byte"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextBytes(Memory<Byte> buffer) => NextBytes(buffer.Span);
		
		/// <summary>
		/// Fills the elements of a specified array of <see cref="Byte"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextBytes(Span<Byte> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region Char
		/// <inheritdoc/>
		public unsafe void Read(out Char element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Char)];
			Base.NextBytes(buffer);
			element = BitConverter.ToChar(buffer);
		}

		/// <summary>
		/// Generates a <see cref="Char"/> value.
		/// </summary>
		/// <returns>A random <see cref="Char"/> value.</returns>
		public Char NextChar() {
			Read(out Char result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="Char"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Char"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Char NextChar(Char min, Char max) {
		TryAgain:
			Char @char = NextChar();
			if (min <= @char && @char <= max) {
				return @char;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Char"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Char"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Char> NextChars(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextChar();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Char"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="Char"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<Char> NextChars(nint amount, Char min, Char max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextChar(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Char"/> with random values.
		/// </summary>
		/// <param name="buffer">The array to be filled with random values.</param>
		public void NextChars([AllowNull] Char[] buffer) => NextChars(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Char"/> with random values.
		/// </summary>
		/// <param name="buffer">The array to be filled with random values.</param>
		public void NextChars(Memory<Char> buffer) => NextChars(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Char"/> with random values.
		/// </summary>
		/// <param name="buffer">The array to be filled with random values.</param>
		public void NextChars(Span<Char> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				buffer[i] = NextChar();
			}
		}
		#endregion

		#region Decimal
		/// <inheritdoc/>
		public void Read(out Decimal element) => element = NextDecimal();

		/// <summary>
		/// Generates a <see cref="Decimal"/> value.
		/// </summary>
		/// <returns>A random <see cref="Decimal"/> value.</returns>
		public Decimal NextDecimal() => new Decimal(NextInt32(), NextInt32(), NextInt32(), NextBoolean(), NextByte(0, 28));

		/// <summary>
		/// Generates a <see cref="Decimal"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Decimal"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Decimal NextDecimal(Decimal min, Decimal max) {
		TryAgain:
			Decimal @decimal = NextDecimal();
			if (min <= @decimal && @decimal <= max) {
				return @decimal;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Decimal"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Decimal"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Decimal> NextDecimals(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextDecimal();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Decimal"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="Decimal"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<Decimal> NextDecimals(nint amount, Decimal min, Decimal max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextDecimal(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Decimal"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextDecimals([AllowNull] Decimal[] buffer) => NextDecimals(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Decimal"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextDecimals(Memory<Decimal> buffer) => NextDecimals(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Decimal"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextDecimals(Span<Decimal> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region Double
		/// <inheritdoc/>
		public unsafe void Read(out Double element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Double)];
			Base.NextBytes(buffer);
			element = BitConverter.ToDouble(buffer);
		}

		/// <summary>
		/// Generates a <see cref="Double"/> value.
		/// </summary>
		/// <returns>A random <see cref="Double"/> value.</returns>
		/// <remarks>
		/// This works differently from <see cref="System.Random"/>'s <see cref="System.Random.NextDouble()"/> in that it covers the entire range of <see cref="Double.MinValue"/>..<see cref="Double.MaxValue"/>. If you need the constrained range, use <see cref="NextDouble(Double, Double)"/>.
		/// </remarks>
		public Double NextDouble() {
			Read(out Double result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="Double"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Double"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Double NextDouble(Double min, Double max) {
		TryAgain:
			Double @double = NextDouble();
			if (min <= @double && @double <= max) {
				return @double;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Double"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Double"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Double> NextDouble(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextDouble();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Double"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="Double"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<Double> NextDoubles(nint amount, Double min, Double max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextDouble(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Double"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextDoubles([AllowNull] Double[] buffer) => NextDoubles(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Double"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextDoubles(Memory<Double> buffer) => NextDoubles(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Double"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextDoubles(Span<Double> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region Int16
		/// <inheritdoc/>
		public unsafe void Read(out Int16 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int16)];
			Base.NextBytes(buffer);
			element = BitConverter.ToInt16(buffer);
		}

		/// <summary>
		/// Generates a <see cref="Int16"/> value.
		/// </summary>
		/// <returns>A random <see cref="Int16"/> value.</returns>
		public Int16 NextInt16() {
			Read(out Int16 result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="Int16"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Int16"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Int16 NextInt16(Int16 min, Int16 max) {
		TryAgain:
			Int16 @short = NextInt16();
			if (min <= @short && @short <= max) {
				return @short;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Int16"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Int16"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Int16> NextInt16s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextInt16();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Int16"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="Int16"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<Int16> NextInt16s(nint amount, Int16 min, Int16 max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextInt16(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Int16"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextInt16s([AllowNull] Int16[] buffer) => NextInt16s(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Int16"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextInt16s(Memory<Int16> buffer) => NextInt16s(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Int16"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextInt16s(Span<Int16> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region Int32
		/// <inheritdoc/>
		public unsafe void Read(out Int32 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int32)];
			Base.NextBytes(buffer);
			element = BitConverter.ToInt32(buffer);
		}

		/// <summary>
		/// Generates a <see cref="Int32"/> value.
		/// </summary>
		/// <returns>A random <see cref="Int32"/> value.</returns>
		public Int32 NextInt32() {
			Read(out Int32 result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="Int32"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Int32"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Int32 NextInt32(Int32 min, Int32 max) {
		TryAgain:
			Int32 @int = NextInt32();
			if (min <= @int && @int <= max) {
				return @int;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Int32"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Int32"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Int32> NextInt32s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextInt32();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Int32"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="Int32"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<Int32> NextInt32s(nint amount, Int32 min, Int32 max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextInt32(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Int32"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextInt32s([AllowNull] Int32[] buffer) => NextInt32s(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Int32"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextInt32s(Memory<Int32> buffer) => NextInt32s(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Int32"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextInt32s(Span<Int32> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region Int64
		/// <inheritdoc/>
		public unsafe void Read(out Int64 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int64)];
			Base.NextBytes(buffer);
			element = BitConverter.ToInt64(buffer);
		}

		/// <summary>
		/// Generates a <see cref="Int64"/> value.
		/// </summary>
		/// <returns>A random <see cref="Int64"/> value.</returns>
		public Int64 NextInt64() {
			Read(out Int64 result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="Int64"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Int64"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Int64 NextInt64(Int64 min, Int64 max) {
		TryAgain:
			Int64 @long = NextInt64();
			if (min <= @long && @long <= max) {
				return @long;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Int64"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Int64"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Int64> NextInt64s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextInt64();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Int64"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="Int64"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<Int64> NextInt64s(nint amount, Int64 min, Int64 max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextInt64(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Int64"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextInt64s([AllowNull] Int64[] buffer) => NextInt64s(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Int64"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextInt64s(Memory<Int64> buffer) => NextInt64s(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Int64"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextInt64s(Span<Int64> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region IntPtr
		/// <inheritdoc/>
		public unsafe void Read(out IntPtr element) => element = NextIntPtr();

		/// <summary>
		/// Generates a <see cref="IntPtr"/> value.
		/// </summary>
		/// <returns>A random <see cref="IntPtr"/> value.</returns>
		public unsafe IntPtr NextIntPtr() {
			switch (sizeof(IntPtr)) {
			case 4:
				Read(out Int32 int32);
				return (IntPtr)int32;
			case 8:
				Read(out Int64 int64);
				return (IntPtr)int64;
			default:
				throw new PlatformNotSupportedException("Numbersome only supports 32 and 64 bit platforms.");
			}
		}

		/// <summary>
		/// Generates a <see cref="IntPtr"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="IntPtr"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public IntPtr NextIntPtr(IntPtr min, IntPtr max) {
		TryAgain:
			nint @nint = NextIntPtr();
			if (min <= @nint && @nint <= max) {
				return @nint;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="IntPtr"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="IntPtr"/> values.</returns>
		[return: NotNull]
		public IEnumerable<IntPtr> NextIntPtrs(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextIntPtr();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="IntPtr"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="IntPtr"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<IntPtr> NextIntPtrs(nint amount, IntPtr min, IntPtr max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextIntPtr(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="IntPtr"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextIntPtrs([AllowNull] IntPtr[] buffer) => NextIntPtrs(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="IntPtr"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextIntPtrs(Memory<IntPtr> buffer) => NextIntPtrs(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="IntPtr"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextIntPtrs(Span<IntPtr> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				buffer[i] = NextIntPtr();
			}
		}
		#endregion

		#region Rune
#if NETCOREAPP3_0_OR_GREATER
		/// <inheritdoc/>
		public void Read(out Rune element) => element = NextRune();

		/// <summary>
		/// Generates a <see cref="Rune"/> value.
		/// </summary>
		/// <returns>A random <see cref="Rune"/> value.</returns>
		public unsafe Rune NextRune() {
		TryAgain:
			Read(out Int32 scalar);
			if (scalar < 0) {
				scalar = Math.Abs(scalar);
			}
			while (scalar > 0x10FFFF) {
				scalar = scalar >> 2;
			}
			if (0xD800 <= scalar && scalar < 0xE000) {
				scalar -= 0xD800;
			}
			return new Rune(scalar);
		}

		/// <summary>
		/// Generates a <see cref="Rune"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Rune"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Rune NextRune(Rune min, Rune max) {
		TryAgain:
			Rune rune = NextRune();
			if (min <= rune && rune <= max) {
				return rune;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Rune"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Rune"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Rune> NextRunes(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextRune();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Rune"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="Rune"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<Rune> NextRunes(nint amount, Rune min, Rune max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextRune(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Rune"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextRunes([AllowNull] Rune[] buffer) => NextRunes(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Rune"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextRunes(Memory<Rune> buffer) => NextRunes(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Rune"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextRunes(Span<Rune> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				buffer[i] = NextRune();
			}
		}
#endif
		#endregion

		#region SByte
		/// <inheritdoc/>
		public void Read(out SByte element) {
			Read(out Byte elmt);
			element = (SByte)elmt;
		}

		/// <summary>
		/// Generates a <see cref="SByte"/> value.
		/// </summary>
		/// <returns>A random <see cref="SByte"/> value.</returns>
		[CLSCompliant(false)]
		public SByte NextSByte() {
			Read(out SByte result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="SByte"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="SByte"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public SByte NextSByte(SByte min, SByte max) {
		TryAgain:
			SByte @sbyte = NextSByte();
			if (min <= @sbyte && @sbyte <= max) {
				return @sbyte;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="SByte"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="SByte"/> values.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<SByte> NextSBytes(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextSByte();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="SByte"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="SByte"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<SByte> NextSBytes(nint amount, SByte min, SByte max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextSByte(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="SByte"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextSBytes([AllowNull] SByte[] buffer) => NextSBytes(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="SByte"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextSBytes(Memory<SByte> buffer) => NextSBytes(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="SByte"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextSBytes(Span<SByte> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region Single
		/// <inheritdoc/>
		public unsafe void Read(out Single element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(Single)];
			Base.NextBytes(buffer);
			element = BitConverter.ToSingle(buffer);
		}

		/// <summary>
		/// Generates a <see cref="Single"/> value.
		/// </summary>
		/// <returns>A random <see cref="Single"/> value.</returns>
		public Single NextSingle() {
			Read(out Single result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="Single"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="Single"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Single NextSingle(Single min, Single max) {
		TryAgain:
			Single @single = NextSingle();
			if (min <= @single && @single <= max) {
				return @single;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Single"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Single"/> values.</returns>
		[return: NotNull]
		public IEnumerable<Single> NextSingles(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextSingle();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="Single"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="Single"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[return: NotNull]
		public IEnumerable<Single> NextSingles(nint amount, Single min, Single max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextSingle(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Single"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextSingles([AllowNull] Single[] buffer) => NextSingles(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Single"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextSingles(Memory<Single> buffer) => NextSingles(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="Single"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public void NextSingles(Span<Single> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region UInt16
		/// <inheritdoc/>
		public unsafe void Read(out UInt16 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt16)];
			Base.NextBytes(buffer);
			element = BitConverter.ToUInt16(buffer);
		}


		/// <summary>
		/// Generates a <see cref="UInt16"/> value.
		/// </summary>
		/// <returns>A random <see cref="UInt16"/> value.</returns>
		[CLSCompliant(false)]
		public UInt16 NextUInt16() {
			Read(out UInt16 result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="UInt16"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="UInt16"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public UInt16 NextUInt16(UInt16 min, UInt16 max) {
		TryAgain:
			UInt16 @ushort = NextUInt16();
			if (min <= @ushort && @ushort <= max) {
				return @ushort;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="UInt16"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="UInt16"/> values.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<UInt16> NextUInt16s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUInt16();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="UInt16"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="UInt16"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<UInt16> NextUInt16s(nint amount, UInt16 min, UInt16 max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUInt16(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UInt16"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUInt16s([AllowNull] UInt16[] buffer) => NextUInt16s(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UInt16"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUInt16s(Memory<UInt16> buffer) => NextUInt16s(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UInt16"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUInt16s(Span<UInt16> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region UInt32
		/// <inheritdoc/>
		public unsafe void Read(out UInt32 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt32)];
			Base.NextBytes(buffer);
			element = BitConverter.ToUInt32(buffer);
		}

		/// <summary>
		/// Generates a <see cref="UInt32"/> value.
		/// </summary>
		/// <returns>A random <see cref="UInt32"/> value.</returns>
		[CLSCompliant(false)]
		public UInt32 NextUInt32() {
			Read(out UInt32 result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="UInt32"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="UInt32"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public UInt32 NextUInt32(UInt32 min, UInt32 max) {
		TryAgain:
			UInt32 @uint = NextUInt32();
			if (min <= @uint && @uint <= max) {
				return @uint;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="UInt32"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="UInt32"/> values.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<UInt32> NextUInt32s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUInt32();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="UInt32"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="UInt32"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<UInt32> NextUInt32s(nint amount, UInt32 min, UInt32 max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUInt32(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UInt32"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUInt32s([AllowNull] UInt32[] buffer) => NextUInt32s(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UInt32"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUInt32s(Memory<UInt32> buffer) => NextUInt32s(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UInt32"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUInt32s(Span<UInt32> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region UInt64
		/// <inheritdoc/>
		public unsafe void Read(out UInt64 element) {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt64)];
			Base.NextBytes(buffer);
			element = BitConverter.ToUInt64(buffer);
		}

		/// <summary>
		/// Generates a <see cref="UInt64"/> value.
		/// </summary>
		/// <returns>A random <see cref="UInt64"/> value.</returns>
		[CLSCompliant(false)]
		public UInt64 NextUInt64() {
			Read(out UInt64 result);
			return result;
		}

		/// <summary>
		/// Generates a <see cref="UInt64"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="UInt64"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public UInt64 NextUInt64(UInt64 min, UInt64 max) {
		TryAgain:
			UInt64 @ulong = NextUInt64();
			if (min <= @ulong && @ulong <= max) {
				return @ulong;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="UInt64"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="UInt64"/> values.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<UInt64> NextUInt64s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUInt64();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="UInt64"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="UInt64"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<UInt64> NextUInt64s(nint amount, UInt64 min, UInt64 max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUInt64(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UInt64"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUInt64s([AllowNull] UInt64[] buffer) => NextUInt64s(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UInt64"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUInt64s(Memory<UInt64> buffer) => NextUInt64s(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UInt64"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUInt64s(Span<UInt64> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				Read(out buffer[i]);
			}
		}
		#endregion

		#region UIntPtr
		/// <inheritdoc/>
		public void Read(out UIntPtr element) => element = NextUIntPtr();

		/// <summary>
		/// Generates a <see cref="UIntPtr"/> value.
		/// </summary>
		/// <returns>A random <see cref="UIntPtr"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe UIntPtr NextUIntPtr() {
			switch (sizeof(UIntPtr)) {
			case 4:
				Read(out UInt32 uint32);
				return (UIntPtr)uint32;
			case 8:
				Read(out UInt64 uint64);
				return (UIntPtr)uint64;
			default:
				throw new PlatformNotSupportedException("Langly only supports 32 and 64 bit platforms.");
			}
		}

		/// <summary>
		/// Generates a <see cref="UIntPtr"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="UIntPtr"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public UIntPtr NextUIntPtr(UIntPtr min, UIntPtr max) {
		TryAgain:
			nuint @nuint = NextUIntPtr();
			if (min <= @nuint && @nuint <= max) {
				return @nuint;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="UIntPtr"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="UIntPtr"/> values.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<UIntPtr> NextUIntPtrs(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUIntPtr();
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="UIntPtr"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A sequence of random <see cref="UIntPtr"/> values within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		[return: NotNull]
		public IEnumerable<UIntPtr> NextUIntPtrs(nint amount, UIntPtr min, UIntPtr max) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUIntPtr(min, max);
			}
		}

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UIntPtr"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUIntPtrs([AllowNull] UIntPtr[] buffer) => NextUIntPtrs(buffer.AsSpan());

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UIntPtr"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUIntPtrs(Memory<UIntPtr> buffer) => NextUIntPtrs(buffer.Span);

		/// <summary>
		/// Fills the elements of a specified array of <see cref="UIntPtr"/> with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		[CLSCompliant(false)]
		public void NextUIntPtrs(Span<UIntPtr> buffer) {
			for (Int32 i = 0; i < buffer.Length; i++) {
				buffer[i] = NextUIntPtr();
			}
		}
		#endregion
	}
}
