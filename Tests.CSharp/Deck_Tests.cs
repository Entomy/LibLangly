using System;
using Collectathon.Pools;
using Xunit;

namespace Langly {
	public class Deck_Tests {
		[Fact]
		public void Constructor() {
			Deck<String> deck = new Deck<String>("heart", "club", "spade", "diamond");
			Assert.Equal(4, deck.Count);
			Assert.True(deck.ContainsAll<String>("heart", "club", "spade", "diamond"));
		}

		[Fact]
		public void Clear() {
			Deck<String> deck = new Deck<String>("heart", "club", "spade", "diamond");
			foreach (String card in deck.Deal(4)) { }
			Assert.Equal(0, deck.Count);
			deck.Clear();
			Assert.Equal(4, deck.Count);
		}

		[Fact]
		public void Deal() {
			Deck<String> deck = new Deck<String>("heart", "club", "spade", "diamond");
			String card = deck.Deal();
			Assert.Equal(3, deck.Count);
			Assert.True(deck.Readable);
			card = deck.Deal();
			Assert.Equal(2, deck.Count);
			Assert.True(deck.Readable);
			card = deck.Deal();
			Assert.Equal(1, deck.Count);
			Assert.True(deck.Readable);
			card = deck.Deal();
			Assert.Equal(0, deck.Count);
			Assert.False(deck.Readable);
		}

		[Fact]
		public void Enumerator() {
			Deck<String> deck = new Deck<String>("heart", "club", "spade", "diamond");
			using var dealt = deck.Dealt;
			using var remaining = deck.Remaining;
			Assert.Equal(0, dealt.Count);
			Assert.Equal(4, remaining.Count);
			_ = deck.Deal();
			Assert.Equal(1, dealt.Count);
			Assert.Equal(3, remaining.Count);
			_ = deck.Deal();
			Assert.Equal(2, dealt.Count);
			Assert.Equal(2, remaining.Count);
			_ = deck.Deal();
			Assert.Equal(3, dealt.Count);
			Assert.Equal(1, remaining.Count);
			_ = deck.Deal();
			Assert.Equal(4, dealt.Count);
			Assert.Equal(0, remaining.Count);
		}
	}
}
