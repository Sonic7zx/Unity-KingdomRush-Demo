using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] int damage = 4;
    private Enemy targetEnemy;
    

    public void Initialize(Enemy target,Vector2 StartPos)
    {
        targetEnemy = target;
        gameObject.SetActive(true);
        transform.position = StartPos;
    }
    void Update()
    {
        if(targetEnemy == null)//当敌人被消灭时
        {
            ReturnToPool();
        }
        
        transform.position = Vector2.MoveTowards(transform.position, targetEnemy.transform.position, speed * Time.deltaTime);//箭矢飞向敌人
        
        if (Vector2.Distance(transform.position, targetEnemy.transform.position) < 0.1f)//当箭矢到达敌人位置时
        {
            targetEnemy.TakeDamage(damage);
            ReturnToPool();
        }
    }
    void ReturnToPool()
    {
        gameObject.SetActive(false);
        PoolManager.Instance.ReleaseArrow(this);
    }
}
