﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Linguistics {
	/// <summary>
	/// Represents a spoken or written language.
	/// </summary>
	public sealed class Language {
		/// <summary>
		/// The Azerbaijani language.
		/// </summary>
		[DisallowNull, NotNull]
		public static Language Azerbaijani { get; } = new(living: true, constructed: false, (Script.Latin, Orthography.Azeribaijani_Latin));

		/// <summary>
		/// The English language.
		/// </summary>
		[DisallowNull, NotNull]
		public static Language English { get; } = new(living: true, constructed: false, (Script.Latin, Orthography.English_Latin));

		/// <summary>
		/// The Russian language.
		/// </summary>
		[DisallowNull, NotNull]
		public static Language Russian { get; } = new(living: true, constructed: false, (Script.Cyrillic, Orthography.Russian_Cyrillic));

		/// <summary>
		/// The Turkish language.
		/// </summary>
		[DisallowNull, NotNull]
		public static Language Turkish { get; } = new(living: true, constructed: false, (Script.Latin, Orthography.Turkish_Latin));

		/// <summary>
		/// Initialize a new <see cref="Language"/> object.
		/// </summary>
		/// <param name="living">Whether the language is living or ancient; that is, actively spoken and developed, or fallen out of use.</param>
		/// <param name="constructed">Whether the language is constructed; that is, deliberately developed rather than naturally formed.</param>
		/// <param name="writingSystems">The mapping of writing systems used for this language.</param>
		private Language(Boolean living, Boolean constructed, params (Script Script, Orthography Orthography)[] writingSystems) {
			Living = living;
			Constructed = constructed;
			Script[] scripts = new Script[writingSystems.Length];
			Dictionary<Script, Orthography> orthographies = new Dictionary<Script, Orthography>(writingSystems.Length);
			for (Int32 i = 0; i < writingSystems.Length; i++) {
				scripts[i] = writingSystems[i].Script;
				orthographies.Add(writingSystems[i].Script, writingSystems[i].Orthography);
			}
			Scripts = scripts;
			Orthographies = orthographies;
		}

		/// <summary>
		/// Whether the language is constructed; that is, deliberately developed rather than naturally formed.
		/// </summary>
		public Boolean Constructed { get; }

		/// <summary>
		/// Whether the language is living or ancient; that is, actively spoken and developed, or fallen out of use.
		/// </summary>
		public Boolean Living { get; }

		/// <summary>
		/// The mapping of <see cref="Script"/> to <see cref="Orthography"/> for this <see cref="Language"/>.
		/// </summary>
		[DisallowNull, NotNull]
		public IReadOnlyDictionary<Script, Orthography> Orthographies { get; }

		/// <summary>
		/// The collection of <see cref="Script"/>s used to write in this language.
		/// </summary>
		[DisallowNull, NotNull]
		public IReadOnlyCollection<Script> Scripts { get; }

		/// <summary>
		/// Looks up the <see cref="Orthography"/> used for this <see cref="Language"/> when using the <paramref name="script"/>.
		/// </summary>
		/// <param name="script">The <see cref="Script"/> to get the <see cref="Orthography"/> for.</param>
		/// <returns>The <see cref="Orthography"/> if found, otherwise <see langword="null"/>.</returns>
		[MaybeNull]
		public Orthography this[[DisallowNull] Script script] => Orthographies[script];
	}
}
