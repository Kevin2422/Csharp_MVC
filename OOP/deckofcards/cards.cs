using System;

namespace deckofcards
{
    public class Card
    {
       public string Name;
        public string Suit;
        public int val;

        public Card(string n, string s, int v)
        {
            Name = n;
            Suit = s;
            val = v;
        }
        public void print()
        {
            Console.WriteLine($"{Name}  {Suit}  {val}");
        }
    }
}