using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Langly.DataStructures {
	/// <summary>
	/// Associates the <typeparamref name="TIndex"/> and <typeparamref name="TElement"/> values.
	/// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Auto)]
	public struct Association<TIndex, TElement> : IEquatable<Association<TIndex, TElement>>, IEquatable<(TIndex Index, TElement Element)>, ISerializable where TIndex : IEquatable<TIndex> {
		/// <summary>
		/// The index of the element.
		/// </summary>
		public TIndex Index;

		/// <summary>
		/// The element.
		/// </summary>
		public TElement Element;

		/// <summary>
		/// Initialize a new <see cref="Association{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="index">The index of the element.</param>
		/// <param name="element">The element.</param>
		public Association(TIndex index, TElement element) {
			Index = index;
			Element = element;
		}

		/// <summary>
		/// Deserialization constructor.
		/// </summary>
		/// <param name="serializationInfo"></param>
		/// <param name="streamingContext"></param>
		private Association(SerializationInfo serializationInfo, StreamingContext streamingContext) {
			Index = (TIndex)serializationInfo.GetValue(nameof(Index), typeof(TIndex));
			Element = (TElement)serializationInfo.GetValue(nameof(Element), typeof(TElement));
		}

		public static Boolean operator ==(Association<TIndex, TElement> left, Association<TIndex, TElement> right) => left.Equals(right);

		public static Boolean operator ==(Association<TIndex, TElement> left, (TIndex, TElement) right) => left.Equals(right);

		public static Boolean operator ==((TIndex, TElement) left, Association<TIndex, TElement> right) => right.Equals(left);

		public static Boolean operator !=(Association<TIndex, TElement> left, Association<TIndex, TElement> right) => !left.Equals(right);

		public static Boolean operator !=(Association<TIndex, TElement> left, (TIndex, TElement) right) => !left.Equals(right);

		public static Boolean operator !=((TIndex, TElement) left, Association<TIndex, TElement> right) => !right.Equals(left);

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Association<TIndex, TElement> association:
				return Equals(association);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(Association<TIndex, TElement> other) => Equals(Index, other.Index) && Equals(Element, other.Element);

		/// <inheritdoc/>
		public Boolean Equals((TIndex Index, TElement Element) other) => Equals(Index, other.Index) && Equals(Element, other.Element);

		/// <inheritdoc/>
		public override Int32 GetHashCode() => base.GetHashCode();

		/// <inheritdoc/>
		public override String ToString() => $"{Index}:{Element}";

		/// <inheritdoc/>
		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			if (info is null) {
				throw new System.ArgumentNullException(nameof(info));
			}
			info.AddValue(nameof(Index), Index, typeof(TIndex));
			info.AddValue(nameof(Element), Element, typeof(TElement));
		}
	}
}
