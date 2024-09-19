namespace ProgressionFramework_Dante_Level0.Katas;

public class ConwaysGameOfLifeKata
{
    private const string EmptyNodeIndicator = "_";
    private const string FilledNodeIndicator = "H";
    private string[,] _map;
    private int mapWidth;
    private int mapHeight;

    public ConwaysGameOfLifeKata()
    {
        mapHeight = 4;
        mapWidth = 4;
        _map = InitializeMap();
    }

    private string[,] InitializeMap()
    {
        string[,] map = new string[mapWidth, mapHeight];
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                map[x, y] = "_";
            }
        }
        return map;
    }

    public string GetCurrentNodeCharacter(int xPos, int yPos)
    {
        return _map[xPos, yPos];
    }

    public bool NodeWillDieNextTurn(ConwayNode node)
    {
        return true;
    }

    public bool AffectedByUnderPopulation(ConwayNode node)
    {
        return true;
    }

    public int GetSurroundingNodesCount(ConwayNode node)
    {
        var surroundingNodes = new List<ConwayNode>();
        surroundingNodes.Add(GetUpperNode(node));
        foreach (var n in surroundingNodes)
        {
            if(n.Indicator == "H") continue;
            surroundingNodes.Remove(n);
        }
        return surroundingNodes.Count;
    }

    public ConwayNode GetUpperNode(ConwayNode node)
    {
        if (node.YPos == 0) return new ConwayNode();
        return new ConwayNode();
    }

    public ConwayNode GetLowerNode()
    {
        return new ConwayNode();
    }

    private ConwayNode GetLeftNode()
    {
        return new ConwayNode();
    }

    private ConwayNode GetRightNode()
    {
        return new ConwayNode();
    }
}

public class ConwayNode
{
    public string Indicator { get; set; } = "_";
    public int XPos { get; set; } = 0;
    public int YPos { get; set; } = 0;
}
