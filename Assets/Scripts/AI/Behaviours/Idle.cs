using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BehaviourNode
{
    public override void Action(sMis actor)
    {
        actor.hunger += Random.Range(0, 4);
        actor.energy -= Random.Range(0, 4);
    }
}
