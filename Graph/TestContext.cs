
namespace Graph
{
    public class TestContext
    {
        public TestContext(int numTests, int numNodes, int numEdges, int startNode, Graph<int> graph)
        {
            NumTests = numTests;
            NumNodes = numNodes;
            NumEdges = numEdges;
            StartNode = startNode;
            Graph = graph;
        }

        public int NumTests { get; }
        public int NumNodes { get; }
        public int NumEdges { get; }
        public int StartNode { get; }

        public Graph<int> Graph { get; }
    }
}