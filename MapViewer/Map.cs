using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MapViewer;

public class Map
{

    public Node EndNode;

    public List<Node> Nodes = new ();

    public List<Node> ShortestPath = new();

    public Node StartNode;
    public static Map Randomize(int nodeCount, int branching, int seed, bool randomWeights)
    {
        var rnd = new Random(seed);
        var map = new Map();

        for (int i = 0; i < nodeCount; i++)
        {
            var newNode = Node.GetRandom(rnd, i.ToString());
            if (!newNode.ToCloseToAny(map.Nodes))
                map.Nodes.Add(newNode);
        }

        foreach (var node in map.Nodes)
            node.ConnectClosestNodes(map.Nodes, branching, rnd, randomWeights);
        //map.StartNode = map.Nodes.OrderBy(n => n.Point.X + n.Point.Y).First();
        //map.EndNode = map.Nodes.OrderBy(n => n.Point.X + n.Point.Y).Last();
        map.EndNode = map.Nodes[rnd.Next(map.Nodes.Count - 1)];
        map.StartNode = map.Nodes[rnd.Next(map.Nodes.Count - 1)];

        foreach (var node in map.Nodes)
        {
            Debug.WriteLine($"{node}");
            foreach (var cnn in node.Connections)
            {
                Debug.WriteLine($"{cnn}");
            }
        }
        return map;
    }
}
