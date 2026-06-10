using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] int maxHealth = 10;
    protected int damageToPlayer = 1;
    [SerializeField] int getGold = 25;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Destination"))
        {
            Destination destination = other.GetComponent<Destination>();
            if (destination != null)
            {
                destination.TakeDamage(damageToPlayer);
            }
            Destroy(gameObject);
        }
    }
}
