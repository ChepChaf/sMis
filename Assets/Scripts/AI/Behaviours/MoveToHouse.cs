using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHouse : BehaviourNode
{
    public override void Action(sMis actor)
    {
        Vector3 direction = actor.house.transform.position - actor.transform.position;
        actor.transform.Translate(direction.normalized * 70.0f * Time.deltaTime);
    }
}
