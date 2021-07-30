﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.CompilerServices;

#if NETSTANDARD2_1
[assembly: TypeForwardedTo(typeof(System.Range))]
#else
namespace System {
	/// <summary>Represent a range has start and end indexes.</summary>
	/// <remarks>
	/// Range is used by the C# compiler to support the range syntax.
	/// <code>
	/// int[] someArray = new int[5] { 1, 2, 3, 4, 5 };
	/// int[] subArray1 = someArray[0..2]; // { 1, 2 }
	/// int[] subArray2 = someArray[1..^0]; // { 2, 3, 4, 5 }
	/// </code>
	/// </remarks>
	public readonly struct Range : IEquatable<Range> {
		/// <summary>Represent the inclusive start index of the Range.</summary>
		public Index Start { get; }

		/// <summary>Represent the exclusive end index of the Range.</summary>
		public Index End { get; }

		/// <summary>Construct a Range object using the start and end indexes.</summary>
		/// <param name="start">Represent the inclusive start index of the range.</param>
		/// <param name="end">Represent the exclusive end index of the range.</param>
		public Range(Index start, Index end) {
			Start = start;
			End = end;
		}

		/// <summary>Indicates whether the current Range object is equal to another object of the same type.</summary>
		/// <param name="value">An object to compare with this object</param>
		public override Boolean Equals(Object? value) => value is Range r && r.Start.Equals(Start) && r.End.Equals(End);

		/// <summary>Indicates whether the current Range object is equal to another Range object.</summary>
		/// <param name="other">An object to compare with this object</param>
		public Boolean Equals(Range other) => other.Start.Equals(Start) && other.End.Equals(End);

		/// <summary>Returns the hash code for this instance.</summary>
		public override Int32 GetHashCode() => (Start.GetHashCode() * 31) + End.GetHashCode();

		/// <summary>Converts the value of the current Range object to its equivalent string representation.</summary>
		public override String ToString() => Start + ".." + End;

		/// <summary>Create a Range object starting from start index to the end of the collection.</summary>
		public static Range StartAt(Index start) => new Range(start, Index.End);

		/// <summary>Create a Range object starting from first element in the collection to the end Index.</summary>
		public static Range EndAt(Index end) => new Range(Index.Start, end);

		/// <summary>Create a Range object starting from first element to the end.</summary>
		public static Range All => new Range(Index.Start, Index.End);

		/// <summary>Calculate the start offset and length of range object using a collection length.</summary>
		/// <param name="length">The length of the collection that the range will be used with. length has to be a positive value.</param>
		/// <remarks>
		/// For performance reason, we don't validate the input length parameter against negative values.
		/// It is expected Range will be used with collections which always have non negative length/count.
		/// We validate the range is inside the length scope though.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public (Int32 Offset, Int32 Length) GetOffsetAndLength(Int32 length) {
			Int32 start;
			Index startIndex = Start;
			start = startIndex.IsFromEnd ? length - startIndex.Value : startIndex.Value;
			Int32 end;
			Index endIndex = End;
			end = endIndex.IsFromEnd ? length - endIndex.Value : endIndex.Value;
			if ((UInt32)end > (UInt32)length || (UInt32)start > (UInt32)end) {
				throw new ArgumentOutOfRangeException(nameof(length));
			}
			return (start, end - start);
		}
	}
}
#endif
