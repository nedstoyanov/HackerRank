using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class Graph<T>
    {
        private Graph(Dictionary<T, Node<T>> nodes)
        {
            Nodes = nodes;
        }

        public Dictionary<T, Node<T>> Nodes { get; }

        public void CalculateShortestPaths(Node<T> startNode)
        {
            var unprocessedNodes = new Queue<Node<T>>();
            unprocessedNodes.Enqueue(startNode);

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

        public static Graph<T> CreateGraph(IList<T> nodes, List<Tuple<T, T, int>> edges)
        {
            var graphNodes = new Dictionary<T, Node<T>>();

            foreach (var key in nodes)
            {
                graphNodes[key] = new Node<T>(key);
            }
           
            foreach (var edge in edges)
            {
                var edgeObject = new Edge<T>(graphNodes[edge.Item1], graphNodes[edge.Item2], edge.Item3);
                graphNodes[edge.Item1].Edges.Add(edgeObject);
                graphNodes[edge.Item2].Edges.Add(edgeObject);
            }

            return new Graph<T>(graphNodes);
        }
    }    
}
