using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MapViewer;

public class Map
{
    public static Map GenerateRandomMap(int nodeCount, int branching, int seed, bool randomWeights)
    {
        var random = new Random(seed);
        var nodes = new List<Node>();

        for (int i = 0; i < nodeCount; i++)
        {
            var newNode = Node.GetRandom(random, i.ToString());
            if (!newNode.IsNearToAny(nodes))
                nodes.Add(newNode);
        }

        foreach (var node in nodes)
            node.ConnectNearestNodes(nodes, branching, random, randomWeights);

        var start = nodes[random.Next(nodes.Count)];
        var end = nodes[random.Next(nodes.Count)];

        foreach (var node in nodes)
        {
            Debug.WriteLine($"{node}");
            foreach (var cnn in node.Edges)
            {
                Debug.WriteLine($"{cnn}");
            }
        }
        return new (start, end, nodes);
    }

    public readonly Node StartNode;
    public readonly Node EndNode;
    public readonly List<Node> Nodes;
    public readonly List<Node> ShortestPath = new();

    public Map(Node StartNode, Node EndNode, List<Node> Nodes)
    {
        this.StartNode = StartNode;
        this.EndNode = EndNode;
        this.Nodes = Nodes;
    }
}
