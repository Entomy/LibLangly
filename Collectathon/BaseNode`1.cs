using Langly;
using System;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace Collectathon {
	/// <summary>
	/// Represents the base node type of any simple collection.
	/// </summary>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class BaseNode<TElement, TSelf> : IClearable, IEquatable<TElement>, IEquatable<BaseNode<TElement, TSelf>>, IPeekable<TElement> where TSelf : BaseNode<TElement, TSelf> {
		/// <summary>
		/// The element contained in the node.
		/// </summary>
		public TElement Element;

		/// <summary>
		/// Initializes a new <see cref="BaseNode{TElement, TSelf}"/>.
		/// </summary>
		/// <param name="element">The value contained in the node.</param>
		protected BaseNode(TElement element) => Element = element;

		public static Boolean operator !=(BaseNode<TElement, TSelf> left, BaseNode<TElement, TSelf> right) => !left.Equals(right);

		public static Boolean operator !=(BaseNode<TElement, TSelf> left, TElement right) => !left.Equals(right);

		public static Boolean operator !=(TElement left, BaseNode<TElement, TSelf> right) => !right.Equals(left);

		public static Boolean operator ==(BaseNode<TElement, TSelf> left, BaseNode<TElement, TSelf> right) => left.Equals(right);

		public static Boolean operator ==(BaseNode<TElement, TSelf> left, TElement right) => left.Equals(right);

		public static Boolean operator ==(TElement left, BaseNode<TElement, TSelf> right) => right.Equals(left);

		/// <inheritdoc/>
		public abstract void Clear();

		/// <inheritdoc/>
		public sealed override Boolean Equals(Object obj) {
			switch (obj) {
			case BaseNode<TElement, TSelf> node:
				return Equals(node);
			case TElement value:
				return Equals(value);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(TElement other) => !(other is null) && other.Equals(Element);

		/// <inheritdoc/>
		public Boolean Equals(BaseNode<TElement, TSelf> other) => !(other is null) && other.Equals(Element);

		/// <inheritdoc/>
		[SuppressMessage("Major Bug", "S3249:Classes directly extending \"object\" should not call \"base\" in \"GetHashCode\" or \"Equals\"", Justification = "If you look at the example Sonar provides, they're clearly talking about this being a bad thing with regards to types with value semantics. In that context I completely agree. This method was forcibly sealed specifically to ensure that reference semantics always exist, preventing this issue. Unfortunantly Sonar doesn't understand patterns, and can't see that this 'violation' is actually preventing real violations.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public ref readonly TElement Peek() => ref Element;

		/// <inheritdoc/>
		public sealed override String ToString() => Element.ToString();
	}
}
