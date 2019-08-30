using Laboratorio_3_OOP_201902.Cards;
using Laboratorio_3_OOP_201902.Enums;
using System;
using System.Collections.Generic;

namespace Laboratorio_3_OOP_201902
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            cards.Add(new CombatCard("Goblin", Enums.EnumType.melee, null, 5, false));
            cards.Add(new SpecialCard("Snow", Enums.EnumType.weather, "All LongRange attack points to 1"));
            cards.Add(new SpecialCard("General Harris", Enums.EnumType.captain, "All LongRange attack points to 10"));
            cards.Add(new SpecialCard("General Smith", Enums.EnumType.captain, "All Range attack points to 10"));
            cards.Add(new SpecialCard("Motivation", Enums.EnumType.buff, "All minions attack double on selected line"));
            cards.Add(new CombatCard("Destructor", Enums.EnumType.longRange, null, 10, true));
            Console.WriteLine(cards[1].GetType().Name == nameof(Card));
            Board board = new Board();
            board.AddCard(cards[2],0);
            board.AddCard(cards[1]);
            Console.WriteLine(board.PlayerCards[0][Enums.EnumType.captain][0].Name);
            Console.WriteLine(board.WeatherCards[0].Name);
            board.AddCard(cards[3], 1);
            Console.WriteLine(board.PlayerCards[1][Enums.EnumType.captain][0].Name);
            board.AddCard(cards[4], 0, "melee");
            Console.WriteLine(board.PlayerCards[0][Enums.EnumType.buffmelee][0].Name);
            board.AddCard(cards[4], 0, "range");
            Console.WriteLine(board.PlayerCards[0][Enums.EnumType.buffrange][0].Name);
            board.AddCard(cards[0], 0);
            Console.WriteLine(String.Join(", ", board.GetMeleeAttackPoints()));
            board.AddCard(cards[0], 0);
            Console.WriteLine(String.Join(", ", board.GetMeleeAttackPoints()));
            Console.WriteLine(String.Join(", ", board.GetRangeAttackPoints()));
            board.DestroyCards();
            Console.WriteLine(board.PlayerCards[0][Enums.EnumType.captain][0].Name);
            Console.WriteLine(String.Join(", ", board.GetMeleeAttackPoints()));
            Console.WriteLine(String.Join(", ", board.GetRangeAttackPoints()));
            Console.WriteLine(board.WeatherCards.Count);
        }
    }
}
