public class EdgeScript
{
    public NodeScript startNode;
    public NodeScript endNode;
    public EdgeScript (NodeScript fodasse, NodeScript fodasseDemais)
    {
        this.startNode = fodasse;
        this.endNode = fodasseDemais;

    }

}