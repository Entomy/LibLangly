﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.CompilerServices;

#if NETSTANDARD2_1
[assembly: TypeForwardedTo(typeof(System.Index))]
#else
namespace System {
	/// <summary>Represent a type can be used to index a collection either from the start or the end.</summary>
	/// <remarks>
	/// Index is used by the C# compiler to support the new index syntax
	/// <code>
	/// int[] someArray = new int[5] { 1, 2, 3, 4, 5 } ;
	/// int lastElement = someArray[^1]; // lastElement = 5
	/// </code>
	/// </remarks>
	public readonly struct Index : IEquatable<Index> {
		private readonly Int32 _value;

		/// <summary>Construct an Index using a value and indicating if the index is from the start or from the end.</summary>
		/// <param name="value">The index value. it has to be zero or positive number.</param>
		/// <param name="fromEnd">Indicating if the index is from the start or from the end.</param>
		/// <remarks>
		/// If the Index constructed from the end, index value 1 means pointing at the last element and index value 0 means pointing at beyond last element.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Index(Int32 value, Boolean fromEnd = false) {
			if (value < 0) {
				throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
			}
			_value = fromEnd ? ~value : value;
		}

		// The following private constructors mainly created for perf reason to avoid the checks
		private Index(Int32 value) {
			_value = value;
		}

		/// <summary>Create an Index pointing at first element.</summary>
		public static Index Start => new Index(0);

		/// <summary>Create an Index pointing at beyond last element.</summary>
		public static Index End => new Index(~0);

		/// <summary>Create an Index from the start at the position indicated by the value.</summary>
		/// <param name="value">The index value from the start.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Index FromStart(Int32 value) {
			if (value < 0) {
				throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
			}

			return new Index(value);
		}

		/// <summary>Create an Index from the end at the position indicated by the value.</summary>
		/// <param name="value">The index value from the end.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Index FromEnd(Int32 value) {
			if (value < 0) {
				throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
			}

			return new Index(~value);
		}

		/// <summary>Returns the index value.</summary>
		public Int32 Value => _value < 0 ? ~_value : _value;

		/// <summary>Indicates whether the index is from the start or the end.</summary>
		public Boolean IsFromEnd => _value < 0;

		/// <summary>Calculate the offset from the start using the giving collection length.</summary>
		/// <param name="length">The length of the collection that the Index will be used with. length has to be a positive value</param>
		/// <remarks>
		/// For performance reason, we don't validate the input length parameter and the returned offset value against negative values.
		/// we don't validate either the returned offset is greater than the input length.
		/// It is expected Index will be used with collections which always have non negative length/count. If the returned offset is negative and
		/// then used to index a collection will get out of range exception which will be same affect as the validation.
		/// </remarks>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Int32 GetOffset(Int32 length) {
			Int32 offset = _value;
			if (IsFromEnd) {
				// offset = length - (~value)
				// offset = length + (~(~value) + 1)
				// offset = length + value + 1

				offset += length + 1;
			}
			return offset;
		}

		/// <summary>Indicates whether the current Index object is equal to another object of the same type.</summary>
		/// <param name="value">An object to compare with this object</param>
		public override Boolean Equals(Object? value) => value is Index && _value == ((Index)value)._value;

		/// <summary>Indicates whether the current Index object is equal to another Index object.</summary>
		/// <param name="other">An object to compare with this object</param>
		public Boolean Equals(Index other) => _value == other._value;

		/// <summary>Returns the hash code for this instance.</summary>
		public override Int32 GetHashCode() => _value;

		/// <summary>Converts integer number to an Index.</summary>
		public static implicit operator Index(Int32 value) => FromStart(value);

		/// <summary>Converts the value of the current Index object to its equivalent string representation.</summary>
		public override String ToString() => IsFromEnd ? "^" + ((UInt32)Value).ToString() : ((UInt32)Value).ToString();
	}
}
#endif