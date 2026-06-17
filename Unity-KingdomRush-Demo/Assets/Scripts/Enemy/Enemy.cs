using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] int maxHealth = 10;
    protected int damageToPlayer = 1;
    [SerializeField] int getGold = 25;
    protected int defense = 0;
    private int currentHealth = 10;
    [SerializeField] Animator animator;
    public bool isAlive = true;
    void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
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
            DestroyEnemy();
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            isAlive = false;
        }
    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }


}
