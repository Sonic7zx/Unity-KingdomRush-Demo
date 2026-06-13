using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] int damage = 4;
    private Enemy targetEnemy;
    void Start()
    {
        
    }
    public void Initialize(Enemy target)
    {
        targetEnemy = target;
    }
    void Update()
    {
        if(targetEnemy == null)
        {
            ReturnToPool();
        }
        transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetEnemy.transform.position) < 0.1f)
        {
            targetEnemy.TakeDamage(damage);
            ReturnToPool();
        }
    }
    void ReturnToPool()
    {

    }
}
