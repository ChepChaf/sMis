using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;

using UnityEngine;

public class Brain
{
    sMis actor;
    ConditionalGraph<BehaviourNode> behaviour = new ConditionalGraph<BehaviourNode>();
    string currentAction;

    public Brain(sMis actor)
    {
        this.actor = actor;

        behaviour.AddVertex(new Node<BehaviourNode>(new Idle(), "Idle"));
        behaviour.AddVertex(new Node<BehaviourNode>(new Die(), "Die"));
        behaviour.AddVertex(new Node<BehaviourNode>(new SearchForHome(), "SearchForHome"));
        behaviour.AddVertex(new Node<BehaviourNode>(new MoveToHouse(), "MoveToHouse"));

        behaviour.AddEdgeCondition("Idle", "Die", delegate (object a) 
        { 
            return ((sMis)a).hunger >= 100 || ((sMis)a).energy <= 0; 
        });
        behaviour.AddEdgeCondition("Idle", "SearchForHome", delegate (object a)
        {
            return ((sMis)a).house == null;
        });
        behaviour.AddEdgeCondition("SearchForHome", "MoveToHouse", delegate (object a)
        {
            return ((sMis)a).house != null;
        });
        behaviour.AddEdgeCondition("MoveToHouse", "MoveToHouse", delegate (object a)
        {
            return Vector3.Distance(((sMis)a).house.transform.position, ((sMis)a).transform.position) > 0.1f;
        });
        behaviour.AddEdgeCondition("MoveToHouse", "Idle", delegate (object a)
        {
            return Vector3.Distance(((sMis)a).house.transform.position, ((sMis)a).transform.position) <= 0.1f;
        });

        behaviour.AddEdgeCondition("Idle", "Idle", delegate (object a) { return true; });

        currentAction = "Idle";
    }

    public void Act()
    {
        Node<BehaviourNode> currentBehaviour = behaviour.GetAvailableNode(currentAction, actor);
        currentAction = currentBehaviour.name;

        currentBehaviour.value.Action(actor);
    }
}
