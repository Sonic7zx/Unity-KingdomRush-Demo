using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    protected override void Awake()
    {
        maxHealth = 10;
        getGold = 25;
        damageToPlayer = 2;
        defense = 1;
        base.Awake();
    }
}