using System;
using System.Collections.Generic;
using System.Linq;

namespace MapViewer;

public class Node
{
    public readonly string Name;
    public readonly Guid Id;
    public readonly Point Point;

    public readonly List<Edge> Edges = new();
    public double? MinCostToStart = null;
    public Node? NearestToStart = null;
    public double DirectDistanceToEnd = 0;
    public bool Visited = false;
    public Node(Point p, Guid Id, string name)
    {
        this.Name = name;
        this.Id = Id;
        this.Point = p;
    }
    public void ConnectNearestNodes(List<Node> nodes, int branching, Random rnd, bool randomWeight)
    {
        var edges = new List<Edge>();
        foreach (var node in nodes)
        {
            if (node.Id == this.Id)
                continue;

            var distance = this.GetDistanceTo(node);
            // Math.Sqrt(Math.Pow(Point.X - node.Point.X, 2) + Math.Pow(Point.Y - node.Point.Y, 2));
            edges.Add(new Edge(distance, randomWeight ? rnd.NextDouble() : distance, node));
        }
        edges = edges.OrderBy(x => x.Length).ToList();
        var count = 0;
        foreach (var edge in edges)
        {
            //Connect three closes nodes that are not connected.
            if (!Edges.Any(c => c.Target == edge.Target))
                Edges.Add(edge);
            count++;

            //Make it a two way connection if not already connected
            if (!edge.Target.Edges.Any(cc => cc.Target == this))
            {
                //var backConnection = ;
                edge.Target.Edges.Add(new(edge.Length, edge.Cost, this));
            }
            if (count == branching)
                return;
        }
    }

    public static Node GetRandom(Random random, string name) => new(
            new(random.NextDouble(), random.NextDouble()),
            Guid.NewGuid(),
            name);

    public double GetDistanceTo(Node node) => Math.Sqrt(
            (Point.X - node.Point.X) * (Point.X - node.Point.X) +
            (Point.Y - node.Point.Y) * (Point.Y - node.Point.Y));

    public bool IsNearToAny(List<Node> nodes,double threshold = 0.01)
    {
        foreach (var node in nodes)
            if (GetDistanceTo(node) < threshold)
                return true;
        return false;
    }
    public override string ToString() => Name;
}
