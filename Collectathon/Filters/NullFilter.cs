using Logician;

namespace Collectathon.Filters {
	/// <summary>
	/// A dummy <see cref="Filter{TElement}"/> to prevent needing null checks.
	/// </summary>
	/// <typeparam name="TElement"></typeparam>
	internal sealed class NullFilter<TElement> : Filter<TElement> {
		private NullFilter() : base(adds: false, contains: false) { }

		/// <summary>
		/// Gets a singleton instance of a <see cref="NullFilter{TElement}"/>.
		/// </summary>
		internal static NullFilter<TElement> Instance => Singleton.Instance;

		/// <inheritdoc/>
		public override Filter Type => Filter.None;

		/// <inheritdoc/>
		public override Filter<TElement> Clone() => this;

		/// <inheritdoc/>
		public override Ł3 Contains(TElement element) => Ł3.Unknown;

		private static class Singleton {
			static Singleton() { }

			internal static readonly NullFilter<TElement> Instance = new NullFilter<TElement>();
		}
	}
}
