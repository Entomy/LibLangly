using System;
using Xunit;
using Xunit.Sdk;

namespace Langly.DataStructures.Lists {
	public class SinglyLinkedList2_Tests {
		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" })]
		public void Clear(Char[] indicies, String[] elements) {
			SinglyLinkedList<Char, String> list = new SinglyLinkedList<Char, String>() { indicies.Zip(elements) };
			Assert.Equal(indicies.Length, list.Count);
			list.Clear();
			Assert.Equal(0, list.Count);
			foreach (Association<Char, String> item in list) {
				//If this executes at all, the enumerator found elements even though the length was properly cleared.
				throw new FalseException("", null);
			}
		}

		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, "Foxtrot", false)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, "Charlie", true)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, "Echo", true)]
		public void Contains(Char[] indicies, String[] elements, String item, Boolean expected) {
			SinglyLinkedList<Char, String> list = new SinglyLinkedList<Char, String>() { indicies.Zip(elements) };
			Assert.Equal(expected, list.Elements.Contains(item));
		}

		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" })]
		public void Enumerator(Char[] indicies, String[] elements) {
			SinglyLinkedList<Char, String> list = new SinglyLinkedList<Char, String>();
			Int32 i = 0;
			foreach (Association<Char, String> item in list) {
				Assert.Equal(new Association<Char, String>(indicies[i], elements[i++]), item);
			}
		}

		[Theory]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, 'a', true)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, 'c', true)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, 'e', true)]
		[InlineData(new[] { 'a', 'b', 'c', 'd', 'e' }, new[] { "Alfa", "Bravo", "Charlie", "Delta", "Echo" }, 'f', false)]
		public void Indexer(Char[] indicies, String[] elements, Char item, Boolean expected) {
			SinglyLinkedList<Char, String> list = new SinglyLinkedList<Char, String>() { indicies.Zip(elements) };
			if (expected) {
				_ = list[item];
			} else {
				Assert.Throws<ArgumentOutOfRangeException>(() => list[item]);
			}
		}
	}
}
