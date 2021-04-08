using System;
using Xunit;
using Langly.Traits;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures {
	public class Stack1_Tests : IAddContract {
		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract.Add_Array_Data), MemberType = typeof(IAddContract))]
		public void Add_Array<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) {
			Stack<TElement> stack = initial is not null ? new(initial) : null;
			IAddContract.Validate(expected, stack, values);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract.Add_Element_Data), MemberType = typeof(IAddContract))]
		public void Add_Element<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[] values) {
			Stack<TElement> stack = initial is not null ? new(initial) : null;
			IAddContract.Validate(expected, stack, values);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract.Add_Array_Data), MemberType = typeof(IAddContract))]
		public void Add_Memory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) {
			Stack<TElement> stack = initial is not null ? new(initial) : null;
			IAddContract.Validate(expected, stack, Batch.AsMemory(values));
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract.Add_Array_Data), MemberType = typeof(IAddContract))]
		public void Add_ReadOnlyMemory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) {
			Stack<TElement> stack = initial is not null ? new(initial) : null;
			IAddContract.Validate(expected, stack, Batch.AsReadOnlyMemory(values));
		}

		[Theory]
		[InlineData(new Int32[] { }, new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 }, new Int32[] { 5, 4, 3, 2, 1 })]

		public void Stack(Int32[] expected, Int32[] values) {
			Stack<Int32> stack = new Stack<Int32>().Write(values);
			Assert.Equal(expected.Length, stack.Count);
			Assert.Equal(expected, stack);
			stack.Read(expected.Length, out ReadOnlyMemory<Int32> vals);
			Assert.Equal(0, stack.Count);
			Assert.Equal(expected, vals.ToArray());
		}
	}
}
