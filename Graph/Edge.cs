using System;

namespace Graph
{
    public class Edge<T>
    {
        public Edge(Node<T> startNode, Node<T> endNode, int weight)
        {
            StartNode = startNode;
            EndNode = endNode;
            Weight = weight;
        }

        public Node<T> GetOtherNode(Node<T> current)
        {
            if (current == StartNode) return EndNode;
            if (current == EndNode) return StartNode;

            throw new ArgumentException("Invalid node");
        }

        public Node<T> StartNode { get; }

        public Node<T> EndNode { get; }

        public int Weight { get; }
    }
}