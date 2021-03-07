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
			if (Check.Within(@byte, min, max)) {
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
			if (Check.Within(@char, min, max)) {
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
			if (Check.Within(@double, min, max)) {
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
			if (Check.Within(@short, min, max)) {
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
			if (Check.Within(@int, min, max)) {
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
			if (Check.Within(@long, min, max)) {
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
			IntPtr @nint = IntPtr();
			if (Check.Within(@nint, min, max)) {
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
			if (Check.Within(@sbyte, min, max)) {
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
			if (Check.Within(@single, min, max)) {
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
			if (Check.Within(@ushort, min, max)) {
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
			if (Check.Within(@uint, min, max)) {
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
			if (Check.Within(@ulong, min, max)) {
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
			UIntPtr @nuint = UIntPtr();
			if (Check.Within(@nuint, min, max)) {
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
