using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T>
{
    public T value;
    public string name;
    public Node()
    {

    }

    public Node(T value, string name)
    {
        this.value = value;
        this.name = name;
    }
}
