using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MapViewer;

public class Map
{
    public static Map GenerateRandomMap(int nodeCount, int branching, int seed, bool randomWeights)
    {
        var random = new Random(seed);
        List<Node> Nodes = new();

        for (int i = 0; i < nodeCount; i++)
        {
            var newNode = Node.GetRandom(random, i.ToString());
            if (!newNode.IsNearToAny(Nodes))
                Nodes.Add(newNode);
        }

        foreach (var node in Nodes)
            node.ConnectClosestNodes(Nodes, branching, random, randomWeights);
        //map.StartNode = map.Nodes.OrderBy(n => n.Point.X + n.Point.Y).First();
        //map.EndNode = map.Nodes.OrderBy(n => n.Point.X + n.Point.Y).Last();
        var EndNode = Nodes[random.Next(Nodes.Count - 1)];
        var StartNode = Nodes[random.Next(Nodes.Count - 1)];

        foreach (var node in Nodes)
        {
            Debug.WriteLine($"{node}");
            foreach (var cnn in node.Connections)
            {
                Debug.WriteLine($"{cnn}");
            }
        }
        return new Map(StartNode, EndNode, Nodes, new());
    }

    public readonly Node StartNode;
    public readonly Node EndNode;
    public readonly List<Node> Nodes;
    public readonly List<Node> ShortestPath;

    public Map(Node StartNode, Node EndNode, List<Node> Nodes, List<Node> ShortestPath)
    {
        this.StartNode = StartNode;
        this.EndNode = EndNode;
        this.Nodes = Nodes;
        this.ShortestPath = ShortestPath;
    }
}
