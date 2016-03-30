using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class TestInputParser
    {
        public static List<TestContext> Parse()
        {
            var tests = new List<TestContext>();

            int numTests = readInt();

            for (int j = 0; j < numTests; j++)
            {


                var nodesAndEndges = readIntArray();
                int numNodes = nodesAndEndges.Count > 0 ? nodesAndEndges[0] : 0;
                int numEdges = nodesAndEndges.Count > 1 ? nodesAndEndges[1] : 0;

                var edges = new List<Tuple<int, int>>();

                for (int i = 0; i < numEdges; i++)
                {
                    var edge = readIntArray();

                    if (edge.Count == 2)
                    {
                        edges.Add(Tuple.Create(edge[0], edge[1]));
                    }
                }

                int startNode = readInt();                
                var graph = createGraph(numNodes, edges);

                tests.Add(new TestContext(numTests, numNodes, numEdges, startNode, graph));
            }

            return tests;
        }

        private Dictionary<int, Node> createGraph(int numNodes,  List<Tuple<int, int>> edges)
        {
            var nodes = new Dictionary<int, Node>();

            for (int i = 0; i < numNodes; i++)
            {
                nodes[i] = new Node(i);
            }

            foreach (var edge in edges)
            {
                nodes[edge.Item1].Neighbours.Add(nodes[edge.Item2]);
                nodes[edge.Item2].Neighbours.Add(nodes[edge.Item1]);
            }

            return nodes;
        }

        private List<int> readIntArray()
        {
            var line = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(line))
            {
                return line.Split(' ').Select(int.Parse).ToList();
            }

            return new List<int>();
        }

        private int readInt()
        {
            var line = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(line))
            {
                return int.Parse(line);
            }

            return -1;
        }
    }


    public class TestContext
    {
        public TestContext(int numTests, int numNodes, int numEdges, int startNode, Dictionary<int, Node> graph)
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

        public Dictionary<int, Node> Graph { get; }
    }

    public class Node
    {        
        public Node(int value)
        {
            Value = value;
            Neighbours = new List<Node>();
            ShortestPath = -1;
            ShortestPathParent = null;
        }

        public Node ShortestPathParent { get; set; }
        public int ShortestPath { get; set; }
        public int Value { get; }
        public IList<Node>  Neighbours { get; }
    }

    public class Solution
    {
        public static void GetShortestPaths(TestContext test)
        {
            
        }

        static void Main(String[] args)
        {
            var tests = TestInputParser.Parse();

            foreach (var test in tests)
            {
                GetShortestPaths(test);
            }
        }
    }
}