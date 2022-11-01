using System;
using System.Collections.Generic;

namespace _03._Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> validCards = new List<Card>();
            string[] cards = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cards.Length; i++)
            {
                string[] currentCard = cards[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currentCardFace = currentCard[0];
                string currentCardSuit = currentCard[1];
                try
                {
                    Card card = new Card(currentCardFace, currentCardSuit);
                    validCards.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine(String.Join(" ", validCards));
        }
    }
    public class Card
    {
        private string cardFace;

        public string CardFace
        {
            get { return cardFace; }
            private set
            {
                switch (value)
                {
                    case "2": this.cardFace = value; break;
                    case "3": this.cardFace = value; break;
                    case "4": this.cardFace = value; break;
                    case "5": this.cardFace = value; break;
                    case "6": this.cardFace = value; break;
                    case "7": this.cardFace = value; break;
                    case "8": this.cardFace = value; break;
                    case "9": this.cardFace = value; break;
                    case "10": this.cardFace = value; break;
                    case "J": this.cardFace = value; break;
                    case "Q": this.cardFace = value; break;
                    case "K": this.cardFace = value; break;
                    case "A": this.cardFace = value; break;
                    default: throw new ArgumentException("Invalid card!");
                }
            }
        }
        private string cardSuit;

        public string CardSuit
        {
            get { return cardSuit; }
            private set
            {
                switch (value)
                {
                    case "S": this.cardSuit = value; break;
                    case "H": this.cardSuit = value; break;
                    case "D": this.cardSuit = value; break;
                    case "C": this.cardSuit = value; break;
                    default: throw new ArgumentException("Invalid card!");
                }
            }
        }
        public Card(string face, string suit)
        {
            this.CardFace = face;
            this.CardSuit = suit;
        }
        public override string ToString()
        {
            switch (this.CardSuit)
            {
                case "S": this.cardSuit = "\u2660"; break;
                case "H": this.cardSuit = "\u2665"; break;
                case "D": this.cardSuit = "\u2666"; break;
                case "C": this.cardSuit = "\u2663"; break;
            }
            return $"[{this.CardFace}{this.CardSuit}]";
        }
    }
}
