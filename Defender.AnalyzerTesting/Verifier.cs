using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Defender {
	/// <summary>
	/// Represents the analyzer verifier used to abstract across test runners.
	/// </summary>
	internal sealed class Verifier : IVerifier {
		/// <summary>
		/// Tracks context.
		/// </summary>
		private readonly ImmutableStack<String> Context;

		/// <summary>
		/// Initializes a new <see cref="Verifier"/>.
		/// </summary>
		public Verifier() : this(ImmutableStack<String>.Empty) { }

		/// <summary>
		/// Initializes a new <see cref="Verifier"/>.
		/// </summary>
		/// <param name="context">The context stack to include.</param>
		private Verifier(ImmutableStack<String> context) => Context = context;

		/// <inheritdoc/>
		public void Empty<T>(String collectionName, IEnumerable<T> collection) {
			using IEnumerator<T> enumerator = collection.GetEnumerator();
			if (enumerator.MoveNext()) {
				throw new AssertException($"'{collectionName}' is not empty.\n{FormatContext()}");
			}
		}

		/// <inheritdoc/>
		public void Equal<T>(T expected, T actual, String? message = null) {
			if (message is null && Context.IsEmpty) {
				if (!Equals(expected, actual)) {
					throw new AssertException($"This instance was not what was expected.\nActual: {actual}\nExpected: {expected}");
				}
			} else {
				if (!EqualityComparer<T>.Default.Equals(expected, actual)) {
					throw new AssertException($"This instance was not what was expected.\nActual: {actual}\nExpected: {expected}\n{FormatContext()}");
				}
			}
		}

		/// <inheritdoc/>
		[DoesNotReturn]
		public void Fail(String? message = null) {
			if (message is null && Context.IsEmpty) {
				throw new AssertException($"Failure was manually triggered.");
			} else {
				throw new AssertException($"Failure was manually triggered.\n{FormatContext()}");
			}
		}

		/// <inheritdoc/>
		public void False([DoesNotReturnIf(true)] Boolean assert, String? message = null) {
			if (message is null && Context.IsEmpty) {
				if (assert) {
					throw new AssertException($"The expression was expected to be false, but was true.");
				}
			} else {
				if (assert) {
					throw new AssertException($"The expression was expected to be false, but was true.\n{FormatContext()}");
				}
			}
		}

		/// <inheritdoc/>
		public void LanguageIsSupported(String language) {
			if (language != LanguageNames.CSharp && language != LanguageNames.VisualBasic && language != LanguageNames.FSharp) {
				throw new AssertException($"The target language is not supported.\nLanguage: {language}");
			}
		}

		/// <inheritdoc/>
		public void NotEmpty<T>(String collectionName, IEnumerable<T> collection) {
			using IEnumerator<T> enumerator = collection.GetEnumerator();
			if (!enumerator.MoveNext()) {
				throw new AssertException($"'{collectionName}' is empty.\n{FormatContext()}");
			}
		}

		/// <inheritdoc/>
		public IVerifier PushContext(String context) => new Verifier(Context.Push(context));

		/// <inheritdoc/>
		public void SequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T>? equalityComparer = null, String? message = null) {
			if (message is null && Context.IsEmpty) {
				using IEnumerator<T> exp = expected.GetEnumerator();
				using IEnumerator<T> act = expected.GetEnumerator();
				if (equalityComparer is null) {
					while (exp.MoveNext() && act.MoveNext()) {
						if (!Equals(exp.Current, act.Current)) {
							goto NotEqual;
						}
					}
					if (exp.MoveNext() || act.MoveNext()) {
						goto NotEqual;
					}
				} else {
					while (exp.MoveNext() && act.MoveNext()) {
						if (!equalityComparer.Equals(exp.Current, act.Current)) {
							goto NotEqual;
						}
					}
					if (exp.MoveNext() || act.MoveNext()) {
						goto NotEqual;
					}
				}
				return;
			NotEqual:
				throw new AssertException($"");
			} else {
				SequenceEqualEnumerableEqualityComparer<T> comparer = new SequenceEqualEnumerableEqualityComparer<T>(equalityComparer);
				Boolean areEqual = comparer.Equals(expected, actual);
				if (!areEqual) {
					throw new AssertException($"");
				}
			}
		}

		/// <inheritdoc/>
		public void True([DoesNotReturnIf(false)] Boolean assert, String? message = null) {
			if (message is null && Context.IsEmpty) {
				if (!assert) {
					throw new AssertException($"The expression was expected to be true, but was false.");
				}
			} else {
				if (!assert) {
					throw new AssertException($"The expression was expected to be true, but was false.\n{FormatContext()}");
				}
			}
		}

		private String FormatContext() {
			String message = "";
			foreach (String? frame in Context) {
				message = "Context: " + frame + Environment.NewLine + message;
			}
			return message;
		}
	}
}
