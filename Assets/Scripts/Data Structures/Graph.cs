using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph<T>
{
    Dictionary<string, Node<T>> vertices = new Dictionary<string, Node<T>>();
    Dictionary<Node<T>, List<Node<T>>> conditionalEdges = new Dictionary<Node<T>, List<Node<T>>>();
    public void AddVertex(Node<T> node)
    {
        vertices.Add(node.name, node);
    }

    public void AddEdge(Node<T> node1, Node<T> node2)
    {
        AddConectionToNode(node1, node2);
    }

    public void AddEdge(string node1Name, string node2Name)
    {
        Node<T> node1 = GetVertex(node1Name);
        Node<T> node2 = GetVertex(node2Name);

        AddConectionToNode(node1, node2);
    }

    public Node<T> GetVertex(string name)
    {
        if (vertices.ContainsKey(name))
        {
            return vertices[name];
        }
        Debug.LogError("Trying to get unexistent node: " + name);

        return null;
    }

    private void AddConectionToNode(Node<T> baseNode, Node<T> newConnection)
    {
        if (!conditionalEdges.ContainsKey(baseNode))
        {
            conditionalEdges.Add(baseNode, new List<Node<T>>());
        }
        conditionalEdges[baseNode].Add(newConnection);
    }
}
