using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class ConditionalGraph<T> : Graph<T>
{
    public delegate bool Condition(object obj);

    Dictionary<Node<T>, List<Tuple<Condition, Node<T>>>> conditionalEdges = new Dictionary<Node<T>, List<Tuple<Condition, Node<T>>>>();

    public void AddEdgeCondition(string node1Name, string node2Name, Condition condition)
    {
        AddEdge(node1Name, node2Name);

        AddConditionalConectionToNode(GetVertex(node1Name), GetVertex(node2Name), condition);
    }

    public Node<T> GetAvailableNode(string nodeName, object obj)
    {
        Node<T> node = GetVertex(nodeName);
        foreach (Tuple<Condition, Node<T>> conditionNodeTuple in conditionalEdges[node])
        {
            if (conditionNodeTuple.Item1(obj))
            {
                return conditionNodeTuple.Item2;
            }
        }

        return null;
    }

    private void AddConditionalConectionToNode(Node<T> baseNode, Node<T> newConnection, Condition condition)
    {
        if (!conditionalEdges.ContainsKey(baseNode))
        {
            conditionalEdges.Add(baseNode, new List<Tuple<Condition, Node<T>>>());
        }
        conditionalEdges[baseNode].Add(new Tuple<Condition, Node<T>>(condition, newConnection));
    }
}
