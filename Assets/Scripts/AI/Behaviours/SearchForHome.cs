using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForHome : BehaviourNode
{
    public override void Action(sMis actor)
    {
        House house = GameManager.Instance.GetRandomHouse();

        while (house.residents.Count > 0)
        {
            house = GameManager.Instance.GetRandomHouse();
        }

        actor.house = house;
    }
}
