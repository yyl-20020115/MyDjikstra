namespace MapViewer;

public class Edge
{
    public readonly double Length;
    public readonly double Cost;
    public readonly Node Target;
    public Edge(double Length, double Cost, Node Target)
    {
        this.Length = Length;
        this.Cost = Cost;
        this.Target = Target;
    }
    public override string ToString() 
        => "-> " + Target.ToString();
}
