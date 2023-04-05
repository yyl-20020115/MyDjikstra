namespace MapViewer;

public class Edge
{
    public double Length;
    public double Cost;
    public Node ConnectedNode;

    public override string ToString() 
        => "-> " + ConnectedNode.ToString();
}
