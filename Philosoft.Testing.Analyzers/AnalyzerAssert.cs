using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

namespace System.Traits.Testing {
	/// <summary>
	/// Represents a <see cref="Tests"/> asserter.
	/// </summary>
	/// <remarks>The type of the analyzer to make assertions against.</remarks>
	[CLSCompliant(false)]
	public readonly ref struct AnalyzerAssert<TAnalyzer> where TAnalyzer : DiagnosticAnalyzer, new() {
		[DisallowNull, NotNull]
		private readonly String file;

		/// <summary>
		/// The case represented in the source being tested.
		/// </summary>
		[DisallowNull, NotNull]
		public String Case => Path.GetFileNameWithoutExtension(file);

		/// <summary>
		/// The extension of the file being analyzed.
		/// </summary>
		[DisallowNull, NotNull]
		public String Extension => Path.GetExtension(file);

		/// <summary>
		/// The language being analyzed.
		/// </summary>
		/// <remarks>
		/// This uses the constants in <see cref="LanguageNames"/> for consistencies sake.
		/// </remarks>
		[DisallowNull, NotNull]
		public String Language {
			get {
				switch (Extension) {
				case ".cs":
					return LanguageNames.CSharp;
				case ".vb":
					return LanguageNames.VisualBasic;
				case ".fs":
				case ".fsi":
					return LanguageNames.FSharp;
				default:
					throw new NotSupportedException($"The extension '{Extension}' is not supported.");
				}
			}
		}

		/// <summary>
		/// Initializes a new <see cref="AnalyzerAssert{TAnalyzer}"/>.
		/// </summary>
		/// <param name="file">The filename of the source to analyze.</param>
		public AnalyzerAssert([DisallowNull] String file) => this.file = file;

		/// <summary>
		/// Asserts that when this source is analyzed, it reports no diagnostics.
		/// </summary>
		/// <returns>This <see cref="AnalyzerAssert{TAnalyzer}"/>.</returns>
		public AnalyzerAssert<TAnalyzer> Reports() {
			switch (Language) {
			case LanguageNames.CSharp:
				CSharpAnalyzerVerifier<TAnalyzer, PhilosoftVerifier>.VerifyAnalyzerAsync(File.ReadAllText(State.Path + file));
				break;
			default:
				throw new NotSupportedException($"The language '{Language}' is not supported.");
			}
			return this;
		}

		/// <summary>
		/// Asserts that when this source is analyzed, it reports a diagnostic with the <paramref name="id"/>.
		/// </summary>
		/// <param name="id">The identifier of the expected diagnostic.</param>
		/// <returns>This <see cref="AnalyzerAssert{TAnalyzer}"/>.</returns>
		public AnalyzerAssert<TAnalyzer> Reports([DisallowNull] String id) {
			switch (Language) {
			case LanguageNames.CSharp:
				CSharpAnalyzerVerifier<TAnalyzer, PhilosoftVerifier>.VerifyAnalyzerAsync(File.ReadAllText(State.Path + file), CSharpAnalyzerVerifier<TAnalyzer, PhilosoftVerifier>.Diagnostic(id));
				break;
			default:
				throw new NotSupportedException($"The language '{Language}' is not supported.");
			}
			return this;
		}

		/// <summary>
		/// Asserts that when this source is analyzed, it reports each diagnostic in the specified <paramref name="ids"/>.
		/// </summary>
		/// <param name="ids">The identifiers of the expected diagnostics.</param>
		/// <returns>This <see cref="AnalyzerAssert{TAnalyzer}"/>.</returns>
		public AnalyzerAssert<TAnalyzer> Reports([DisallowNull] params String[] ids) {
			switch (Language) {
			case LanguageNames.CSharp:
				DiagnosticResult[] diagnostics = new DiagnosticResult[ids.Length];
				for (Int32 i = 0; i < ids.Length; i++) {
					diagnostics[i] = CSharpAnalyzerVerifier<TAnalyzer, PhilosoftVerifier>.Diagnostic(ids[i]);
				}
				CSharpAnalyzerVerifier<TAnalyzer, PhilosoftVerifier>.VerifyAnalyzerAsync(File.ReadAllText(State.Path + file), diagnostics);
				break;
			default:
				throw new NotSupportedException($"The language '{Language}' is not supported.");
			}
			return this;
		}

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("The asserter isn't meant to be used as a normal type.", error: true)]
		public override Boolean Equals([AllowNull] Object obj) => throw new NotSupportedException();

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("The asserter isn't meant to be used as a normal type.", error: true)]
		public override Int32 GetHashCode() => throw new NotSupportedException();

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("The asserter isn't meant to be used as a normal type.", error: true)]
		[return: NotNull]
		public override String ToString() => throw new NotSupportedException();
	}
}
