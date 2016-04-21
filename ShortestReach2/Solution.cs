using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Graph
{
        
    public class Solution
    {
        private static readonly IPrinter printer = new ConsolePrinter();

        public static void GetShortestPaths(TestContext test)
        {
            var startNode = test.Graph.Nodes[test.StartNode];

            test.Graph.CalculateShortestPaths(startNode);

            printer.Print(test.Graph.Nodes.Values.Where(x => x != startNode));
        }
    

        private static void getShortestPaths(Queue<Node<int>> unprocessedNodes)
        {       
            if(unprocessedNodes == null) throw new ArgumentNullException(nameof(unprocessedNodes));    

            while (unprocessedNodes.Count > 0)
            {
                var currentNode = unprocessedNodes.Dequeue();
                var discoveredNodes = currentNode.Process();

                foreach (var discoveredNode in discoveredNodes)
                {
                    if (!unprocessedNodes.Contains(discoveredNode) && !discoveredNode.IsProcessed)
                    {
                        unprocessedNodes.Enqueue(discoveredNode);
                    }
                }
            }
        }

        static void Main(String[] args)
        {
            var tests = ConsoleInputParser.Parse();

            foreach (var test in tests)
            {
                GetShortestPaths(test);
            }

            Console.ReadLine();
        }
    }
}