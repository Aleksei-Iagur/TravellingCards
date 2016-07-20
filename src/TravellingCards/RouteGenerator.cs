using System.Collections.Generic;
using System.Linq;

namespace TravellingCards
{
    /// <summary>
    /// Class that generates routes from unsorted collections of travelling cards.
    /// </summary>
    public class RouteGenerator
    {
        private readonly Dictionary<string, Node> _sources;
        private readonly Dictionary<string, Node> _destinations;
        private Node _firstNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteGenerator"/> class.
        /// </summary>
        public RouteGenerator()
        {
            _sources = new Dictionary<string, Node>();
            _destinations = new Dictionary<string, Node>();
            _firstNode = null;
        }

        /// <summary>
        /// Generates a route (sorted collection of travelling cards).
        /// </summary>
        /// <param name="unsortedCards">Unsorted collection of travelling cards.</param>
        /// <returns>Sorted collection of <see cref="TravellingCard"/>.</returns>
        public List<TravellingCard> GenerateRouteFromCards(List<TravellingCard> unsortedCards)
        {
            if (unsortedCards == null || !unsortedCards.Any())
            {
                return null;
            }

            foreach (var card in unsortedCards)
            {
                AddTravellingCardToRoute(card);
            }

            var route = GetRoute();

            return route.Count == unsortedCards.Count ? route : null;
        }

        private void AddTravellingCardToRoute(TravellingCard card)
        {
            var node = new Node(card);

            if (_sources.ContainsKey(card.To))
            {
                node.Next = _sources[card.To];
            }

            if (_destinations.ContainsKey(card.From))
            {
                _destinations[card.From].Next = node;
            }
            else
            {
                _firstNode = node;
            }

            _sources.Add(card.From, node);
            _destinations.Add(card.To, node);
        }

        private List<TravellingCard> GetRoute()
        {
            var route = new List<TravellingCard>();
            var current = _firstNode;

            while (current != null)
            {
                route.Add(current.Card);
                current = current.Next;
            }

            return route;
        }

        private class Node
        {
            public Node Next { get; set; }
            public TravellingCard Card { get; }

            public Node(TravellingCard card)
            {
                Card = card;
            }
        }
    }
}
