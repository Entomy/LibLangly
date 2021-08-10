using System;
using System.Traits.Testing;
using Collectathon;
using Xunit;

namespace Collectathon {
	public class Deck_Tests : Tests {
		[Fact]
		public void Constructor() {
			Deck<String> deck = new("heart", "club", "spade", "diamond");
			Assert.That(deck.Count).Equals(4);
			Assert.That(deck.ContainsAll("heart", "club", "spade", "diamond")).True();
		}

		[Fact]
		public void Clear() {
			Deck<String> deck = new("heart", "club", "spade", "diamond");
			foreach (String card in deck.Deal(4)) { }
			Assert.That(deck.Count).Equals(0);
			deck.Clear();
			Assert.That(deck.Count).Equals(4);
		}

		[Fact]
		public void Deal() {
			Deck<String> deck = new("heart", "club", "spade", "diamond");
			String card = deck.Deal();
			Assert.That(deck.Count).Equals(3);
			card = deck.Deal();
			Assert.That(deck.Count).Equals(2);
			card = deck.Deal();
			Assert.That(deck.Count).Equals(1);
			card = deck.Deal();
			Assert.That(deck.Count).Equals(0);
		}

		[Fact]
		public void Enumerator() {
			Deck<String> deck = new("heart", "club", "spade", "diamond");
			var dealt = deck.Dealt;
			var remaining = deck.Remaining;
			Assert.That(dealt.Count).Equals(0);
			Assert.That(remaining.Count).Equals(4);
			_ = deck.Deal();
			Assert.That(dealt.Count).Equals(1);
			Assert.That(remaining.Count).Equals(3);
			_ = deck.Deal();
			Assert.That(dealt.Count).Equals(2);
			Assert.That(remaining.Count).Equals(2);
			_ = deck.Deal();
			Assert.That(dealt.Count).Equals(3);
			Assert.That(remaining.Count).Equals(1);
			_ = deck.Deal();
			Assert.That(dealt.Count).Equals(4);
			Assert.That(remaining.Count).Equals(0);
		}
	}
}
