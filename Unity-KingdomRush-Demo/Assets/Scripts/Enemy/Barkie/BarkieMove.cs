using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarkieMove : EnemyMove
{   
    protected override void Awake()
    {
        speed = 3;
        waypointParent = GameObject.Find("Waypoints_barkie").transform;
        base.Awake();
    }
}
