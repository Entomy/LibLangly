using System;
using System.Diagnostics.CodeAnalysis;

#if NETSTANDARD1_3
namespace System {
	/// <summary>
	/// Supports cloning, which creates a new instance of a class with the same value as an existing instance.
	/// </summary>
	/// <remarks>
	/// The <see cref="ICloneable"/> interface enables you to provide a customized implementation that creates a copy of an existing object. The <see cref="ICloneable"/> interface contains one member, the <see cref="Clone()"/> method, which is intended to provide cloning support beyond that supplied by <see cref="Object.MemberwiseClone()"/>. For more information about cloning, deep versus shallow copies, and examples, see the <see cref="Object.MemberwiseClone()"/> method.
	/// </remarks>
	public interface ICloneable {
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		/// <remarks>
		/// <para>The resulting clone must be of the same type as, or compatible with, the original instance.</para>
		/// <para>An implementation of <see cref="Clone"/> can perform either a deep copy or a shallow copy. In a deep copy, all objects are duplicated; in a shallow copy, only the top-level objects are duplicated and the lower levels contain references. Because callers of <see cref="Clone"/> cannot depend on the method performing a predictable cloning operation, we recommend that <see cref="ICloneable"/> not be implemented in public APIs.</para>
		/// <para>See <see cref="Object.MemberwiseClone"/> for more information on cloning, deep versus shallow copies, and examples.</para>
		/// </remarks>
		Object Clone();
	}
}
#else
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(ICloneable))]
#endif

namespace Langly {
	/// <summary>
	/// Supports cloning, which creates a new instance of a class with the same value as an existing instance.
	/// </summary>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// The <see cref="ICloneable{T}"/> interface enables you to provide a customized implementation that creates a copy of an existing object. The <see cref="ICloneable{T}"/> interface contains one member, the <see cref="Clone()"/> method, which is intended to provide cloning support beyond that supplied by <see cref="Object.MemberwiseClone()"/>. For more information about cloning, deep versus shallow copies, and examples, see the <see cref="Object.MemberwiseClone()"/> method.
	/// </remarks>
	public interface ICloneable<out TSelf> : ICloneable {
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		/// <remarks>
		/// <para>The resulting clone must be of the same type as, or compatible with, the original instance.</para>
		/// <para>An implementation of <see cref="Clone"/> can perform either a deep copy or a shallow copy. In a deep copy, all objects are duplicated; in a shallow copy, only the top-level objects are duplicated and the lower levels contain references. Because callers of <see cref="Clone"/> cannot depend on the method performing a predictable cloning operation, we recommend that <see cref="ICloneable{TSelf}"/> not be implemented in public APIs.</para>
		/// <para>See <see cref="Object.MemberwiseClone"/> for more information on cloning, deep versus shallow copies, and examples.</para>
		/// </remarks>
		[SuppressMessage("Class Design", "AV1010:Member hides inherited member", Justification = "Method shadowing is deliberate here.")]
		new TSelf Clone();

		/// <inheritdoc/>
		[SuppressMessage("Performance", "HAA0601:Value type to reference type conversion causing boxing allocation", Justification = "Well aware, and can't do anything about it. But that's why this interface and the new Clone() exist.")]
		Object ICloneable.Clone() => Clone();
	}

	public static partial class Extensions {
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <typeparam name="TSelf">The type of this collection; itself.</typeparam>
		/// <returns>A new object that is a copy of this instance.</returns>
		/// <remarks>
		/// <para>The resulting clone must be of the same type as, or compatible with, the original instance.</para>
		/// <para>An implementation of <see cref="ICloneable{TSelf}.Clone"/> can perform either a deep copy or a shallow copy. In a deep copy, all objects are duplicated; in a shallow copy, only the top-level objects are duplicated and the lower levels contain references. Because callers of <see cref="ICloneable{TSelf}.Clone"/> cannot depend on the method performing a predictable cloning operation, we recommend that <see cref="ICloneable{TSelf}"/> not be implemented in public APIs.</para>
		/// <para>See <see cref="Object.MemberwiseClone"/> for more information on cloning, deep versus shallow copies, and examples.</para>
		/// </remarks>
		public static TSelf Clone<TSelf>(this ICloneable<TSelf> collection) => collection is null ? default : collection.Clone();

		/// <summary>
		/// Creates a new memory region that is a copy of the current memory.
		/// </summary>
		/// <typeparam name="T">The type of elements in the memory region.</typeparam>
		/// <param name="memory">This memory region.</param>
		/// <returns>A new memory region that is a copy of the current memory.</returns>
		public static Memory<T> Clone<T>(this Memory<T> memory) {
			Memory<T> clone = new T[memory.Length];
			memory.CopyTo(clone);
			return clone;
		}

		/// <summary>
		/// Creates a new memory region that is a copy of the current memory.
		/// </summary>
		/// <typeparam name="T">The type of elements in the memory region.</typeparam>
		/// <param name="memory">This memory region.</param>
		/// <returns>A new memory region that is a copy of the current memory.</returns>
		public static ReadOnlyMemory<T> Clone<T>(this ReadOnlyMemory<T> memory) {
			Memory<T> clone = new T[memory.Length];
			memory.CopyTo(clone);
			return clone;
		}
	}
}
