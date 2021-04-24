using Collectathon.Arrays;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits.Contracts;
using Xunit;

namespace Langly {
	public class DynamicArray1_Tests : IAddContract<xUnit>, IClearContract<xUnit>, ISequenceContract<xUnit>, IShiftContract<xUnit>, ISliceContract<xUnit> {
		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract<xUnit>.Add_Array_Data), MemberType = typeof(IAddContract<xUnit>))]
		public void Add_Array<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IAddContract<xUnit>.Test_Array(expected, array, values);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract<xUnit>.Add_Element_Data), MemberType = typeof(IAddContract<xUnit>))]
		public void Add_Element<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[] values) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IAddContract<xUnit>.Test_Element(expected, array, values);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract<xUnit>.Add_Array_Data), MemberType = typeof(IAddContract<xUnit>))]
		public void Add_Memory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IAddContract<xUnit>.Test_Memory(expected, array, values);
		}

		/// <inheritdoc/>
		public void Add_Pointer<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) => throw new NotImplementedException();

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract<xUnit>.Add_Array_Data), MemberType = typeof(IAddContract<xUnit>))]
		public void Add_ReadOnlyMemory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IAddContract<xUnit>.Test_ReadOnlyMemory(expected, array, values);
		}

		/// <inheritdoc/>
		public void Add_ReadOnlySpan<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) => throw new NotImplementedException();

		/// <inheritdoc/>
		public void Add_Span<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) => throw new NotImplementedException();

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IClearContract<xUnit>.Clear_Data), MemberType = typeof(IClearContract<xUnit>))]
		public void Clear<TElement>([AllowNull] TElement[] initial) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IClearContract<xUnit>.Test<TElement, DynamicArray<TElement>>(array);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ISequenceContract<xUnit>.Enumerator_Data), MemberType = typeof(ISequenceContract<xUnit>))]
		public void Enumerator<TElement>([DisallowNull] TElement[] values) {
			DynamicArray<TElement> array = values is not null ? new DynamicArray<TElement>(values) : null;
			ISequenceContract<xUnit>.Test_Enumerator(values, array);
		}

		/// <inheritdoc/>
		[Theory]
		[InlineData(new Int32[] { })]
		[InlineData(new Int32[] { 1, 2, 3, 4, 5 })]

		public void Equals([AllowNull] Int32[] values) {
			DynamicArray<Int32> val = values is not null ? new DynamicArray<Int32>(values) : null;
			Assert.Equal(values, val);
			Assert.True(val.Equals(values));
			DynamicArray<Int32> exp = values is not null ? new DynamicArray<Int32>(values) : null;
			Assert.Equal(exp, val);
			Assert.Equal<Int32>(exp, val);
			Assert.True(val.Equals(exp));
			BoundedArray<Int32> dval = values is not null ? new BoundedArray<Int32>(values) : null;
			BoundedArray<Int32> dexp = values is not null ? new BoundedArray<Int32>(values) : null;
			Assert.True(val.Equals(dval));
			Assert.True(dval.Equals(val));
		}

		/// <inheritdoc/>
		[Theory]
		[InlineData(0, null)]
		[InlineData(0, new Int32[] { })]
		[InlineData(15, new Int32[] { 1, 2, 3, 4, 5 })]
		public void Fold(Int32 expected, [AllowNull] Int32[] values) {
			DynamicArray<Int32> array = values is not null ? new DynamicArray<Int32>(values) : null;
			ISequenceContract<xUnit>.Test_Fold(expected, array, (a, b) => a + b, 0);
		}

		/// <inheritdoc/>
		public void Replace_Complex<TSearch, TReplace>([AllowNull] TSearch[] expected, [AllowNull] TSearch[] initial, [AllowNull] TSearch search, [AllowNull] TReplace replace) => throw new NotImplementedException();

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IReplaceContract<xUnit>.Replace_Data), MemberType = typeof(IReplaceContract<xUnit>))]
		public void Replace_Simple<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement search, [AllowNull] TElement replace) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IReplaceContract<xUnit>.Test(expected, array, search, replace);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftLeft_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftLeft<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Test_Left(expected, array);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftLeftBy_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftLeftBy<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Test_Left(expected, array, amount);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftLeftBy_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftLeftOp<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Validate(expected, array << amount);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftRight_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftRight<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Test_Right(expected, array);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftRightBy_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftRightBy<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Test_Right(expected, array, amount);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftRightBy_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftRightOp<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Validate(expected, array >> amount);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ISliceContract<xUnit>.Slice_Data), MemberType = typeof(ISliceContract<xUnit>))]
		public void Slice<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			ISliceContract<xUnit>.Test(expected, array);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ISliceContract<xUnit>.Slice_Range_Data), MemberType = typeof(ISliceContract<xUnit>))]
		public void Slice_Range<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 start, Int32 end) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			ISliceContract<xUnit>.Validate(expected, array[start..end]);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ISliceContract<xUnit>.Slice_Start_Data), MemberType = typeof(ISliceContract<xUnit>))]
		public void Slice_Start<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 start) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			ISliceContract<xUnit>.Test(expected, array, start);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ISliceContract<xUnit>.Slice_Start_Length_Data), MemberType = typeof(ISliceContract<xUnit>))]
		public void Slice_Start_Length<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 start, Int32 length) {
			DynamicArray<TElement> array = initial is not null ? new DynamicArray<TElement>(initial) : null;
			ISliceContract<xUnit>.Test(expected, array, start, length);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ISequenceContract<xUnit>.ToArray_Data), MemberType = typeof(ISequenceContract<xUnit>))]
		public void ToArray<TElement>([AllowNull] TElement[] values) {
			DynamicArray<TElement> array = values is not null ? new DynamicArray<TElement>(values) : null;
			ISequenceContract<xUnit>.Test_ToArray(values, array);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(ISequenceContract<xUnit>.ToString_Data), MemberType = typeof(ISequenceContract<xUnit>))]
		public void ToString<TElement>([DisallowNull] String expected, [DisallowNull] TElement[] values, Int32 amount) {
			DynamicArray<TElement> array = new DynamicArray<TElement>(values);
			ISequenceContract<xUnit>.Test_ToString(expected, array, amount);
		}
	}
}
