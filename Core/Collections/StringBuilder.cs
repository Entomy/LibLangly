using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Collections {
	/// <summary>
	/// Represents a mutable string of characters. This is a specialization of <see cref="System.Text.StringBuilder"/>.
	/// </summary>
	/// <remarks>
	/// This is a small-size optimization that is only likely to be useful inside of quick functions. Instead of being a dynamically resizing array, it is a partially unrolled linked-list of variable chunk size. As it turns out, this performs better for most operations below certain append counts and under certain sizes. This is API compatable but not an intended general replacement for <see cref="System.Text.StringBuilder"/>.
	/// </remarks>
	public sealed class StringBuilder {
		//! This type must be API compatible with a type that works quite differently. As such, there are some "code smells" that have to exist. Where possible they've been marked [Obsolete]. If you're a purist, get over it. This needs to be easy to use, and a lower barrier to entry is a huge part of that.

		private Chunk? Head;
		private Int32 length;
		private Chunk? Tail;

		/// <summary>
		/// Initializes a new instance of the <see cref="StringBuilder"/> class.
		/// </summary>
		/// <remarks>
		/// The string value of this instance is set to <see cref="String.Empty"/>. There is no capacity concept for this replacement.
		/// </remarks>
		public StringBuilder() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="StringBuilder"/> class.
		/// </summary>
		[Obsolete("Remove the capcity, as this type is fully dynamically sized")]
		public StringBuilder(Int32 capacity) : this() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="StringBuilder"/> class using the specified string.
		/// </summary>
		/// <param name="value">The string used to initialized the value of the instance. If <paramref name="value"/> is <see langword="null"/>, the new <see cref="StringBuilder"/> will contain the empty string (that is, it contains <see cref="String.Empty"/>).</param>
		/// <remarks>
		/// If <paramref name="value"/> is <see langword="null"/>, the new <see cref="StringBuilder"/> will contain the empty string (that is, it contains <see cref="String.Empty"/>).
		/// </remarks>
		public StringBuilder(String value) : this() {
			if (!String.IsNullOrEmpty(value)) {
				_ = Append(value);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StringBuilder"/> class that starts with a specified capacity and can grow to a specified maximum.
		/// </summary>
		/// <param name="capacity">The suggested starting size of the <see cref="StringBuilder"/>.</param>
		/// <param name="maxCapacity">The maximum number of characters the current string can contain.</param>
		[Obsolete("Remove the capcity, as this type is fully dynamically sized")]
		public StringBuilder(Int32 capacity, Int32 maxCapacity) : this() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="StringBuilder"/> using the specified string and capacity.
		/// </summary>
		/// <param name="value">The string used to initialize the value of the instance. If <paramref name="value"/> is <see langword="null"/>, the new <see cref="StringBuilder"/> will contain the empty string (that is, it contains <see cref="String.Empty"/>).</param>
		/// <param name="capacity">The suggested starting size of the <see cref="StringBuilder"/>.</param>
		[Obsolete("Remove the capcity, as this type is fully dynamically sized")]
		public StringBuilder(String value, Int32 capacity) : this(value) { }

		/// <summary>
		/// Initializes a new isntance of the <see cref="StringBuilder"/> class from the specified substring and capacity.
		/// </summary>
		/// <param name="value">The string that contains the substring used to initialize the value of this instance. If <paramref name="value"/> is <see langword="null"/>, the new <see cref="StringBuilder"/> will contain the empty string (that is, it contains <see cref="String.Empty"/>).</param>
		/// <param name="startIndex">The position within <paramref name="value"/> where the substring begins.</param>
		/// <param name="length">The number of characters in the substring.</param>
		/// <param name="capacity">The suggested starting size of the <see cref="StringBuilder"/>.</param>
		[Obsolete("Use Substring() or a range slice on the string instead. Remove the capcity, as this type is fully dynamically sized.")]
		public StringBuilder(String value, Int32 startIndex, Int32 length, Int32 capacity) : this(value.Substring(startIndex, length)) { }

		/// <summary>
		/// Gets or sets the maximum number of characters that can be contained in the memory allocated by the current instance.
		/// </summary>
		/// <value>The maximum number of characters that can be contained in the memory allocated by the current instance. Its value is always <see cref="MaxCapacity"/>.</value>
		/// <remarks>The setter for this property does nothing and only exists for API Compatability.</remarks>
		public Int32 Capacity {
			get => MaxCapacity;
			[Obsolete("This type is fully dynamically sized, so setting a capacity is pointless")]
			set => _ = value;
		}


		/// <summary>
		/// Gets or sets the length of the current <see cref="StringBuilder"/> object.
		/// </summary>
		/// <value>The length of this instance.</value>
		/// <remarks>The setter for this property does nothing and only exists for API Compatability.</remarks>
		[SuppressMessage("Critical Bug", "S4275:Getters and setters should access the expected fields", Justification = "This has to remain API compatible with Microsoft's, despite implementation differences.")]
		public Int32 Length {
			get => length;
			[Obsolete("This type is fully dynamically sized, so setting a length is pointless")]
			set => _ = value;
		}

		/// <summary>
		/// Gets the maximum capacity of this instance.
		/// </summary>
		/// <value>The maximum number of characters this instance can hold.</value>
		public Int32 MaxCapacity => Int32.MaxValue;


		/// <summary>
		/// Gets or sets the character at the specified character position in this instance.
		/// </summary>
		/// <param name="index">The position of the character.</param>
		/// <returns>The Unicode character at position <paramref name="index"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is outside the bounds of this instance while setting a character.</exception>
		/// <exception cref="IndexOutOfRangeException"><paramref name="index"/> is outside the bounds of this instance while getting a character.</exception>
		[SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "This is literally an indexer, and the exception is thrown when the index is out of range. CWE-397 is about an exception being too general/vague, not about specific exceptions being thrown. Sonar doesn't understand this.")]
		[SuppressMessage("Major Code Smell", "S907:\"goto\" statement should not be used", Justification = "And what, throw the exception from two separate places? If a message is included, which is probably will be, that's now a code duplication issue, and there's a whole rabbit hole that is just much easier to address this way.")]
		public Char this[Int32 index] {
			get {
				if (index >= Length || index < 0) {
					goto Error;
				}
				Chunk? N = Head;
				Int32 i = 0;
				Int32 l = 0;
				while (N is Object) {
					i += N.Length;
					if (index >= i) {
						l += N.Length;
						N = N.Next;
					} else {
						return N[index - l];
					}
				}
			Error:
				throw new IndexOutOfRangeException();
			}
			set => throw new NotImplementedException();
		}

		/// <summary>
		/// Appends a copy of the specified char to this instance.
		/// </summary>
		/// <param name="value">The char to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Char value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of the Unicode characters in a specified array to this instance.
		/// </summary>
		/// <param name="value">The array of characters to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Char[] value) => Append(new String(value));

		/// <summary>
		/// Appens an array of Unicode characters starting at a specified address to this instance.
		/// </summary>
		/// <param name="value">A pointer to an array of characters.</param>
		/// <param name="valueCount">The number of characters in the array.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <para><paramref name="valueCount"/> is less than zero.</para>
		/// -or-
		/// <para>Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</para>
		/// </exception>
		/// <exception cref="NullReferenceException"><paramref name="value"/> is a null pointer.</exception>
		[CLSCompliant(false)]
		[SuppressMessage("Major Code Smell", "S112:General exceptions should never be thrown", Justification = "Microsoft threw NullReferenceException here. Idk why. This API has to remain API compatible, so the same exception gets thrown.")]
		public unsafe StringBuilder Append(Char* value, Int32 valueCount) {
			if (value is null) {
				throw new NullReferenceException(); //This should be NullArgumentException. I'm not sure why MS used this instead.
			} else if (valueCount < 0) {
				throw new ArgumentOutOfRangeException(nameof(valueCount));
			} else {
				return Append(new String(value, 0, valueCount));
			}
		}

		/// <summary>
		/// Appends a copy of the specified string to this instance.
		/// </summary>
		/// <param name="value">The string to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(String value) {
			if (Tail is null) {
				Tail = new Chunk(value, null);
				if (Head is null) {
					Head = Tail;
				}
			} else {
				Tail.Next = new Chunk(value, null);
				Tail = Tail.Next;
			}
			length += value.Length;
			return this;
		}

		/// <summary>
		/// Appends a copy of a specified substring to this instance.
		/// </summary>
		/// <param name="value">The string that contains the substring to append.</param>
		/// <param name="startIndex">The starting position of the substring within <paramref name="value"/>.</param>
		/// <param name="count">The number of characters in <paramref name="value"/> to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>, and <paramref name="startIndex"/> and <paramref name="count"/> are not zero.</exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <para><paramref name="count"/> less than zero.</para>
		/// -or-
		/// <para><paramref name="startIndex"/> less than zero.</para>
		/// -or-
		/// <para><paramref name="startIndex"/> + <paramref name="count"/> is greater than the length of <paramref name="value"/>.</para>
		/// </exception>
		[Obsolete("Use Substring() or a range slice on the string instead.")]
		public StringBuilder Append(String value, Int32 startIndex, Int32 count) {
			if (value is null) {
				throw new ArgumentNullException(nameof(value));
			} else {
				return Append(value.Substring(startIndex, count));
			}
		}

		/// <summary>
		/// Appends the string representation of a specified object to this instance.
		/// </summary>
		/// <param name="value">The object to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Object value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified 8-bit unsigned integer to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Byte value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified 16-bit unsigned integer to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		[CLSCompliant(false)]
		public StringBuilder Append(UInt16 value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified 32-bit unsigned integer to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		[CLSCompliant(false)]
		public StringBuilder Append(UInt32 value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified 64-bit unsigned integer to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		[CLSCompliant(false)]
		public StringBuilder Append(UInt64 value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified 8-bit signed integer to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		[CLSCompliant(false)]
		public StringBuilder Append(SByte value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified 16-bit signed integer to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Int16 value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified 32-bit signed integer to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Int32 value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified 64-bit signed integer to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Int64 value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified single-precision floating-point number to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Single value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified double-precision floating-point number to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Double value) => Append(value.ToString());

		/// <summary>
		/// Appends the string representation of a specified decimal number to this instance.
		/// </summary>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Decimal value) => Append(value.ToString());

		/// <summary>
		///Appends the string representation of a specified Boolean value to this instance.
		/// </summary>
		/// <param name="value">The Boolean value to append.</param>
		/// <returns>A reference to this instance after the append operation has completed.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="MaxCapacity"/>.</exception>
		public StringBuilder Append(Boolean value) => Append(value.ToString());

		/// <summary>
		/// Removes all characters from the current <see cref="StringBuilder"/> instance.
		/// </summary>
		/// <returns>An object whose <see cref="Length"/> is 0 (zero).</returns>
		public StringBuilder Clear() {
			Chunk? P = Head;
			Chunk? N = Head?.Next;
			while (P is Object) {
				P.Next = null;
				P = N;
				N = N?.Next;
				length--;
			}
			Head = null;
			return this;
		}

		[Obsolete("This type is fully dynamically sized, so setting a capacity is pointless")]
		public Int32 EnsureCapacity(Int32 capacity) => MaxCapacity;

		/// <summary>
		/// Converts the value of a <see cref="StringBuilder"/> to a <see cref="String"/>.
		/// </summary>
		/// <returns>A string whose value is the same as this instance.</returns>
		public override unsafe String ToString() {
			if (Length == 0) { return String.Empty; }
			String result = new String('\0', Length);
			Int32 r = 0;
			Chunk? N = Head;
			fixed (Char* res = result) {
				while (N is Object) {
					foreach (Char c in N.String) {
						res[r++] = c;
					}
					N = N.Next;
				}
			}
			return result;
		}

		/// <summary>
		/// Represents a linked chunk of text; part of the <see cref="StringBuilder"/>'s text.
		/// </summary>
		private class Chunk {
			public readonly String String;
			public Chunk? Next;

			public Chunk(String @string, Chunk? next) {
				String = @string;
				Next = next;
			}

			public Int32 Length => String.Length;

			public Char this[Int32 index] => String[index];
		}
	}
}
