using System;
using System.Collections.Generic;
using System.Linq;

namespace MapViewer;

public class Node
{
    public readonly List<Edge> Connections = new();
    public readonly string Name;
    public readonly Guid Id;
    public readonly Point Point;

    public double? MinCostToStart;
    public Node NearestToStart;
    public double StraightLineDistanceToEnd;
    public bool Visited;
    public Node(Point p, Guid Id, string name)
    {
        this.Name = name;
        this.Id = Id;
        this.Point = p;
    }
    public void ConnectClosestNodes(List<Node> nodes, int branching, Random rnd, bool randomWeight)
    {
        var connections = new List<Edge>();
        foreach (var node in nodes)
        {
            if (node.Id == this.Id)
                continue;

            var dist = Math.Sqrt(Math.Pow(Point.X - node.Point.X, 2) + Math.Pow(Point.Y - node.Point.Y, 2));
            connections.Add(new Edge(dist, randomWeight ? rnd.NextDouble() : dist, node));
        }
        connections = connections.OrderBy(x => x.Length).ToList();
        var count = 0;
        foreach (var cnn in connections)
        {
            //Connect three closes nodes that are not connected.
            if (!Connections.Any(c => c.ConnectedNode == cnn.ConnectedNode))
                Connections.Add(cnn);
            count++;

            //Make it a two way connection if not already connected
            if (!cnn.ConnectedNode.Connections.Any(cc => cc.ConnectedNode == this))
            {
                //var backConnection = ;
                cnn.ConnectedNode.Connections.Add(new(cnn.Length, cnn.Cost, this));
            }
            if (count == branching)
                return;
        }
    }

    public static Node GetRandom(Random rnd, string name) => new(
            new(rnd.NextDouble(), rnd.NextDouble()),
            Guid.NewGuid(),
            name);

    public double StraightLineDistanceTo(Node end)
        => Math.Sqrt(Math.Pow(Point.X - end.Point.X, 2) + Math.Pow(Point.Y - end.Point.Y, 2));

    internal bool ToCloseToAny(List<Node> nodes)
    {
        foreach (var node in nodes)
        {
            var d = Math.Sqrt(Math.Pow(Point.X - node.Point.X, 2) + Math.Pow(Point.Y - node.Point.Y, 2));
            if (d < 0.01)
                return true;
        }
        return false;
    }
    public override string ToString() => Name;
}
