using System;
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
        Start = map.StartNode;
        End = map.EndNode;
        Map = map;
    }

    public List<Node> GetShortestPathDijkstra()
    {
        DijkstraSearch();
        var shortestPath = new List<Node> { End };
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
        var priorityQueue = new List<Node>{Start };
        var startToEndCost = double.MaxValue;
        do
        {
            NodeVisits++;
            priorityQueue = priorityQueue.OrderBy(x => x.MinCostToStart.Value).ToList();
            var node = priorityQueue.First();
            priorityQueue.Remove(node);
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
                    if (!priorityQueue.Contains(childNode))
                        priorityQueue.Add(childNode);
                }
            }
            node.Visited = true;
            if (node == End)
                startToEndCost = node.MinCostToStart.Value;
        } while (priorityQueue.Any());
    }

    public List<Node> GetShortestPathAStart()
    {
        foreach (var node in Map.Nodes)
            node.StraightLineDistanceToEnd = node.StraightLineDistanceTo(End);
        AStarSearch();
        var shortestPath = new List<Node> { End };
        BuildShortestPath(shortestPath, End);
        shortestPath.Reverse();
        return shortestPath;
    }

    private void AStarSearch()
    {
        NodeVisits = 0;
        Start.MinCostToStart = 0;
        var priorityQueue = new List<Node> { Start };
        do {
            priorityQueue = priorityQueue.OrderBy(x => x.MinCostToStart + x.StraightLineDistanceToEnd).ToList();
            var node = priorityQueue.First();
            priorityQueue.Remove(node);
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
                    if (!priorityQueue.Contains(childNode))
                        priorityQueue.Add(childNode);
                }
            }
            node.Visited = true;
            if (node == End)
                return;
        } while (priorityQueue.Any());
    }
}
