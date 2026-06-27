using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMove : EnemyMove
{
    protected override void Awake()
    {
        speed = 1.5f;
        waypointParent = GameObject.Find("Waypoints").transform;
        base.Awake();
    }
}
