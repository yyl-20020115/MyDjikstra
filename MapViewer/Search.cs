using System;
using System.Linq;
using System.Collections.Generic;

namespace MapViewer;

public class SearchEngine
{
    public event EventHandler Updated;
    //private void OnUpdated() => Updated?.Invoke(null, EventArgs.Empty);
    public readonly Map Map;
    public readonly Node Start;
    public readonly Node End;
    public int NodeVisits { get; protected set; }
    public double ShortestPathCost { get; protected set; }
    public double ShortestPathLength { get; protected set; }

    public SearchEngine(Map map)
    {
        this.Start = map.StartNode;
        this.End = map.EndNode;
        this.Map = map;
    }

    public List<Node> GetShortestPathDijkstra()
    {
        this.DijkstraSearch();
        var shortestPath = new List<Node> { End };
        this.BuildShortestPath(shortestPath, End);
        shortestPath.Reverse();
        return shortestPath;
    }
    public List<Node> GetShortestPathAStart()
    {
        foreach (var node in Map.Nodes)
            node.StraightLineDistanceToEnd = node.GetDistanceTo(End);
        this.AStarSearch();
        var shortestPath = new List<Node> { End };
        this.BuildShortestPath(shortestPath, End);
        shortestPath.Reverse();
        return shortestPath;
    }

    protected void BuildShortestPath(List<Node> list, Node node)
    {
        if (node.NearestToStart == null) return;
        list.Add(node.NearestToStart);
        this.ShortestPathLength += node.Connections.Single(x => x.ConnectedNode == node.NearestToStart).Length;
        this.ShortestPathCost += node.Connections.Single(x => x.ConnectedNode == node.NearestToStart).Cost;
        this.BuildShortestPath(list, node.NearestToStart);
    }

    protected void DijkstraSearch()
    {
        NodeVisits = 0;
        Start.MinCostToStart = 0;
        var priorityQueue = new List<Node> { Start };
        var startToEndCost = double.MaxValue;
        
        while(priorityQueue.Count > 0)
        {
            NodeVisits++;
            priorityQueue = priorityQueue.OrderBy(x => x.MinCostToStart.GetValueOrDefault()).ToList();
            var node = priorityQueue[0];
            priorityQueue.RemoveAt(0);
            node.Visited = true;
            foreach (var cnn in node.Connections.OrderBy(x => x.Cost))
            {
                var childNode = cnn.ConnectedNode;
                if (!childNode.Visited)
                {
                    if (childNode.MinCostToStart == null ||
                        node.MinCostToStart + cnn.Cost < childNode.MinCostToStart
                        && node.MinCostToStart + cnn.Cost < startToEndCost)
                    {
                        childNode.MinCostToStart = node.MinCostToStart + cnn.Cost;
                        childNode.NearestToStart = node;
                        if (!priorityQueue.Contains(childNode))
                            priorityQueue.Add(childNode);
                    }
                }
            }
            if (node == End)
                startToEndCost = node.MinCostToStart.Value;
        }
    }

    protected void AStarSearch()
    {
        NodeVisits = 0;
        Start.MinCostToStart = 0;
        var priorityQueue = new List<Node> { Start };
        while (priorityQueue.Count > 0)
        {
            priorityQueue = priorityQueue.OrderBy(x => x.MinCostToStart + x.StraightLineDistanceToEnd).ToList();
            var node = priorityQueue[0];
            priorityQueue.RemoveAt(0);
            NodeVisits++;
            node.Visited = true;
            foreach (var cnn in node.Connections.OrderBy(x => x.Cost))
            {
                var childNode = cnn.ConnectedNode;
                if (!childNode.Visited)
                {
                    if (childNode.MinCostToStart == null ||
                        node.MinCostToStart + cnn.Cost < childNode.MinCostToStart)
                    {
                        childNode.MinCostToStart = node.MinCostToStart + cnn.Cost;
                        childNode.NearestToStart = node;
                        if (!priorityQueue.Contains(childNode))
                            priorityQueue.Add(childNode);
                    }
                }
            }
            if (node == End)
                return;
        }
    }
}
