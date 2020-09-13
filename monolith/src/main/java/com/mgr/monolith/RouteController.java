package com.mgr.monolith;

import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.stream.Collectors;

@RestController
public class RouteController {

	@RequestMapping(path = "/route", method = RequestMethod.GET)
	public List<String> getRoute() {
		Point[] input = GetRandomPoints(10000);
		ArrayList<Point> route = FindRoute(input);
		return route.stream().map(x -> x.getName()).collect(Collectors.toList());
	}

	private Point[] GetRandomPoints(int count)
	{
		Random random = new Random();
		Point[] points = new Point[count];

		for (int i = 0; i < count; i++)
			points[i] = new Point("Loc"+i, (double)random.nextInt(90), (double)random.nextInt(180));

		return points;
	}

	private static ArrayList<Point> FindRoute(Point[] points)
	{
		Random random = new Random();
		int startIndex = random.nextInt(points.length);
		Point currentPoint = points[startIndex];
		ArrayList<Point> route = new ArrayList<>(10000);
		route.add(currentPoint);
		int numberOfVisited = 1;
		boolean[] visitedPoints = new boolean[points.length];
		visitedPoints[startIndex] = true;

		Point nextPoint = null;
		while (numberOfVisited < points.length)
		{
			double minCost = Double.POSITIVE_INFINITY;
			int currentIndex = -1;
			for (int i = 0; i < points.length; i++)
			{
				if (visitedPoints[i]) continue;

				double tmpCost = Euclidean(currentPoint, points[i]);
				if (tmpCost >= minCost) continue;

				minCost = tmpCost;
				nextPoint = points[i];
				currentIndex = i;
			}
			route.add(nextPoint);
			visitedPoints[currentIndex] = true;
			numberOfVisited++;
			currentPoint = nextPoint;
		}

		return route;
	}

	public static double Euclidean(Point p1, Point p2) {
		return Math.sqrt((p1.getLat() - p2.getLat())*(p1.getLat() - p2.getLat())
				+ (p1.getLon() - p2.getLon())*(p1.getLon() - p2.getLon()));
	}
}
