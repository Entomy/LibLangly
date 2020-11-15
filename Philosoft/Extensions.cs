namespace Philosoft {
	/// <summary>
	/// Provides extension methods for the traits in <see cref="Philosoft"/>.
	/// </summary>
	public static partial class Extensions {
		/// <summary>
		/// Provides CLS Compiliant Consumer friendly variants for problematic extension methods.
		/// </summary>
		/// <remarks>
		/// This is effectively part of the binding process, where very C/C#-idiomatic code is converted into a way that is consumable for everything, regardless of the intentions. Using any of these directly would be horribly foolish for various reasons. Examples are how <see cref="Extensions.Read{TElement, TError}(IReadable{TElement, TError}, out TElement)"/> uses its out parameter for overloading on types, since overloading on returns isn't possible in C#. Furthermore, consider examples like <see cref="Extensions.TryRead{TElement, TError}(IReadable{TElement, TError}, out TElement)"/> which follow the well defined try-method idiot. This winds up problematic for other CLS Compliant Consumers, and so methods in <see cref="Friendly"/> work to convert those appropriately. In most cases, this conversion is only enough to get CLS Compliant Consumers to be able to consume the method, with some extra binding done on the consumers end to make it feel native.
		/// </remarks>
		public static partial class Friendly { }
	}
}
