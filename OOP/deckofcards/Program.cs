using System;

namespace deckofcards
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Deck deck1 = new Deck();
            deck1.shuffle();
            Player kevin = new Player("kevin");
            kevin.drawone(deck1);
            kevin.drawone(deck1);
            kevin.drawone(deck1);
            kevin.discard(0);
            kevin.printhand();
            
        }
    }
}
