using GenericDataStructures.Helpers;
using GlobalHelpers.Helpers;
using GlobalHelpers.Interfaces;

namespace GenericDataStructures.GraphADT;

internal class Graph
{
    public List<Node<DataPoint>>? Points { get; set; }
    
    private const string GraphPointJsonPath = "GlobalHelpers/Resources/JSON/GraphPoints.json";

    private readonly IJsonParser<Node<DataPoint>> _jsonParser;

    public Graph(IJsonParser<Node<DataPoint>> jsonParser)
    {
        _jsonParser = jsonParser ?? throw new ArgumentNullException(nameof(jsonParser));
    }
    
    public void AddPoints(int pointListId)
    {
        var dataPoints = _jsonParser.LoadJson(GraphPointJsonPath);
        Points = dataPoints;
    }
}
