//using System;
//using System.Collections.Generic;

//namespace Philosoft {
//	/// <summary>
//	/// Indicates the type associates values of two other types.
//	/// </summary>
//	/// <typeparam name="TIndex">The type of the index.</typeparam>
//	/// <typeparam name="TElement">The type of the element.</typeparam>
//	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
//	public interface IAssociator<TIndex, TElement, TSelf> where TIndex : IEquatable<TIndex> where TSelf : IAssociator<TIndex, TElement, TSelf>, IEnumerable<Association<TIndex, TElement>> {
//		/// <summary>
//		/// Gets a view of the indicies of this collection.
//		/// </summary>
//		IndexView<TIndex, TElement, TSelf> Indicies { get; }

//		/// <summary>
//		/// Gets a view of the elements of this collection.
//		/// </summary>
//		ElementView<TIndex, TElement, TSelf> Elements { get; }
//	}
//}
