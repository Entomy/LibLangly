using System;
using System.Collections.Generic;

namespace Langly {
	/// <summary>
	/// Provides a generator for the creation of random values and objects.
	/// </summary>
	public sealed class Generator {
		/// <summary>
		/// The backing random number generator.
		/// </summary>
		private readonly Random Random;

		/// <summary>
		/// Initializes a new <see cref="Generator"/>.
		/// </summary>
		public Generator() => Random = new Random();

		/// <summary>
		/// Generates a <see cref="System.Boolean"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.Boolean"/> value.</returns>
		public unsafe Boolean Boolean() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Boolean)];
			Random.NextBytes(buffer);
			return buffer[0] % 2 == 0; // even/odd checks ensure equal distribution, whereas casts would favor true.
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.Boolean"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.Boolean"/> values.</returns>
		public IEnumerable<Boolean> Boolean(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Boolean();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.Byte"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.Byte"/> value.</returns>
		public unsafe Byte Byte() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Byte)];
			Random.NextBytes(buffer);
			return buffer[0];
		}

		/// <summary>
		/// Generates a <see cref="System.Byte"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.Byte"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Byte Byte(Byte min, Byte max) {
		TryAgain:
			Byte @byte = Byte();
			if (min <= @byte && @byte <= max) {
				return @byte;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.Byte"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.Byte"/> values.</returns>
		public IEnumerable<Byte> Byte(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Byte();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.Char"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.Char"/> value.</returns>
		public unsafe Char Char() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Char)];
			Random.NextBytes(buffer);
			return BitConverter.ToChar(buffer);
		}

		/// <summary>
		/// Generates a <see cref="System.Char"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.Char"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Char Char(Char min, Char max) {
		TryAgain:
			Char @char = Char();
			if (min <= @char && @char <= max) {
				return @char;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.Char"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.Char"/> values.</returns>
		public IEnumerable<Char> Char(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Char();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.Decimal"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.Decimal"/> value.</returns>
		public unsafe Decimal Decimal() => new Decimal(Int32(), Int32(), Int32(), Boolean(), Byte(0, 28));

		/// <summary>
		/// Generates a <see cref="System.Decimal"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.Decimal"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Decimal Decimal(Decimal min, Decimal max) {
		TryAgain:
			Decimal @decimal = Decimal();
			if (min <= @decimal && @decimal <= max) {
				return @decimal;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.Decimal"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.Decimal"/> values.</returns>
		public IEnumerable<Decimal> Decimal(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Decimal();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.Double"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.Double"/> value.</returns>
		public unsafe Double Double() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Double)];
			Random.NextBytes(buffer);
			return BitConverter.ToDouble(buffer);
		}

		/// <summary>
		/// Generates a <see cref="System.Double"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.Double"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Double Double(Double min, Double max) {
		TryAgain:
			Double @double = Double();
			if (min <= @double && @double <= max) {
				return @double;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.Double"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.Double"/> values.</returns>
		public IEnumerable<Double> Double(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Double();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.Int16"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.Int16"/> value.</returns>
		public unsafe Int16 Int16() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int16)];
			Random.NextBytes(buffer);
			return BitConverter.ToInt16(buffer);
		}

		/// <summary>
		/// Generates a <see cref="System.Int16"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.Int16"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Int16 Int16(Int16 min, Int16 max) {
		TryAgain:
			Int16 @short = Int16();
			if (min <= @short && @short <= max) {
				return @short;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.Int16"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.Int16"/> values.</returns>
		public IEnumerable<Int16> Int16(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Int16();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.Int32"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.Int32"/> value.</returns>
		public unsafe Int32 Int32() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int32)];
			Random.NextBytes(buffer);
			return BitConverter.ToInt32(buffer);
		}

		/// <summary>
		/// Generates a <see cref="System.Int32"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.Int32"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Int32 Int32(Int32 min, Int32 max) {
		TryAgain:
			Int32 @int = Int32();
			if (min <= @int && @int <= max) {
				return @int;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.Int32"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.Int32"/> values.</returns>
		public IEnumerable<Int32> Int32(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Int32();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.Int64"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.Int64"/> value.</returns>
		public unsafe Int64 Int64() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Int64)];
			Random.NextBytes(buffer);
			return BitConverter.ToInt64(buffer);
		}

		/// <summary>
		/// Generates a <see cref="System.Int64"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.Int64"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Int64 Int64(Int64 min, Int64 max) {
		TryAgain:
			Int64 @long = Int64();
			if (min <= @long && @long <= max) {
				return @long;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.Int64"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.Int64"/> values.</returns>
		public IEnumerable<Int64> Int64(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Int64();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.IntPtr"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.IntPtr"/> value.</returns>
		public unsafe IntPtr IntPtr() {
			Span<Byte> buffer = stackalloc Byte[sizeof(IntPtr)];
			Random.NextBytes(buffer);
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
		/// Generates a <see cref="System.IntPtr"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.IntPtr"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public IntPtr IntPtr(IntPtr min, IntPtr max) {
		TryAgain:
			nint @nint = IntPtr();
			if (min <= @nint && @nint <= max) {
				return @nint;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.IntPtr"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.IntPtr"/> values.</returns>
		public IEnumerable<IntPtr> IntPtr(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return IntPtr();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.SByte"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.SByte"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe SByte SByte() {
			Span<Byte> buffer = stackalloc Byte[sizeof(SByte)];
			Random.NextBytes(buffer);
			return unchecked((SByte)buffer[0]);
		}

		/// <summary>
		/// Generates a <see cref="System.SByte"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.SByte"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public SByte SByte(SByte min, SByte max) {
		TryAgain:
			SByte @sbyte = SByte();
			if (min <= @sbyte && @sbyte <= max) {
				return @sbyte;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.SByte"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.SByte"/> values.</returns>
		[CLSCompliant(false)]
		public IEnumerable<SByte> SByte(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return SByte();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.Single"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.Single"/> value.</returns>
		public unsafe Single Single() {
			Span<Byte> buffer = stackalloc Byte[sizeof(Single)];
			Random.NextBytes(buffer);
			return BitConverter.ToSingle(buffer);
		}

		/// <summary>
		/// Generates a <see cref="System.Single"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.Single"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		public Single Single(Single min, Single max) {
		TryAgain:
			Single @single = Single();
			if (min <= @single && @single <= max) {
				return @single;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.Single"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.Single"/> values.</returns>
		public IEnumerable<Single> Single(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return Single();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.UInt16"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.UInt16"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe UInt16 UInt16() {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt16)];
			Random.NextBytes(buffer);
			return BitConverter.ToUInt16(buffer);
		}

		/// <summary>
		/// Generates a <see cref="System.UInt16"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.UInt16"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public UInt16 UInt16(UInt16 min, UInt16 max) {
		TryAgain:
			UInt16 @ushort = UInt16();
			if (min <= @ushort && @ushort <= max) {
				return @ushort;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.UInt16"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.UInt16"/> values.</returns>
		[CLSCompliant(false)]
		public IEnumerable<UInt16> UInt16(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return UInt16();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.UInt32"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.UInt32"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe UInt32 UInt32() {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt32)];
			Random.NextBytes(buffer);
			return BitConverter.ToUInt32(buffer);
		}

		/// <summary>
		/// Generates a <see cref="System.UInt32"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.UInt32"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public UInt32 UInt32(UInt32 min, UInt32 max) {
		TryAgain:
			UInt32 @uint = UInt32();
			if (min <= @uint && @uint <= max) {
				return @uint;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.UInt32"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.UInt32"/> values.</returns>
		[CLSCompliant(false)]
		public IEnumerable<UInt32> UInt32(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return UInt32();
			}
		}

		/// <summary>
		/// Generates a <see cref="System.UInt64"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.UInt64"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe UInt64 UInt64() {
			Span<Byte> buffer = stackalloc Byte[sizeof(UInt64)];
			Random.NextBytes(buffer);
			return BitConverter.ToUInt64(buffer);
		}

		/// <summary>
		/// Generates a <see cref="System.UInt64"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.UInt64"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public UInt64 UInt64(UInt64 min, UInt64 max) {
		TryAgain:
			UInt64 @ulong = UInt64();
			if (min <= @ulong && @ulong <= max) {
				return @ulong;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.UInt64"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.UInt64"/> values.</returns>
		[CLSCompliant(false)]
		public IEnumerable<UInt64> UInt64(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return UInt64();
			}
		}
		/// <summary>
		/// Generates a <see cref="System.UIntPtr"/> value.
		/// </summary>
		/// <returns>A random <see cref="System.UIntPtr"/> value.</returns>
		[CLSCompliant(false)]
		public unsafe UIntPtr UIntPtr() {
			Span<Byte> buffer = stackalloc Byte[sizeof(UIntPtr)];
			Random.NextBytes(buffer);
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
		/// Generates a <see cref="System.UIntPtr"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.
		/// </summary>
		/// <param name="min">The minimum possible value.</param>
		/// <param name="max">The maximum possible value.</param>
		/// <returns>A random <see cref="System.UIntPtr"/> value within the range of <paramref name="min"/>..<paramref name="max"/>.</returns>
		[CLSCompliant(false)]
		public UIntPtr UIntPtr(UIntPtr min, UIntPtr max) {
		TryAgain:
			nuint @nuint = UIntPtr();
			if (min <= @nuint && @nuint <= max) {
				return @nuint;
			} else {
				goto TryAgain;
			}
		}

		/// <summary>
		/// Generates a sequence of <see cref="System.UIntPtr"/> values.
		/// </summary>
		/// <param name="amount">The amount of values to generate.</param>
		/// <returns>A sequence of random <see cref="System.UIntPtr"/> values.</returns>
		[CLSCompliant(false)]
		public IEnumerable<UIntPtr> UIntPtr(nint amount) {
			for (nint i = 0; i < amount; i++) {
				yield return UIntPtr();
			}
		}
	}
}
