using System.Collections.Generic;

namespace Graph
{
    public class Node<T>
    {
        public const int DefaultShortestPath = -1;

        public Node(T value)
        {
            Value = value;
            Edges = new List<Edge<T>>();
            ShortestPath = DefaultShortestPath;
        }

        public IList<Node<T>> Process()
        {
            var discoveredNodes = new List<Node<T>>();
            Discover();

            foreach (var edge in Edges)
            {
                var otherNode = edge.GetOtherNode(this);

                otherNode.Visit(ShortestPath + edge.Weight);

                if (!otherNode.IsProcessed)
                {
                    discoveredNodes.Add(otherNode);
                }
            }

            IsProcessed = true;

            return discoveredNodes;
        }

        public void Discover()
        {
            IsDiscovered = true;

            if (ShortestPath == DefaultShortestPath)
            {
                ShortestPath = 0;
            }
        }

        public void Visit(int shortestPath)
        {
            if (ShortestPath > shortestPath || ShortestPath == DefaultShortestPath)
            {
                ShortestPath = shortestPath;

                // Reprocess Node as updating the shortest path may have knock on effects.
                IsProcessed = false;
            }
        }

        public int ShortestPath { get; set; }
        public T Value { get; }
        public bool IsDiscovered { get; set; }
        public bool IsProcessed { get; set; }

        public IList<Edge<T>> Edges { get; }
    }
}