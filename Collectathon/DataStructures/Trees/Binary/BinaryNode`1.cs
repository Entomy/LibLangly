using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Trees.Binary {
	/// <summary>
	/// Represents the base node type of any binary tree.
	/// </summary>
	/// <typeparam name="TElement">The type contained in the node.</typeparam>
	/// <typeparam name="TSelf">The implementing node type; itself.</typeparam>
	public abstract class BinaryNode<TElement, TSelf> : TreeNode<TElement, TSelf> where TSelf : BinaryNode<TElement, TSelf> {
		/// <inheritdoc/>
		protected BinaryNode(TElement element, TSelf parent, TSelf left, TSelf right) : base(element) {
			Parent = parent;
			Left = left;
			Right = right;
		}

		/// <summary>
		/// The grandparent node.
		/// </summary>
		public TSelf Grandparent => Parent?.Parent;

		/// <summary>
		/// The lefthand child node.
		/// </summary>
		public TSelf Left { get; private set; }

		/// <summary>
		/// The parent node.
		/// </summary>
		public TSelf Parent { get; private set; }

		/// <summary>
		/// The righthand child node.
		/// </summary>
		public TSelf Right { get; private set; }

		/// <summary>
		/// The sibling node.
		/// </summary>
		[SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "I'm considering it fine in this case because the initial part is so obvious and ignorable, that for all intents and purposes you're just looking at the second part, and therefore only one ternary. I've written the expression specifically to help with this, rather than a 'not null' condition which would put the rest of the initial ternary after the second ternary, which would lead to a great deal of confusion.")]
		public TSelf Sibling => Parent is null ? null : (ReferenceEquals(this, Parent.Left) ? Parent.Right : Parent.Left);

		/// <summary>
		/// The uncle node.
		/// </summary>
		public TSelf Uncle => Parent?.Sibling;

		/// <inheritdoc/>
		public override void Clear() {
			Left?.Clear();
			Right?.Clear();
		}

		/// <inheritdoc/>
		public override Boolean Contains(TElement element) => (Element?.Equals(element) ?? false) || (Left?.Contains(element) ?? false) || (Right?.Contains(element) ?? false);

		/// <inheritdoc/>
		public override void Replace(TElement oldElement, TElement newElement) {
			if (Element?.Equals(oldElement) ?? false) {
				Element = newElement;
			}
			Left?.Replace(oldElement, newElement);
			Right?.Replace(oldElement, newElement);
		}

		/// <inheritdoc/>
		public override void Replace(Predicate<TElement> match, TElement newElement) {
			if (match(Element)) {
				Element = newElement;
			}
			Left?.Replace(match, newElement);
			Right?.Replace(match, newElement);
		}

		/// <summary>
		/// Rotates the node leftward.
		/// </summary>
		public void RotateLeft() {
			TSelf New = Right;
			TSelf Top = Parent;
			if (New is null) {
				return;
			}
			Right = New.Left;
			New.Left = (TSelf)this;
			Parent = New;
			if (Right is not null) {
				Right.Parent = (TSelf)this;
			}
			if (Top is not null) {
				if (ReferenceEquals(this, Top.Left)) {
					Top.Left = New;
				} else if (ReferenceEquals(this, Top.Right)) {
					Top.Right = New;
				}
			}
			New.Parent = Top;
		}

		/// <summary>
		/// Rotates the node rightward.
		/// </summary>
		public void RotateRight() {
			TSelf New = Left;
			TSelf Top = Parent;
			if (New is null) {
				return;
			}
			Left = New.Right;
			New.Right = (TSelf)this;
			Parent = New;
			if (Left is not null) {
				Left.Parent = (TSelf)this;
			}
			if (Top is not null) {
				if (ReferenceEquals(this, Top.Left)) {
					Top.Left = New;
				} else if (ReferenceEquals(this, Top.Right)) {
					Top.Right = New;
				}
			}
			New.Parent = Top;
		}
	}
}
