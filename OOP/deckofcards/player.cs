using System;
using System.Collections.Generic;

namespace deckofcards
{
    public class Player
    {
        public string Name;
        public List<Card> Hand;

        public Player(string n)
        {
            Name = n;
            Hand = new List<Card>();
        }


        public Card drawone(Deck deck)
        {
            Card carddrawn = deck.drawfromtop();
            Hand.Add(carddrawn);
            return carddrawn;
        }
        public void printhand()
        {
            foreach(Card c in Hand)
            {
                Console.WriteLine($"{c.Suit} {c.val}");
            }
        }
        public Card discard(int index)
        {
            if(index >= 0 && index < Hand.Count)
            {
            Card card = Hand[index];
            Hand.RemoveAt(index);
            return card;
            }
            else{
                return null;
            }
        }
    }
}