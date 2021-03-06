﻿using System;
using Xunit;

namespace Langly.DataStructures {
	public class Dictionary1_Tests {
		[Fact]
		public void Constructor() {
			Dictionary<Int32> dict = null;
			dict = new Dictionary<Int32>();
			dict = new Dictionary<Int32>(Filter.None);
		}

		[Theory]
		[InlineData(new Char[] { }, new Int32[] { })]
		[InlineData(new Char[] { 'a' }, new Int32[] { 1 })]
		[InlineData(new Char[] { 'a', 'b', 'c' }, new Int32[] { 1, 2, 3 })]
		public void Insert_Char(Char[] indicies, Int32[] elements) {
			Dictionary<Int32> dict = new Dictionary<Int32>();
			for (nint i = 0; i < indicies.Length; i++) {
				dict = dict.Insert(indicies[i], elements[i]);
			}
			Assert.Equal(indicies.Length, dict.Count);
			for (nint i = 0; i < indicies.Length; i++) {
				Assert.Equal(elements[i], dict[indicies[i]]);
			}
		}

		[Theory]
		[InlineData(new String[] { }, new Int32[] { })]
		[InlineData(new String[] { "add" }, new Int32[] { 3 })]
		[InlineData(new String[] { "add", "addition" }, new Int32[] { 3, 8 })]
		public void Insert_String(String[] indicies, Int32[] elements) {
			Dictionary<Int32> dict = new Dictionary<Int32>();
			for (nint i = 0; i < indicies.Length; i++) {
				dict = dict.Insert(indicies[i], elements[i]);
			}
			Assert.Equal(indicies.Length, dict.Count);
			for (nint i = 0; i < indicies.Length; i++) {
				Assert.Equal(elements[i], dict[indicies[i]]);
			}
		}
	}
}
