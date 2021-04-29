using System;
using System.Collections.Generic;

namespace Numbersome {
	/// <summary>
	/// Represents a pseudo-random number generator, which is an algorithm that produces a sequence of numbers that meet certain statistical requirements for randomness.
	/// </summary>
	public sealed class Random : System.Random {
		/// <summary>
		/// Initializes a new instance of the <see cref="Random"/> class using a default seed value.
		/// </summary>
		public Random() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Random"/> class, using the specified <paramref name="seed"/> value.
		/// </summary>
		/// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. If a negative number is specified, the absolute value of the number is used.</param>
		public Random(Int32 seed) : base(seed) { }

		/// <summary>
		/// Generates a <see cref="Boolean"/> value.
		/// </summary>
		/// <returns>A random <see cref="Boolean"/> value.</returns>
		public unsafe Boolean NextBoolean() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Boolean)];
			NextBytes(buffer);
			return buffer[0] % 2 == 0; // even/odd checks ensure equal distribution, whereas casts would favor true.
		}

		/// <summary>
		/// Generates a sequence of <see cref="Boolean"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="Boolean"/> values.</returns>
		public IEnumerable<Boolean> NextBooleans(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextBoolean();
			}
		}

		/// <summary>
		/// Generates a <see cref="Byte"/> value.
		/// </summary>
		/// <returns>A random <see cref="Byte"/> value.</returns>
		public unsafe Byte NextByte() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Byte)];
			NextBytes(buffer);
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
		public IEnumerable<Byte> NextBytes(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextByte();
			}
		}

		/// <summary>
		/// Generates a <see cref="Char"/> value.
		/// </summary>
		/// <returns>A random <see cref="Char"/> value.</returns>
		public unsafe Char NextChar() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Char)];
			NextBytes(buffer);
			return BitConverter.ToChar(buffer);
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
		public IEnumerable<Char> NextChars(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextChar();
			}
		}

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
		public IEnumerable<Decimal> NextDecimals(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextDecimal();
			}
		}

		/// <summary>
		/// Generates a <see cref="Double"/> value.
		/// </summary>
		/// <returns>A random <see cref="Double"/> value.</returns>
		new public unsafe Double NextDouble() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Double)];
			NextBytes(buffer);
			return BitConverter.ToDouble(buffer);
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
		public IEnumerable<Double> NextDouble(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextDouble();
			}
		}

		/// <summary>
		/// Generates a <see cref="Int16"/> value.
		/// </summary>
		/// <returns>A random <see cref="Int16"/> value.</returns>
		public unsafe Int16 NextInt16() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int16)];
			NextBytes(buffer);
			return BitConverter.ToInt16(buffer);
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
		public IEnumerable<Int16> NextInt16s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextInt16();
			}
		}

		/// <summary>
		/// Generates a <see cref="Int32"/> value.
		/// </summary>
		/// <returns>A random <see cref="Int32"/> value.</returns>
		public unsafe Int32 NextInt32() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int32)];
			NextBytes(buffer);
			return BitConverter.ToInt32(buffer);
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
		public IEnumerable<Int32> NextInt32s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextInt32();
			}
		}

		/// <summary>
		/// Generates a <see cref="Int64"/> value.
		/// </summary>
		/// <returns>A random <see cref="Int64"/> value.</returns>
		public unsafe Int64 NextInt64() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int64)];
			NextBytes(buffer);
			return BitConverter.ToInt64(buffer);
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
		public IEnumerable<Int64> NextInt64s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextInt64();
			}
		}

		/// <summary>
		/// Generates a <see cref="IntPtr"/> value.
		/// </summary>
		/// <returns>A random <see cref="IntPtr"/> value.</returns>
		public unsafe IntPtr NextIntPtr() {
			Span<Byte> buffer = stackalloc Byte[sizeof(IntPtr)];
			NextBytes(buffer);
			switch (sizeof(IntPtr)) {
			case 4:
				return (IntPtr)BitConverter.ToInt32(buffer);
			case 8:
				return (IntPtr)BitConverter.ToInt64(buffer);
			default:
				throw new PlatformNotSupportedException("Langly only supports 32 and 64 bit platforms.");
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
		public IEnumerable<IntPtr> NextIntPtrs(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextIntPtr();
			}
		}

		/// <summary>
		/// Generates a <see cref="SByte"/> value.
		/// </summary>
		/// <returns>A random <see cref="SByte"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe SByte NextSByte() {
			Span<Byte> buffer = stackalloc Byte[sizeof(SByte)];
			NextBytes(buffer);
			return unchecked((SByte)buffer[0]);
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
		public IEnumerable<SByte> NextSBytes(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextSByte();
			}
		}

		/// <summary>
		/// Generates a <see cref="Single"/> value.
		/// </summary>
		/// <returns>A random <see cref="Single"/> value.</returns>
		public unsafe Single NextSingle() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Single)];
			NextBytes(buffer);
			return BitConverter.ToSingle(buffer);
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
		public IEnumerable<Single> NextSingles(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextSingle();
			}
		}

		/// <summary>
		/// Generates a <see cref="UInt16"/> value.
		/// </summary>
		/// <returns>A random <see cref="UInt16"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe UInt16 NextUInt16() {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt16)];
			NextBytes(buffer);
			return BitConverter.ToUInt16(buffer);
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
		public IEnumerable<UInt16> NextUInt16s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUInt16();
			}
		}

		/// <summary>
		/// Generates a <see cref="UInt32"/> value.
		/// </summary>
		/// <returns>A random <see cref="UInt32"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe UInt32 NextUInt32() {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt32)];
			NextBytes(buffer);
			return BitConverter.ToUInt32(buffer);
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
		public IEnumerable<UInt32> NextUInt32s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUInt32();
			}
		}

		/// <summary>
		/// Generates a <see cref="UInt64"/> value.
		/// </summary>
		/// <returns>A random <see cref="UInt64"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe UInt64 NextUInt64() {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt64)];
			NextBytes(buffer);
			return BitConverter.ToUInt64(buffer);
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
		public IEnumerable<UInt64> NextUInt64s(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUInt64();
			}
		}
		/// <summary>
		/// Generates a <see cref="UIntPtr"/> value.
		/// </summary>
		/// <returns>A random <see cref="UIntPtr"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe UIntPtr NextUIntPtr() {
			Span<Byte> buffer = stackalloc Byte[sizeof(UIntPtr)];
			NextBytes(buffer);
			switch (sizeof(UIntPtr)) {
			case 4:
				return (UIntPtr)BitConverter.ToUInt32(buffer);
			case 8:
				return (UIntPtr)BitConverter.ToUInt64(buffer);
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
		public IEnumerable<UIntPtr> NextUIntPtrs(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return NextUIntPtr();
			}
		}
	}
}
