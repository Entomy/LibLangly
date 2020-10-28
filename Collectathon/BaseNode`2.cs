using Philosoft;
using static Philosoft.Extensions;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Collectathon {
	/// <summary>
	/// Represents the base node type of any associative collection.
	/// </summary>
	/// <typeparam name="TIndex">The type of the index.</typeparam>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class BaseNode<TIndex, TElement, TSelf> : IClearable, IEquatable<(TIndex Index, TElement Element)>, IEquatable<BaseNode<TIndex, TElement, TSelf>> where TIndex : IEquatable<TIndex> where TSelf : BaseNode<TIndex, TElement, TSelf> {
		/// <summary>
		/// The full member of the node.
		/// </summary>
		public Association<TIndex, TElement> Member;

		/// <summary>
		/// The index of the node.
		/// </summary>
		public ref TIndex Index => ref Member.Index;

		/// <summary>
		/// The element of the node.
		/// </summary>
		public ref TElement Element => ref Member.Element;

		public static Boolean operator !=(BaseNode<TIndex, TElement, TSelf> left, BaseNode<TIndex, TElement, TSelf> right) => !left.Equals(right);

		public static Boolean operator !=(BaseNode<TIndex, TElement, TSelf> left, TElement right) => !left.Equals(right);

		public static Boolean operator !=(TElement left, BaseNode<TIndex, TElement, TSelf> right) => !right.Equals(left);

		public static Boolean operator ==(BaseNode<TIndex, TElement, TSelf> left, BaseNode<TIndex, TElement, TSelf> right) => left.Equals(right);

		public static Boolean operator ==(BaseNode<TIndex, TElement, TSelf> left, TElement right) => left.Equals(right);

		public static Boolean operator ==(TElement left, BaseNode<TIndex, TElement, TSelf> right) => right.Equals(left);

		/// <summary>
		/// Initializes a new <see cref="BaseNode{TIndex, TElement, TSelf}"/>.
		/// </summary>
		/// <param name="index">The index of the node.</param>
		/// <param name="element">The element contained in the node.</param>
		protected BaseNode(TIndex index, TElement element) => Member = new Association<TIndex, TElement>(index, element);

		/// <inheritdoc/>
		public abstract void Clear();

		/// <inheritdoc/>
		public sealed override Boolean Equals(Object? obj) {
			switch (obj) {
			case BaseNode<TIndex, TElement, TSelf> node:
				return Equals(node);
			case ValueTuple<TIndex, TElement> value:
				return Equals(value);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals((TIndex Index, TElement Element) other) => other.Index is not null && other.Element is not null && Index.Equals(other.Index) && Element.Equals(other.Element);

		/// <inheritdoc/>
		public Boolean Equals(BaseNode<TIndex, TElement, TSelf> other) => other is not null && other.Equals(Member);

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "If you look at the example Sonar provides, they're clearly talking about this being a bad thing with regards to types with value semantics. In that context I completely agree. This method was forcibly sealed specifically to ensure that reference semantics always exist, preventing this issue. Unfortunantly Sonar doesn't understand patterns, and can't see that this 'violation' is actually preventing real violations.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public sealed override String ToString() => Member.ToString();
	}
}
