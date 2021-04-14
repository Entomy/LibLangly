using Collectathon.Arrays;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits.Contracts;
using Xunit;

namespace Langly {
	public class BoundedArray1_Tests : IAddContract<xUnit>, IClearContract<xUnit>, IReplaceContract<xUnit>, IShiftContract<xUnit> {
		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract<xUnit>.Add_Array_Data), MemberType = typeof(IAddContract<xUnit>))]
		public void Add_Array<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IAddContract<xUnit>.Test_Array(expected, array, values);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract<xUnit>.Add_Element_Data), MemberType = typeof(IAddContract<xUnit>))]
		public void Add_Element<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[] values) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IAddContract<xUnit>.Test_Element(expected, array, values);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract<xUnit>.Add_Array_Data), MemberType = typeof(IAddContract<xUnit>))]
		public void Add_Memory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IAddContract<xUnit>.Test_Memory(expected, array, values);
		}

		/// <inheritdoc/>
		public void Add_Pointer<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) => throw new NotImplementedException();

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IAddContract<xUnit>.Add_Array_Data), MemberType = typeof(IAddContract<xUnit>))]
		public void Add_ReadOnlyMemory<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement[][] values) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
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
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IClearContract<xUnit>.Test<TElement, BoundedArray<TElement>>(array);
		}

		/// <inheritdoc/>
		public void Replace_Complex<TSearch, TReplace>([AllowNull] TSearch[] expected, [AllowNull] TSearch[] initial, [AllowNull] TSearch search, [AllowNull] TReplace replace) => throw new NotImplementedException();

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IReplaceContract<xUnit>.Replace_Data), MemberType = typeof(IReplaceContract<xUnit>))]
		public void Replace_Simple<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, [AllowNull] TElement search, [AllowNull] TElement replace) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IReplaceContract<xUnit>.Test(expected, array, search, replace);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftLeft_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftLeft<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Test_Left(expected, array);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftLeftBy_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftLeftBy<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Test_Left(expected, array, amount);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftLeftBy_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftLeftOp<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Validate(expected, array << amount);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftRight_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftRight<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Test_Right(expected, array);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftRightBy_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftRightBy<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Test_Right(expected, array, amount);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(IShiftContract<xUnit>.ShiftRightBy_Data), MemberType = typeof(IShiftContract<xUnit>))]
		public void ShiftRightOp<TElement>([AllowNull] TElement[] expected, [AllowNull] TElement[] initial, Int32 amount) {
			BoundedArray<TElement> array = initial is not null ? new BoundedArray<TElement>(initial) : null;
			IShiftContract<xUnit>.Validate(expected, array >> amount);
		}
	}
}
