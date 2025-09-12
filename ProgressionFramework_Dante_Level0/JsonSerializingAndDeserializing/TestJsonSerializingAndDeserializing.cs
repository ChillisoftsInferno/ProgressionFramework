using FluentAssertions;
using GlobalHelpers;
using Newtonsoft.Json;
using ProgressionFramework_Dante_Level0.FunSideActivities.JSON;
using JsonReader = ProgressionFramework_Dante_Level0.FunSideActivities.JSON.JsonReader;

namespace ProgressionFramework_Dante_Level0.JsonSerializingAndDeserializing;

public class TestJsonSerializingAndDeserializing
{

    [TestFixture]
    public class TestJsonReader
    {
        private const string SampleJson = @"
        [
          { ""nodeId"": 1, ""firstValue"": 67, ""secondValue"": 563 },
          { ""nodeId"": 2, ""firstValue"": 995, ""secondValue"": 321 },
          { ""nodeId"": 3, ""firstValue"": 23, ""secondValue"": 711 },
          { ""nodeId"": 4, ""firstValue"": 387, ""secondValue"": 173 },
          { ""nodeId"": 5, ""firstValue"": 228, ""secondValue"": 329 },
          { ""nodeId"": 6, ""firstValue"": 32, ""secondValue"": 751 },
          { ""nodeId"": 7, ""firstValue"": 841, ""secondValue"": 440 },
          { ""nodeId"": 8, ""firstValue"": 497, ""secondValue"": 311 },
          { ""nodeId"": 9, ""firstValue"": 23, ""secondValue"": 711 },
          { ""nodeId"": 10, ""firstValue"": 855, ""secondValue"": 670 },
          { ""nodeId"": 11, ""firstValue"": 776, ""secondValue"": 469 },
          { ""nodeId"": 12, ""firstValue"": 984, ""secondValue"": 472 }
        ]";

        [Test]
        public void ShouldDeserializeJsonIntoNodeValuesList()
        {
            // Arrange
            var json = SampleJson;

            // Act
            var nodeValuesList = JsonConvert.DeserializeObject<List<NodeValues>>(json);

            // Assert
            nodeValuesList.Should().NotBeNull();
            nodeValuesList.Should().HaveCount(12);
            nodeValuesList!.First().NodeId.Should().Be(1);
            nodeValuesList.First().FirstValue.Should().Be(67);
            nodeValuesList.First().SecondValue.Should().Be(563);
        }

        [Test]
        public void ShouldAssignTreeDataStructureCorrectly()
        {
            // Arrange
            var nodeValuesList = JsonConvert.DeserializeObject<List<NodeValues>>(SampleJson)!;
            var reader = new JsonReader();

            // Act
            // Use reflection to call the private AssignTreeDataStructureValues
            var assignMethod = typeof(JsonReader)
                .GetMethod("AssignTreeDataStructureValues", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            assignMethod!.Invoke(reader, new object[]
            {
                nodeValuesList
            });

            var tree = reader.GetTreeDataStructure();

            // Assert
            tree.Should().NotBeNull();
            tree.Root.Value.NodeId.Should().Be(1);
        }

        [Test]
        public void ShouldThrowException_WhenTreeDataStructureNotInitialized()
        {
            // Arrange
            var reader = new JsonReader();

            // Act
            Action act = () => reader.GetTreeDataStructure();

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("*Tree data structure was null.*");
        }

        [Test]
        public void ShouldFindNodeById_WhenNodeExists()
        {
            // Arrange
            var nodeValuesList = JsonConvert.DeserializeObject<List<NodeValues>>(SampleJson)!;
            var root = new Node<NodeValues>(nodeValuesList.First());
            var tree = new Tree<NodeValues>(root.Value);
            for (int i = 1; i < nodeValuesList.Count; i++)
                tree.Add(nodeValuesList[i]);

            // Act
            var result = nodeValuesList.First().FindById(tree.Root, 10);

            // Assert
            result.Should().NotBeNull();
            result!.Value.NodeId.Should().Be(10);
        }

        [Test]
        public void ShouldReturnNull_WhenNodeDoesNotExist()
        {
            // Arrange
            var nodeValuesList = JsonConvert.DeserializeObject<List<NodeValues>>(SampleJson)!;
            var root = new Node<NodeValues>(nodeValuesList.First());
            var tree = new Tree<NodeValues>(root.Value);

            // Act
            var result = nodeValuesList.First().FindById(tree.Root, 999);

            // Assert
            result.Should().BeNull();
        }
    }
}

