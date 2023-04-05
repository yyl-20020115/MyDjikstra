using System;
using System.Collections.Generic;
using System.Linq;

namespace MapViewer;

public class Node
{
    public readonly List<Edge> Connections = new();
    public readonly Guid Id;

    public double? MinCostToStart;
    public readonly string Name;
    public Node NearestToStart;
    public readonly Point Point;
    public double StraightLineDistanceToEnd;
    public bool Visited;
    public Node(Point p, Guid Id, string name)
    {
        this.Point= p;
        this.Id= Id;
        this.Name= name;
    }

    internal void ConnectClosestNodes(List<Node> nodes, int branching, Random rnd, bool randomWeight)
    {
        var connections = new List<Edge>();
        foreach (var node in nodes)
        {
            if (node.Id == this.Id)
                continue;

            var dist = Math.Sqrt(Math.Pow(Point.X - node.Point.X, 2) + Math.Pow(Point.Y - node.Point.Y, 2));
            connections.Add(new Edge
            {
                ConnectedNode = node,
                Length = dist,
                Cost = randomWeight ? rnd.NextDouble() : dist,
            });
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
                var backConnection = new Edge { ConnectedNode = this, Length = cnn.Length, Cost = cnn.Cost };
                cnn.ConnectedNode.Connections.Add(backConnection);
            }
            if (count == branching)
                return;
        }
    }

    internal static Node GetRandom(Random rnd, string name)
    {
        return new Node(
            new Point
            {
                X = rnd.NextDouble(),
                Y = rnd.NextDouble()
            },
            Guid.NewGuid(),
            name);
    }

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
