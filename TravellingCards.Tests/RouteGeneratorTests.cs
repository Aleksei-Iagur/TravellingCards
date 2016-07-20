using System.Collections.Generic;
using Xunit;

namespace TravellingCards.Tests
{
    public class RouteGeneratorTests
    {
        [Fact]
        public void Generate_NullCollection_NullReturned()
        {
            var route = new RouteGenerator().GenerateRouteFromCards(null);

            Assert.Null(route);
        }

        [Fact]
        public void Generate_OneCard_CorrectRouteReturned()
        {
            var cards = new List<TravellingCard>
            {
                new TravellingCard { From = "Paris",    To = "Dublin" }
            };

            var route = new RouteGenerator().GenerateRouteFromCards(cards);

            Assert.True(IsGoodRoute(route));
        }

        [Fact]
        public void Generate_NotConnectedCardsCollection_NullReturned()
        {
            var cards = new List<TravellingCard>
            {
                new TravellingCard { From = "Paris",    To = "Dublin" },
                new TravellingCard { From = "Rome",     To = "Monaco" }
            };

            var route = new RouteGenerator().GenerateRouteFromCards(cards);

            Assert.Null(route);
        }

        [Fact]
        public void Generate_NormalCardsCollection_CorrectRouteReturned()
        {
            var cards = new List<TravellingCard>
            {
                new TravellingCard { From = "Paris",    To = "Dublin" },
                new TravellingCard { From = "Rome",     To = "Amsterdam" },
                new TravellingCard { From = "Dublin",   To = "Rome" },
                new TravellingCard { From = "Monaco",   To = "Paris" }
            };

            var route = new RouteGenerator().GenerateRouteFromCards(cards);

            Assert.True(IsGoodRoute(route));
        }

        private static bool IsGoodRoute(List<TravellingCard> route)
        {
            if (route == null)
            {
                return false;
            }

            if (route.Count == 1)
            {
                return true;
            }

            for (var i = 0; i < route.Count - 1; i++)
            {
                if (!route[i].To.Equals(route[i + 1].From))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
