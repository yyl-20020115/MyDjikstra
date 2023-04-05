namespace MapViewer;

public class Edge
{
    public readonly double Length;
    public readonly double Cost;
    public readonly Node ConnectedNode;
    public Edge(double Length, double Cost, Node ConnectedNode)
    {
        this.Length = Length;
        this.Cost = Cost;
        this.ConnectedNode = ConnectedNode;
    }
    public override string ToString() 
        => "-> " + ConnectedNode.ToString();
}
