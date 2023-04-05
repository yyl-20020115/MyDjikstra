﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MapViewer;

public class SearchEngine
{
    public event EventHandler Updated;
    private void OnUpdated() => Updated?.Invoke(null, EventArgs.Empty);
    public readonly Map Map;
    public readonly Node Start;
    public readonly Node End;
    public int NodeVisits { get; protected set; }
    public double ShortestPathCost { get; protected set; }
    public double ShortestPathLength { get; protected set; }

    public SearchEngine(Map map)
    {
        Map = map;
        End = map.EndNode;
        Start = map.StartNode;
    }

    public List<Node> GetShortestPathDijikstra()
    {
        DijkstraSearch();
        var shortestPath = new List<Node>
        {
            End
        };
        BuildShortestPath(shortestPath, End);
        shortestPath.Reverse();
        return shortestPath;
    }

    private void BuildShortestPath(List<Node> list, Node node)
    {
        if (node.NearestToStart == null)
            return;
        list.Add(node.NearestToStart);
        ShortestPathLength += node.Connections.Single(x => x.ConnectedNode == node.NearestToStart).Length;
        ShortestPathCost += node.Connections.Single(x => x.ConnectedNode == node.NearestToStart).Cost;
        BuildShortestPath(list, node.NearestToStart);
    }

    private void DijkstraSearch()
    {
        NodeVisits = 0;
        Start.MinCostToStart = 0;
        var prioQueue = new List<Node>
        {
            Start
        };
        var startToEndCost = double.MaxValue;
        do
        {
            NodeVisits++;
            prioQueue = prioQueue.OrderBy(x => x.MinCostToStart.Value).ToList();
            var node = prioQueue.First();
            prioQueue.Remove(node);
            foreach (var cnn in node.Connections.OrderBy(x => x.Cost))
            {
                var childNode = cnn.ConnectedNode;
                if (childNode.Visited)
                    continue;
                if (childNode.MinCostToStart == null ||
                    node.MinCostToStart + cnn.Cost < childNode.MinCostToStart && node.MinCostToStart + cnn.Cost < startToEndCost)
                {
                    childNode.MinCostToStart = node.MinCostToStart + cnn.Cost;
                    childNode.NearestToStart = node;
                    if (!prioQueue.Contains(childNode))
                        prioQueue.Add(childNode);
                }
            }
            node.Visited = true;
            if (node == End)
                startToEndCost = node.MinCostToStart.Value;
        } while (prioQueue.Any());
    }

    public List<Node> GetShortestPathAstart()
    {
        foreach (var node in Map.Nodes)
            node.StraightLineDistanceToEnd = node.StraightLineDistanceTo(End);
        AstarSearch();
        var shortestPath = new List<Node>
        {
            End
        };
        BuildShortestPath(shortestPath, End);
        shortestPath.Reverse();
        return shortestPath;
    }

    private void AstarSearch()
    {
        NodeVisits = 0;
        Start.MinCostToStart = 0;
        var prioQueue = new List<Node>
        {
            Start
        };
        do {
            prioQueue = prioQueue.OrderBy(x => x.MinCostToStart + x.StraightLineDistanceToEnd).ToList();
            var node = prioQueue.First();
            prioQueue.Remove(node);
            NodeVisits++;
            foreach (var cnn in node.Connections.OrderBy(x => x.Cost))
            {
                var childNode = cnn.ConnectedNode;
                if (childNode.Visited)
                    continue;
                if (childNode.MinCostToStart == null ||
                    node.MinCostToStart + cnn.Cost < childNode.MinCostToStart)
                {
                    childNode.MinCostToStart = node.MinCostToStart + cnn.Cost;
                    childNode.NearestToStart = node;
                    if (!prioQueue.Contains(childNode))
                        prioQueue.Add(childNode);
                }
            }
            node.Visited = true;
            if (node == End)
                return;
        } while (prioQueue.Any());
    }
}
