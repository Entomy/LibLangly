using System;
using System.Diagnostics.CodeAnalysis;
using Langly.DataStructures.Filters;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents any possible data structure.
	/// </summary>
	/// <remarks>
	/// This is extremely anemic in order to avoid the false assumption and leaky abstraction problems most collections libraries get themselves into. This class only sets up things that are truely common for all data structures.
	/// </remarks>
	public abstract class DataStructure<TElement, TSelf, TEnumerator> : ICloneable<TSelf>, IEnumerable<TElement, TEnumerator>, IEquatable<DataStructure<TElement, TSelf, TEnumerator>>, IEquatable<TElement[]>, IEquatable<System.Collections.Generic.IEnumerable<TElement>> where TSelf : DataStructure<TElement, TSelf, TEnumerator> where TEnumerator : IEnumerator<TElement> {
		/// <summary>
		/// The filter used.
		/// </summary>
		/// <remarks>
		/// This won't ever be <see langword="null"/>, and instead a special dummy filter gets used to prevent needing null checks in addition to feature checks.
		/// </remarks>
		protected readonly Filter<TElement> Filterer;

		/// <summary>
		/// Initializes a new <see cref="DataStructure{TElement, TSelf, TEnumerator}"/>.
		/// </summary>
		/// <param name="filter">The type of filter to use.</param>
		protected DataStructure(Filter filter) => Filterer = filter switch
		{
			Filter.Unique => new Unique<TElement, TEnumerator>(this),
			_ => NullFilter<TElement>.Instance,
		};

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <param name="filterer">The <see cref="Filter{TElement}"/> responsible for this data structure.</param>
		protected DataStructure(Filter<TElement> filterer) => Filterer = filterer;

		public static Boolean operator !=(DataStructure<TElement, TSelf, TEnumerator> left, DataStructure<TElement, TSelf, TEnumerator> right) => !(left == right);

		public static Boolean operator !=(DataStructure<TElement, TSelf, TEnumerator> left, TElement[] right) => !(left == right);

		public static Boolean operator !=(TElement[] left, DataStructure<TElement, TSelf, TEnumerator> right) => !(left == right);

		public static Boolean operator !=(DataStructure<TElement, TSelf, TEnumerator> left, System.Collections.Generic.IEnumerable<TElement> right) => !(left == right);

		public static Boolean operator !=(System.Collections.Generic.IEnumerable<TElement> left, DataStructure<TElement, TSelf, TEnumerator> right) => !(left == right);

		public static Boolean operator ==(DataStructure<TElement, TSelf, TEnumerator> left, DataStructure<TElement, TSelf, TEnumerator> right) => (left is null && right is null) || (left?.Equals(right) ?? false);

		public static Boolean operator ==(DataStructure<TElement, TSelf, TEnumerator> left, TElement[] right) => (left is null && right is null) || (left?.Equals(right) ?? false);

		public static Boolean operator ==(TElement[] left, DataStructure<TElement, TSelf, TEnumerator> right) => (left is null && right is null) || (right?.Equals(left) ?? false);

		public static Boolean operator ==(DataStructure<TElement, TSelf, TEnumerator> left, System.Collections.Generic.IEnumerable<TElement> right) => (left is null && right is null) || (left?.Equals(right) ?? false);

		public static Boolean operator ==(System.Collections.Generic.IEnumerable<TElement> left, DataStructure<TElement, TSelf, TEnumerator> right) => (left is null && right is null) || (right?.Equals(left) ?? false);

		/// <inheritdoc/>
		Object ICloneable.Clone() => Clone();

		/// <inheritdoc/>
		TSelf ICloneable<TSelf>.Clone() => Clone();

		/// <inheritdoc/>
		public sealed override Boolean Equals(Object obj) {
			switch (obj) {
			case DataStructure<TElement, TSelf, TEnumerator> dataStructure:
				return Equals(dataStructure);
			case TElement[] array:
				return Equals(array);
			case System.Collections.Generic.IEnumerable<TElement> enumerable:
				return Equals(enumerable);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public abstract Boolean Equals(DataStructure<TElement, TSelf, TEnumerator> other);

		/// <inheritdoc/>
		public virtual Boolean Equals(TElement[] other) {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Get enumerator for this list
			TEnumerator ths = GetEnumerator();
			// And index for the array
			nint o = 0;
			// Now iterate through both
			while (ths.MoveNext() && o < other.Length) {
				// If the current elements are not equal to each other
				if (!Equals(ths.Current, other[o++])) {
					// They aren't equal
					return false;
				}
			}
			// If the enumerator can still advance or the array index isn't at its length
			if (ths.MoveNext() || o < other.Length) {
				// They aren't the same length and therefore aren't equal.
				return false;
			}
			// We've validated that the enumerable and array are the same length and contain the same elements in the same order, so are therefore equal
			return true;
		}

		/// <inheritdoc/>
		public Boolean Equals(System.Collections.Generic.IEnumerable<TElement> other) {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Get enumerators for each
			TEnumerator ths = GetEnumerator();
			using System.Collections.Generic.IEnumerator<TElement> oth = other.GetEnumerator();
			// Now iterate through both
			while (ths.MoveNext() && oth.MoveNext()) {
				// If the current elements are not equal to each other
				if (!Equals(ths.Current, oth.Current)) {
					// They aren't equal
					return false;
				}
			}
			// If any enumerator can still advance
			if (ths.MoveNext() || oth.MoveNext()) {
				// They aren't the same length and therefore aren't equal
				return false;
			}
			// We've validated that the enumerables are the same length and contain the same elements in the same order, so are therefore equal
			return true;
		}

		/// <inheritdoc/>
		public Boolean Equals<TOtherEnumerator>(IEnumerable<TElement, TOtherEnumerator> other) where TOtherEnumerator : IEnumerator<TElement> {
			// We're calling this off an instance, so if the other is null
			if (other is null) {
				// They aren't equal
				return false;
			}
			// Get enumerators for each
			TEnumerator ths = GetEnumerator();
			TOtherEnumerator oth = other.GetEnumerator();
			// Now iterate through both
			while (ths.MoveNext() && oth.MoveNext()) {
				// If the current elements are not equal to each other
				if (!Equals(ths.Current, oth.Current)) {
					// They aren't equal
					return false;
				}
			}
			// If any enumerator can still advance
			if (ths.MoveNext() || oth.MoveNext()) {
				// They aren't the same length and therefore aren't equal
				return false;
			}
			// We've validated that the enumerables are the same length and contain the same elements in the same order, so are therefore equal
			return true;
		}

		/// <inheritdoc/>
		public abstract TEnumerator GetEnumerator();

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "If you look at the example Sonar provides, they're clearly talking about this being a bad thing with regards to types with value semantics. In that context I completely agree. This method was forcibly sealed specifically to ensure that reference semantics always exist, preventing this issue. Unfortunantly Sonar doesn't understand patterns, and can't see that this 'violation' is actually preventing real violations.")]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <remarks>
		/// This is the actual implementation of <see cref="ICloneable{TSelf}.Clone()"/>
		/// </remarks>
		protected abstract TSelf Clone();
	}
}
