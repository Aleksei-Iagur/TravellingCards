using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace TravellingCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cards = new List<TravellingCard>
            {
                new TravellingCard { From = "Paris",    To = "Dublin" },
                new TravellingCard { From = "Rome",     To = "Amsterdam" },
                new TravellingCard { From = "Dublin",   To = "Rome" },
                new TravellingCard { From = "Monaco",   To = "Paris" }
            };

            Console.WriteLine($"=== Added {cards.Count} travelling cards ===");
            Console.WriteLine();
            PrintCards(cards);

            var route = new RouteGenerator().GenerateRouteFromCards(cards);

            Console.WriteLine("=== Generated route ===");
            Console.WriteLine();
            PrintCards(route);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void PrintCards(List<TravellingCard> cards)
        {
            foreach (var travellingCard in cards)
            {
                Console.WriteLine($"From: {travellingCard.From}, To: {travellingCard.To}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
