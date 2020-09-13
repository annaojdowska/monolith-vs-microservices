using System;
using System.Collections.Generic;
using System.Linq;
using Point = MonolithicApp.Model.Point;

namespace MonolithicApp.Services
{
    public interface IRouteService
    { 
        string[] FindShortestRoute();
    }

    public class RouteService : IRouteService
    {
        private string[] FindShortestRoute(Point[] input)
        {
            var route = HeuristicForTsp.FindRoute(input);
            return route.Select(x => x.Name).ToArray();
        }

        public string[] FindShortestRoute()
        {
            var input = GetRandomPoints(10000);
            return FindShortestRoute(input);
        }

        private Point[] GetRandomPoints(int count)
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
}