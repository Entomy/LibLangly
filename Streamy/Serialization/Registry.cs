using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Serialization {
	/// <summary>
	/// Registry for serialization and deserialization metadata.
	/// </summary>
	public static class Registry {
		/// <summary>
		/// Phi, the golden ratio.
		/// </summary>
		private const Double φ = 1.6180339887_4989484820_4586834365_6381177203_0917980576_2862135448_6227052604_6281890244_9707207204_1893911374_8475408807_5386891752;

		/// <summary>
		/// The entries of the serialization registry.
		/// </summary>
		[SuppressMessage("Performance", "HAA0501:Explicit new array type allocation", Justification = "Yup. This must happen.")]
		private static Entry[] Entries = Array.Empty<Entry>();

		/// <summary>
		/// The current capacity of the collection before needing to be resized.
		/// </summary>
		private static nint Capacity => Entries.Length;

		/// <summary>
		/// The amount of entries in the registry.
		/// </summary>
		private static nint Count { get; set; }

		/// <summary>
		/// Adds the type to the registry.
		/// </summary>
		/// <typeparam name="T">The serializable type.</typeparam>
		/// <param name="size">The types' size in bytes.</param>
		public static void Add<T>(Int32 size) where T : ISerializable {
			if (Count == Capacity) {
				Grow();
			}
			Entries[Count++] = new Entry(typeof(T), size);
		}

		/// <summary>
		/// Gets the payload size of the <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The type.</typeparam>
		/// <returns>The types' size in bytes; <c>-1</c> if the type is not registered.</returns>
		public static Int32 GetSize<T>() where T : ISerializable {
			foreach (Entry entry in Entries) {
				if (entry.Type == typeof(T)) {
					return entry.Size;
				}
			}
			return -1;
		}

		/// <summary>
		/// Grows the collection by a computed factor.
		/// </summary>
		private static void Grow() {
			if (Capacity <= 8) {
				Resize(13);
			} else {
				Resize((Int32)(Capacity * φ));
			}
		}

		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The new capacity of the collection.</param>
		private static void Resize(nint capacity) {
			Entry[] newEntries = new Entry[capacity];
			Entries.AsSpan().CopyTo(newEntries.AsSpan());
			Entries = newEntries;
		}

		/// <summary>
		/// Shrinks the collection by a computed factor.
		/// </summary>
		private static void Shrink() => Resize((nint)(Capacity / φ));

		/// <summary>
		/// Represents a serialization registry entry.
		/// </summary>
		private sealed class Entry {
			/// <summary>
			/// Initializes a new <see cref="Registry"/> <see cref="Entry"/>.
			/// </summary>
			/// <param name="type">The type.</param>
			/// <param name="size">The types' size in bytes.</param>
			internal Entry(Type type, Int32 size) {
				Type = type;
				Size = size;
			}

			/// <summary>
			/// The types' size in bytes.
			/// </summary>
			public Int32 Size { get; }

			/// <summary>
			/// The type.
			/// </summary>
			public Type Type { get; }
		}
	}
}
