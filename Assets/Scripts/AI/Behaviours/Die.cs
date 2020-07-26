using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : BehaviourNode
{
    public override void Action(sMis actor)
    {
        GameManager.Instance.RemoveSMis(actor.gameObject);
        GameObject.Destroy(actor.gameObject);
    }
}
