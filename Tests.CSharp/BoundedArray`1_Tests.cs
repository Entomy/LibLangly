using Collectathon.Arrays;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits.Contracts;
using Xunit;

namespace Langly {
	public class BoundedArray1_Tests : IAddContract<xUnit>, IClearContract<xUnit> {
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
	}
}
