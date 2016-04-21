using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Graph
{
    public class ConsoleInputParser
    {
        private static readonly ConsoleParser parser = new ConsoleParser();
            
        public static List<TestContext> Parse()
        {
            var tests = new List<TestContext>();

            int numTests = parser.Read<int>();

            for (int j = 0; j < numTests; j++)
            {
                var nodesAndEndges = parser.ReadList<int>();
                int numNodes = nodesAndEndges.Count > 0 ? nodesAndEndges[0] : 0;
                int numEdges = nodesAndEndges.Count > 1 ? nodesAndEndges[1] : 0;

                var edges = new List<Tuple<int, int, int>>();

                for (int i = 0; i < numEdges; i++)
                {
                    var edge = parser.ReadList<int>();

                    if (edge.Count == 3)
                    {
                        edges.Add(Tuple.Create(edge[0], edge[1], edge[2]));
                    }
                }

                int startNode = parser.Read<int>();
                var graph = Graph<int>.CreateGraph(Enumerable.Range(1, numNodes).ToList(), edges);

                tests.Add(new TestContext(numTests, numNodes, numEdges, startNode, graph));
            }

            return tests;
        }
       
    }
}
