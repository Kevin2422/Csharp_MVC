using System;
using System.Collections.Generic;

namespace deckofcards
{
    public class Deck
    {
        public List<Card> cards;
        public Deck()
        {
        string suit = "";
        string name = "";
        int val = 0;
        cards = new List<Card>();
        // array of suit names and array of card names
        for (int i = 1; i<=4;i++ )
        {
            for (int j = 1; j<=13; j++ )
            {
                val = j;
                name = j.ToString();
                if (i == 1)
                {
                    suit = "Diamonds";
                }
                else if (i == 2)
                {
                    suit = "Hearts";
                }
                else if (i == 3)
                {
                    suit = "Clubs";
                }
                else if (i ==4)
                {
                    suit = "Spades";
                }
                if (j == 1)
                {
                    name = "Ace";
                    
                }
                if (j == 11)
                {
                    name = "Jack";
                  
                }
                else if (j == 12)
                {
                    name = "Queen";
                }
                else if (j==13)
                {
                    name = "King";
                }
                cards.Add(new Card(name, suit, val));
            
            }
        }
        }

        public void printdeck()
        {
            int x = 0;
        foreach (Card c in cards)
        {
            x++;
            Console.WriteLine($"{x}. {c.Name} of {c.Suit} value {c.val}");
        }
        }
        public Card drawfromtop()
        {
            Card carddrawn = cards[0];
            cards.RemoveAt(0);
            return carddrawn;
        }

        public void reset()
        {
            Deck newdeck = new Deck();
            cards = newdeck.cards;
        }
        public void shuffle()
        {
            Random rand = new Random();
            int n = cards.Count;
            while (n>1)
            {
                n--;
                int k = rand.Next(n+1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}