using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barkie : Enemy
{
    protected override void Awake()
    {
        maxHealth = 6;
        getGold = 10;
        damageToPlayer = 1;
        defense = 0;
        base.Awake();
    }
}
