using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Route.Services;

namespace Route
{
    public class RouteService : RouteServiceProto.RouteServiceProtoBase
    {
        public override async Task<ShortRoute> FindShortestRoute(FindRouteMessage request, ServerCallContext context)
        {
            var locations = await FindShortestRoute();
            var shortRoute = new ShortRoute();
            shortRoute.Point.AddRange(locations);
            return shortRoute;
        }

        private static async Task<string[]> FindShortestRoute(Point[] input)
        {
            var route = await Task.Run(() => HeuristicForTsp.FindRoute(input));
            return route.Select(x => x.Name).ToArray();
        }

        public static Task<string[]> FindShortestRoute()
        {
            var input = GetRandomPoints(10000);
            return FindShortestRoute(input);
        }

        private static Point[] GetRandomPoints(int count)
        {
            var random = new Random();
            var points = new Point[count];

            for (var i = 0; i < count; i++)
                points[i] = new Point("Loc" + i, random.NextDouble()*90.0, random.NextDouble()*180.0);

            return points;
        }
    }
    public class HeuristicForTsp
    {
        public static List<Point> FindRoute(Point[] points)
        {
            var random = new Random();
            var startIndex = random.Next(points.Length);
            var currentPoint = points[startIndex];
            var route = new List<Point>(10000) {currentPoint};
            var numberOfVisited = 1;
            var visitedPoints = new bool[points.Length];
            visitedPoints[startIndex] = true;

            Point nextPoint = null;
            while (numberOfVisited < points.Length)
            {
                var minCost = double.PositiveInfinity;
                var currentIndex = -1;
                for (var i = 0; i < points.Length; i++)
                {
                    if (visitedPoints[i]) continue;
                    
                    var tmpCost = Euclidean(currentPoint, points[i]);
                    if (tmpCost >= minCost) continue;
                    
                    minCost = tmpCost;
                    nextPoint = points[i];
                    currentIndex = i;
                }
                route.Add(nextPoint);
                visitedPoints[currentIndex] = true;
                numberOfVisited++;
                currentPoint = nextPoint;
            }

            return route;
        }

        private static double Euclidean(Point p1, Point p2) 
            => Math.Sqrt((p1.Lat - p2.Lat)*(p1.Lat - p2.Lat) + (p1.Lon - p2.Lon)*(p1.Lon - p2.Lon));
    }
    
    public class Point
    {
        public Point(string name, double lat, double lon)
        {
            Name = name;
            Lat = lat;
            Lon = lon;
        }

        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}